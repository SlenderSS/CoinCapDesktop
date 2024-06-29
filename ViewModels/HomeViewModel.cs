using CoinCapDesktop.Models.Assets;
using CoinCapDesktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinCapDesktop.Services.Interfaces;

namespace CoinCapDesktop.ViewModels
{
    class HomeViewModel : Base.ViewModel
    {

        private ICoinCapService _coinCapService;


        private ObservableCollection<AssetData> _topCryptocurrency;
        public ObservableCollection<AssetData> TopCryptocurrency
        {
            get => _topCryptocurrency;
            set
            {
                Set(ref _topCryptocurrency, value);
                OnPropertyChanged();
            }
        }

        private GeneralInfo _generalInfo;
        public GeneralInfo GeneralInfo { get => _generalInfo; set { Set(ref _generalInfo, value); OnPropertyChanged(); } }

        public HomeViewModel()
        {

        }

        public HomeViewModel(ICoinCapService coinCapService, GeneralInfo generalInfo)
        {

            _coinCapService = coinCapService;
            GeneralInfo = generalInfo;

            TopCryptocurrency = new ObservableCollection<AssetData>(Task.Run(async () =>
            {
                return await _coinCapService.GetData<AssetsCollection>(_coinCapService.BaseUrl, "assets", "?limit=10");

            }).Result.Data);


        }
    }
}
