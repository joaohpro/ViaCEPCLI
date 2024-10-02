using ViaCEP.Models;

namespace ViaCEP.Interfaces
{
    public interface ICepService
    {
        Task<CepInfo> GetCepInfoAsync(string cep);
    }
}
