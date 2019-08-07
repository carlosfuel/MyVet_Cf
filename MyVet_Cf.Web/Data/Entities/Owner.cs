using System.ComponentModel.DataAnnotations;

namespace MyVet_Cf.Web.Data.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]//Que los nombres sean obligatorios
        [MaxLength(30)] //Tamaño máximo del campo 30 caracteres
        public string Document { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name ="Primer Nombre")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Primer Apellido")]
        public string LastName { get; set; }

        [MaxLength(20)]
        [Display(Name = "Teléfono Fijo")]
        public string FixedPhone { get; set; }

        [Required]
        [Display(Name = "Celular")]
        public string CellPhone { get; set; }

        [MaxLength(100)]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Propietario")]
        public string FullName => $"{FirstName} {LastName}"; //Prop de solo lectura

        [Display(Name = "Propietario")]
        public string FullNameWithDocuement => $"{FirstName} {LastName} - {Document}";
    }
}
