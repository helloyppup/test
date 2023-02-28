using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSnake
{
    internal class BeginSence : BeginOrQuiteSence
    {

        public BeginSence() {
            gameTitle = "超级贪吃蛇";
            title1 = "开始游戏";
            title2 = "退出游戏";
        }
        public override void EnterSpacebar()
        {
            if (nowIndex == 0)
            {
                Game.ChangeSence(E_SenceType.Game);
            }
            else
                Environment.Exit(0);
        }
    }
}
