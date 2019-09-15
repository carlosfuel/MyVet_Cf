using MyVet_Cf.Common.Models;
using Prism.Navigation;

namespace MyVet_Cf.Prism.ViewModels
{
    public class HistoryPageViewModel : ViewModelBase
    {
        private HistoryResponse _history;

        public HistoryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Historia Cl";
        }

        public HistoryResponse History
        {
            get => _history;
            set => SetProperty(ref _history, value);                
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("history"))
            {
                History = parameters.GetValue<HistoryResponse>("history");
            }
        }
    }
}
