using ViaCEP.Models;
using ViaCEP.Interfaces;
using Newtonsoft.Json;

namespace ViaCEP.Services
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;

        public CepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CepInfo> GetCepInfoAsync(string cep)
        {
            cep = cep.Trim();
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao buscar informações do CEP: {cep}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CepInfo>(json);
        }
    }
}
