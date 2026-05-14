using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractal_image_coder
{
    internal class RangeBlock
    {
        public int x, y;
        public int[,] pixel8x8;
        public double sumR;
        public double sumR2;
    }
}
