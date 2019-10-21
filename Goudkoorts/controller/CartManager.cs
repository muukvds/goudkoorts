using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    public class CartManager
    {
        Map map;
        public bool stop { get; private set; }
        private int counter;
        private int start;
        public bool scoreUp { get; private set; }
        public CartManager(Map map)
        {
            this.map = map;
            stop = false;
            counter = 0;
            start = 0;
        }

        public void CreateCart(int start)
        {
            map.addCart(start);
        }

        public void MoveCarts()
        {
            foreach (Cart c in map.carts)
            {
                c.Move();
                if (c.crashed)
                {
                    stop = true;
                }
                if (c.location.ship != null)
                    scoreUp = true;
            }
        }

        public void PerformStep(int speed)
        {
            scoreUp = false;
            if (counter <= 0)
            {
                CreateCart(start);
                start++;
                if (start > 2)
                    start = 0;
                counter = 10;
            }
            MoveCarts();
            counter = counter - speed;
            
        }
    }
}
