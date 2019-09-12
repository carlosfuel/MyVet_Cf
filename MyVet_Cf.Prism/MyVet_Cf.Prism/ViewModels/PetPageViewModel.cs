using MyVet_Cf.Common.Models;
using Prism.Navigation;

namespace MyVet_Cf.Prism.ViewModels
{
    public class PetPageViewModel : ViewModelBase
    {
        private PetResponse _pet;

        public PetPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("pet"))
            {
                _pet = parameters.GetValue<PetResponse>("pet");
                Title = _pet.Name;
            }
        }
    }
}
