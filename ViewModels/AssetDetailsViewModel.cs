using CoinCapDesktop.Infrastructure.Commands;
using CoinCapDesktop.Models.Assets;
using CoinCapDesktop.Models.Markets;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using CoinCapDesktop.Services.Interfaces;

namespace CoinCapDesktop.ViewModels
{
    class AssetDetailsViewModel : Base.ViewModel
    {

        #region AssetHistoryDatas
        private ObservableCollection<AssetHistoryData> _assetHistoryDates;
        public ObservableCollection<AssetHistoryData> AssetHistoryDates
        {
            get => _assetHistoryDates;
            set
            {
                Set(ref _assetHistoryDates, value);
                OnPropertyChanged();
            }
        }

        #endregion

        #region Asset data
        private AssetData _assetData;

        public AssetData AssetData
        {
            get => _assetData;
            set
            {
                Set(ref _assetData, value);
                OnPropertyChanged();
            }
        }
        #endregion

        #region Markets
        private ObservableCollection<MarketData> _markets;
        public ObservableCollection<MarketData> Markets { get => _markets; set { Set(ref _markets, value); OnPropertyChanged(); } }

        #endregion

        #region High price
        private double _hightPrice;
        public double HighPrice { get => _hightPrice; set { Set(ref _hightPrice, value); OnPropertyChanged(); } }
        #endregion

        #region Low price
        private double _LowPrice;
        public double LowPrice { get => _LowPrice; set { Set(ref _LowPrice, value); OnPropertyChanged(); } }
        #endregion

        #region Average price
        private double _averagePrice;
        public double AveragePrice { get => _averagePrice; set { Set(ref _averagePrice, value); OnPropertyChanged(); } }
        #endregion

        #region Percent change
        private double _percentChange;

        public double PercentChange { get => _percentChange; set { Set(ref _percentChange, value); OnPropertyChanged(); } }

        #endregion

        public ICoinCapService _coinCapService { get; }

        public ICommand GetHistoryCommand { get; set; }

        private void OnGetHistoryCommandExecution(object obj)
        {
            Task.Run(async () =>
            {

                var result = await _coinCapService
                        .GetData<AssetHistoryCollection>(
                                _coinCapService.BaseUrl, 
                                "assets", $"{AssetData.Id}", 
                                $"history?interval={obj.ToString()}");

                AssetHistoryDates = result.Data;
            }).Wait();

            HighPrice = (double)AssetHistoryDates.Max(x => x.PriceUsd);
            LowPrice = (double)AssetHistoryDates.Min(x => x.PriceUsd);
            AveragePrice = (double)AssetHistoryDates.Average(x => x.PriceUsd);
            PercentChange = ((LowPrice / HighPrice) - 1) * 100;

        }


        public AssetDetailsViewModel()
        {

        }

        public AssetDetailsViewModel(ICoinCapService coinCapService, AssetData assetData)
        {

            try
            {
                GetHistoryCommand = new LambdaCommand(OnGetHistoryCommandExecution);
                _coinCapService = coinCapService;
                AssetData = assetData;

                Task.Run(async () =>
                {
                    var result = await _coinCapService.GetData<MarketsCollection>(_coinCapService.BaseUrl, "assets", $"{assetData.Id}", "markets");
                    Markets = result.Data;
                }).Wait();


                OnGetHistoryCommandExecution("m1");

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

    }
}
