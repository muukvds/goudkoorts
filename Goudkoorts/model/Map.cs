using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{

    public class Map
    {
        public Road[,] field;
        public Road startA { get; set; }
        public Road startB { get; set; }
        public Road startC { get; set; }
        public Switch[] switches;
        public Road quay { get; set; }
        public List<Cart> carts { get; private set; }

        public Map(Road[,] field, Road startA, Road startB, Road startC, Switch[] switches, Road quay)
        {
            this.quay = quay;
            this.field = field;
            this.startA = startA;
            this.startB = startB;
            this.startC = startC;
            this.switches = switches;
            carts = new List<Cart>();
        }

        public void addCart(int start)
        {
            Cart cart = new Cart(startA);
            switch (start)
            {
                case 0:
                    startA.cart = cart;
                    break;
                case 1:
                    cart = new Cart(startB);
                    startB.cart = cart;
                    break;
                case 2:
                    cart = new Cart(startC);
                    startC.cart = cart;
                    break;
            }
            carts.Add(cart);
        }

    }
}
