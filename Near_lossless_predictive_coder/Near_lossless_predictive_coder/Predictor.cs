using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Near_lossless_predictive_coder
{
    class Predictor
    {
        private int[,] errorPMatrix, errorPQMatrix, errorPDQMatrix, errorMatrix;
        private byte[,] predictionMatrix, predictionMatrix2, decodedImg;
        private int k;

        private Bitmap originalBitmap;
        private int width;
        private int height;
        private string imagePath;

        public Predictor(string imagePath, int width, int height, int k)
        {
            this.imagePath = imagePath;
            this.width = width;
            this.height = height;
            originalBitmap = new Bitmap(imagePath);
            this.k = k;

            predictionMatrix = new byte[width, height];
            predictionMatrix2 = new byte[width, height];
            decodedImg = new byte[width, height];
            errorPMatrix = new int[width, height];
            errorPQMatrix = new int[width, height];
            errorPDQMatrix = new int[width, height];
            errorMatrix = new int[width, height];
            
        }

        private void SetFirstLine()
        {
            predictionMatrix[0, 0] = 128;
            predictionMatrix2[0, 0] = 128;
            Console.WriteLine($"original: {0},{0}: {originalBitmap.GetPixel(0, 0).R}");
            Console.WriteLine("First line from original");
            for (int i = 1; i<width; i++)
            {
                Console.WriteLine($"original: {i},{0}: {originalBitmap.GetPixel(i, 0).R}");
            }
            errorPMatrix[0, 0] = originalBitmap.GetPixel(0, 0).R - predictionMatrix[0, 0];
            errorPQMatrix[0, 0] = (int)Math.Floor((double)(errorPMatrix[0, 0] + k) / (2 * k + 1));
            errorPDQMatrix[0, 0] = errorPQMatrix[0, 0] * (2 * k + 1);
            decodedImg[0, 0] = Limit(errorPDQMatrix[0, 0] + predictionMatrix2[0, 0]);

            Console.WriteLine($"decoded: {0},{0}: {decodedImg[0, 0]}");

            for (int i = 1; i < width; i++)
            {
                predictionMatrix[i, 0] = decodedImg[i-1, 0];
                errorPMatrix[i, 0] = originalBitmap.GetPixel(i, 0).R - predictionMatrix[i, 0];
                errorPQMatrix[i, 0] = (int)Math.Floor((double)(errorPMatrix[i, 0] + k) / (2 * k + 1));
                errorPDQMatrix[i, 0] = errorPQMatrix[i, 0] * (2 * k + 1);
                predictionMatrix2[i, 0] = decodedImg[i - 1, 0];
                decodedImg[i, 0] = Limit(errorPDQMatrix[i, 0] + predictionMatrix2[i, 0]);
            }
        }

        private void SetFirstColumn()
        {
            for (int j = 1; j < height; j++)
            {
                Console.WriteLine($"original: {0},{j}: {originalBitmap.GetPixel(0, j).R}");
            }

            for (int j = 1; j < height; j++)
            {
                predictionMatrix[0, j] = decodedImg[0, j - 1];
                errorPMatrix[0, j] = originalBitmap.GetPixel(0, j).R - predictionMatrix[0, j];
                errorPQMatrix[0, j] = (int)Math.Floor((double)(errorPMatrix[0, j] + k) / (2 * k + 1));
                errorPDQMatrix[0, j] = errorPQMatrix[0, j] * (2 * k + 1);
                predictionMatrix2[0, j] = decodedImg[0, j - 1];
                decodedImg[0, j] = Limit(errorPDQMatrix[0, j] + predictionMatrix2[0, j]);
            }
        }

        public void Predictor128()
        {
            //SetFirstLine();
            //SetFirstColumn();

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    predictionMatrix[i, j] = 128;
                    errorPMatrix[i, j] = originalBitmap.GetPixel(i, j).R - predictionMatrix[i, j];
                    errorPQMatrix[i, j] = (int)Math.Floor((double)(errorPMatrix[i, j] + k) / (2 * k + 1));
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = 128;
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }

            calculateErrorMatrixPredictor();
        }

        public void PredictorA()
        {
            SetFirstLine();
            SetFirstColumn();

            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    predictionMatrix[i, j] = decodedImg[i - 1, j];
                    errorPMatrix[i, j] = originalBitmap.GetPixel(i, j).R - predictionMatrix[i, j];
                    errorPQMatrix[i, j] = (int)Math.Floor((double)(errorPMatrix[i, j] + k) / (2 * k + 1));
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = decodedImg[i - 1, j];
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }

            calculateErrorMatrixPredictor();
        }

        public void PredictorB()
        {
            SetFirstLine();
            SetFirstColumn();

            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    predictionMatrix[i, j] = decodedImg[i, j - 1];
                    errorPMatrix[i, j] = originalBitmap.GetPixel(i, j).R - predictionMatrix[i, j];
                    errorPQMatrix[i, j] = (int)Math.Floor((double)(errorPMatrix[i, j] + k) / (2 * k + 1));
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = decodedImg[i, j - 1];
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }

            calculateErrorMatrixPredictor();
        }

        public void PredictorC()
        {
            SetFirstLine();
            SetFirstColumn();

            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    predictionMatrix[i, j] = decodedImg[i - 1, j - 1];
                    errorPMatrix[i, j] = originalBitmap.GetPixel(i, j).R - predictionMatrix[i, j];
                    errorPQMatrix[i, j] = (int)Math.Floor((double)(errorPMatrix[i, j] + k) / (2 * k + 1));
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = decodedImg[i - 1, j - 1];
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }

            calculateErrorMatrixPredictor();
        }

        public void Predictor5()
        {
            SetFirstLine();
            SetFirstColumn();
            byte a, b, c;

            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    a = decodedImg[i - 1, j];
                    b = decodedImg[i, j - 1];
                    c = decodedImg[i - 1, j - 1];
                    predictionMatrix[i, j] = Limit(a + b - c);
                    errorPMatrix[i, j] = originalBitmap.GetPixel(i, j).R - predictionMatrix[i, j];
                    errorPQMatrix[i, j] = (int)Math.Floor((double)(errorPMatrix[i, j] + k) / (2 * k + 1));
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = Limit(a + b - c); ;
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }

            calculateErrorMatrixPredictor();
        }

        public void Predictor6()
        {
            SetFirstLine();
            SetFirstColumn();
            byte a, b, c;

            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    a = decodedImg[i - 1, j];
                    b = decodedImg[i, j - 1];
                    c = decodedImg[i - 1, j - 1];
                    predictionMatrix[i, j] = Limit(a + (b - c) / 2);
                    errorPMatrix[i, j] = originalBitmap.GetPixel(i, j).R - predictionMatrix[i, j];
                    errorPQMatrix[i, j] = (int)Math.Floor((double)(errorPMatrix[i, j] + k) / (2 * k + 1));
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = Limit(a + (b - c) / 2);
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }

            calculateErrorMatrixPredictor();
        }

        public void Predictor7()
        {
            SetFirstLine();
            SetFirstColumn();
            byte a, b, c;

            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    a = decodedImg[i - 1, j];
                    b = decodedImg[i, j - 1];
                    c = decodedImg[i - 1, j - 1];
                    predictionMatrix[i, j] = Limit(b + (a - c) / 2); ;
                    errorPMatrix[i, j] = originalBitmap.GetPixel(i, j).R - predictionMatrix[i, j];
                    errorPQMatrix[i, j] = (int)Math.Floor((double)(errorPMatrix[i, j] + k) / (2 * k + 1));
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = Limit(b + (a - c) / 2); ;
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }

            calculateErrorMatrixPredictor();
        }


        public void Predictor8()
        {
            SetFirstLine();
            SetFirstColumn();
            byte a, b;

            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    a = decodedImg[i - 1, j];
                    b = decodedImg[i, j - 1];
                    predictionMatrix[i, j] = Limit((a + b) / 2);
                    errorPMatrix[i, j] = originalBitmap.GetPixel(i, j).R - predictionMatrix[i, j];
                    errorPQMatrix[i, j] = (int)Math.Floor((double)(errorPMatrix[i, j] + k) / (2 * k + 1));
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = Limit((a + b) / 2);
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }

            calculateErrorMatrixPredictor();
        }

        public void Predictor9()
        {
            SetFirstLine();
            SetFirstColumn();
            byte a, b, c;

            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    a = decodedImg[i - 1, j];
                    b = decodedImg[i, j - 1];
                    c = decodedImg[i - 1, j - 1];
                    if (c >= Math.Max(a, b))
                    {
                        predictionMatrix[i, j] = (byte)Math.Min(a, b);
                        predictionMatrix2[i, j] = (byte)Math.Min(a, b);
                    }
                    else if (c <= Math.Min(a, b))
                    {
                        predictionMatrix[i, j] = (byte)Math.Max(a, b);
                        predictionMatrix2[i, j] = (byte)Math.Max(a, b);
                    }
                    else
                    {
                        predictionMatrix[i, j] = Limit(a + b - c);
                        predictionMatrix2[i, j] = Limit(a + b - c);
                    }
                    errorPMatrix[i, j] = originalBitmap.GetPixel(i, j).R - predictionMatrix[i, j];
                    errorPQMatrix[i, j] = (int)Math.Floor((double)(errorPMatrix[i, j] + k) / (2 * k + 1));
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }

            calculateErrorMatrixPredictor();
        }

        protected void calculateErrorMatrixPredictor()
        {
            Console.WriteLine("Error Matrix");
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    errorMatrix[i, j] = (int)(originalBitmap.GetPixel(i, j).R - decodedImg[i, j]);
                    Console.Write($"{i}, {j}: {errorMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private byte Limit(int value)
        {
            if (value > 255) 
                return 255;
            if (value < 0) 
                return 0;

            return (byte)value;
        }

        public int[,] GetPredictionErrorMatrix()
        {
            return errorPMatrix;
        }

        public int[,] GetQuantizedPredictionErrorMatrix()
        {
            return errorPQMatrix;
        }

        public byte[,] GetDecodedPredictorImage()
        {
            return decodedImg;
        }
    }
}
