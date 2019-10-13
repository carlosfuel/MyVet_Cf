using Prism.Navigation;

namespace MyVet_Cf.Prism.ViewModels
{
    public class EditPetViewModel : ViewModelBase
    {
        public EditPetViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Nueva Mascota";
        }
    }
}
