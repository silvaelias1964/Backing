using System.ComponentModel.DataAnnotations;

namespace Backing.Models
{
    public class CriptoMonedaModel
    {
        
        public int CrmId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El campo: {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 5)]
        public string? CrmNombre { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "El campo: {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string? CrmSimbolo { get; set; }

        [MaxLength(200)]
        public string? CrmWebOrigen { get; set; }

        [MaxLength(255)]
        public string? CrmDescripcion { get; set; }

        public DateTime? CrmFechaLanzamiento { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public DateTime? Fecha_Actualizacion { get; set; }
    }
}
