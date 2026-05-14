using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractal_image_coder
{
    internal class FractalCoder
    {
        Bitmap origImg;
        int width, height;
        int[,] origImgInt;

        List<DomainBlock> domainBlocks = new List<DomainBlock>();
        List<RangeBlock> rangeBlocks = new List<RangeBlock>();
        List<RangeParameters> rangeParameters = new List<RangeParameters>();

        public FractalCoder(Bitmap origImg, int width, int height)
        {
            this.origImg = origImg;
            this.width = width;
            this.height = height;

            origImgInt = new int[width, height];
        }

        public async Task StartCoding(IProgress<int> progress)
        {
            await Task.Run(() =>
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        origImgInt[x, y] = (int)origImg.GetPixel(x, y).R;
                    }
                }
            });

            InitializationPhase();
            await Task.Run(() => SearchPhase(progress));
        }

        private void InitializationPhase()
        {
            for (int y = 0;y < height; y = y + 8)
            { 
                for (int x = 0;x < width; x = x + 8)
                {
                    RangeBlock rangeBlock = new RangeBlock();
                    rangeBlock.x = x;
                    rangeBlock.y = y;
                    rangeBlock.pixel8x8 = new int[8, 8];
                    rangeBlock.sumR = 0;
                    rangeBlock.sumR2 = 0;

                    for (int j=0; j < 8; j++)
                    {
                        for (int i=0; i<8; i++)
                        {
                            int pixel = origImgInt[x + i, y + j];
                            rangeBlock.pixel8x8[i, j] = pixel;
                            rangeBlock.sumR = rangeBlock.sumR + pixel;
                            rangeBlock.sumR2 = rangeBlock.sumR2 + (double)(pixel*pixel);
                        }
                    }

                    rangeBlocks.Add(rangeBlock);
                }
            }

            for (int y = 0; y < height; y= y + 16)
            {
                for (int x = 0; x < width; x = x + 16)
                {
                    DomainBlock domainBlock = new DomainBlock();
                    domainBlock.x = x;
                    domainBlock.y = y;
                    domainBlock.pixel8x8 = new int[8, 8];
                    domainBlock.sumD = 0;
                    domainBlock.sumD2 = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            int p1 = origImgInt[x + i * 2, y + j * 2];
                            int p2 = origImgInt[x + i * 2 + 1, y + j * 2];
                            int p3 = origImgInt[x + i * 2, y + j * 2 + 1];
                            int p4 = origImgInt[x + i * 2 + 1, y + j * 2 + 1];
                            int medie = (p1 + p2 + p3 + p4) / 4;

                            domainBlock.pixel8x8[i, j] = medie;
                            domainBlock.sumD += medie;
                            domainBlock.sumD2 += (double)medie * medie;
                        }
                    }

                    domainBlocks.Add(domainBlock);
                }
            }
        }

        private void SearchPhase(IProgress<int> progress)
        {
            int n = 64;
            int totalRanges = rangeBlocks.Count;
            int currentRange = 0;

            foreach (var R in rangeBlocks)
            {
                double minErr = int.MaxValue;
                RangeParameters bestPar = null;

                foreach (var D in domainBlocks)
                {
                    for (int izo = 0; izo < 8; izo++)
                    {
                        double sumRD = 0;
                        for (int j=0; j<8; j++)
                        {
                            for (int i=0; i<8; i++)
                            {
                                sumRD = sumRD + R.pixel8x8[i, j] * GetIzometricPixel(D.pixel8x8, i, j, izo);
                            }
                        }

                        double s = 0, o = 0;
                        s = (n * sumRD - R.sumR * D.sumD) / (n * D.sumD2 - D.sumD * D.sumD);
                        o = (1.0 / n) * (R.sumR - s * D.sumD);

                        int sQ = (int)Math.Round(((s - (-1.2)) / 2.4) * 31);
                        int oQ = (int)Math.Round((o / 255) * 127);

                        sQ = Math.Max(0, Math.Min(31, sQ));
                        oQ = Math.Max(0, Math.Min(127, oQ));

                        double err = 1.0 / n * (R.sumR2 + s * (s * D.sumD2 - 2 * sumRD + o * 2 * D.sumD) + o * (o * n - 2 * R.sumR));
                        if (err < minErr)
                        {
                            minErr = err;
                            bestPar = new RangeParameters
                            {
                                rx = R.x, ry = R.y,
                                dx = D.x, dy = D.y,
                                izo = izo,
                                sQ = sQ,
                                oQ = oQ
                            };
                            
                        }
                    }
                }
                if (bestPar != null)
                {
                    Console.WriteLine($"range {R.x}, {R.y}: domain {bestPar.dx}, {bestPar.dy}, izo {bestPar.izo}");
                    rangeParameters.Add(bestPar);
                }
                currentRange++;
                progress.Report(currentRange);
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

        public List<RangeParameters> GetRangeParameters()
        {
            return rangeParameters;
        }

        public int[,] GetConvertedImage()
        {
            return origImgInt;
        }
    }
}
