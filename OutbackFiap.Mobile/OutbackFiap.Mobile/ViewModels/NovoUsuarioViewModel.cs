using System;
using System.Collections.Generic;
using OutbackFiap.Mobile.Models;
using OutbackFiap.Mobile.Services;
using OutbackFiap.Mobile.Utils;
using Xamarin.Forms;

namespace OutbackFiap.Mobile.ViewModels
{
    public class NovoUsuarioViewModel : BaseViewModel
    {
        private readonly IUsuarioService usuarioService;
        private string nome;
        private string email;
        private string senha;
        private TipoUsuario? tipoUsuario;
        private Command salvarCommand;
        private Command cancelarCommand;

        public NovoUsuarioViewModel(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        public string Nome { get => this.nome; set => base.SetProperty(ref this.nome, value); }
        public string Email { get => this.email; set => base.SetProperty(ref this.email, value); }
        public string Senha { get => this.senha; set => base.SetProperty(ref this.senha, value); }
        public string TipoUsuario
        {
            get => this.tipoUsuario.ToString();
            set
            {
                if (Enum.TryParse(value, out TipoUsuario tipoUsuario))
                {
                    base.SetProperty<TipoUsuario?>(ref this.tipoUsuario, tipoUsuario);
                }
            }
        }
        public IEnumerable<string> TiposUsuario { get => Enum.GetNames(typeof(TipoUsuario)); }

        public Command SalvarCommand =>
            this.salvarCommand = this.salvarCommand ?? new Command(() =>
            {
                try
                {
                    this.Message = string.Empty;
                    if (string.IsNullOrEmpty(this.nome)
                        || string.IsNullOrEmpty(this.email)
                        || string.IsNullOrEmpty(this.senha)
                        || !this.tipoUsuario.HasValue
                    )
                    {
                        this.Message = "Preencha todos os campos";
                        return;
                    }

                    if (!Helpers.IsAValidEmail(this.email))
                    {
                        this.Message = "Informar um email válido";
                        return;
                    }

                    if (this.senha.Length < 6)
                    {
                        this.Message = "A senha tem que ter pelo menos 6 caracteres";
                        return;
                    }

                    if (this.usuarioService.GetByEmail(this.email) != null)
                    {
                        this.Message = "Email já cadastrado!";
                        return;
                    }

                    this.usuarioService.Insert(new Usuario()
                    {
                        Nome = this.nome.Trim(),
                        Email = this.email.Trim(),
                        Senha = this.senha.Trim(),
                        TipoUsuario = this.tipoUsuario.Value
                    });


                    Application.Current.MainPage.Navigation.PopAsync();

                }
                catch
                {

                    this.Message = "Erro ao salvar usuário";
                }
            });

        public Command CancelarCommand =>
            this.cancelarCommand = this.cancelarCommand ?? new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
    }
}
