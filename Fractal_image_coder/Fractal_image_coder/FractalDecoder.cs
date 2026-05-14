using Laborator1_citire_scriere_biti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractal_image_coder
{
    internal class FractalDecoder
    {
        private int width;
        private int height;
        private string encodedFilePath;
        private int numberOfSteps;

        //list of range parameters

        public FractalDecoder(int width, int height, string encodedFilePath, int numberOfSteps)
        {
            this.width = width;
            this.height = height;
            this.encodedFilePath = encodedFilePath;
            this.numberOfSteps = numberOfSteps;
        }

        public void StartDecoding()
        {
            BitReader bitReader = new BitReader(encodedFilePath);
            for (int i = 0; i < 1078; i++)
            {
                bitReader.ReadNBits(8);
            }

            //start reading the parameters

            bitReader.Close();
        }
    }
}
