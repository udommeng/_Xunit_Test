using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Mvc01.Models;

namespace Mvc01.Services {
    public class CsvPriceFeeder : IPriceFeeder, IDisposable {
        private StreamReader _reader;

        public CsvPriceFeeder(IHostingEnvironment env) {
            var filePath = Path.Combine(env.ContentRootPath, "Files", "S50.csv");
            _reader = new StreamReader(filePath);
        }

        public void Dispose() => _reader?.Dispose();

        public Price GetCurrentPrice() {
            var line = _reader.ReadLine();
            if (line == null) return null;

            var data = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            if (data.Length >= 2) {
                return new Price {
                    Date = DateTime.Parse(data[0]),
                    Last = double.Parse(data[1])
                };
            }

            return null;
        }
    }
}
