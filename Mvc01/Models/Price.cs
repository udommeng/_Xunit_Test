using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc01.Models {
    public class Price {

        public Price(double last = 0) {
            //Date = DateTime.Now;
            Last = last;
        }

        public DateTime Date { get; set; } = DateTime.Now;
        public double Last { get; set; }

    }
}
