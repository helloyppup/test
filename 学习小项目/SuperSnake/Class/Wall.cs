using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSnake
{
    internal class Wall : GameObject
    {
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("■");
        }
        public Wall(Pos pos)
        {
            this.pos=pos;
        }

        public Wall(int x,int y)
        {
            pos.x = x;
            pos.y = y;
        }
    }
}
