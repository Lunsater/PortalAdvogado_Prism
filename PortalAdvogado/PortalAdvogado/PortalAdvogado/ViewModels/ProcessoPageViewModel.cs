using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalAdvogado.ViewModels
{
    public class ProcessoPageViewModel : ViewModelBase
	{
        private String _numProcesso;

        public String NumProcesso
        {
            get { return _numProcesso; }
            set { SetProperty(ref _numProcesso, value); }
        }

        private String _numeroUnico;

        public String NumeroUnico
        {
            get { return _numeroUnico; }
            set { SetProperty(ref _numeroUnico, value); }
        }

        private String _dataDistribuicao;

        public String DataDistribuicao
        {
            get { return _dataDistribuicao; }
            set { SetProperty(ref _dataDistribuicao, value); }
        }

        private String _autor;

        public String Autor
        {
            get { return _autor; }
            set { SetProperty(ref _autor, value); }
        }

        private String _reu;

        public String Reu
        {
            get { return _reu; }
            set { SetProperty(ref _reu, value); }
        }

        private String _assunto;

        public String Assunto
        {
            get { return _assunto; }
            set { SetProperty(ref _assunto, value); }
        }

        public ProcessoPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            Title = "Detalhes do processo";
        }
    }
}
