using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace CoinCapDesktop.Models.Markets
{
    internal class MarketsCollection : ViewModels.Base.ViewModel
    {
        [JsonProperty("data")]
        public ObservableCollection<MarketData> Data { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
