using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace CoinCapDesktop.Models.Exchanges
{
    internal class ExchangeCollection : ViewModels.Base.ViewModel
    {
        [JsonProperty("data")]
        public ObservableCollection<ExchangeData> Data { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
