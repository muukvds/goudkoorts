using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    public class Ship
    {
        public bool full { get; private set; }
        public int load { get; private set; }
        private int capacity;
        public Ship(int capacity)
        {
            load = 0;
            this.capacity = capacity;
            full = false;
        }

        public void Load()
        {
            load++;
            if (load == capacity)
            {
                full = true;
            }
        }
    }
}
