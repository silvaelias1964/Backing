using System.ComponentModel.DataAnnotations;

namespace WebBacking.Models
{
    public class CriptoPrecioModel
    {        
        public int prcId { get; set; }
        public int crmId { get; set; }          
        public int monId { get; set; }          
        public decimal prcPrecio { get; set; }
        public string? prcPrecioFecha { get; set; }
        public string? criptoMoneda {  get; set; }
        public string? moneda {  get; set; }

    }
}
