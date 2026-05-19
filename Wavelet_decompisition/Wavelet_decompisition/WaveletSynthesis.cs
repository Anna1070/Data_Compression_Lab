using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wavelet_decompisition
{
    internal class WaveletSynthesis
    {
        int width, height;
        double[,] currentImageD;
        double[,] waveletImageD;

        double[] synthesisL = {0.000000000000, -0.091271763114, -0.057543526229, 0.591271763114, 1.115087052457, 0.591271763114,
                                -0.057543526229, -0.091271763114, 0.000000000000};

        double[] synthesisH = {0.026748757411, 0.016864118443, -0.078223266529, -0.266864118443, 0.602949018236, -0.266864118443,
                                 -0.078223266529, 0.016864118443, 0.026748757411};

        public WaveletSynthesis(double[,] waveletImageD, int width, int height)
        {
            this.waveletImageD = waveletImageD;
            this.width = width;
            this.height = height;

            currentImageD = new double[width, height];
            Array.Copy(waveletImageD, currentImageD, currentImageD.Length);
        }

        public void SynthesisH1()
        {
            double[,] temp = new double[width, height];

            for (int j = 0; j < height; j++)
            {
                double[] currentLine = new double[width];
                for (int i = 0; i < width; i++)
                {
                    currentLine[i] = waveletImageD[i, j];
                }

                double[] procesedLine = SynthesisH(currentLine, width);

                for (int i = 0; i < width; i++)
                {
                    temp[i, j] = procesedLine[i];
                }
            }

            currentImageD = temp;
        }
        public void SynthesisV1()
        {
            double[,] temp = new double[width, height];
            for (int i = 0; i < width; i++)
            {
                double[] currentColumn = new double[height];
                for (int j = 0; j < height; j++)
                {
                    currentColumn[j] = waveletImageD[i, j];
                }

                double[] processedColumn = SynthesisV(currentColumn, height);

                for (int j = 0; j < height; j++)
                {
                    temp[i, j] = processedColumn[j];
                }
            }

            currentImageD = temp;
        }

        public double[] SynthesisH(double[] line, int width)
        {
            int halfW = width / 2;

            double[] upsampledL = new double[width];
            double[] upsampledH = new double[width];

            for (int i = 0; i < halfW; i++)
            {
                upsampledL[i * 2] = line[i];
                upsampledL[i * 2 + 1] = 0;

                upsampledH[i * 2] = 0;
                upsampledH[i * 2 + 1] = line[halfW + i];
            }

            double[] extendedL = new double[width + 8];
            for (int i = 0; i < width; i++)
            {
                extendedL[i + 4] = upsampledL[i];
            }

            extendedL[3] = upsampledL[1];
            extendedL[2] = upsampledL[2];
            extendedL[1] = upsampledL[3];
            extendedL[0] = upsampledL[4];

            extendedL[width + 4] = upsampledL[width - 2];
            extendedL[width + 4 + 1] = upsampledL[width - 3];
            extendedL[width + 4 + 2] = upsampledL[width - 4];
            extendedL[width + 4 + 3] = upsampledL[width - 5];

            double[] extendedH = new double[width + 8];
            for (int i = 0; i < width; i++)
            {
                extendedH[i + 4] = upsampledH[i];
            }
            extendedH[3] = upsampledH[1];
            extendedH[2] = upsampledH[2];
            extendedH[1] = upsampledH[3];
            extendedH[0] = upsampledH[4];

            extendedH[width + 4] = upsampledH[width - 2];
            extendedH[width + 4 + 1] = upsampledH[width - 3];
            extendedH[width + 4 + 2] = upsampledH[width - 4];
            extendedH[width + 4 + 3] = upsampledH[width - 5];

            double[] output = new double[width];
            for (int i = 0; i < width; i++)
            {
                int currentPoz = i + 4;
                double resultL = 0;
                double resultH = 0;

                for (int k = 0; k < 9; k++)
                {
                    int f = k - 4;
                    resultL += synthesisL[k] * extendedL[currentPoz + f];
                    resultH += synthesisH[k] * extendedH[currentPoz + f];
                }

                output[i] = resultL + resultH;
            }

            return output;
        }

        public double[] SynthesisV(double[] column, int height)
        {
            int halfH = height / 2;

            double[] upsampledL = new double[height];
            double[] upsampledH = new double[height];

            for (int j = 0; j < halfH; j++)
            {
                upsampledL[j * 2] = column[j];
                upsampledL[j * 2 + 1] = 0;

                upsampledH[j * 2] = 0;
                upsampledH[j * 2 + 1] = column[halfH + j];
            }

            double[] extendedL = new double[height + 8];
            for (int j = 0; j < height; j++)
            {
                extendedL[j + 4] = upsampledL[j];
            }

            extendedL[3] = upsampledL[1]; 
            extendedL[2] = upsampledL[2];
            extendedL[1] = upsampledL[3];
            extendedL[0] = upsampledL[4];

            extendedL[height + 4] = upsampledL[height - 2];
            extendedL[height + 4 + 1] = upsampledL[height - 3];
            extendedL[height + 4 + 2] = upsampledL[height - 4]; 
            extendedL[height + 4 + 3] = upsampledL[height - 5];

            double[] extendedH = new double[height + 8];
            for (int j = 0; j < height; j++)
            {
                extendedH[j + 4] = upsampledH[j];
            }
            extendedH[3] = upsampledH[1]; 
            extendedH[2] = upsampledH[2];
            extendedH[1] = upsampledH[3]; 
            extendedH[0] = upsampledH[4];

            extendedH[height + 4] = upsampledH[height - 2]; 
            extendedH[height + 4 + 1] = upsampledH[height - 3];
            extendedH[height + 4 + 2] = upsampledH[height - 4]; 
            extendedH[height + 4 + 3] = upsampledH[height - 5];

            double[] output = new double[height];
            for (int j = 0; j < height; j++)
            {
                int currentPoz = j + 4;
                double resultL = 0;
                double resultH = 0;

                for (int k = 0; k < 9; k++)
                {
                    int f = k - 4;
                    resultL += synthesisL[k] * extendedL[currentPoz + f];
                    resultH += synthesisH[k] * extendedH[currentPoz + f];
                }

                output[j] = resultL + resultH;
            }

            return output;
        }

        public void SynthesisH2()
        {
            double[,] temp = new double[width, height];
            Array.Copy(currentImageD, temp, currentImageD.Length);

            for (int j = 0; j < height / 2; j++)
            {
                double[] currentLine = new double[width / 2];
                for (int i = 0; i < width / 2; i++)
                {
                    currentLine[i] = currentImageD[i, j];
                }

                double[] procesedLine = SynthesisH(currentLine, width / 2);

                for (int i = 0; i < width / 2; i++)
                {
                    temp[i, j] = procesedLine[i];
                }
            }

            currentImageD = temp;
        }

        public void SynthesisV2()
        {
            double[,] temp = new double[width, height];
            Array.Copy(currentImageD, temp, currentImageD.Length);

            for (int i = 0; i < width / 2; i++)
            {
                double[] currentColumn = new double[height / 2];
                for (int j = 0; j < height / 2; j++)
                {
                    currentColumn[j] = currentImageD[i, j];
                }

                double[] processedColumn = SynthesisV(currentColumn, height / 2);

                for (int j = 0; j < height / 2; j++)
                {
                    temp[i, j] = processedColumn[j];
                }
            }

            currentImageD = temp;
        }

        public void SynthesisFromALevel(int startLevel)
        {
            int currentW = width / (int)Math.Pow(2, startLevel - 1);
            int currentH = height / (int)Math.Pow(2, startLevel - 1);
            for (int level = startLevel; level >= 1; level--)
            {
                double[,] temp = new double[width, height];
                Array.Copy(currentImageD, temp, currentImageD.Length);

                for (int i = 0; i < currentW; i++)
                {
                    double[] currentColumn = new double[currentH];
                    for (int j = 0; j < currentH; j++)
                    {
                        currentColumn[j] = currentImageD[i, j];
                    }

                    double[] processedColumn = SynthesisV(currentColumn, currentH);

                    for (int j = 0; j < currentH; j++)
                    {
                        temp[i, j] = processedColumn[j];
                    }
                }

                Array.Copy(temp, currentImageD, temp.Length);

                for (int j = 0; j < currentH; j++)
                {
                    double[] currentLine = new double[currentW];
                    for (int i = 0; i < currentW; i++)
                    {
                        currentLine[i] = currentImageD[i, j];
                    }

                    double[] processedLine = SynthesisH(currentLine, currentW);

                    for (int i = 0; i < currentW; i++)
                    {
                        temp[i, j] = processedLine[i];
                    }
                }

                Array.Copy(temp, currentImageD, temp.Length);
                currentW *= 2;
                currentH *= 2;
            }
        }

        public double[,] GetCurrentImageD()
        {
            return currentImageD;
        }
    }
}
