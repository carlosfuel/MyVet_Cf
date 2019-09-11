using MyVet_Cf.Common.Models;
using MyVet_Cf.Common.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyVet_Cf.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _loginCommand;

        public LoginPageViewModel(
            INavigationService navigationService,
            IApiService apiService
            ): base(navigationService)
        {
            Title = "Autenticación...";
            IsEnabled = true;
            _navigationService = navigationService;
            _apiService = apiService;

            //Borrar esta parte es temporal.............
            Email ="carlosfuel@outlook.com";
            Password = "123456";
        }

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));

        
        public string Email { get; set; }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

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

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "No has digitado el Correo electrónico", "Aceptar");               
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "No ha digitado la contraseña", "Aceptar");
                return;                
            }

            IsRunning = true;
            IsEnabled = false;

            var request = new TokenRequest
            {
                Password = Password,
                Username = Email 
            };

            var  url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetTokenAsync(url, "/Account", "/CreateToken", request);            

            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert("Error", "El Correo o Contraseña son Incorrectos", "Aceptar");
                Password = string.Empty;
                return;
            }

            var token = (TokenResponse)response.Result;
            var rta2 = await _apiService.GetOwnerByEmailAsync(url, "/api", "/Owners/GetOwnerByEmail", "bearer",token.Token,Email);
            if (!rta2.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert("Error"
                    , "El Usuario tiene un problema.. comuniquese con su soporte", "Aceptar");                
                return;
            }

            var owner = (OwnerResponse)rta2.Result;
            var parametros = new NavigationParameters
            {
                { "owner", owner }
            };

            IsRunning = false;
            IsEnabled = true;
            
            await _navigationService.NavigateAsync("PetsPage",parametros);
            Password = string.Empty;
            //await App.Current.MainPage.DisplayAlert("Ok", "Muy bien", "Aceptar");
        }
    }
}
