using CoinCapDesktop.Infrastructure.Commands;
using CoinCapDesktop.Models.Assets;
using CoinCapDesktop.Models.Exchanges;
using CoinCapDesktop.Models.Markets;
using CoinCapDesktop.Models;
using System.Windows.Input;
using CoinCapDesktop.Services.Interfaces;

namespace CoinCapDesktop.ViewModels
{
    class MainWindowViewModel : Base.ViewModel
    {

        #region Title
        private string _title = "CoinCap Desktop";
        public string Title { get => _title; set => Set(ref _title, value); }
        #endregion


        #region Current view
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        #endregion



        public readonly ICoinCapService _coinCapService;


        private GeneralInfo _generalInfo;
        public GeneralInfo GeneralInfo { get => _generalInfo; set { Set(ref _generalInfo, value); OnPropertyChanged(); } }


        private MarketsCollection _markets;
        public MarketsCollection MarketsCol { get => _markets; set { Set(ref _markets, value); OnPropertyChanged(); } }

        private AssetsCollection _assets;
        public AssetsCollection AssetsCol { get => _assets; set { Set(ref _assets, value); OnPropertyChanged(); } }


        private ExchangeCollection _exchanges;
        public ExchangeCollection ExchangesCol { get => _exchanges; set { Set(ref _exchanges, value); OnPropertyChanged(); } }

        #region Commands

        public ICommand HomeCommand { get; set; }
        public ICommand AssetsCommand { get; set; }
        public ICommand ExchangeCommand { get; set; }

        #endregion



        private void Home(object obj) => CurrentView = new HomeViewModel(_coinCapService, GeneralInfo);
        private bool CanHomeExecute(object obj)
        {
            if (!(CurrentView is HomeViewModel)) return true;
            return false;
        }
        private void Assets(object obj) => CurrentView = new AssetsViewModel(_coinCapService, AssetsCol, OpenUserControl);
        private bool CanAssetsExecute(object obj)
        {
            if (!(CurrentView is AssetsViewModel)) return true;
            return false;
        }
        private void Exchanges(object obj) => CurrentView = new ExchangesViewModel(ExchangesCol);

        private bool CanExchangesExecute(object obj)
        {
            if (!(CurrentView is ExchangesViewModel)) return true;
            return false;
        }



        private void OpenUserControl(string path, AssetData assetData)
        {
            switch (path)
            {
                case "AD":
                    CurrentView = new AssetDetailsViewModel(_coinCapService, assetData);
                    break;
            }

        }

        public MainWindowViewModel(ICoinCapService coinCapService)
        {
            #region Commands
            HomeCommand = new LambdaCommand(Home, CanHomeExecute);
            AssetsCommand = new LambdaCommand(Assets, CanAssetsExecute);
            ExchangeCommand = new LambdaCommand(Exchanges, CanExchangesExecute);

            #endregion

            _coinCapService = coinCapService;
            GeneralInfo = new GeneralInfo();

            Task.Run(async () =>
            {
                AssetsCol = await _coinCapService.GetData<AssetsCollection>(_coinCapService.BaseUrl, "assets");
                MarketsCol = await _coinCapService.GetData<MarketsCollection>(_coinCapService.BaseUrl, "markets");
                ExchangesCol = await _coinCapService.GetData<ExchangeCollection>(_coinCapService.BaseUrl, "exchanges");


                GeneralInfo.Exchanges = (ushort)ExchangesCol.Data.Count;
                GeneralInfo.ExchangeVolume = ExchangesCol.Data.Sum(x => x.VolumeUsd);


                GeneralInfo.Markets = MarketsCol.Data.Count;

                GeneralInfo.Assets = (ushort)AssetsCol.Data.Count();
                GeneralInfo.MarketCapUsd = AssetsCol.Data.Sum(x => x.MarketCapUsd);

                var domAsset = AssetsCol.Data.FirstOrDefault();
                GeneralInfo.DominateCurrency = domAsset.Symbol;
                GeneralInfo.DomIndex = (float)((domAsset.MarketCapUsd / GeneralInfo.MarketCapUsd) * 100);

            }).Wait();



            CurrentView = new HomeViewModel(_coinCapService, GeneralInfo);

        }
    }
}
