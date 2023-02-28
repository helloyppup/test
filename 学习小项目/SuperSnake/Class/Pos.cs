using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSnake
{
    internal struct Pos
    {
        public int x;
        public int y;

        public Pos(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Pos a, Pos b)
        {
            if(a.x == b.x && a.y == b.y)
                return true;
            return false;
        }
        public static bool operator !=(Pos a, Pos b)
        {
            if (a.x != b.x && a.y != b.y)
                return true;
            return false;
        }
    }
}
