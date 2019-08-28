using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyVet_Cf.Web.Data.Entities;

namespace MyVet_Cf.Web.Models
{
    public class HistoryViewModel : History
    {
        public int PetId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Tipo de Servicio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un tipo de servicio...")]
        public int ServiceTypeId { get; set; }

        public IEnumerable<SelectListItem> ServiceTypes { get; set; }
    }
}
