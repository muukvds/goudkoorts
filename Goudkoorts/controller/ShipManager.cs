using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class ShipManager
    {
        public int shipCounter { get; private set; }
        Map map;
        Ship currentShip;
        public char shipState { get; private set; }
        public ShipManager(Map map)
        {
            this.map = map;
            shipCounter = 0;
            currentShip = map.quay.ship;
            shipState = 'S';
        }

        public void UpdateShipState()
        {
            currentShip = map.quay.ship;
            if (currentShip != null)
            {
                if (currentShip.full)
                {
                    currentShip = null;
                    shipCounter = 5;
                    shipState = ' ';
                }
            }
            else
            {
                shipCounter--;
                if (shipCounter == 0)
                {
                    Ship ship = new Ship(10);
                    currentShip = ship;
                    shipState = 'S';
                }
                
            }
            map.quay.ship = currentShip;
        }
        
    }
}