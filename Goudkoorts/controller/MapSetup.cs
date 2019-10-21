using System;

namespace Goudkoorts
{
    class MapSetup
    {
        public Road[,] field;
        public Road startA { get; set; }
        public Road startB { get; set; }
        public Road startC { get; set; }
        public Switch[] switches;
        public Map map { private set; get; }
        public MapSetup()
        {
            field = new Road[12, 10];
            Road quay = null;
            switches = new Switch[5];
            String path = ("..\\Resources\\Map.txt");
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            String line;
            int y = 0;
            while ((line = file.ReadLine()) != null)
            {
                int switchCounter = 0;
                int x = 0;
                foreach (char c in line)
                {
                    switch (c)
                    {
                        case 'x':
                            field[x, y] = new Road();
                            break;
                        case ' ':
                            break;
                        case 'a':
                            startA = new Road();
                            field[x, y] = startA;
                            break;
                        case 'b':
                            startB = new Road();
                            field[x, y] = startB;
                            break;
                        case 'c':
                            startC = new Road();
                            field[x, y] = startC;
                            break;
                        case 'k':
                            field[x, y] = new Road();
                            quay = field[x, y];
                            Ship ship = new Ship(10);
                            field[x, y].ship = ship;
                            break;
                        case '<':
                            field[x, y] = new ExitSwitch();
                            switches[switchCounter] = (Switch)field[x, y];
                            switchCounter++;
                            break;
                        case '>':
                            field[x, y] = new EntrySwitch();
                            switches[switchCounter] = (Switch)field[x, y];
                            switchCounter++;
                            break;
                        case 'y':
                            field[x, y] = new Yard();
                            break;
                    }
                    x++;
                }
                y++;
            }
            setSwitches();
            setNext();

            map = new Map(field, startA, startB, startC, switches, quay);
        }


        private void setNext()
        {
            String path = ("..\\Resources\\Directions.txt");
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            String line;
            int y = 0;
            while ((line = file.ReadLine()) != null)
            {
                int x = 0;
                foreach (char c in line)
                {
                    Road f = null;
                    bool change = false;
                    switch (c)
                    {
                        case 'l':
                            f = field[x - 1, y];
                            change = true;
                            break;
                        case 'b':
                            f = field[x, y - 1];
                            change = true;
                            break;
                        case 'o':
                            f = field[x, y + 1];
                            change = true;
                            break;
                        case 'r':
                            f = field[x + 1, y];
                            change = true;
                            break;
                    }
                    if (change)
                        field[x, y].next = f;
                    x++;
                }
                y++;
            }
        }

        private void setSwitches()
        {
            End e = new End();
            field[0, 0] = e;
            field[1, 0].next = e;

            EntrySwitch s = (EntrySwitch)field[3, 3];
            s.previousA = field[3, 2];
            s.previousB = field[3, 4];
            s.previousCurrent = field[3, 2];

            ExitSwitch s2 = (ExitSwitch)field[5, 3];
            s2.nextA = field[5, 4];
            s2.nextB = field[5, 2];

            EntrySwitch s3 = (EntrySwitch)field[9, 3];
            s3.previousA = field[9, 2];
            s3.previousB = field[9, 4];
            s3.previousCurrent = field[9, 2];

            EntrySwitch s4 = (EntrySwitch)field[6, 5];
            s4.previousA = field[6, 4];
            s4.previousB = field[6, 6];
            s4.previousCurrent = field[6, 4];

            ExitSwitch s5 = (ExitSwitch)field[8, 5];
            s5.nextA = field[8, 6];
            s5.nextB = field[8, 4];
            s5.next = field[8, 6];

            switches[0] = s;
            switches[1] = s2;
            switches[2] = s3;
            switches[3] = s4;
            switches[4] = s5;


        }
    }
}
