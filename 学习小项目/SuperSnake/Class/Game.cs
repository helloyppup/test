using SuperSnake.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSnake
{
    enum E_SenceType
    {
        Begin,
        Game,
        Quite,
    }
    internal class Game
    {
       public const int w = 80;
        public const int h = 20;
        public static ISenceUpdate nowSence;

        public Game()
        {
            
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);
            Console.CursorVisible = false;

            ChangeSence(E_SenceType.Begin);
        }

        public void Start()
        {
           while (true)
            {
                if(nowSence!=null)
                {
                    nowSence.Update();
                }
                
            }
        }

        public static void ChangeSence(E_SenceType type)
        {
            Console.Clear();

            switch (type)
            {
                case E_SenceType.Begin:
                    nowSence = new BeginSence();
                    break;
                case E_SenceType.Game:
                    nowSence = new GameSence();
                    break;
                case E_SenceType.Quite:
                    nowSence = new QuiteSence();
                    break;
            }
        }
       
    }
}
