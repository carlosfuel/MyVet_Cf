using MyVet_Cf.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyVet_Cf.Prism.ViewModels
{
    public class VeterinaryMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public VeterinaryMasterDetailPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_pets_menu",
                    PageName = "PetsPage",
                    Title = "Mis Mascotas"
                },

                new Menu
                {
                    Icon = "ic_list_alt",
                    PageName = "AgendaPage",
                    Title = "Mi Agenda"
                },

                new Menu
                {
                    Icon = "ic_map",
                    PageName = "MapPage",
                    Title = "Mapa"
                },

                new Menu
                {
                    Icon = "ic_person",
                    PageName = "ProfilePage",
                    Title = "Modificar Perfil"
                },

                new Menu
                {
                    Icon = "ic_exit_to_app",
                    PageName = "LoginPage",
                    Title = "Cerrar Sesión"
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }
    }
}
