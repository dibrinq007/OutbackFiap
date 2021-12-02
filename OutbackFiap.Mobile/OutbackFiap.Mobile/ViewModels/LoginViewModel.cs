using OutbackFiap.Mobile.Services;
using OutbackFiap.Mobile.Views;
using Xamarin.Forms;

namespace OutbackFiap.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string email;
        private string senha;
        private readonly IUsuarioService usuarioService;

        public LoginViewModel(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
            this.LoginCommand = new Command(this.OnLoginClicked);
            this.CreateAccountCommand = new Command(this.OnCreateCommandClicked);
        }

        public string Email
        {
            get => this.email;
            set => this.SetProperty(ref this.email, value);
        }

        public string Senha
        {
            get => this.senha;
            set => this.SetProperty(ref this.senha, value);
        }

        static public string TipoUsuario { get; set; }

        public Command LoginCommand { get; }
        public Command CreateAccountCommand { get; }

        private async void OnCreateCommandClicked()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NovoUsuarioPage());
        }

        private void OnLoginClicked(object obj)
        {
            if (this.usuarioService.Login(this.email, this.senha))
            {
                var usuario = this.usuarioService.GetByEmail(this.email);
                TipoUsuario = usuario.TipoUsuario.ToString();


                Shell.Current.Navigation.PushAsync(new ListEstabelecimentoPage());
            }
            else
            {
                this.Message = "Email e/ou senha inválidos";
            }
        }
    }
}
