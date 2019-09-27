using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyVet_Cf.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboPetTypes();

        IEnumerable<SelectListItem> GetComboServiceTypes();

        IEnumerable<SelectListItem> GetComboOwners();

        IEnumerable<SelectListItem> GetComboPets(int ownerId);
    }
}