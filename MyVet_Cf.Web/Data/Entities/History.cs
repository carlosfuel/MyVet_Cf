using System;
using System.ComponentModel.DataAnnotations;

namespace MyVet_Cf.Web.Data.Entities
{
    public class History
    {
        public int Id { get; set; }
                
        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} obligatorio")]
        public string Description { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} obligatorio")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Remarks { get; set; }  //comentarios

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => Date.ToLocalTime();

        //---------------------Relaciones--------------
        public ServiceType ServiceType { get; set; }
        public Pet Pet { get; set; }
    }
}
