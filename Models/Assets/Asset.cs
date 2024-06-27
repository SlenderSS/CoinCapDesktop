using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCapDesktop.Models.Assets
{
    internal class Asset : ViewModels.Base.ViewModel
    {
        [JsonProperty("data")]
        public AssetData Data { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
