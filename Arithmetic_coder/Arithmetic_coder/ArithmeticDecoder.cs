using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_coder
{
    class ArithmeticDecoder
    {
        public uint low;
        public uint high;
        public uint value;
        public UInt64 range;

        public uint firstShiftMask = 0x80000000;
        public uint secondShiftMask = 0x40000000;

        //public Dictionary<char, int> counts;
        //public Dictionary<char, int> sums;
        //public int totalS;

        //public const char EOF = '\0';

        public const int countSize = 257;
        public const int eofIndex = 256;

        public int[] counts = new int[countSize];
        public int[] sums = new int[countSize];
        public int totalS;

        public void InitializeDynamicModel()
        {
            low = 0x00000000;
            high = 0xFFFFFFFF;

            //counts = new Dictionary<char, int>();
            //sums = new Dictionary<char, int>();

            //counts['A'] = 1;
            //counts['B'] = 1;
            //counts[EOF] = 1;

            for (int i = 0; i < countSize; i++)
            {
                counts[i] = 1;
            }

            RecalculateSums();
        }

        public void RecalculateSums()
        {
            //sums['A'] = 0;
            //sums['B'] = sums['A'] + counts['A'];
            //sums[EOF] = sums['B'] + counts['B'];

            //totalS = sums[EOF] + counts[EOF];

            int currentSum = 0;
            for (int i = 0; i < countSize; i++)
            {
                sums[i] = currentSum;
                currentSum += counts[i];
            }
            totalS = currentSum;
        }

        public void InitializeDecoder(BitReader bitReader)
        {
            InitializeDynamicModel();

            value = 0;
            for (int i = 0; i < 32; i++)
            {
                uint bit = ReadBitWithZeroPadding(bitReader);
                value = (value << 1) | bit;
            }
        }

        public int DecodeSymbol(BitReader bitReader)
        {
            range = (UInt64)(high - low) + 1;

            UInt64 sumc = (((UInt64)(value - low) + 1) * (UInt64)totalS - 1) / range;

            //char decodedSymbol = ' ';
            int decodedSymbol = -1;

            //if (sumc >= (UInt64)sums['A'] && sumc < (UInt64)sums['B'])
            //{
            //    decodedSymbol = 'A';
            //}
            //else if (sumc >= (UInt64)sums['B'] && sumc < (UInt64)sums[EOF])
            //{
            //    decodedSymbol = 'B';
            //}
            //else
            //{
            //    decodedSymbol = EOF;
            //}

            for (int i = 0; i < countSize; i++)
            {
                int nextSum;

                if (i == eofIndex)
                {
                    nextSum = totalS;
                }
                else
                {
                    nextSum = sums[i + 1];
                }

                if (sumc >= (UInt64)sums[i] && sumc < (UInt64)nextSum)
                {
                    decodedSymbol = i;
                    break;
                }
            }

            high = low + (uint)((range * (UInt64)(sums[decodedSymbol] + counts[decodedSymbol])) / (UInt64)totalS) - 1;
            low = low + (uint)((range * (UInt64)sums[decodedSymbol]) / (UInt64)totalS);

            counts[decodedSymbol]++;
            RecalculateSums();

            while (true)
            {
                if ((low & firstShiftMask) == (high & firstShiftMask))
                {
                    low = low << 1;
                    high = (high << 1) | 1;

                    uint nextBit = ReadBitWithZeroPadding(bitReader);
                    value = (value << 1) | nextBit;
                }
                else if ((low & secondShiftMask) != 0 && (high & secondShiftMask) == 0)
                {
                    low = (low << 1) ^ firstShiftMask;
                    high = ((high ^ firstShiftMask) << 1) | firstShiftMask | 1;

                    uint nextBit = ReadBitWithZeroPadding(bitReader);
                    value = ((value - secondShiftMask) << 1) | nextBit;
                }
                else
                {
                    break;
                }
            }

            return decodedSymbol;
        }

        private uint ReadBitWithZeroPadding(BitReader bitReader)
        {
            try
            {
                return bitReader.ReadNBits(1);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
