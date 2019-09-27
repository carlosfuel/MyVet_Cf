using System.ComponentModel.DataAnnotations;

namespace MyVet_Cf.Web.Models
{
    public class AddUserViewModel : EditUserViewModel
    {
        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [EmailAddress]
        public string Username { get; set; }

        //[Display(Name = "Documento")]
        //[MaxLength(20, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        //public string Document { get; set; }

        //[Display(Name = "Nombre")]
        //[MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        //public string FirstName { get; set; }

        //[Display(Name = "Apellido")]
        //[MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        //public string LastName { get; set; }

        //[Display(Name = "Dirección")]
        //[MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        //public string Address { get; set; }

        //[Display(Name = "Número telefónico")]
        //[MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        //public string PhoneNumber { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0}  debe contener entre {2} y {1} caracteres")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0}  debe contener entre {2} y {1} caracteres")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
