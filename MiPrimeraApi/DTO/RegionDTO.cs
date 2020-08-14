using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.DTO
{
    public class RegionDTO
    {
        public int IdRegion { get; set; }
        public string Nombre { get; set; }    
        public bool Activo { get; set; }      
        public int IdUCreo { get; set; }       
        public DateTime FechaCreo { get; set; }
        public int IdUModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
