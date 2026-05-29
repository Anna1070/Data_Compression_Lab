using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_coder
{
    internal class BitReader
    {
        private byte bufferRead;
        private int numberOfBits;
        private FileStream fileStream;

        public BitReader (string filePath)
        {
            numberOfBits = 0;
            fileStream = new FileStream(filePath, FileMode.Open);
        }

        private bool IsBufferEmpty()
        {
            if (numberOfBits == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int ReadBit()
        {
            if (IsBufferEmpty())
            {
                int byteRead = fileStream.ReadByte();
                bufferRead = (byte)byteRead;
                numberOfBits = 8;
            }

            int result = (bufferRead >> 7) & 1;
            bufferRead = (byte)(bufferRead << 1);
            numberOfBits--;

            return result;
        }

        public uint ReadNBits(int nr)
        {
            uint result = 0;
            for (int i = 0; i < nr; i++)
            {
                int bit = ReadBit();
                result = (uint)((result << 1) | bit);
            }

            return result;
        }

        public void Close()
        {
            fileStream.Close();
        }
    }
}
