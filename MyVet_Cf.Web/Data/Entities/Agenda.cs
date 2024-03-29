﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MyVet_Cf.Web.Data.Entities
{
    public class Agenda
    {
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} obligatorio")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Comentarios")]
        public string Remarks { get; set; }

        [Display(Name = "Está Disponible?")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Fecha")]        
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd} HH:mm}")]
        public DateTime DateLocal => Date.ToLocalTime();

        //-------------------------- Relaciones----------
        public Owner Owner { get; set; }
        public Pet Pet { get; set; }
    }
}
