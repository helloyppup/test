using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SuperSnake
{
    internal class Map:IDraw
    {
        public Wall[] walls;
        public int index;

        public Map() 
        { 
           walls = new Wall[Game.w+(Game.h-3)*2];
            index = 0;
           // 横着的墙
           for(int i = 0; i < Game.w; i+=2)
            {
                walls[index] = new Wall(i, 0);
                index++;
                walls[index]=new Wall(i, Game.h-2);
                index++;
            }

           //竖着的墙
           for(int i = 1;i<Game.h-2;i++)
            {
                walls[index]= new Wall(0,i);
                index++;
                walls[index] = new Wall(Game.w - 2, i);
                index++;
            }
        }

        public void Draw()
        {
            for(int i=0;i<index;i++)
            {
                walls[i].Draw();
            }
        }
    }
}
