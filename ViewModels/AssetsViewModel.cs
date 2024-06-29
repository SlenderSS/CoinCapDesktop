using CoinCapDesktop.Infrastructure.Commands;
using CoinCapDesktop.Models.Assets;
using CoinCapDesktop.Services.Interfaces;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace CoinCapDesktop.ViewModels
{
    class AssetsViewModel : Base.ViewModel
    {
        private readonly Action<string, AssetData> _action;

        public AssetData SelectedAsset { get; set; }

        public readonly ICoinCapService _coinCapService;

        private AssetsCollection _assets;
        public AssetsCollection AssetsCol
        {
            get => _assets;
            set
            {
                if (!(Set(ref _assets, value))) return;
                _AssetsCollection.Source = value?.Data;

                OnPropertyChanged(nameof(AssetsCollection));
            }
        }


        #region Assets filter

        private CollectionViewSource _AssetsCollection = new CollectionViewSource();
        public ICollectionView AssetsCollection => _AssetsCollection?.View;


        private string _assetFilterText;

        public string AssetFilterText
        {
            get => _assetFilterText; set
            {
                if (!Set(ref _assetFilterText, value)) return;
                _AssetsCollection.View.Refresh();

            }
        }

        private void OnAssetFiltered(object sender, FilterEventArgs E)
        {
            if (!(E.Item is AssetData assetData)) return;

            var filterText = _assetFilterText;
            if (string.IsNullOrWhiteSpace(filterText)) return;

            if (assetData.Symbol.Contains(filterText)) return;
            if (assetData.Name.Contains(filterText)) return;

            E.Accepted = false;
        }
        #endregion

        public ICommand AssetDetailsCommand { get; set; }

        private void AssetDetails(object obj)
        {
            if (SelectedAsset != null)
                _action.Invoke("AD", SelectedAsset);
            else return;
        }

        public AssetsViewModel(ICoinCapService coinCapService, AssetsCollection assetsCollection, Action<string, AssetData> action)
        {
            AssetDetailsCommand = new LambdaCommand(AssetDetails);

            _action = action;
            _coinCapService = coinCapService;
            AssetsCol = assetsCollection;


            _AssetsCollection.Filter += OnAssetFiltered;
        }


    }
}
