using AlejandroChRProyecto.Entities;
using System.Net.Http.Json;

namespace AlejandroChRProyecto.Client.Services
{
    public class ClienteService
    {
        private readonly HttpClient http;
        public ClienteService(HttpClient _http)
        {
            http = _http;
        }
        public async Task<List<ClienteCLS>> listarAutores()
        {
            try
            {
                var response = await http.GetFromJsonAsync<List<ClienteCLS>>("api/Cliente");
                if (response == null)
                {
                    return new List<ClienteCLS>();
                }
                else
                {
                    return response;
                }
            }
            catch
            {
                return new List<ClienteCLS>();
            }
        }
    }
}
