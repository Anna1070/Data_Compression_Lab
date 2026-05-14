using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractal_image_coder
{
    internal class DomainBlock
    {
        public int x, y;
        public int[,] pixel8x8;
        public double sumD;
        public double sumD2;
    }
}
