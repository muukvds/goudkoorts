using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
         //   game.paintThread.Start();
            game.switchThread.Start();
            game.step.Start();
        }
    }
}
