using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wavelet_decompisition
{
    internal class WaveletCoder
    {
        int width, height;
        double[,] originalImageD;
        double[,] currentImageD;

        double[] analysisL = {0.026748757411, -0.016864118443, -0.078223266529, 0.266864118443, 0.602949018236, 0.266864118443,
                              -0.078223266529, -0.016864118443, 0.026748757411};

        double[] analysisH = {0.000000000000, 0.091271763114, -0.057543526229, -0.591271763114, 1.115087052457, -0.591271763114,
                                -0.057543526229, 0.091271763114, 0.000000000000};

        public WaveletCoder(double[,] originalImageD, int width, int height)
        {
            this.originalImageD = originalImageD;
            this.width = width;
            this.height = height;

            currentImageD = new double[width, height];
            Array.Copy(originalImageD, currentImageD, originalImageD.Length);
        }

        public void AnalysisH1()
        {
            double[,] temp = new double[width, height];

            for (int j=0; j<height; j++)
            {
                double[] currentLine = new double[width];
                for (int i=0; i<width; i++)
                {
                    currentLine[i] = currentImageD[i, j];
                }

                double[] procesedLine = AnalysisH(currentLine, width);

                for (int i=0; i < width; i++)
                {
                    temp[i,j] = procesedLine[i];
                }
            }

            currentImageD = temp;
        }

        public void AnalysisV1()
        {
            double[,] temp = new double[width, height];

            for (int i = 0; i < width; i++)
            {
                double[] currentColumn = new double[height];
                for (int j = 0; j < height; j++)
                {
                    currentColumn[j] = currentImageD[i, j];
                }

                double[] processedColumn = AnalysisV(currentColumn, height);

                for (int j = 0; j < height; j++)
                {
                    temp[i, j] = processedColumn[j];
                }
            }

            currentImageD = temp;
        }

        private double[] AnalysisH(double[] line, int width)
        {
            double[] extendedLine = new double[width + 8];

            for (int i=0; i<width;i++)
            {
                extendedLine[i + 4] = line[i];
            }

            extendedLine[3] = line[1];
            extendedLine[2] = line[2];
            extendedLine[1] = line[3];
            extendedLine[0] = line[4];

            extendedLine[width + 4] = line[width - 2];
            extendedLine[width + 4 + 1] = line[width - 3];
            extendedLine[width + 4 + 2] = line[width - 4];
            extendedLine[width + 4 + 3] = line[width - 5];

            double[] columnL = new double[width];
            double[] columnH = new double[width];
            for (int i=0; i<width; i++)
            {
                int currentPoz = i + 4;

                double resultL = 0;
                double resultH = 0;

                for (int k = 0; k < 9; k++)
                {
                    int f = k - 4;

                    resultL = resultL + analysisL[k] * extendedLine[currentPoz + f];
                    resultH = resultH + analysisH[k] * extendedLine[currentPoz + f];
                }

                columnL[i] = resultL;
                columnH[i] = resultH;
            }

            double[] rearrangedLine = new double[width];
            for (int i=0; i < width / 2; i++)
            {
                int even = i * 2;
                rearrangedLine[i] = columnL[even];

                int odd = i * 2 + 1;
                rearrangedLine[width/2 + i] = columnH[odd];
            }

            return rearrangedLine;
        }

        private double[] AnalysisV(double[] column, int height)
        {
            double[] extendedColumn = new double[height + 8];

            for (int j = 0; j < height; j++)
            {
                extendedColumn[j + 4] = column[j];
            }

            extendedColumn[3] = column[1];
            extendedColumn[2] = column[2];
            extendedColumn[1] = column[3];
            extendedColumn[0] = column[4];

            extendedColumn[height + 4] = column[height - 2];
            extendedColumn[height + 4 + 1] = column[height - 3];
            extendedColumn[height + 4 + 2] = column[height - 4];
            extendedColumn[height + 4 + 3] = column[height - 5];

            double[] lineL = new double[height];
            double[] lineH = new double[height];
            for (int j = 0; j < height; j++)
            {
                int currentPoz = j + 4;

                double resultL = 0;
                double resultH = 0;

                for (int k = 0; k < 9; k++)
                {
                    int f = k - 4;

                    resultL = resultL + analysisL[k] * extendedColumn[currentPoz + f];
                    resultH = resultH + analysisH[k] * extendedColumn[currentPoz + f];
                }

                lineL[j] = resultL;
                lineH[j] = resultH;
            }

            double[] rearrangedColumn = new double[height];
            for (int j = 0; j < height / 2; j++)
            {
                int even = j * 2;
                rearrangedColumn[j] = lineL[even];

                int odd = j * 2 + 1;
                rearrangedColumn[height / 2 + j] = lineH[odd];
            }

            return rearrangedColumn;
        }

        public void AnalysisH2()
        {
            double[,] temp = new double[width, height];
            Array.Copy(currentImageD, temp, currentImageD.Length);

            for (int j = 0; j < height/2; j++)
            {
                double[] currentLine = new double[width/2];
                for (int i = 0; i < width/2; i++)
                {
                    currentLine[i] = currentImageD[i, j];
                }

                double[] procesedLine = AnalysisH(currentLine, width/2);

                for (int i = 0; i < width / 2; i++)
                {
                    temp[i, j] = procesedLine[i];
                }
            }

            currentImageD = temp;
        }

        public void AnalysisV2()
        {
            double[,] temp = new double[width, height];
            Array.Copy(currentImageD, temp, currentImageD.Length);

            for (int i = 0; i < width /2; i++)
            {
                double[] currentColumn = new double[height/2];
                for (int j = 0; j < height/2; j++)
                {
                    currentColumn[j] = currentImageD[i, j];
                }

                double[] processedColumn = AnalysisV(currentColumn, height/2);

                for (int j = 0; j < height/2; j++)
                {
                    temp[i, j] = processedColumn[j];
                }
            }

            currentImageD = temp;
        }

        public void AnalyzeToALevel(int level)
        {
            Array.Copy(originalImageD, currentImageD, originalImageD.Length);

            int currentW = width;
            int currentH = height;

            for (int l=1; l<=level; l++)
            {
                double[,] temp = new double[width, height];
                Array.Copy(currentImageD, temp, currentImageD.Length);

                for (int j = 0; j < currentH; j++)
                {
                    double[] currentLine = new double[currentW];
                    for (int i = 0; i < currentW; i++)
                    {
                        currentLine[i] = currentImageD[i, j];
                    }

                    double[] processedLine = AnalysisH(currentLine, currentW);

                    for (int i = 0; i < currentW; i++)
                    {
                        temp[i, j] = processedLine[i];
                    }
                }

                Array.Copy(temp, currentImageD, temp.Length);

                for (int i = 0; i < currentW; i++)
                {
                    double[] currentColumn = new double[currentH];
                    for (int j = 0; j < currentH; j++)
                    {
                        currentColumn[j] = currentImageD[i, j];
                    }

                    double[] processedColumn = AnalysisV(currentColumn, currentH);

                    for (int j = 0; j < currentH; j++)
                    {
                        temp[i, j] = processedColumn[j];
                    }
                }

                Array.Copy(temp, currentImageD, temp.Length);
                currentW = currentW / 2;
                currentH = currentH / 2;
            }
        }

        public double[,] GetCurrentImageD()
        {
            return currentImageD;
        }
    }
}
