using System;
using System.Collections.Generic;
using System.Text;

namespace App01 {
    public class Counter : ICounter {
        private const int MAX_COUNT = 9999;
        private int iCount = 0;

        public int Count => iCount;

        public void Inc() {
            iCount++;
            if (iCount > MAX_COUNT) {
                iCount = 0;
            }
        }

        public void Reset() => iCount = 0;

    }
}
