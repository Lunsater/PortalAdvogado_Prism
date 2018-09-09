using Xamarin.Forms;

namespace PortalAdvogado.Views
{
    public partial class FasesPage : ContentPage
    {
        public FasesPage()
        {
            InitializeComponent();
            Title = "Fases/andamento";
        }

        private void FasesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            FasesListView.SelectedItem = null;
        }
    }
}
