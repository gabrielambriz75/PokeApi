using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; } 
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreo { get; set; }
        public int IdUcreo { get; set; }
        public DateTime FechaModifico { get; set; }
        public int IdUModifico { get; set; }
    }
}
