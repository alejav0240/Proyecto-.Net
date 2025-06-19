using BlazorAppAlejandroChR.Entities;
using Microsoft.JSInterop;
using System.ComponentModel;
using System.Net.Http.Json;

namespace BlazorAppAlejandroChR.Client.Services
{
    public class LbroService
    {
        private List<LibroListCLS> lista;

        private TipoLibroService tipolibroservice;
        private readonly HttpClient http;
        private readonly IJSRuntime jsRuntime;
        public LbroService(TipoLibroService _tipolibroservice, HttpClient _http, IJSRuntime _jsRuntime)
        {
            http = _http;
            jsRuntime = _jsRuntime;
            tipolibroservice = _tipolibroservice;
            lista = new List<LibroListCLS>();
            //lista.Add(new LibroListCLS() { idLibro = 1, titulo = "Caperucita roja", nombretipolibro = "Cuento" });
            //lista.Add(new LibroListCLS() { idLibro = 2, titulo = "Don Quijote de la Mancha", nombretipolibro = "novela" });
        }

        public event Func<string, Task> OnSearch = delegate { return Task.CompletedTask; };
        public async Task notificarBuscarqueda(string titulolibro)
        {
            if (OnSearch != null)
            {
                await OnSearch.Invoke(titulolibro);
            }
        }

        public async Task<List<LibroListCLS>> listarLibros()
        {
            try
            {
                var response = await http.GetFromJsonAsync<List<LibroListCLS>>("api/Libro");
                if (response == null)
                {
                    return new List<LibroListCLS>();
                }
                else
                {
                    return response;
                }
            }
            catch (Exception ex)
            {
                return new List<LibroListCLS>();
            }   
        }

        public async Task<List<LibroListCLS>> filtrarLibros(string titulo)
        {
            List<LibroListCLS> l = await listarLibros();
            if (string.IsNullOrEmpty(titulo))
            {
                return l;
            }
            else
            {
                return l.Where(p => p.titulo.ToLower().Contains(titulo.ToLower())).ToList();
            }
        }

        public async Task<string> eliminarLibro(int idLibro)
        {
            var response = await http.DeleteAsync($"api/Libro/{idLibro}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "Error" + await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<LibroFormCLS> recuperarLibroPorId(int idLibro)
        {
            try
            {
                var response = await http.GetFromJsonAsync<LibroFormCLS>($"api/Libro/{idLibro}");
                if (response == null)
                {
                    return new LibroFormCLS();
                }
                else
                {
                    return response;
                }
            }
            catch 
            {
                return new LibroFormCLS();
            }
        }

        public async Task<string> recuperarArchivoPorId(int idlibro)
        {
            try
            {
                Console.WriteLine("idlibro" + idlibro);
                var response = await http.GetFromJsonAsync <byte[]>($"api/Libro/recuperarArchivo/{idlibro}");
                Console.WriteLine("repuesta"+response);
                if (response == null)
                {
                    Console.WriteLine("No hay archivo");
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

        public async Task<string> guardarLibro (LibroFormCLS oLibroFormCLS)
        {
            try
            {
                var response = await http.PostAsJsonAsync("api/Libro", oLibroFormCLS);
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

        public async Task descargar(int idlibro, string nombrearchivo)
        {
            string archivo = await recuperarArchivoPorId(idlibro);

            Console.WriteLine(idlibro);
            Console.WriteLine(archivo);

            if (archivo != null)
            {
                Console.WriteLine(archivo);
                await jsRuntime.InvokeVoidAsync("descargarArchivo", archivo, nombrearchivo);
            }
        }

    }
}
