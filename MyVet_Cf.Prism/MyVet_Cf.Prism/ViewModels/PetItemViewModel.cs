using MyVet_Cf.Common.Helpers;
using MyVet_Cf.Common.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;

namespace MyVet_Cf.Prism.ViewModels
{
    public class PetItemViewModel : PetResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectPetCommand;

        public PetItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectPetCommand =>
            _selectPetCommand ?? (_selectPetCommand = new DelegateCommand(SelectPet));

        private async void SelectPet()
        {
            Settings.Pet = JsonConvert.SerializeObject(this);
            await _navigationService.NavigateAsync("PetTabbedPage");
        }
    }
}
