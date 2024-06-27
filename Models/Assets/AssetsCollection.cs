using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace CoinCapDesktop.Models.Assets
{
    internal class AssetsCollection : ViewModels.Base.ViewModel
    {
        [JsonProperty("data")]
        public ObservableCollection<AssetData> Data { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

    }
}
