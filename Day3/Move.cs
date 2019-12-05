using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    class Move
    {
        public int  x1, y1, x2, y2, trashx, trashy;
        char direction;

        public int X1 { get { return x1; } }
        public int Y1 { get { return y1; } }
        public int X2 { get { return x2; } }
        public int Y2 { get { return y2; } }

        public char Direction { get { return direction; } }

        public Move(int x1, int y1, int x2, int y2, char direction)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.direction = direction;
        }

        public Move(int x1, int y1, int x2, int y2, char direction, int trashx1, int trashx2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.direction = direction;
            this.trashx = trashx1;
            this.trashy = trashx2;
        }
    }
}
