using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.DTO
{
    public class TipoDTO
    {
        public int IdTipo { get; set; }       
        public string Descripcion { get; set; }      
        public int IdUCreo { get; set; }       
        public DateTime FechaCreo { get; set; }
        public int IdUModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
