using Xamarin.Forms;

namespace PortalAdvogado.Views
{
    public partial class ProcessoPage : ContentPage
    {
        public ProcessoPage()
        {
            InitializeComponent();
            Title = "Detalhe do processo";
        }

        private void ProcessosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ProcessosListView.SelectedItem = null;
        }
    }
}
