using Microsoft.Extensions.DependencyInjection;
using OutbackFiap.Mobile.Services;
using OutbackFiap.Mobile.ViewModels;
using OutbackFiap.Mobile.Views;
using System;
using Xamarin.Forms;

namespace OutbackFiap.Mobile
{
    public partial class App : Application
    {

        public App(Action<IServiceCollection> addPlatformServices = null)
        {
            this.InitializeComponent();
            this.SetupServices(addPlatformServices);
            this.MainPage = new AppShell();
        }

        private void SetupServices(Action<IServiceCollection> addPlatformServices)
        {
            var services = new ServiceCollection();
            addPlatformServices?.Invoke(services);

            services.AddTransient<NovoEstabelecimentoViewModel>()
                .AddTransient<EstabelecimentoDetailViewModel>()
                .AddTransient<ListEstabelecimentoViewModel>()
                .AddTransient<EstabelecimentoEditViewModel>()
                .AddTransient<HomeViewModel>()
                .AddTransient<NovoUsuarioViewModel>()
                .AddTransient<LoginViewModel>();

            services.AddSingleton<IEstabelecimentoService, EstabelecimentoService>()
                .AddSingleton<IUsuarioService, UsuarioService>();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected static IServiceProvider ServiceProvider { get; set; }

        public static TViewModel GetViewModel<TViewModel>() where TViewModel : BaseViewModel
            => ServiceProvider.GetService<TViewModel>();

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
