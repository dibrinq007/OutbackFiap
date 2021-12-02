using OutbackFiap.Mobile.Models;
using OutbackFiap.Mobile.ViewModels;
using OutbackFiap.Mobile.Views;
using Xamarin.Forms;

namespace OutbackFiap.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            this.InitializeComponent();

            this.BindingContext = new AppShellViewModel();
            Routing.RegisterRoute(nameof(ListEstabelecimentoPage), typeof(ListEstabelecimentoPage));
            Routing.RegisterRoute(nameof(EstabeleceimentoDetalhePage), typeof(EstabeleceimentoDetalhePage));
            Routing.RegisterRoute(nameof(NewEstabelecimentoPage), typeof(NewEstabelecimentoPage));
        }

    }
}
