using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.DTO
{
    public class UsuarioAuthDTO
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage ="El nombre usuario Correo o Guid es necesario")]
        public string ClientId { get; set; }
        [Required(ErrorMessage ="La contraseña es requerida")]
        [StringLength(12,MinimumLength =6,ErrorMessage ="Longitud no valida, debe ser entre 6 y 12 caracteres.")]
        public string Password { get; set; }
    }
}
