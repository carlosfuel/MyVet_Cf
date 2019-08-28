using Microsoft.AspNetCore.Mvc.Rendering;
using MyVet_Cf.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet_Cf.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboPetTypes()
        {
            var list = _dataContext.PetTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"

            })
                .OrderBy(pt => pt.Text)
                .ToList();

            // item 0 del combobox
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de Mascota...]",
                Value = "0"
            });


            return list;
        }

        public IEnumerable<SelectListItem> GetComboServiceTypes()
        {
            var list = _dataContext.ServiceTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"

            })
                 .OrderBy(pt => pt.Text)
                 .ToList();

            // item 0 del combobox
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de Servicio...]",
                Value = "0"
            });


            return list;
        }
    }
}
