using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalAdvogado.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand SearchCommand => new DelegateCommand(SearchAction);

        private String _numeroProcesso;

        public String NumeroProcesso
        {
            get { return _numeroProcesso; }
            set { SetProperty(ref _numeroProcesso, value); }
        }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService) 
            : base (navigationService, dialogService)
        {
            Title = "Tribunal de Justiça de Sergipe";
        }

        private async void SearchAction()
        {
            var param = new NavigationParameters();
            param.Add("NomeAdvogado", NumeroProcesso);
            await NavigationService.NavigateAsync("/MenuPage/Navigation/ProcessoPage", param);
        }


    }
}
