using OutbackFiap.Mobile.ViewModels;
using Xamarin.Forms;

namespace OutbackFiap.Mobile.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            this.InitializeComponent();
            this.BindingContext = App.GetViewModel<HomeViewModel>();
        }
    }
}