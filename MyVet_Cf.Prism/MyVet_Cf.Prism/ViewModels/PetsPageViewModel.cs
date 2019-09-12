using MyVet_Cf.Common.Models;
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

        public PetsPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = "Mascotas";
            _navigationService = navigationService;
        }

        public ObservableCollection<PetItemViewModel> Pets
        {
            get => _pets;
            set => SetProperty(ref _pets, value);
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            if (parameters.ContainsKey("owner"))
            {
                _owner = parameters.GetValue<OwnerResponse>("owner");
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

        }
    }
}
