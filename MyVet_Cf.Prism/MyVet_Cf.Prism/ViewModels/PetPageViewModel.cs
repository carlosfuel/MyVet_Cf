using System;
using MyVet_Cf.Common.Helpers;
using MyVet_Cf.Common.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;

namespace MyVet_Cf.Prism.ViewModels
{
    public class PetPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private PetResponse _pet;
        private DelegateCommand _editPetCommand;

        public PetPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            //Title = "Detalles";
            _navigationService = navigationService;
        }

        public DelegateCommand EditPetCommand =>  _editPetCommand ?? (_editPetCommand= new DelegateCommand(EditPetAsync));

        

        public PetResponse Pet
        {
            get => _pet;
            set => SetProperty(ref _pet,value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Pet = JsonConvert.DeserializeObject<PetResponse>(Settings.Pet);
            
        }

        private async void EditPetAsync()
        {
            var parametros = new NavigationParameters
            {
                { "pet", Pet }
            };
            await _navigationService.NavigateAsync("EditPet",parametros);
        }
    }
}
