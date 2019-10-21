using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    public class ExitSwitch : Switch
    {
        public Road nextA { private get; set; }
        public Road nextB { private get; set; }
        public override void Shift()
        {
            if (next == nextA)
                next = nextB;
            else next = nextA;
            up = !up;
        }
    }
}
