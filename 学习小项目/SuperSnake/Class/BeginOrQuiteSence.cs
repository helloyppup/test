using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSnake
{
    internal abstract class BeginOrQuiteSence : ISenceUpdate
    {
        protected  string gameTitle;
        protected string title1;
        protected string title2;
        protected int nowIndex;

        public abstract void EnterSpacebar();
        
        public void Update()
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Game.w / 2 - gameTitle.Length, 4);
            Console.Write(gameTitle);

            Console.ForegroundColor = nowIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.SetCursorPosition(Game.w / 2 - title1.Length, 4 + 2);
            Console.Write(title1);

            Console.ForegroundColor = nowIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.SetCursorPosition(Game.w / 2 - title2.Length, 4 + 3);
            Console.Write(title2);


            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    nowIndex--;
                    if(nowIndex < 0)
                    {
                        nowIndex = 0;
                    }
                    break;
                case ConsoleKey.S:
                    nowIndex++;
                    if (nowIndex > 1)
                        nowIndex = 1;
                    break;
                case ConsoleKey.Spacebar:
                    EnterSpacebar();
                    break;
            }

        }
    }
}
