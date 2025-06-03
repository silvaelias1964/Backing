using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Backing.Models
{
    public class UsuarioModel
    {
        
        public int UsrId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El campo: {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 5)]
        public string? UsrNombre { get; set; }

        [MaxLength(50, ErrorMessage = "El campo: {0} debe tener un máximo de {1} caracteres")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El correo no es valido!")]
        public string? UsrCorreo { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "El campo: {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 5)]
        public string? UsrUsuario { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "El campo: {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 5)]
        public string? UsrClave { get; set; }

        [Required(ErrorMessage = "El Rol es requerido (0) Usuario Estandar (1) Administrador")]
        public int UsrRol {  get; set; }
    }
}
