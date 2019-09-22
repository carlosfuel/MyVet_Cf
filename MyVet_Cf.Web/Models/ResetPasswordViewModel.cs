using System.ComponentModel.DataAnnotations;

namespace MyVet_Cf.Web.Models
{
    public class ResetPasswordViewModel
    {
        [Display(Name = "Correo Electrónico")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Contraseña")]
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Token { get; set; }
    }

}
