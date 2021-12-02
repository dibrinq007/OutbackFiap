using OutbackFiap.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutbackFiap.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoUsuarioPage : ContentPage
    {
        public NovoUsuarioPage()
        {
            this.InitializeComponent();
            this.BindingContext = App.GetViewModel<NovoUsuarioViewModel>();
        }
    }
}