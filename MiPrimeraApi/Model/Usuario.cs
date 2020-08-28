using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.Model
{
    [Table("Usuario", Schema = "Usu")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Contrasena { get; set; }
        public bool Activo { get; set; }

        public DateTime FechaCreo { get; set; }
        public int IdUcreo { get; set; }
        public DateTime FechaModifico { get; set; }
        public int IdUModifico { get; set; }


    }
}
