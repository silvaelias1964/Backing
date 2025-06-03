using System.ComponentModel.DataAnnotations;

namespace Backing.Data
{
    public class Moneda
    {
        [Key]
        public int MonId { get; set; }

        [Required]
        public string? MonNombre { get; set; }

        [Required]
        public string? MonSimbolo { get; set; }

        public ICollection<PrecioCripto> PrecioCripto { get; set; }
    }
}
