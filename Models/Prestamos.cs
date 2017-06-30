using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestamosBrito.Models
{
    [Table("Prestamos")]
    public class Prestamos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public long Cantidad { get; set; }
     
        [Required]
        public decimal Tasa { get; set; }
       
        [Required]
        [Display(Name ="Tiempo En Meses")]
        public decimal Tiempo { get; set; }

        [Required]
        [Display(Name ="Cliente")]
        public int ClientesID { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}