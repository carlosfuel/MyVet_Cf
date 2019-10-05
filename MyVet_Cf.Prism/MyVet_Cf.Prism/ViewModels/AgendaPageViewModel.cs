using Prism.Navigation;

namespace MyVet_Cf.Prism.ViewModels
{
    public class AgendaPageViewModel : ViewModelBase
    {
        public AgendaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Agenda";
        }
    }
}
