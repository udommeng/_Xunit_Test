using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc01.Models {
    public class BitKubTicker {
        public THBBTC THB_BTC { get; set; }
    }

    public class THBBTC {
        public int id { get; set; }
        public int last { get; set; }
        public int lowestAsk { get; set; }
        public int highestBid { get; set; }
        public double percentChange { get; set; }
        public double baseVolume { get; set; }
        public double quoteVolume { get; set; }
        public int isFrozen { get; set; }
        public int high24hr { get; set; }
        public int low24hr { get; set; }
    }


}
