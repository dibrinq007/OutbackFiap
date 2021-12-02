using System.Collections.ObjectModel;
using System.Linq;
using OutbackFiap.Mobile.Models;
using OutbackFiap.Mobile.Services;
using OutbackFiap.Mobile.Views;
using Xamarin.Forms;

namespace OutbackFiap.Mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IEstabelecimentoService estabelecimentoService;
        private Command findCommand;
        private Command selectionChanged;
        private Estabelecimento selectedItem;
        private string searchValue;


        public ObservableCollection<Estabelecimento> Items { get; private set; }

        public HomeViewModel(IEstabelecimentoService estabelecimentoService)
        {
            this.estabelecimentoService = estabelecimentoService;
            this.Items = new ObservableCollection<Estabelecimento>();
            this.ListItems();
            MessagingCenter.Subscribe(this, "EDIT_ESTAB", (string _) => this.ListItems());
        }

        public Estabelecimento SelectedItem
        {
            get => this.selectedItem;
            set => this.SetProperty(ref this.selectedItem, value);
        }

        private void ListItems()
        {
            this.Items.Clear();
            var estabs = this.estabelecimentoService.Search(this.searchValue).ToList();
            estabs.ForEach(item => this.Items.Add(item));
        }

        public Command FindCommand => this.findCommand = this.findCommand ?? new Command(ListItems);

        public Command SelectionChanged => this.selectionChanged = this.selectionChanged ?? new Command(async () =>
        {
            if (this.selectedItem != null)
            {
                await Shell.Current.Navigation.PushModalAsync(new EstabelecimentoEdit(this.selectedItem));
            }
        });

        public string SearchValue
        {
            get => this.searchValue;
            set => this.SetProperty(ref this.searchValue, value);
        }

    }
}