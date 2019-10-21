using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    public class Cart
    {
        public Road location { get; private set; }
        public bool loaded { get; private set; }
        public bool crashed { get; private set; }

        public Cart(Road location)
        {
            this.location = location;
            loaded = true;
            crashed = false;
        }

        public void Move()
        {
            if (location is End)
            {
                End e = (End)location;
                e.delete();
            }
            if (CheckNext())
            {
                location.cart = null;
                location = location.next;
                location.cart = this;
            }
            if(location.ship!= null)
            {
                Empty();
                location.ship.Load();
            }
        }

        public bool CheckNext()
        {
          
            if (location.next == null)
            {
                return false;
            }
            if (location.next.cart != null)
            {
                if (!(location is Yard))
                {
                    crashed = true;
                }
                return false;
            }
            return true;
        }


        public void Empty()
        {
            loaded = false;
        }
    }
}
