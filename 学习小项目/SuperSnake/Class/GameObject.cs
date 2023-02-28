using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSnake
{
    internal abstract class GameObject:IDraw
    {
        public Pos pos;
        public abstract void Draw();

    }
}
