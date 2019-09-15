using MyVet_Cf.Common.Models;
using Prism.Commands;
using Prism.Navigation;
using System;

namespace MyVet_Cf.Prism.ViewModels
{
    public class HistoryItemViewModel : HistoryResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectHistoryCommand;

        public HistoryItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectHistoryCommand => _selectHistoryCommand ??
            (_selectHistoryCommand = new DelegateCommand(SelectHistory));

        private async void SelectHistory()
        {
            var parametros = new NavigationParameters
            {
                { "history", this }
            };
            await _navigationService.NavigateAsync("HistoryPage",parametros);
        }
    }
}
