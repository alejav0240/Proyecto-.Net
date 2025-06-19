using AlejandroChRProyecto.Entities;
using Microsoft.JSInterop;
using System.ComponentModel;
using System.Net.Http.Json;

namespace AlejandroChRProyecto.Client.Services
{
    public class EventoService
    {
        private List<EventoListCLS> lista;

        private TipoEventoService tipoeventoservice;
        private readonly HttpClient http;
        private readonly IJSRuntime jsRuntime;
        public EventoService(TipoEventoService _tipoeventoservice, HttpClient _http, IJSRuntime _jsRuntime)
        {
            http = _http;
            jsRuntime = _jsRuntime;
            tipoeventoservice = _tipoeventoservice;
            lista = new List<EventoListCLS>();
        }

        public event Func<string, Task> OnSearch = delegate { return Task.CompletedTask; };
        public async Task notificarBuscarqueda(string tituloevento)
        {
            if (OnSearch != null)
            {
                await OnSearch.Invoke(tituloevento);
            }
        }

        public async Task<List<EventoListCLS>> listarEventos()
        {
            try
            {
                var response = await http.GetFromJsonAsync<List<EventoListCLS>>("api/Evento");
                if (response == null)
                {
                    return new List<EventoListCLS>();
                }
                else
                {
                    return response;
                }
            }
            catch (Exception ex)
            {
                return new List<EventoListCLS>();
            }   
        }

        public async Task<List<EventoListCLS>> filtrarEventos(string nombre)
        {
            List<EventoListCLS> l = await listarEventos();
            if (string.IsNullOrEmpty(nombre))
            {
                return l;
            }
            else
            {
                return l.Where(p => p.nombre.ToLower().Contains(nombre.ToLower())).ToList();
            }
        }

        public async Task<string> eliminarLibro(int idEvento)
        {
            var response = await http.DeleteAsync($"api/Evento/{idEvento}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "Error" + await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<EventoCLS> recuperarLibroPorId(int idEvento)
        {
            try
            {
                var response = await http.GetFromJsonAsync<EventoCLS>($"api/Evento/{idEvento}");
                if (response == null)
                {
                    return new EventoCLS();
                }
                else
                {
                    return response;
                }
            }
            catch 
            {
                return new EventoCLS();
            }
        }

        public async Task<string> recuperarArchivoPorId(int idevento)
        {
            try
            {
                var response = await http.GetFromJsonAsync <byte[]>($"api/Evento/recuperarArchivo/{idevento}");
                if (response == null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToBase64String(response);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e.Message);
                return "";
            }
        }

        public async Task<string> guardarLibro (EventoCLS oEventoCLS)
        {
            try
            {
                var response = await http.PostAsJsonAsync("api/Evento", oEventoCLS);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "Error" + await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return "Error :" + ex.Message;
            }
        }

        public async Task descargar(int idevento, string nombrearchivo)
        {
            string archivo = await recuperarArchivoPorId(idevento);

            if (archivo != null)
            {
                await jsRuntime.InvokeVoidAsync("descargarArchivo", archivo, nombrearchivo);
            }
        }

    }
}
