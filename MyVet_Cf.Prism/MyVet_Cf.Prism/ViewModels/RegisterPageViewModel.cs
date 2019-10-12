using MyVet_Cf.Common.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;

namespace MyVet_Cf.Prism.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _registerCommand;

        public RegisterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Registrando nuevo usuario";
            IsEnabled = true;
        }

        public DelegateCommand RegisterCommand => _registerCommand ?? (_registerCommand = new DelegateCommand(Register));

        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void Register()
        {
            var isValid = await ValidateData();
            if (!isValid)
            {
                return;
            }
        }

        private async Task<bool> ValidateData()
        {
            if (string.IsNullOrEmpty(Document))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingresa un documento", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(FirstName))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingresa los nombres", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(LastName))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingresa los apellidos", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(Address))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingresa una Dirección.", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(Email) || !RegexHelper.IsValidEmail(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes ingresar un correo electrónico válido.", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(Phone))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingresa un número de teléfono.", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(Password) || Password.Length < 6)
            {
                await App.Current.MainPage.DisplayAlert("Error"
                    , "Ingresa una Contraseña por lo menos de 6 caracteres", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(PasswordConfirm))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingresa nuevamente la contraseña", "Accept");
                return false;
            }

            if (!Password.Equals(PasswordConfirm))
            {
                await App.Current.MainPage.DisplayAlert("Error", "No coinciden la contraseña y la confirmación", "Aceptar");
                return false;
            }

            return true;
        }
    }

}
