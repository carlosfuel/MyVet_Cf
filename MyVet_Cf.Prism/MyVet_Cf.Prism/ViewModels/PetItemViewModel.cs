using MyVet_Cf.Common.Models;
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
            var parametros = new NavigationParameters
            {
                { "pet", this }
            };

            await _navigationService.NavigateAsync("HistoriesPage", parametros);
        }
    }
}
