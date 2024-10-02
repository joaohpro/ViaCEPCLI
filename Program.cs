using ViaCEP.Services;
using ViaCEP.Interfaces;
using ViaCEP.Models;
using Lolcat;

namespace ViaCEP
{
    public class Program
    {
        static readonly string ASCIIART = @" __     ___        ____ _____ ____   ____ _     ___ 
 \ \   / (_) __ _ / ___| ____|  _ \ / ___| |   |_ _|
  \ \ / /| |/ _` | |   |  _| | |_) | |   | |    | | 
   \ V / | | (_| | |___| |___|  __/| |___| |___ | | 
    \_/  |_|\__,_|\____|_____|_|    \____|_____|__|";

        static async Task Main()
        {
            var style = new RainbowStyle();
            var rainbow = new Rainbow(style);

            rainbow.WriteLineWithMarkup(ASCIIART);

            using var httpClient = new HttpClient();
            ICepService cepService = new CepService(httpClient);

            string info = rainbow.Markup("CEP: ");
            Console.Write(info);
            string cep = Console.ReadLine();

            try
            {
                CepInfo cepInfo = await cepService.GetCepInfoAsync(cep);

                // Abra uma issue se souber uma forma de evitar esse monte de Console.WriteLine (:
                Console.WriteLine("========================");
                rainbow.WriteLineWithMarkup($"CEP: {cepInfo.cep}");
                rainbow.WriteLineWithMarkup($"Estado: {cepInfo.estado}");
                rainbow.WriteLineWithMarkup($"Regiao: {cepInfo.regiao}");
                rainbow.WriteLineWithMarkup($"Localidade: {cepInfo.localidade}");
                rainbow.WriteLineWithMarkup($"Logradouro: {cepInfo.logradouro}");
                rainbow.WriteLineWithMarkup($"UF: {cepInfo.uf}");
                rainbow.WriteLineWithMarkup($"DDD: {cepInfo.ddd}");
                Console.WriteLine("========================");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
