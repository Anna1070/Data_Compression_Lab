using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator1_citire_scriere_biti
{
    internal class BitWriter
    {
        private byte bufferWrite;
        private int numberOfBitsWrite;
        FileStream fileStream;

        public BitWriter(string filePath)
        {
            numberOfBitsWrite = 0;
            fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        }

        private bool IsBufferFull()
        {
            if (numberOfBitsWrite == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void WriteBit(int bit)
        {
            bufferWrite = (byte)((bufferWrite << 1) | bit);
            numberOfBitsWrite++;
            if (IsBufferFull())
            {
                fileStream.WriteByte(bufferWrite);
                bufferWrite = 0;
                numberOfBitsWrite = 0;
            }
        }

        public void WriteNBits (uint value, int numberBits)
        {
            for(int i = numberBits-1; i >= 0; i--)
            {
                int bit = (int)((value >> i) & 1);
                WriteBit(bit);
            }
        }

        public void Close()
        {
            if (numberOfBitsWrite > 0)
            {
                bufferWrite = (byte)(bufferWrite << (8 - numberOfBitsWrite));
                fileStream.WriteByte(bufferWrite);
            }
            fileStream.Close();
        }
    }
}
