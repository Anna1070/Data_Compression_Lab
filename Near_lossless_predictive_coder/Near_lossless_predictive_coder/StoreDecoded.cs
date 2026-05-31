using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Near_lossless_predictive_coder
{
    internal class StoreDecoded
    {
        private byte[] first1078BytesEncoded;
        private string decodedFilePath;
        int width, height;
        Bitmap decodedMatrix;

        public StoreDecoded(byte[] first1078BytesEncoded, string decodedFilePath, Bitmap decodedMatrix, int width, int height)
        {
            this.decodedFilePath = decodedFilePath;
            this.decodedMatrix = decodedMatrix;
            this.first1078BytesEncoded = first1078BytesEncoded;
            this.width = width;
            this.height = height;
        }

        public void startStoring()
        {
            BitWriter bitWriter = new BitWriter(decodedFilePath);

            for (int i = 0; i < first1078BytesEncoded.Length; i++)
            {
                bitWriter.WriteNBits(first1078BytesEncoded[i], 8);
            }

            for (int j = height-1; j >= 0; j--)
            {
                for (int i = 0; i < width; i++)
                {
                    byte value = decodedMatrix.GetPixel(i, j).R;
                    bitWriter.WriteNBits(value, 8);
                }
            }

            bitWriter.Close();
            MessageBox.Show("Finished storing");
        }
    }
}
