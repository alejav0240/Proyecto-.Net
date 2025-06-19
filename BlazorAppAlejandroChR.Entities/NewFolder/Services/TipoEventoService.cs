using AlejandroChRProyecto.Entities;
using System.Net.Http.Json;

namespace AlejandroChRProyecto.Client.Services
{
    public class TipoEventoService
    {
        private readonly HttpClient http;
        public List<TipoEventoCLS> lista;
        public TipoEventoService(HttpClient _http) 
        {
            http = _http;
            lista = new List<TipoEventoCLS>();
        }
        public async Task<List<TipoEventoCLS>> listarTipoEventos()
        {
            try
            {
                var response = await http.GetFromJsonAsync<List<TipoEventoCLS>>("api/TipoEvento");
                if (response == null) 
                {
                    return new List<TipoEventoCLS>();
                }
                else
                {
                    return response;
                }
            }
            catch 
            {
                return new List<TipoEventoCLS>();
            }
        }

        public int obtenerIdTipoLibro(string nombreTipoEvento)
        {
            var obj = lista.Where(x => x.nombreTipo == nombreTipoEvento).FirstOrDefault();
            if (obj != null)
            {
                return obj.idTipoevento;
            }
            else
            {
                return 0;
            }
        }

        public string obtenerNombreTipoLibro(int idTipoLibro)
        {
            var obj = lista.Where(x => x.idTipoevento == idTipoLibro).FirstOrDefault();
            if (obj != null)
            {
                return obj.nombreTipo;
            }
            else
            {
                return "";
            }
        }
    }
}
