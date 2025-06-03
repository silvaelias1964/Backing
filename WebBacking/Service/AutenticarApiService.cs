
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


        public async Task<Usuario> GetLogin(string correo, string clave)
        {
            //var cliente = new HttpClient();
            //cliente.BaseAddress = new Uri(_baseurl);
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
                        //string response = await client.GetStringAsync(_url);
                        //var data = JsonConvert.DeserializeObject<TadawulModeList>(response);
                        //return Ok(data);

                        var content = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");
                        var response = await cliente.PostAsync($"{_baseurl}api/Token", content);
                        var json_response = await response.Content.ReadAsStringAsync();
                        //var resultado = JsonConvert.DeserializeObject<ResultadoToken>(json_response);
                        //_token = resultado.token;

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
