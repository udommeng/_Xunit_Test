using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mvc01.Models;
using RestSharp;

namespace Mvc01.Services {
    public class BitkubPriceFeeder : IPriceFeeder {

        // HttpClient
        // RastShrtp

        public Price GetCurrentPrice() {
            var c = new RestClient("https://api.bitkub.com");
            var req = new RestRequest("api/market/ticker", Method.GET);
            req.AddQueryParameter("sym", "THB_BTC");

            var res = c.Execute<BitKubTicker>(req);

            return new Price {
                Date = DateTime.Now,
                Last = res.Data.THB_BTC.last
            };
        }
    }
}
