﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet_Cf.Web.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres ")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        public string Document { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres ")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres ")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        public string LastName { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres ")]
        public string Address { get; set; }
        //------------------------------------------------
        [Display(Name = "Latitud")]
        [DisplayFormat(DataFormatString = "{0:N6}")]
        public double Latitude { get; set; }

        [Display(Name = "Longitud")]
        [DisplayFormat(DataFormatString = "{0:N6}")]
        public double Longitude { get; set; }
        //-----------------------------------------------

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Usuario")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";
    }
}
