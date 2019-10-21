using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    public class Switch : Road
    {
        public bool up { get; protected set; }
        public virtual void Shift()
        {

        }
    }
}
