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
	public class LoginViewModel : ViewModelBase
    {
        public DelegateCommand LoginCommand => new DelegateCommand(LoginAction);

        private String _oab;

        public String Oab
        {
            get { return _oab; }
            set { SetProperty(ref _oab, value); }
        }

        private String _letra = "";

        public String Letra
        {
            get { return _letra; }
            set { SetProperty(ref _letra, value); }
        }

        private String _uf = "SE";

        public String Uf
        {
            get { return _uf; }
            set { SetProperty(ref _uf, value); }
        }

        private String _senha;

        public String Senha
        {
            get { return _senha; }
            set { SetProperty(ref _senha, value); }
        }

        public LoginViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {

        }

        private async void LoginAction()
        {
            try
            {
                using (var cliente = IniciarClient())
                {
                    UserDialogs.Instance.ShowLoading("Carregando...");
                    var conteudoJson = JsonConvert.SerializeObject(new LoginAdvogado(Oab, Letra, Uf, Senha));
                    var conteudo = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

                    var resposta = await cliente.PostAsync("/tjse-mobile-rest-services/login/advogado", conteudo);
                    if (resposta.IsSuccessStatusCode)
                    {
                        var respString = resposta.Content.ReadAsStringAsync().Result;
                        var param = new NavigationParameters();
                        param.Add("NomeAdvogado", respString);
                        await NavigationService.NavigateAsync("NavigationPage/MainPage", param);
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("Resultado", resposta.Content.ReadAsStringAsync().Result, "Ok");
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
