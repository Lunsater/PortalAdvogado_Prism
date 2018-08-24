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

        private int _qtdFases;

        public int QtdFases
        {
            get { return _qtdFases; }
            set { SetProperty(ref _qtdFases, value); }
        }

        private int _qtdMovimentos;

        public int QtdMovimentos
        {
            get { return _qtdMovimentos; }
            set { SetProperty(ref _qtdMovimentos, value); }
        }

        private int _qtdDecisoes;

        public int QtdDecisoes
        {
            get { return _qtdDecisoes; }
            set { SetProperty(ref _qtdDecisoes, value); }
        }

        private int _qtdPartes;

        public int QtdPartes
        {
            get { return _qtdPartes; }
            set { SetProperty(ref _qtdPartes, value); }
        }

        public ProcessoResponse ProcResponse { get; set; }

        public ObservableCollection<ProcessoInfo> Processo { get; set; }


        public ProcessoPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            Title = "Detalhes do processo";
            Processo = new ObservableCollection<ProcessoInfo>();
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
            procInfo.Descricao = "Fases";
            procInfo.Quantidade = procResponse.qtdFases;
            Processo.Add(procInfo);

            procInfo = new ProcessoInfo();
            procInfo.Descricao = "Movimentos";
            procInfo.Quantidade = procResponse.qtdMovimento;
            Processo.Add(procInfo);

            procInfo = new ProcessoInfo();
            procInfo.Descricao = "Decisões";
            procInfo.Quantidade = procResponse.qtdDecisoes;
            Processo.Add(procInfo);

            procInfo = new ProcessoInfo();
            procInfo.Descricao = "Partes e Advogados";
            procInfo.Quantidade = procResponse.qtdPartes;
            Processo.Add(procInfo);

            /*
            QtdMovimentos = procResponse.qtdMovimento;
            QtdFases = procResponse.qtdFases;
            QtdDecisoes = procResponse.qtdDecisoes;
            QtdPartes = procResponse.qtdPartes;

            Processo.Add(procResponse);
            */
        }
    }

    public class ProcessoInfo
    {
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
    }
}
