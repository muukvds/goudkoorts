using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class SwitchManager
    {
        Map map;
        public SwitchManager(Map map)
        {
            this.map = map;
        }


        public int ReadInput()
        {
            Char input = Console.ReadKey().KeyChar;
            if (char.IsNumber(input))
            {
                return input - 48;
            }
            return 0;
        }

        public bool DoSwitch()
        {
                int input = ReadInput();
                if (input > 0 && input < 6)
                {
                    map.switches[input - 1].Shift();

                }
                return (input > 0 && input < 6);
        }



    }
}
