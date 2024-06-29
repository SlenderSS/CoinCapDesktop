using Microsoft.Extensions.DependencyInjection;

namespace CoinCapDesktop.ViewModels
{
    static class ViewModelsRegistrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<AssetsViewModel>()
            .AddSingleton<AssetDetailsViewModel>()
            .AddSingleton<ExchangesViewModel>()
            ;
    }
}
