using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.Model
{

    [Table("Categoria", Schema = "Cat")]
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public class Categoria
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
        [Key]
        public int IdCategoria { get; set; }
        [Required]
        [StringLength(50)]
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
