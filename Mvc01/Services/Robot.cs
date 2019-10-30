using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc01.Models;

namespace Mvc01.Services {
    public class Robot {
        private readonly IPriceFeeder feeder;


        public double MinPrice { get; set; } = double.MaxValue;

        public Robot(IPriceFeeder feeder) {
            this.feeder = feeder;
        }

        public async Task<string> RunSimulation() {
            var sb = new StringBuilder();

            for (int i = 0; i < 1000; i++) {
                var p = feeder.GetCurrentPrice();

                string order = Run(p);
                if (order != null) {
                    sb.AppendLine(order);
                }

                //await Task.Delay(100);
            }

            return sb.ToString();
        }

        private double lastOrderPrice = 0;
        private string direction = "unknown";

        public string Run(Price p) {

            if (p.Last < 0) {
                var m = $"Invalid price: {p.Last}";
                throw new ArgumentOutOfRangeException(m);
            }

            if (lastOrderPrice == 0) lastOrderPrice = p.Last;

            if (direction != "up" && lastOrderPrice - p.Last >= 3.0) {
                direction = "down";
                lastOrderPrice = p.Last;
                return $"SF @{p.Last} x 1";
            }
            if (direction != "down" && p.Last - lastOrderPrice >= 3.0) {
                direction = "up";
                lastOrderPrice = p.Last;
                return $"LF @{p.Last} x 1";
            }

            if (direction != "up" && p.Last - lastOrderPrice >= 5.0) {
                direction = "up";
                lastOrderPrice = p.Last;
                return $"LF @{p.Last} x 1";
            }
            if (direction != "down" && lastOrderPrice - p.Last >= 5.0) {
                direction = "down";
                lastOrderPrice = p.Last;
                return $"SF @{p.Last} x 1";
            }

            return null;
        }

        public string Run() {
            var p = feeder.GetCurrentPrice();
            return Run(p);
        }
    }

}
