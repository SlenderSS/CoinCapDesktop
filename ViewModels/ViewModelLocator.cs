using Microsoft.Extensions.DependencyInjection;

namespace CoinCapDesktop.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}
