﻿//using FFImageLoading.Work;
using MyVet_Cf.Common.Models;
using Prism.Navigation;
using System;
using Xamarin.Forms;


namespace MyVet_Cf.Prism.ViewModels
{
    public class EditPetViewModel : ViewModelBase
    {
        private PetResponse _pet;
        private ImageSource _imageSource;
        private bool _isRunning;
        private bool _isEnabled;
        private bool _isEdit;

        public EditPetViewModel(INavigationService navigationService) : base(navigationService)
        {
            //Title = "Nueva Mascota";
            IsEnabled = true;
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEdit
        {
            get => _isEdit;
            set => SetProperty(ref _isEdit, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public PetResponse Pet
        {
            get => _pet;
            set => SetProperty(ref _pet, value);
        }

        public ImageSource ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("pet"))
            {
                Pet = parameters.GetValue<PetResponse>("pet");
                ImageSource = Pet.ImageUrl;
                IsEdit = true;
                Title = "Editando Mascota";
            }
            else
            {
                Pet = new PetResponse { Born = DateTime.Today };
                ImageSource = "noimage";
                IsEdit = false;
                Title = "Nueva Mascota";
            }
        }

    }

}
