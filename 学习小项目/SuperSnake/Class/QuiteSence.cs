using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSnake.Class
{
    internal class QuiteSence : BeginOrQuiteSence
    {

        public QuiteSence() {
            gameTitle = "游戏结束";
            title1 = "重新开始";
            title2 = "退出游戏";
        }
        public override void EnterSpacebar()
        {

            if (nowIndex == 0)
            {
                Game.ChangeSence(E_SenceType.Begin);
            }
            else
                Environment.Exit(0);
        }
    }
}
