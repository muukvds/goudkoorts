using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class MapView
    {
        public void Repaint(Road[,] field, int score, Char ship)
        {
            Console.Clear();
            printMap(field,score,ship);

        }
        public void printMap(Road[,] field, int score, Char ship)
        {
            Console.WriteLine("██████████"+ship+"███        Score: "+score);
            for (int j = 0; j < 9; j++)
            {
                Console.Write("█");
                for (int i = 0; i < 12; i++) { 
                    Console.Write(checkChar(field[i,j])); 
                }
                Console.Write("█");
                Console.WriteLine("");
            }
            Console.WriteLine("██████████████");
        }

        private Char checkChar(Road r)
        {
            if (r == null)
                return '█';
            if (r.cart != null)
            {
                if (r.cart.loaded)
                    return 'ø';
                return 'o';
            }
            if (r is Switch)
            {
                Switch s = (Switch)r;
                if (s.up)
                    return '/';
                return '\\';
            }
            if (r is Yard)
                return '|';
            return ' ';
        }
    }

    
}
