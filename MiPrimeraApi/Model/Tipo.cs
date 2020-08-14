using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.Model
{
    [Table("Tipo", Schema = "Tip")]
    public class Tipo
    {
        [Key]
        public int IdTipo { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]    
        public int IdUCreo { get; set; }
        [Required]
        public DateTime FechaCreo { get; set; }
    
        public int IdUModifico { get; set; }
        
        public DateTime FechaModifico { get; set; }
    }
}
