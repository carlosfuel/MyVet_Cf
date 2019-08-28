using System.Threading.Tasks;
using MyVet_Cf.Web.Data.Entities;
using MyVet_Cf.Web.Models;

namespace MyVet_Cf.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Pet> ToPetAsync(PetViewModel model, string path,bool isNew);
                
        PetViewModel ToPetViewMOdel(Pet pet);

        //------------------------------------------------

        Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew);

        HistoryViewModel ToHistoryViewModel(History history);
        
        //-----------------------------------------------------------

    }
}