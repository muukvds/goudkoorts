using System.Threading;


namespace Goudkoorts
{
    public class Game

    {
        private Map map;
        private int speed;
        private int score;
        private CartManager cartManager;
        private SwitchManager switchManager;
        private ShipManager shipManager;
        private MessageView messageView;
        private MapView mapView;
        public Thread step;
        public Thread switchThread;
        bool go;
        public Game()
        {
            go = true;
            MapSetup mapSetup = new MapSetup();
            mapView = new MapView();
            map = mapSetup.map;
            score = 0;
            speed = 1;
            messageView = new MessageView();
            shipManager = new ShipManager(map);
            switchManager = new SwitchManager(map);
            cartManager = new CartManager(map);
            step = new Thread(PerformStep);
            switchThread = new Thread(Switch);
        }

        public void Stop()
        {
            go = false;
            messageView.CrashMessage();
        }

        public void Repaint()
        {
            mapView.Repaint(map.field, score, shipManager.shipState);
            messageView.ShipMessage(shipManager.shipCounter);
            messageView.ControlMessage();
        }

        public void Switch()
        {
            while (go)
            {
                if (switchManager.DoSwitch())
                    Repaint();
                Thread.Sleep(50);
            }
        }
        public void cartStep()
        {
            cartManager.PerformStep(speed);
            if (cartManager.stop)
                Stop();
            if (cartManager.scoreUp)
                score++;
        }
       
        public void PerformStep()
        {
            while (go)
            {
                shipManager.UpdateShipState();
                cartStep();
                speed = score / 10 + 1;
                Repaint();
                Thread.Sleep(500/speed);
            }
        }
    }
}
