using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Near_lossless_predictive_coder
{
    internal class Decoder
    {
        private int[,] errorPQMatrix, errorPDQMatrix;
        private byte[,] predictionMatrix2, decodedImg;
        private int k;
        private int width;
        private int height;
        private string encodedFilePath;
        private int predictorOption, saveMode;

        public Decoder(string encodedFilePath, int width, int height)
        {
            this.encodedFilePath = encodedFilePath;
            this.width = width;
            this.height = height;

            predictionMatrix2 = new byte[width, height];
            decodedImg = new byte[width, height];
            errorPQMatrix = new int[width, height];
            errorPDQMatrix = new int[width, height];
        }

        public void StartDecoding()
        {
            BitReader bitReader = new BitReader(encodedFilePath);
            for (int i = 0; i < 1078; i++)
            {
                bitReader.ReadNBits(8);
            }

            predictorOption = (int)bitReader.ReadNBits(4);
            Console.WriteLine($"Predictorul {predictorOption}");

            k = (int)bitReader.ReadNBits(4);
            Console.WriteLine($"k : {k}");

            saveMode = (int)bitReader.ReadNBits(2);
            Console.WriteLine($"saveMode: {saveMode}");

            if(saveMode == 0)
            {
                Console.WriteLine("Fixed Save Mode");
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        uint current9Bits = bitReader.ReadNBits(9);
                        int value = (int)(current9Bits - 255);
                        errorPQMatrix[i, j] = value;
                    }
                }
                ReconstructImage();
            }
            else if(saveMode == 1)
            {
                Console.WriteLine("Table Save Mode");
                DecodeTableMode(bitReader);
            }
            else if(saveMode == 2)
            {
                Console.WriteLine("Arithmetic Save Mode");
                DecodeArithmeticMode(bitReader);
            }

            bitReader.Close();
        }

        private void ReconstructImage()
        {
            if (predictorOption!= 1)
            {
                DecodeFirstLine();
                DecodeFirstColumn();
            }
            switch (predictorOption)
            {
                case 1:
                    DecodePredictionOption1();
                    break;

                case 2:
                    DecodePredictionOption2();
                    break;

                case 3:
                    DecodePredictionOption3();
                    break;

                case 4:
                    DecodePredictionOption4();
                    break;

                case 5:
                    DecodePredictionOption5();
                    break;

                case 6:
                    DecodePredictionOption6();
                    break;

                case 7:
                    DecodePredictionOption7();
                    break;

                case 8:
                    DecodePredictionOption8();
                    break;

                case 9:
                    DecodePredictionOption9();
                    break;
            }
        }

        private void DecodeFirstLine()
        {
            predictionMatrix2[0, 0] = 128;
            errorPDQMatrix[0, 0] = errorPQMatrix[0, 0] * (2 * k + 1);
            decodedImg[0, 0] = Limit(errorPDQMatrix[0, 0] + predictionMatrix2[0, 0]);

            Console.WriteLine($"decoded: {0},{0}: {decodedImg[0, 0]}");
            for (int i = 1; i < width; i++)
            {
                errorPDQMatrix[i, 0] = errorPQMatrix[i, 0] * (2 * k + 1);
                predictionMatrix2[i, 0] = decodedImg[i - 1, 0];
                decodedImg[i, 0] = Limit(errorPDQMatrix[i, 0] + predictionMatrix2[i, 0]);
                Console.WriteLine($"decoded: {i},{0}: {decodedImg[i, 0]} ");
            }
        }

        private void DecodeFirstColumn()
        {
            for (int j = 1; j < height; j++)
            {
                errorPDQMatrix[0, j] = errorPQMatrix[0, j] * (2 * k + 1);
                predictionMatrix2[0, j] = decodedImg[0, j - 1];
                decodedImg[0, j] = Limit(errorPDQMatrix[0, j] + predictionMatrix2[0, j]);
                Console.WriteLine($"decoded: {0},{j}: {decodedImg[0, j]} ");
            }
        }

        private void DecodePredictionOption1()
        {
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = 128;
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                    Console.Write($"{i}, {j}: {decodedImg[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public void DecodePredictionOption2()
        {
            Console.WriteLine("Decoded:");
            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = decodedImg[i - 1, j];
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                    Console.Write($"{i}, {j}: {decodedImg[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void DecodePredictionOption3()
        {
            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = decodedImg[i, j - 1];
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }
        }

        public void DecodePredictionOption4()
        {
            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = decodedImg[i - 1, j - 1];
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }
        }

        public void DecodePredictionOption5()
        {
            byte a, b, c;
            Console.WriteLine("Decoded:");
            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    a = decodedImg[i - 1, j];
                    b = decodedImg[i, j - 1];
                    c = decodedImg[i - 1, j - 1];
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = Limit(a + b - c); ;
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                    Console.Write($"{i}, {j}: {decodedImg[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void DecodePredictionOption6()
        {
            byte a, b, c;

            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    a = decodedImg[i - 1, j];
                    b = decodedImg[i, j - 1];
                    c = decodedImg[i - 1, j - 1];
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = Limit(a + (b - c) / 2);
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }
        }

        public void DecodePredictionOption7()
        {
            byte a, b, c;

            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    a = decodedImg[i - 1, j];
                    b = decodedImg[i, j - 1];
                    c = decodedImg[i - 1, j - 1];
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = Limit(b + (a - c) / 2); ;
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }
        }


        public void DecodePredictionOption8()
        {
            byte a, b;

            for (int j = 1; j < height; j++)
            {
                for (int i = 1; i < width; i++)
                {
                    a = decodedImg[i - 1, j];
                    b = decodedImg[i, j - 1];
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    predictionMatrix2[i, j] = Limit((a + b) / 2);
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }
        }

        public void DecodePredictionOption9()
        {
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
                        predictionMatrix2[i, j] = (byte)Math.Min(a, b);
                    }
                    else if (c <= Math.Min(a, b))
                    {
                        predictionMatrix2[i, j] = (byte)Math.Max(a, b);
                    }
                    else
                    {
                        predictionMatrix2[i, j] = Limit(a + b - c);
                    }
                    errorPDQMatrix[i, j] = errorPQMatrix[i, j] * (2 * k + 1);
                    decodedImg[i, j] = Limit(errorPDQMatrix[i, j] + predictionMatrix2[i, j]);
                }
            }
        }

        private void DecodeTableMode(BitReader bitReader)
        {
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int L = 0;
                    while (bitReader.ReadNBits(1) == 1)
                    {
                        L++;
                    }

                    int value = 0;
                    if (L > 0)
                    {
                        uint index = bitReader.ReadNBits(L);
                        int halfPoint = 1 << (L - 1);

                        if (index >= halfPoint)
                        {
                            value = (int)index;
                        }
                        else
                        {
                            value = (int)index + 1 - (1 << L);
                        }
                    }

                    errorPQMatrix[i, j] = value;
                }
            }

            ReconstructImage();
        }

        private void DecodeArithmeticMode(BitReader bitReader)
        {
            ArithmeticDecoder decoder = new ArithmeticDecoder();
            decoder.InitializeDecoder(bitReader);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int symbol = decoder.DecodeSymbol(bitReader);

                    if (symbol == ArithmeticDecoder.eofIndex)
                    {
                        break;
                    }

                    int originalValue = symbol - 255;
                    errorPQMatrix[i, j] = originalValue;
                }
            }

            ReconstructImage();
        }

        public byte[,] GetDecodedImageDecoder()
        {
            return decodedImg;
        }

        public int[,] GetPQMatrixDecoder()
        {
            return errorPQMatrix;
        }

        public int[,] GetPDQMatrixDecoder()
        {
            return errorPDQMatrix;
        }

        private byte Limit(int value)
        {
            if (value > 255)
                return 255;
            if (value < 0)
                return 0;

            return (byte)value;
        }
    }
}
