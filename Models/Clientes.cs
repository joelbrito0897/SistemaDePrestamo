using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrestamosBrito.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo {0} Esta Vaciao")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Campo {0} Esta Vaciao")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Campo {0} Esta Vaciao")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El Campo {0} Esta Vaciao")]
        public string Telefono { get; set; }

        public virtual ICollection<Prestamos> Prestamos { get; set; }
    }
}