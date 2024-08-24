using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Client.Services
{
    public class DelitoService : IDelitoService
    {

        private readonly HttpClient _http;

        public DelitoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<DelitosDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<DelitosDTO>>>("api/delito/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
