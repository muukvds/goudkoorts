using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class MessageView
    {

        public void ControlMessage()
        {
            Console.WriteLine("Controleer waar de karretjes heen gaan door de schakels om ze zetten");
            Console.WriteLine("Zet de schakels om met de knoppen 1-5 (van links naar rechts en van boven naar beneden)");
        }
        public void CrashMessage()
        {
            Console.Clear();
            Console.WriteLine("Je karretjes zijn gecrashed");
            Console.WriteLine("Game Over");
        }

        public void ShipMessage(int counter)
        {
            if(counter!=0)
                Console.WriteLine("Het schip is vol, er is een nieuw schip in: " + counter);
        }
    }
}
