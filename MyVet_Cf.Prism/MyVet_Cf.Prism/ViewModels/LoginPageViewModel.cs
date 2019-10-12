using MyVet_Cf.Common.Helpers;
using MyVet_Cf.Common.Models;
using MyVet_Cf.Common.Services;
using Newtonsoft.Json;
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
        private DelegateCommand _registerCommand;

        public LoginPageViewModel(
            INavigationService navigationService,
            IApiService apiService
            ): base(navigationService)
        {
            Title = "Autenticación...";
            IsEnabled = true;
            IsRemember = true;

            _navigationService = navigationService;
            _apiService = apiService;

            //Borrar esta parte es temporal.............
            Email ="carlosfuel@outlook.com";
            Password = "123456";
        }

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));

        public DelegateCommand RegisterCommand => _registerCommand ?? (_registerCommand = new DelegateCommand(Register));

        public bool IsRemember { get; set; }

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

            var url = App.Current.Resources["UrlAPI"].ToString();
            var connection = await _apiService.CheckConnection(url);
            if (!connection)
            {
                IsEnabled = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error de conexión a Internet"
                    , "Revise su Conexión a Internet..", "Aceptar");
                return;
            }


            var request = new TokenRequest
            {
                Password = Password,
                Username = Email 
            };

            //var  url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetTokenAsync(url, "/Account", "/CreateToken", request);            

            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert("Error", "El Correo o Contraseña son Incorrectos", "Aceptar");
                Password = string.Empty;
                return;
            }

            var token = response.Result;
            var rta2 = await _apiService.GetOwnerByEmailAsync(url, "/api", "/Owners/GetOwnerByEmail", "bearer",token.Token,Email);
            if (!rta2.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert("Error"
                    , "El Usuario tiene un problema.. comuniquese con su soporte", "Aceptar");                
                return;
            }

            var owner = rta2.Result;
            //-------------------------------------------
            Settings.Owner = JsonConvert.SerializeObject(owner);
            Settings.Token = JsonConvert.SerializeObject(token);
            //-------------------------------------------
            //var parametros = new NavigationParameters
            //{
            //    { "owner", owner }
            //};

            IsRunning = false;
            IsEnabled = true;
            
            await _navigationService.NavigateAsync("/VeterinaryMasterDetailPage/NavigationPage/PetsPage");
            Password = string.Empty;
            //await App.Current.MainPage.DisplayAlert("Ok", "Muy bien", "Aceptar");
        }

        private async void Register()
        {
            await _navigationService.NavigateAsync("RegisterPage");
        }
    }
}
