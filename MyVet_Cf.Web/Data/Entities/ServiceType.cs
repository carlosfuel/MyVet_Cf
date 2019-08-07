using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVet_Cf.Web.Data.Entities
{
    public class ServiceType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Servicio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede sobrepasar {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        //Relaciones-----------------
        public ICollection<History> Histories { get; set; }
    }
}
