using System.ComponentModel.DataAnnotations;

namespace WebBacking.Models
{
    public class Usuario
    {                
        public string correo { get; set; }
        public string clave { get; set; }
        public int rol {  get; set; }
        public string token { get; set; }
    }
}
