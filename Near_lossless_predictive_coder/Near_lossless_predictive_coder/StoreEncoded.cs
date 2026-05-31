using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Near_lossless_predictive_coder
{
    internal class StoreEncoded
    {
        int width, height;
        int predictorOption;
        byte[] first1078Bytes;
        int k;
        string encodedFilePath;
        string saveMode;
        int[,] quantizedErrorMatrix;

        public StoreEncoded(int width, int height, int predictorOption, byte[] first1078Bytes, int k, string encodedFilePath, int[,] quantizedErrorMatrix)
        {
            this.width = width;
            this.height = height;
            this.predictorOption = predictorOption;
            this.first1078Bytes = first1078Bytes;
            this.k = k;
            this.encodedFilePath = encodedFilePath;
            this.quantizedErrorMatrix = quantizedErrorMatrix;
        }

        private void StoreHeaderPredictorK(BitWriter bitWriter)
        {
            Console.WriteLine("/////////////////////// First 1078 bytes ////////////////////////////////////////");
            for (int i = 0; i < first1078Bytes.Length; i++)
            {
                byte currentByte = first1078Bytes[i];
                bitWriter.WriteNBits(currentByte, 8);
            }

            Console.WriteLine("/////////////////////// Predictor Used ////////////////////////////////////////");
            bitWriter.WriteNBits((uint)predictorOption, 4);

            Console.WriteLine("/////////////////////// k value ////////////////////////////////////////");
            bitWriter.WriteNBits((uint)k, 4);
        }

        public void StartStoringFixed()
        {
            BitWriter bitWriter= new BitWriter(encodedFilePath);

            StoreHeaderPredictorK(bitWriter);

            Console.WriteLine("/////////////////////// Save Mode ////////////////////////////////////////");
            bitWriter.WriteNBits((uint)0, 2);
                
            Console.WriteLine("/////////////////////// Quantized Matrix ////////////////////////////////////////");
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int value = quantizedErrorMatrix[i, j];
                    uint newValue = (uint)value + 255;

                    bitWriter.WriteNBits(newValue, 9);
                }
            }

            bitWriter.Close();
            MessageBox.Show("Finished storing");
        }

        public void StartStoringTable()
        {
            BitWriter bitWriter = new BitWriter(encodedFilePath);

            StoreHeaderPredictorK(bitWriter);

            Console.WriteLine("/////////////////////// Save Mode ////////////////////////////////////////");
            bitWriter.WriteNBits((uint)1, 2);

            Console.WriteLine("/////////////////////// Quantized Matrix ////////////////////////////////////////");
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int value = quantizedErrorMatrix[i, j];

                    if(value == 0)
                    {
                        bitWriter.WriteNBits(0, 1);
                    }
                    else
                    {
                        int L = (int)Math.Floor(Math.Log(Math.Abs(value), 2)) + 1;
                        uint unaryCode = (uint)(((1 << L) - 1) << 1);
                        int unaryLength = L + 1;

                        bitWriter.WriteNBits(unaryCode, unaryLength);

                        int index;
                        if (value > 0)
                        {
                            index = value;
                        }
                        else
                        {
                            index = value - 1 + (1 << L);
                        }

                        bitWriter.WriteNBits((uint)index, L);
                    }  
                }
            }

            bitWriter.Close();
            MessageBox.Show("Finished storing");
        }

        public void StartStoringArithmetic()
        {
            BitWriter bitWriter = new BitWriter(encodedFilePath);

            StoreHeaderPredictorK(bitWriter);

            Console.WriteLine("/////////////////////// Save Mode ////////////////////////////////////////");
            bitWriter.WriteNBits((uint)2, 2);

            Console.WriteLine("/////////////////////// Quantized Matrix ////////////////////////////////////////");
            ArithmeticCoder coder = new ArithmeticCoder();
            coder.InitializeDynamicModel();

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int val = quantizedErrorMatrix[i, j];

                    int symbol = val + 255;

                    coder.EncodeSymbol(symbol, bitWriter);
                }
            }

            coder.EncodeSymbol(ArithmeticCoder.eofIndex, bitWriter);
            coder.DoneEncoding(bitWriter);

            bitWriter.Close();
            MessageBox.Show("Finished storing");
        }
    } 
}
