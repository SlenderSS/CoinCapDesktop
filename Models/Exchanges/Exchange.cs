using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCapDesktop.Models.Exchanges
{
    internal class Exchange : ViewModels.Base.ViewModel
    {
        [JsonProperty("data")]
        public ExchangeData Data { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
