using System.ComponentModel.DataAnnotations;

namespace Backing.Data
{
    public class Usuario
    {
        [Key]
        public int UsrId { get; set; }

        [Required]        
        public string? UsrNombre { get; set; }

        public string? UsrCorreo { get; set; }

        [Required]        
        public string? UsrUsuario { get; set; }

        [Required]
        public string? UsrClave { get; set; }

        [Required]
        public int UsrRol { get; set; }
    }
}
