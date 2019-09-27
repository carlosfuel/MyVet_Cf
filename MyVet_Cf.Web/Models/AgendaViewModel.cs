using Microsoft.AspNetCore.Mvc.Rendering;
using MyVet_Cf.Web.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVet_Cf.Web.Models
{
    public class AgendaViewModel : Agenda
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Propietario")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un propietario")]
        public int OwnerId { get; set; }

        public IEnumerable<SelectListItem> Owners { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Mascota")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una mascota")]
        public int PetId { get; set; }

        public IEnumerable<SelectListItem> Pets { get; set; }

        public bool IsMine { get; set; }

        public string Reserved => "Reserved";
    }
}
