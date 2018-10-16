using Acr.UserDialogs;
using Newtonsoft.Json;
using PortalAdvogado.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            try
            {
                using (var cliente = IniciarClient())
                {
                    UserDialogs.Instance.ShowLoading("Carregando...");
                    var resposta = await cliente.GetStringAsync("/processo-api/v1/processo/" + NumeroProcesso);
                    var processoResponse = JsonConvert.DeserializeObject<ProcessoResponse>(resposta);
                    if (processoResponse != null)
                    {
                        var param = new NavigationParameters();
                        param.Add("ProcessoResponse", processoResponse);
                        await NavigationService.NavigateAsync("ProcessoPage", param);
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("Resultado", "Nenhum processo encontrado!", "Ok");
                    }
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }
    }
}
