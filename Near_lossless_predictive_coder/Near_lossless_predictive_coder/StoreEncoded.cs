using Laborator1_citire_scriere_biti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public StoreEncoded(int width, int height, int predictorOption, byte[] first1078Bytes, int k, string encodedFilePath, string saveMode, int[,] quantizedErrorMatrix)
        {
            this.width = width;
            this.height = height;
            this.predictorOption = predictorOption;
            this.first1078Bytes = first1078Bytes;
            this.k = k;
            this.encodedFilePath = encodedFilePath;
            this.saveMode = saveMode;
            this.quantizedErrorMatrix = quantizedErrorMatrix;
        }

        public void StartStoringFixed()
        {
            BitWriter bitWriter= new BitWriter(encodedFilePath);

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
        }
    } 
}
