using BlazorAppAlejandroChR.Entities;
using System.Net.Http.Json;

namespace BlazorAppAlejandroChR.Client.Services
{
    public class TipoLibroService
    {
        private readonly HttpClient http;
        public List<TipoLibroCLS> lista;
        public TipoLibroService(HttpClient _http) 
        {
            http = _http;
            lista = new List<TipoLibroCLS>();
            //lista.Add(new TipoLibroCLS { idtipolibro = 1, nombretipolibro = "Cuento" });
            //lista.Add(new TipoLibroCLS { idtipolibro = 2, nombretipolibro = "Novela" });
        }
        public async Task<List<TipoLibroCLS>> listarTipoLibros()
        {
            try
            {
                var response = await http.GetFromJsonAsync<List<TipoLibroCLS>>("api/TipoLibro");
                if (response == null) 
                {
                    return new List<TipoLibroCLS>();
                }
                else
                {
                    return response;
                }
            }
            catch 
            {
                return new List<TipoLibroCLS>();
            }
        }

        public int obtenerIdTipoLibro(string nombreTipoLibro)
        {
            var obj = lista.Where(x => x.nombretipolibro == nombreTipoLibro).FirstOrDefault();
            if (obj != null)
            {
                return obj.idtipolibro;
            }
            else
            {
                return 0;
            }
        }

        public string obtenerNombreTipoLibro(int idTipoLibro)
        {
            var obj = lista.Where(x => x.idtipolibro == idTipoLibro).FirstOrDefault();
            if (obj != null)
            {
                return obj.nombretipolibro;
            }
            else
            {
                return "";
            }
        }
    }
}
