using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSnake.Class
{
    internal class Food : GameObject
    {
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("▼");
        }
        public Food(Snake sanke)
        {
            ChangePos(sanke);
        }
       
        public void ChangePos(Snake snake)
        {
            Random r=new Random();
            int x = r.Next(1, (Game.w / 2 - 1) )*2;
            int y = r.Next(1, Game.h - 3);
            pos=new Pos(x,y);

            //判断不能和蛇重合
            //防止在食物内部对蛇进行遍历 直接在蛇内部封装一个方法
            if(snake.IsOverlap(pos))
            {
                ChangePos(snake);
            }
        }
    }
}
