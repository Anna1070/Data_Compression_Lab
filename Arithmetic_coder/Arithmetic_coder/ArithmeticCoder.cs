using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_coder
{
    internal class ArithmeticCoder
    {
        public uint low;
        public uint high;
        public UInt64 range;
        public int underflow_counter;

        public uint firstShiftMask = 0x80000000;
        public uint secondShiftMask = 0x40000000;

        public Dictionary<char, int> counts;
        public Dictionary<char, int> sums;
        public int totalS;

        public const char EOF = '\0';

        public  void InitializeStaticModel()
        {
            low = 0x00000000;
            high = 0xFFFFFFFF;
            underflow_counter = 0;

            counts = new Dictionary<char, int>();
            sums = new Dictionary<char, int>();

            counts['A'] = 1;
            counts['B'] = 1;
            counts[EOF] = 1;

            sums['A'] = 0;                     
            sums['B'] = sums['A'] + counts['A']; 
            sums[EOF] = sums['B'] + counts['B']; 

            totalS = sums[EOF] + counts[EOF];
        }

        public void EncodeSymbol(char symbol, BitWriter bitWriter)
        {
            range = (UInt64)(high - low) + 1;
            high = low + (uint)((range * (UInt64)(sums[symbol] + counts[symbol])) / (UInt64)totalS) - 1;
            low = low + (uint)((range * (UInt64)sums[symbol]) / (UInt64)totalS);

            while (true)
            {  
                if ((low & firstShiftMask) == (high & firstShiftMask))
                {
                    Console.WriteLine($"Low first bit: {low >> 31}   High first bit: {high >> 31}");
                    int bit = (int)((low & firstShiftMask) >> 31);

                    bitWriter.WriteNBits((uint)bit, 1);

                    while (underflow_counter > 0)
                    {
                        int oppositeBit;
                        if (bit == 1)
                        {
                            oppositeBit = 0;
                        }
                        else
                        {
                            oppositeBit = 1;
                        }
                        bitWriter.WriteNBits((uint)oppositeBit, 1);
                        underflow_counter--;
                    }

                    low = low << 1;
                    high = (high << 1) | 1;
                }

                else if ((low & secondShiftMask) != 0 && (high & secondShiftMask) == 0)
                {
                    underflow_counter++;

                    low = (low << 1) ^ firstShiftMask;
                    high = ((high ^ firstShiftMask) << 1) | firstShiftMask | 1;
                }
                else
                {
                    break;
                }
            }
        }

        public void DoneEncoding(BitWriter bitWriter)
        {
            uint sfertLow = low >> 30;

            int firstBit;
            int secondBit;

            if (sfertLow == 0)
            {
                firstBit = 0;
                secondBit = 1;
            }
            else if (sfertLow == 1)
            {
                firstBit = 1;
                secondBit = 0;
            }
            else
            {
                firstBit = 1;
                secondBit = 0;
            }

            bitWriter.WriteNBits((uint)firstBit, 1);

            while (underflow_counter > 0)
            {
                int oppositeBit;
                if (firstBit == 1)
                {
                    oppositeBit = 0;
                }
                else
                {
                    oppositeBit = 1;
                }
                bitWriter.WriteNBits((uint)oppositeBit, 1);
                underflow_counter--;
            }

            bitWriter.WriteNBits((uint)secondBit, 1);
        }
    }
}
