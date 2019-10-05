using MyVet_Cf.Common.Helpers;
using MyVet_Cf.Common.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyVet_Cf.Prism.ViewModels
{
    public class PetsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private OwnerResponse _owner;
        private ObservableCollection<PetItemViewModel> _pets;

        //------------------------------------------------------------

        public PetsPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {            
            _navigationService = navigationService;
            Title = "Mascotas";
            CargarPropietario();//lo enviamos por persistencia
        }

        //------------------------------------------------------------

        public ObservableCollection<PetItemViewModel> Pets
        {
            get => _pets;
            set => SetProperty(ref _pets, value);
        }

        //-------------------------------------------------------------

        private void CargarPropietario()
        {
            _owner = JsonConvert.DeserializeObject<OwnerResponse>(Settings.Owner);
            Title = $"Mascotas de: {_owner.FullName}";
            Pets = new ObservableCollection<PetItemViewModel>(_owner.Pets.Select(p => new PetItemViewModel(_navigationService)
            {
                Born = p.Born,
                Histories = p.Histories,
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                PetType = p.PetType,
                Race = p.Race,
                Remarks = p.Remarks
            }).ToList());
        }

        //------------------------------------------------------------
    }
}
