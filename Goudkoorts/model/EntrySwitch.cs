using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
  
        public class EntrySwitch : Switch
        {
            public Road previousA { set; private get; }
            public Road previousB { set; private get; }
            public Road previousCurrent { set; private get; }
            public override void Shift()
            {
                if (previousCurrent == previousA)
                {
                    previousA.next = null;
                    previousB.next = this;
                previousCurrent = previousB;
                }
                else
                {
                    previousB.next = null;
                    previousA.next = this;
                previousCurrent = previousA;
            }
            up = !up;

           
        }
        }
    }

