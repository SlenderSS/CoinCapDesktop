using Newtonsoft.Json;

namespace CoinCapDesktop.Models.Assets
{
    internal class AssetHistoryData : ViewModels.Base.ViewModel
    {
        [JsonProperty("priceUsd")]
        public double? PriceUsd { get; set; }

        [JsonProperty("time")]
        public long? Time { get; set; }

    }
}
