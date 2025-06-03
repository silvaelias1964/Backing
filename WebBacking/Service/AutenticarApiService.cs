
using Newtonsoft.Json;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using WebBacking.Models;
using WebBacking.Service.IService;

namespace WebBacking.Service
{
    public class AutenticarApiService : IAutenticarApiService
    {
        private static string _clave;
        private static string _correo;
        private static string _baseurl;
        private static string _token;


        public AutenticarApiService() 
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;

        }

        /// <summary>
        /// Login y obtención del token JWT de la api
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        public async Task<Usuario> GetLogin(string correo, string clave)
        {
            
            var credenciales = new Usuario() { 
                correo = correo, 
                clave = clave 
            };

            try
            {
                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                    using (HttpClient cliente = new HttpClient(handler))
                    {

                        var content = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");
                        var response = await cliente.PostAsync($"{_baseurl}api/Token", content);
                        var json_response = await response.Content.ReadAsStringAsync();

                        _token = json_response;

                        credenciales.token = _token;

                        return credenciales;


                    }
                }
            }
            catch (Exception ex)
            {
                credenciales.correo = "Error";
                credenciales.token = "Error";
                return credenciales;
            }



        }
    }
}
