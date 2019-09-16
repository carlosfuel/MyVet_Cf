using MyVet_Cf.Common.Helpers;
using MyVet_Cf.Common.Models;
using Newtonsoft.Json;
using Prism.Navigation;

namespace MyVet_Cf.Prism.ViewModels
{
    public class PetTabbedPageViewModel : ViewModelBase
    {
        public PetTabbedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            var pet = JsonConvert.DeserializeObject<PetResponse>(Settings.Pet);
            Title = $"Mascota: {pet.Name}";

        }
    }
}
