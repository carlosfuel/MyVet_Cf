using MyVet_Cf.Common.Helpers;
using MyVet_Cf.Common.Models;
using MyVet_Cf.Common.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyVet_Cf.Prism.Views
{
    public partial class MapPage : ContentPage
    {
        private readonly IGeolocatorService _geolocatorService;
        private readonly IApiService _apiService;

        public MapPage(IGeolocatorService geolocatorService,
            IApiService apiService
            )
        {
            InitializeComponent();
            _geolocatorService = geolocatorService;
            _apiService = apiService;
            ShowOwnersAsync();
            MoveMapToCurrentPositionAsync();
            
        }

        private async void MoveMapToCurrentPositionAsync()
        {
            await _geolocatorService.GetLocationAsync();
            var position = new Position(
                _geolocatorService.Latitude,
                _geolocatorService.Longitude);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                position,
                Distance.FromKilometers(.5)));
        }

        private async void ShowOwnersAsync()
        {
            var url = App.Current.Resources["UrlAPI"].ToString();
            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);

            var response = await _apiService.GetListAsync<OwnerResponse>(url, "api", "/Owners", "bearer", token.Token);

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    response.Message, 
                    "Aceptar");
                return;
            }

            var owners = (List<OwnerResponse>)response.Result;

            foreach (var owner in owners)
            {
                MyMap.Pins.Add(new Pin
                {
                    Address = owner.Address,
                    Label = owner.FullName,
                    Position = new Position(owner.Latitude, owner.Longitude),
                    Type = PinType.Place
                });
            }
        }

    }
}
