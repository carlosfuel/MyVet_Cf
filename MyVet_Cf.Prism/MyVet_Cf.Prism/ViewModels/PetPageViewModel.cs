using MyVet_Cf.Common.Helpers;
using MyVet_Cf.Common.Models;
using Newtonsoft.Json;
using Prism.Navigation;

namespace MyVet_Cf.Prism.ViewModels
{
    public class PetPageViewModel : ViewModelBase
    {
        private PetResponse _pet;

        public PetPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = "Detalles";
        }

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
    }
}
