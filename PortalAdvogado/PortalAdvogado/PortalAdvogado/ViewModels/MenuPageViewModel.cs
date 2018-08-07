using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalAdvogado.ViewModels
{
	public class MenuPageViewModel : ViewModelBase
    {
        public MenuPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            Title = "Menu principal";
        }
        
	}
}
