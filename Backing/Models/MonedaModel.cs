using System.ComponentModel.DataAnnotations;

namespace Backing.Models
{
    public class MonedaModel
    {
        public int MonId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El campo: {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 5)]
        public string? MonNombre { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El campo: {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string? MonSimbolo { get; set; }

    }
}
