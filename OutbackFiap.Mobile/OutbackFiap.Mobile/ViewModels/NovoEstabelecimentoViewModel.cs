using System;
using System.Diagnostics;
using OutbackFiap.Mobile.Models;
using OutbackFiap.Mobile.Services;
using Xamarin.Forms;

namespace OutbackFiap.Mobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class NovoEstabelecimentoViewModel : BaseViewModel
    {
        private string unidade;
        private string endereco;
        private int numero;
        private string complemento;
        private string bairro;
        private string cidade;
        private string estado;
        private string cep;
        private int itemId;      
 
        private readonly IEstabelecimentoService estabelecimentoService;

        public NovoEstabelecimentoViewModel(IEstabelecimentoService estabelecimentoService)
        {
           
            this.SaveCommand = new Command(this.OnSave, this.ValidateSave);
            this.CancelCommand = new Command(this.OnCancel);
            this.PropertyChanged += (_, __) => this.SaveCommand.ChangeCanExecute();

            this.estabelecimentoService = estabelecimentoService;
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(this.Unidade)
                && !string.IsNullOrWhiteSpace(Endereco)
                && (this.numero > 0)
                && !string.IsNullOrWhiteSpace(Bairro)
                && !string.IsNullOrWhiteSpace(Cidade)
                && !string.IsNullOrWhiteSpace(Estado)
                && !string.IsNullOrWhiteSpace(CEP);
        }

        public int ItemId
        {
            get => itemId;
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public string Unidade
        {
            get => unidade;
            set => SetProperty(ref unidade, value);
        }

        public string Endereco
        {
            get => endereco;
            set => SetProperty(ref endereco, value);
        }
        public int Numero
        {
            get => numero;
            set => SetProperty(ref numero, value);
        }
        public string Complemento
        {
            get => complemento;
            set => SetProperty(ref complemento, value);
        }
        public string Bairro
        {
            get => bairro;
            set => SetProperty(ref bairro, value);
        }
        public string Cidade
        {
            get => cidade;
            set => SetProperty(ref cidade, value);
        }
        public string Estado
        {
            get => estado;
            set => SetProperty(ref estado, value);
        }
        public string CEP
        {
            get => cep;
            set => SetProperty(ref cep, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private void LoadItemId(int value)
        {
            try
            {
                var item = this.estabelecimentoService.GetById(value);
        
                Unidade = item.Unidade;
                Endereco = item.Endereco;
                Numero = item.Numero;
                Complemento = item.Complemento;
                Bairro = item.Bairro;
                Cidade = item.Cidade;
                Estado = item.Estado;
                CEP = item.CEP;
            }
            catch (Exception)
            {
                Debug.WriteLine("Ocorreu um erro durante o carregamento dos estabelecimentos.");
            }
        }

        private async void OnCancel()
        {           
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            if (this.itemId == 0)
            {
                var newEstab = new Estabelecimento()
                {
                    Unidade = Unidade,
                    Endereco = Endereco,
                    Numero = Numero,
                    Complemento = Complemento,
                    Bairro = Bairro,
                    Cidade = Cidade,
                    Estado = Estado,
                    CEP = CEP
                };

                this.estabelecimentoService.Insert(newEstab);
            }
            else
            {
                var editEstab = new Estabelecimento()
                {
                    Id = this.itemId,
                    Unidade = Unidade,
                    Endereco = Endereco,
                    Numero = Numero,
                    Complemento = Complemento,
                    Bairro = Bairro,
                    Cidade = Cidade,
                    Estado = Estado,
                    CEP = CEP
                };

                this.estabelecimentoService.Update(editEstab);
            }


            MessagingCenter.Send(string.Empty, "EDIT_ESTAB");
            await Shell.Current.GoToAsync("..");
        }
    }
}
