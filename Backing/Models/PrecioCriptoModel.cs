using System.ComponentModel.DataAnnotations;

namespace Backing.Models
{
    public class PrecioCriptoModel
    {
        public int PrcId { get; set; }

        [Required]
        public int CrmId { get; set; }  // Relación con CriptoMoneda

        [Required]
        public int MonId { get; set; }  // Relación con Moneda

        [Required]
        public decimal PrcPrecio { get; set; }

        [Required]
        public DateTime PrcPrecioFecha { get; set; }
    }
}
