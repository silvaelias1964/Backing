using System.ComponentModel.DataAnnotations;

namespace Backing.Data
{
    public class CriptoMoneda
    {
        [Key]
        public int CrmId { get; set; }
        
        [Required]
        public string? CrmNombre { get; set; }
        
        [Required]
        public string? CrmSimbolo { get; set; }

        public string? CrmWebOrigen { get; set; }
        public string? CrmDescripcion { get; set; }

        public DateTime? CrmFechaLanzamiento { get; set; }
        public DateTime? Fecha_Creacion  { get; set; }
        public DateTime? Fecha_Actualizacion { get; set; }

        public ICollection<PrecioCripto> PrecioCripto { get; set; }
    }
}
