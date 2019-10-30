using Mvc01.Models;
using Mvc01.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mvc01.Tests {
    class FakePriceFeeder : IPriceFeeder {
        private double[] _prices;
        private int n = 0;

        public FakePriceFeeder(params double[] prices) {
            _prices = prices;
        }

        public Price GetCurrentPrice() {
            if (n >= _prices.Length) return null;

            return new Price {
                Date = DateTime.Now,
                Last = _prices[n++]
            };
        }
    }
}
