using Laborator1_citire_scriere_biti;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractal_image_coder
{
    internal class StoreDecoded
    {
        private byte[] first1078BytesEncoded;
        private string decodedFilePath;
        int width, height;
        int[,] currentStep;

        public StoreDecoded(byte[] first1078BytesEncoded, string decodedFilePath, int[,] currentStep, int width, int height)
        {
            this.decodedFilePath = decodedFilePath;
            this.currentStep = currentStep;
            this.first1078BytesEncoded = first1078BytesEncoded;
            this.width = width;
            this.height = height;
        }

        public void StartStoring()
        {
            BitWriter bitWriter = new BitWriter(decodedFilePath);

            for (int i = 0; i < first1078BytesEncoded.Length; i++)
            {
                bitWriter.WriteNBits(first1078BytesEncoded[i], 8);
            }

            for (int j = height - 1; j >= 0; j--)
            {
                for (int i = 0; i < width; i++)
                {
                    int pixel = currentStep[i, j];
                    bitWriter.WriteNBits((uint)pixel, 8);
                }
            }

            bitWriter.Close();
        }
    }
}
