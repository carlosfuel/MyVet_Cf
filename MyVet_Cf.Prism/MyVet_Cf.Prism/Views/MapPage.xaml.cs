using MyVet_Cf.Common.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyVet_Cf.Prism.Views
{
    public partial class MapPage : ContentPage
    {
        private readonly IGeolocatorService _geolocatorService;

        public MapPage(IGeolocatorService geolocatorService)
        {
            InitializeComponent();
            _geolocatorService = geolocatorService;
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
    }
}
