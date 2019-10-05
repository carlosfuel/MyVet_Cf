using Prism.Navigation;

namespace MyVet_Cf.Prism.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {
        public MapPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Mapa";
        }
    }
}
