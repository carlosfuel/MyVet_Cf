using System.ComponentModel.DataAnnotations;

namespace MyVet_Cf.Web.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
