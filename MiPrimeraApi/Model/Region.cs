using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.Model
{
    [Table("Region", Schema = "Reg")]
    public class Region
    {
       [Key]
        public int IdRegion { get; set; }
        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public int IdUCreo { get; set; }
        [Required]
        public DateTime FechaCreo { get; set; }

        public int IdUModifico { get; set; }

        public DateTime FechaModifico { get; set; }
    }
}
