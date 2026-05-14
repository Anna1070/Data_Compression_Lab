using Laborator1_citire_scriere_biti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractal_image_coder
{
    internal class StoreEncoded
    {
        string encodedFilePath;
        byte[] first1078Bytes;
        List<RangeParameters> rangesParameters = new List<RangeParameters>();

        public StoreEncoded(string encodedFilePath, byte[] first1078Bytes, List<RangeParameters> rangesParameters)
        {
            this.encodedFilePath = encodedFilePath;
            this.first1078Bytes = first1078Bytes;
            this.rangesParameters = rangesParameters;
        }

        public void StartStoring()
        {
            BitWriter bitWriter = new BitWriter(encodedFilePath);

            Console.WriteLine("/////////////////////// First 1078 bytes ////////////////////////////////////////");
            for (int i = 0; i < first1078Bytes.Length; i++)
            {
                byte currentByte = first1078Bytes[i];
                bitWriter.WriteNBits(currentByte, 8);
            }

            Console.WriteLine("/////////////////////// Range Parameters ////////////////////////////////////////");
            foreach (var  range in rangesParameters)
            {
                bitWriter.WriteNBits((uint)range.dx / 8, 6);
                bitWriter.WriteNBits((uint)range.dy / 8, 6);
                bitWriter.WriteNBits((uint)range.izo, 3);
                bitWriter.WriteNBits((uint)range.sQ, 5);
                bitWriter.WriteNBits((uint)range.oQ, 7);

                Console.WriteLine($"value: dx:{range.dx/8}, dy:{range.dy/8}, izo:{range.izo}, sQ: {range.sQ}, oQ: {range.oQ}");
            }

            MessageBox.Show("Storing was successful");
            bitWriter.Close();
        }
    }
}
