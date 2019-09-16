﻿using MyVet_Cf.Common.Helpers;
using MyVet_Cf.Common.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyVet_Cf.Prism.ViewModels
{
    public class HistoriesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private PetResponse _pet;
        private ObservableCollection<HistoryItemViewModel> _histories;

        public HistoriesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Historias";
            Pet = JsonConvert.DeserializeObject<PetResponse>(Settings.Pet);
            LoadHistories();
        }

        public ObservableCollection<HistoryItemViewModel> Histories
        {
            get => _histories;
            set => SetProperty(ref _histories, value);
        }

        public PetResponse Pet
        {
            get => _pet;
            set => SetProperty(ref _pet, value);
        }

        //public override void OnNavigatedTo(INavigationParameters parameters)
        //{
        //    base.OnNavigatedTo(parameters);
        //    if (parameters.ContainsKey("pet"))
        //    {
        //        Pet = parameters.GetValue<PetResponse>("pet");
        //        Title = $"Historias Cl de:  {Pet.Name}";
        //        LoadHistories();
        //    }
        //}

        private void LoadHistories()
        {
            Histories = new ObservableCollection<HistoryItemViewModel>
                     (Pet.Histories.Select(h => new HistoryItemViewModel(_navigationService)
                     {
                         Date = h.Date,
                         Description = h.Description,
                         Id = h.Id,
                         Remarks = h.Remarks,
                         ServiceType = h.ServiceType
                     }).ToList());
        }
    }
}
