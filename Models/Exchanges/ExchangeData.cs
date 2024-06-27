using Newtonsoft.Json;

namespace CoinCapDesktop.Models.Exchanges
{
    internal class ExchangeData : ViewModels.Base.ViewModel
    {

        [JsonProperty("exchangeId")]
        public string ExchangeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("percentTotalVolume")]
        public double? PercentTotalVolume { get; set; }


        [JsonProperty("volumeUsd")]
        public double? VolumeUsd { get; set; }


        [JsonProperty("tradingPairs")]
        public int TradingPairs { get; set; }


        [JsonProperty("socket")]
        public bool? Socket { get; set; }


        [JsonProperty("exchangeUrl")]
        public string ExchangeUrl { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }
    }
}
