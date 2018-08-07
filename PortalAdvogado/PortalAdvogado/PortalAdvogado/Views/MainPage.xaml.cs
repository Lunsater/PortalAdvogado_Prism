using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PortalAdvogado.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

            Title = "Tribunal de Justiça de Sergipe";
		}

        private void SearchBar_OnSearchButtonPressed(object sender, TextChangedEventArgs e)
        {
            /*
            try
            {
                var texto = ProcessoSearchBar.Text;

                if (string.IsNullOrEmpty(e.NewTextValue) || (texto.Length != 12 && texto.Length != 25))
                {
                    throw new Exception("O nº de processo digitado precisa ser um número válido de 12 caracteres (caso seja processo origem) ou 25 caracteres (caso seja número único).");
                }
                else
                {
                    ProcessosListView.ItemsSource = processos.Where(x => x.numeroProcessoTJSE.ToLower().StartsWith(texto.ToLower()));
                }

                ProcessosListView.IsVisible = true;
                PartesBtn.IsVisible = true;
                MovimentosBtn.IsVisible = true;
                DocumentosBtn.IsVisible = true;
                EmptyListLabel.IsVisible = false;
            }
            catch (Exception ex)
            {
                ProcessosListView.IsVisible = false;
                PartesBtn.IsVisible = false;
                MovimentosBtn.IsVisible = false;
                DocumentosBtn.IsVisible = false;
                EmptyListLabel.IsVisible = true;
                DisplayAlert("Erro", ex.Message, "OK");
            }
            */
        }

        private void SearchBar_OnTextPressed(object sender, TextChangedEventArgs e) { }

        private void OnPartesClicked(object sender, TextChangedEventArgs e)
        {
            /*
            List<List<Parte>> listaPartes = new List<List<Parte>>();
            //listaPartes.Add(processos[0].listaAutores);
            //listaPartes.Add(processos[0].listaReus);
            listaPartes.Add(processos[0].listaAutores.Concat(processos[0].listaReus).ToList());
            Navigation.PushAsync(new PartesView(listaPartes));
            */
        }

        private void OnMovimentosClicked(object sender, TextChangedEventArgs e)
        {
            // Navigation.PushAsync(new MovimentosView(processos[0].listaMovimentos));
        }

        private void OnDocumentosClicked(object sender, TextChangedEventArgs e)
        {
            /*
            List<List<Movimento>> listaMovimentos = new List<List<Movimento>>();
            listaMovimentos.Add(processos[0].listaMovimentos);
            Navigation.PushAsync(new DocumentosView(listaMovimentos));
            */
        }
    }
}