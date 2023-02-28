using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSnake.Class
{
    enum E_BodyType
    {
        Head,
        Body,
    }

    internal class SnakeBody:GameObject
    {
        public E_BodyType type;
        
        public SnakeBody(E_BodyType type,Pos pos)
        {
            this.type = type;
            this.pos = pos;
        }

        public SnakeBody(E_BodyType type,int x,int y)
        {
            this.type = type;
            pos.y = y;
            pos.x = x;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch(type)
            {
                case E_BodyType.Head:
                    Console.Write("●");
                    break;
                case E_BodyType.Body:
                    Console.Write("◎");
                    break;
            }
        }
    }
}
