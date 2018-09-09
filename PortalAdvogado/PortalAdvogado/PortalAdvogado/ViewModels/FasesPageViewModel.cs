using PortalAdvogado.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PortalAdvogado.ViewModels
{
	public class FasesPageViewModel : ViewModelBase
    {
        private string _numProcesso;

        public string NumProcesso
        {
            get { return _numProcesso; }
            set { SetProperty(ref _numProcesso, value); }
        }

        public FaseResponse FaseResp { get; set; }

        public ObservableCollection<FaseInfo> Fases { get; set; }

        public FasesPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            Fases = new ObservableCollection<FaseInfo>();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("FaseResponse"))
            {
                FaseResp = parameters.GetValue<FaseResponse>("FaseResponse");
                CarregaFase(FaseResp);
            }

        }

        private void CarregaFase(FaseResponse faseResp)
        {
            NumProcesso = faseResp.numProcesso;
            foreach (DadosFase dadosFase in faseResp.listaFases)
            {
                FaseInfo faseInfo = new FaseInfo();
                faseInfo.Data = dadosFase.dataFase;
                faseInfo.Descricao = dadosFase.descricao;
                Fases.Add(faseInfo);
            }
        }
    }

    public class FaseInfo
    {
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}
