using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutbackFiap.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutbackFiap.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEstabelecimentoPage : ContentPage
    {
        public ListEstabelecimentoPage()
        {
            this.InitializeComponent();
            this.BindingContext = App.GetViewModel<ListEstabelecimentoViewModel>();
        }
    }
}