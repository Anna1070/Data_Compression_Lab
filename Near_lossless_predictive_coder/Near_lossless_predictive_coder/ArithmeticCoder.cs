using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Near_lossless_predictive_coder
{
    internal class ArithmeticCoder
    {
        public uint low;
        public uint high;
        public UInt64 range;
        public int underflow_counter;

        public uint firstShiftMask = 0x80000000;
        public uint secondShiftMask = 0x40000000;

        public const int countSize = 512;
        public const int eofIndex = 511;

        public int[] counts = new int[countSize];
        public int[] sums = new int[countSize];
        public int totalS;

        public  void InitializeDynamicModel()
        {
            low = 0x00000000;
            high = 0xFFFFFFFF;
            underflow_counter = 0;

            for (int i = 0; i < countSize; i++)
            {
                counts[i] = 1;
            }
            RecalculateSums();
        }

        public void RecalculateSums()
        {
            int currentSum = 0;
            for (int i = 0; i < countSize; i++)
            {
                sums[i] = currentSum;
                currentSum += counts[i];
            }
            totalS = currentSum;
        }

        public void EncodeSymbol(int symbol, BitWriter bitWriter)
        {
            range = (UInt64)(high - low) + 1;
            high = low + (uint)((range * (UInt64)(sums[symbol] + counts[symbol])) / (UInt64)totalS) - 1;
            low = low + (uint)((range * (UInt64)sums[symbol]) / (UInt64)totalS);

            counts[symbol]++;
            RecalculateSums();

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
