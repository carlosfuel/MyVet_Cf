using System.ComponentModel.DataAnnotations;

namespace MyVet_Cf.Common.Models
{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
