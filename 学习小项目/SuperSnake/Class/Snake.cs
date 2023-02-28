using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperSnake.Class
{
   enum E_Dir
    {
        Up,
        Down,
        Right,
        Left,
    }
    internal class Snake:IDraw
    {
        public SnakeBody[] bodys;
        public int snakeLen;
        public E_Dir dir;
        public Snake()
        {
            bodys = new SnakeBody[200];
            bodys[0] = new SnakeBody(E_BodyType.Head, Game.w / 2, Game.h / 2);
            snakeLen++;
            dir = E_Dir.Left;
        }

        public void Draw()
        {
            for(int i=0;i<snakeLen;i++)
            {
                bodys[i].Draw();
            }
        }

        public void Move()
        {
            //擦屁股
            Console.SetCursorPosition(bodys[snakeLen-1].pos.x, bodys[snakeLen-1].pos.y);
            Console.Write("  ");

            //每一个身体从最后一个往前顶
            for(int i=snakeLen-1;i>0;i--)
            {
                bodys[i].pos = bodys[i - 1].pos;
            }

            switch(dir) { 
                case E_Dir.Left:
                    bodys[0].pos.x-=2;
                    break;
                case E_Dir.Right:
                    bodys[0].pos.x+=2;
                    break;
                case E_Dir.Up:
                    bodys[0].pos.y--;
                    break;
                case E_Dir.Down:
                    bodys[0].pos.y++;
                    break;
            }
        }

        public void ChangeDir(E_Dir dir)
        {
            if (dir == this.dir ||
                snakeLen != 1 && (this.dir == E_Dir.Left && dir == E_Dir.Right ||
                                this.dir == E_Dir.Right && dir == E_Dir.Left ||
                                this.dir == E_Dir.Up && dir == E_Dir.Down ||
                                this.dir == E_Dir.Down && dir == E_Dir.Up))
                return;
            else
                this.dir = dir;
        }
        
        public bool IsOverlap(Pos pos)
        {
            for(int i = 0; i < snakeLen; i++)
            {
                if (bodys[i].pos==pos)
                    return true;
            }
            return false;
        }

        public bool IsDead(Map map)
        {
            //遍历是否撞墙
            for(int i = 0;i < map.walls.Length;i++)
            {
                if (bodys[0].pos == map.walls[i].pos)
                    return true;
            }

            for(int i = 1; i<snakeLen; i++)
            {
                if (bodys[0].pos == bodys[i].pos)
                    return true;
            }

            return false;

        }

        public bool Eat(Food food)
        {
            if (bodys[0].pos == food.pos)
            {
                Grow();
                return true;    
            }
            return false;
        }

        private void Grow()
        {
            //当前最后一个位置增加一个身体
            bodys[snakeLen] = new SnakeBody(E_BodyType.Body, bodys[snakeLen - 1].pos);
            snakeLen++;
        }
    }
}
