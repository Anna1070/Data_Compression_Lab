using Laborator1_citire_scriere_biti;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private Bitmap initialImage;
        private int[,] initialImageInt;
        private int[,] currentStep;

        List<RangeParameters> rangeParameters = new List<RangeParameters>();

        public FractalDecoder(Bitmap initialImage, int width, int height, string encodedFilePath, int numberOfSteps)
        {
            this.initialImage = initialImage;
            this.width = width;
            this.height = height;
            this.encodedFilePath = encodedFilePath;
            this.numberOfSteps = numberOfSteps;

            initialImageInt = new int[width, height];
        }

        public void StartDecoding()
        {
            BitReader bitReader = new BitReader(encodedFilePath);
            for (int i = 0; i < 1078; i++)
            {
                bitReader.ReadNBits(8);
            }

            for (int j=0; j < height; j = j + 8)
            {
                for (int i=0; i<width; i = i + 8)
                {
                    RangeParameters rP = new RangeParameters();
                    rP.rx = i; 
                    rP.ry = j;

                    rP.dx = (int)bitReader.ReadNBits(6) * 8;
                    rP.dy = (int)bitReader.ReadNBits(6) * 8;

                    rP.izo = (int)bitReader.ReadNBits(3);
                    rP.sQ = (int)bitReader.ReadNBits(5);
                    rP.oQ = (int)bitReader.ReadNBits(7);

                    rangeParameters.Add(rP);
                }
            }

            ApplyNumberOfSteps(numberOfSteps);

            bitReader.Close();
        }

        private void ApplyNumberOfSteps(int numberOfSteps)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    initialImageInt[x, y] = (int)initialImage.GetPixel(x, y).R;
                }
            }
            currentStep = initialImageInt;

            for (int step = 0; step < numberOfSteps; step++)
            {
                int[,] nextStep = new int[width, height];

                foreach (var range in rangeParameters)
                {
                    int[,] domain = new int[16, 16];
                    for (int j = 0; j < 16; j++)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            domain[i, j] = currentStep[range.dx + i, range.dy + j];
                        }
                    }

                    int[,] domain8x8 = new int[8, 8];
                    for (int j = 0; j < 8; j++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            int p1 = domain[i * 2, j * 2];
                            int p2 = domain[i * 2 + 1, j * 2];
                            int p3 = domain[i * 2, j * 2 + 1];
                            int p4 = domain[i * 2 + 1, j * 2 + 1];
                            int medie = (p1 + p2 + p3 + p4) / 4;

                            domain8x8[i,j] = medie;     
                        }
                    }

                    double s = (range.sQ / 31.0) * 2.4 - 1.2;
                    double o = (range.oQ / 127.0) * 255.0;

                    for (int j=0; j < 8; j++)
                    {
                        for (int i = 0;i < 8; i++)
                        {
                            int pixel = GetIzometricPixel(domain8x8, i, j, range.izo);

                            int finalPixel = (int)(s * pixel + o);

                            if (finalPixel < 0) 
                                finalPixel = 0;
                            if (finalPixel > 255) 
                                finalPixel = 255;

                            nextStep[range.rx + i, range.ry + j] = finalPixel;
                        }
                    }
                }
                currentStep = nextStep;
            }
        }

        private int GetIzometricPixel(int[,] block, int x, int y, int izo, int B = 8)
        {
            switch (izo)
            {
                case 0: return block[x, y];
                case 1: return block[B - 1 - x, y];
                case 2: return block[x, B - 1 - y];
                case 3: return block[B - 1 - y, B - 1 - x];
                case 4: return block[y, x];
                case 5: return block[y, B - 1 - x];
                case 6: return block[B - 1 - x, B - 1 - y];
                case 7: return block[B - 1 - y, x];
                default: return block[x, y];
            }
        }

        public int[,] GetCurrentStep()
        {
            return currentStep;
        }
    }
}
