using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace CoinCapDesktop.Models.Assets
{
    internal class AssetHistoryCollection : ViewModels.Base.ViewModel
    {
        [JsonProperty("data")]
        public ObservableCollection<AssetHistoryData> Data { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
