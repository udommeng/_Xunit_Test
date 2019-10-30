using Mvc01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc01.Services {
    public interface IPriceFeeder {
        Price GetCurrentPrice();
        
    }
}
