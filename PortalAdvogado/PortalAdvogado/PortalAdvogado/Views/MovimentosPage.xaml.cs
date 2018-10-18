using Xamarin.Forms;

namespace PortalAdvogado.Views
{
    public partial class MovimentosPage : ContentPage
    {
        public MovimentosPage()
        {
            InitializeComponent();
        }

        private void MovimentosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MovimentosListView.SelectedItem = null;
        }
    }
}
