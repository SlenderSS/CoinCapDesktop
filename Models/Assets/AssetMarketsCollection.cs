using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace CoinCapDesktop.Models.Assets
{
    internal class AssetMarketsCollection : ObservableCollection<AssetMarketsCollection>
    {
        [JsonProperty("data")]
        public ObservableCollection<AssetMarketData> Data { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
