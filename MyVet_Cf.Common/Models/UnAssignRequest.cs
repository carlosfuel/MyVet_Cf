using System.ComponentModel.DataAnnotations;

namespace MyVet_Cf.Common.Models
{
    public class UnAssignRequest
    {
        [Required]
        public int AgendaId { get; set; }
    }

}
