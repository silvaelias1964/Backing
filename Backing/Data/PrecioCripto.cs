using System.ComponentModel.DataAnnotations;

namespace Backing.Data
{
    public class PrecioCripto
    {
        [Key]
        public int PrcId { get; set; }

        public int CrmId { get; set; }  // Relación con CriptoMoneda
        public int MonId { get; set; }  // Relación con Moneda

        public decimal PrcPrecio { get; set; }
        public DateTime PrcPrecioFecha { get; set; }

        public virtual CriptoMoneda CriptoMoneda { get; set; }
        public virtual Moneda Moneda { get; set; }


    }
}
