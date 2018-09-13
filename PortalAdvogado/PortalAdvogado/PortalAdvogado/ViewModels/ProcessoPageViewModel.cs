using Acr.UserDialogs;
using Newtonsoft.Json;
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
    public class ProcessoPageViewModel : ViewModelBase
	{        
        private string _numProcesso;

        public string NumProcesso
        {
            get { return _numProcesso; }
            set { SetProperty(ref _numProcesso, value); }
        }

        private string _numeroUnico;

        public string NumeroUnico
        {
            get { return _numeroUnico; }
            set { SetProperty(ref _numeroUnico, value); }
        }

        private string _dataDistribuicao;

        public string DataDistribuicao
        {
            get { return _dataDistribuicao; }
            set { SetProperty(ref _dataDistribuicao, value); }
        }

        private string _competencia;

        public string Competencia
        {
            get { return _competencia; }
            set { SetProperty(ref _competencia, value); }
        }

        private string _ultimaFase;

        public string UltimaFase
        {
            get { return _ultimaFase; }
            set { SetProperty(ref _ultimaFase, value); }
        }

        private string _assunto;

        public string Assunto
        {
            get { return _assunto; }
            set { SetProperty(ref _assunto, value); }
        }

        public ProcessoResponse ProcResponse { get; set; }

        public ObservableCollection<ProcessoInfo> Processos { get; set; }

        private ProcessoInfo _itemProcSelecionado;
        public ProcessoInfo ItemProcSelecionado
        {
            get { return _itemProcSelecionado; }
            set
            {
                _itemProcSelecionado = value;
                if (value != null)
                {
                    ItemProcSelecionadoAction(_itemProcSelecionado);
                }
            }
        }

        public ProcessoPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            Title = "Detalhes do processo";
            Processos = new ObservableCollection<ProcessoInfo>();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("ProcessoResponse"))
            {
                ProcResponse = parameters.GetValue<ProcessoResponse>("ProcessoResponse");
                CarregaProcesso(ProcResponse);
            }
                
        }

        private void CarregaProcesso(ProcessoResponse procResponse)
        {
            NumProcesso = procResponse.numProcesso;
            NumeroUnico = procResponse.numUnico;
            DataDistribuicao = procResponse.dataDistribuicao.ToString("dd/MM/yyyy");
            Assunto = procResponse.assunto;
            Competencia = procResponse.competencia;
            UltimaFase = procResponse.ultimaFase;

            ProcessoInfo procInfo= new ProcessoInfo();
            procInfo.NumProcesso = ProcResponse.numProcesso;
            procInfo.Descricao = "Fases";
            procInfo.Quantidade = procResponse.qtdFases;
            Processos.Add(procInfo);

            procInfo = new ProcessoInfo();
            procInfo.NumProcesso = ProcResponse.numProcesso;
            procInfo.Descricao = "Movimentos";
            procInfo.Quantidade = procResponse.qtdMovimento;
            Processos.Add(procInfo);

            procInfo = new ProcessoInfo();
            procInfo.NumProcesso = ProcResponse.numProcesso;
            procInfo.Descricao = "Decisões";
            procInfo.Quantidade = procResponse.qtdDecisoes;
            Processos.Add(procInfo);

            procInfo = new ProcessoInfo();
            procInfo.NumProcesso = ProcResponse.numProcesso;
            procInfo.Descricao = "Partes e Advogados";
            procInfo.Quantidade = procResponse.qtdPartes;
            Processos.Add(procInfo);
        }

        private async void ItemProcSelecionadoAction(ProcessoInfo itemProcSelecionado)
        {
            try
            {
                using (var cliente = IniciarClient())
                {
                    UserDialogs.Instance.ShowLoading("Carregando...");
                    if ("Fases".Equals(itemProcSelecionado.Descricao))
                    {
                        if (itemProcSelecionado.Quantidade > 0)
                        {
                            var resposta = await cliente.GetStringAsync("/processo-api/fase/buscar/" 
                                + itemProcSelecionado.NumProcesso);
                            var faseResponse = JsonConvert.DeserializeObject<FaseResponse>(resposta);
                            var param = new NavigationParameters();
                            param.Add("FaseResponse", faseResponse);
                            await NavigationService.NavigateAsync("FasesPage", param);
                        }
                        else
                        {
                            await DialogService.DisplayAlertAsync("Resultado", "Nenhuma fase encontrada!", "Ok");
                        }
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

    public class ProcessoInfo
    {
        public string NumProcesso { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
    }

}
