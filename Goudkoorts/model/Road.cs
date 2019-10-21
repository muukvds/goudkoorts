using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    public class Road
    {

        public Road next { get; set; }
        public Cart cart { get; set; }

        public Ship ship;

    }
}
