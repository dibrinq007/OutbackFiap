using System;
using System.Collections.Generic;
using OutbackFiap.Mobile.Models;
using OutbackFiap.Mobile.Services;
using Xamarin.Forms;

namespace OutbackFiap.Mobile.ViewModels
{
    public class EstabelecimentoEditViewModel : BaseViewModel
    {
        private readonly IEstabelecimentoService estabelecimentoService;
        private Ocupacao? ocupacao;
        private Command salvarCommand;
        private Command cancelarCommand;
        private Estabelecimento item;
       

        public EstabelecimentoEditViewModel(IEstabelecimentoService estabelecimentoService)
        {
            this.estabelecimentoService = estabelecimentoService;
            this.PropertyChanged += (_, __) => this.salvarCommand?.ChangeCanExecute();
        }

        public IEnumerable<string> Ocupacoes => Enum.GetNames(typeof(Ocupacao));

        public Command SalvarCommand => this.salvarCommand = this.salvarCommand ?? new Command(() =>
        {
            this.Item.Ocupacao = this.ocupacao.Value;
            this.estabelecimentoService.Update(this.Item);
            MessagingCenter.Send(string.Empty, "EDIT_ESTAB");
            Shell.Current.Navigation.PopModalAsync();

        }, () => this.ocupacao.HasValue);


        public Command CancelarCommand => this.cancelarCommand = this.cancelarCommand ?? new Command(() =>
        {
            Shell.Current.Navigation.PopModalAsync();
        });

        public string Ocupacao
        {
            get => this.ocupacao?.ToString();
            set
            {
                if (Enum.TryParse(value, out Ocupacao ocupacao))
                {
                    base.SetProperty<Ocupacao?>(ref this.ocupacao, ocupacao);
                }
            }
        }
        public string Unidade => this.Item?.Unidade;

        public Estabelecimento Item
        {
            get => this.item;
            set
            {
                this.item = value;
                this.Ocupacao = value.Ocupacao.ToString();
            }
        }
    }
}
