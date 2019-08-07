using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVet_Cf.Web.Data.Entities
{
    public class PetType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Mascota")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede sobrepasar {1} characters.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        //-------------------------Relaciones---------------
        public ICollection<Pet> Pets { get; set; }
    }
}
