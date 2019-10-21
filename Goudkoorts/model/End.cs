using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class End : Road
    {
        public void delete()
        {
            this.cart = null;
        }
    }
}