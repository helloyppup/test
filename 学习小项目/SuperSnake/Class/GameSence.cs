using SuperSnake.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperSnake
{
    internal class GameSence : ISenceUpdate
    {
        public Map map;
        public Snake snake;
        protected int frameIndex;
        public Food food;

        public GameSence()
        {
            frameIndex = 1;
            snake = new Snake();
            map=new Map();
            food = new Food(snake);
        }
        public void Update()
        {
            //画地图
            map.Draw();
            
            if (frameIndex%12==0)
            {
                //画食物
                food.Draw();

                //画蛇
                snake.Move();
                snake.Draw();

                if(snake.IsDead(map))
                {
                    Game.ChangeSence(E_SenceType.Quite);
                }

                if(snake.Eat(food))
                {
                    food.ChangePos(snake);
                }

                frameIndex = 0;

            }
            frameIndex++;

            //判断转向
            if(Console.KeyAvailable)
            {
                switch(Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        snake.ChangeDir(E_Dir.Up);
                        break;
                    case ConsoleKey.S:
                        snake.ChangeDir(E_Dir.Down);
                            break;
                    case ConsoleKey.A:
                        snake.ChangeDir(E_Dir.Left);
                        break;
                    case ConsoleKey.D:
                        snake.ChangeDir(E_Dir.Right);
                        break;
                }
            }
           

        }
    }
}
