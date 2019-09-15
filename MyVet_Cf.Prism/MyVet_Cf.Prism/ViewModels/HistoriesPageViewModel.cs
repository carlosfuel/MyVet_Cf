using MyVet_Cf.Common.Models;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace MyVet_Cf.Prism.ViewModels
{
    public class HistoriesPageViewModel : ViewModelBase
    {
        private PetResponse _pet;
        private ObservableCollection<HistoryResponse> _histories;

        public HistoriesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Historias";
        }

        public ObservableCollection<HistoryResponse> Histories
        {
            get => _histories;
            set => SetProperty(ref _histories, value);
        }

        public PetResponse Pet
        {
            get => _pet;
            set => SetProperty(ref _pet, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("pet"))
            {
                Pet = parameters.GetValue<PetResponse>("pet");
                Title = $"Historias Cl de:  {Pet.Name}";
                Histories = new ObservableCollection<HistoryResponse>(Pet.Histories);
            }
        }
    }
}
