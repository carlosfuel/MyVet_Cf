using Prism.Mvvm;
using Prism.Navigation;

namespace MyVet_Cf.Prism.ViewModels
{
    public class ProfilePageViewModel : ViewModelBase
    {
        public ProfilePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Modificar Perfil";
        }
    }
}
