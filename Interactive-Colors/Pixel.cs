using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Colors
{
    class Pixel
    {
        public int R = 0, G = 0, B = 0;
        public int x, y;
        public bool Activated = true;
        public Pixel(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
