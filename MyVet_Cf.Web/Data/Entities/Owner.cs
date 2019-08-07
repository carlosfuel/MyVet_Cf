using MyVet_Cf.Web.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVet_Cf.Web.Data.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        [MaxLength(30,ErrorMessage ="El campo {0} no puede tener mas de {1} caracteres ")] //Tamaño máximo del campo 30 caracteres
        [Required(ErrorMessage ="El campo {0} es Obligatorio")]//Que los nombres sean obligatorios        
        [Display(Name = "Documento")]
        public string Document { get; set; }

        
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres ")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [Display(Name ="Primer Nombre")]
        public string FirstName { get; set; }

        
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres ")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [Display(Name = "Primer Apellido")]
        public string LastName { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres ")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [Display(Name = "Teléfono Fijo")]
        public string FixedPhone { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres ")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [Display(Name = "Celular")]
        public string CellPhone { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres ")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Propietario")]
        public string FullName => $"{FirstName} {LastName}"; //Prop de solo lectura

        [Display(Name = "Propietario")]
        public string FullNameWithDocuement => $"{FirstName} {LastName} - {Document}";

        //Relaciones---------------- Un propietario tiene muchas mascotas----------
        public ICollection<Pet> Pets { get; set; }
        public ICollection<Agenda> Agendas { get; set; }
    }
}
