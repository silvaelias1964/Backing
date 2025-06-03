using WebBacking.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebBacking.Service.IService;
using Newtonsoft.Json.Linq;
using System.Linq;


namespace WebBacking.Service
{
    public class CriptosService : ICriptosService
    {
        private static string _baseurl;

        public CriptosService() 
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        /// <summary>
        /// Lista de criptomonedas, extraidas desde la api
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<List<CriptoPrecioModel>> Lista(string token) 
        {
            try
            {            
                using (HttpClientHandler handler = new HttpClientHandler())
                {                    

                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                    using (HttpClient cliente = new HttpClient(handler))
                    {
                        cliente.BaseAddress = new Uri(_baseurl);
                        cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        var response = await cliente.GetAsync("api/PrecioCripto/lista");
                        if (response.IsSuccessStatusCode)
                        {
                            var json_respuesta = await response.Content.ReadAsStringAsync();
                            var resultado = JsonConvert.DeserializeObject<List<CriptoPrecioModel>>(json_respuesta);

                            if (resultado != null )
                                return resultado;
                            else
                                return new List<CriptoPrecioModel>();
                        }
                        else
                        {
                            return new List<CriptoPrecioModel>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        } 


    }
}
