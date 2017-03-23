using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhongLi.Common
{
    public class MersenneTwister : Random
    {
        
        public MersenneTwister(Int32 seed)
        {
            Init((UInt32)seed);
        }

        public MersenneTwister() : this(new Random().Next()) { }
        public MersenneTwister(Int32[] initKey)
        {

            if (initKey == null)
            {

                throw new ArgumentNullException("initKey");

            }

            UInt32[] initArray = new UInt32[initKey.Length];

            for (int i = 0; i < initKey.Length; ++i)
            {

                initArray[i] = (UInt32)initKey[i];

            }

            Init(initArray);

        }



        public MersenneTwister(Random rnd)
        {

            // TODO: Complete member initialization

            this.rnd = rnd;

        }


        public virtual UInt32 NextUInt32()
        {

            return GenerateUInt32();

        }

        public virtual UInt32 NextUInt32(UInt32 maxValue)
        {

            return (UInt32)(GenerateUInt32() / ((Double)UInt32.MaxValue / maxValue));

        }


        public virtual UInt32 NextUInt32(UInt32 minValue, UInt32 maxValue) /*throws ArgumentOutOfRangeException */
        {

            if (minValue >= maxValue)
            {

                throw new ArgumentOutOfRangeException();

            }
            return (UInt32)(GenerateUInt32() / ((Double)UInt32.MaxValue / (maxValue - minValue)) + minValue);

        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <returns></returns>
        public override Int32 Next()
        {
            return Next(Int32.MaxValue);
        }
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="maxValue">最大值</param>
        /// <returns></returns>
        public override Int32 Next(Int32 maxValue)
        {
            if (maxValue <= 1)
            {
                if (maxValue < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return 0;
            }
            return (Int32)(NextDouble() * maxValue);

        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        /// <returns></returns>
        public override Int32 Next(Int32 minValue, Int32 maxValue)
        {

            if (maxValue <= minValue)
            {

                throw new ArgumentOutOfRangeException();

            }

            if (maxValue == minValue)
            {

                return minValue;

            }
            return Next(maxValue - minValue) + minValue;

        }
        public override void NextBytes(Byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException();
            }
            Int32 bufLen = buffer.Length;

            for (Int32 idx = 0; idx < bufLen; ++idx)
            {
                buffer[idx] = (Byte)Next(256);
            }
        }

        public override Double NextDouble()
        {
            return compute53BitRandom(0, InverseOnePlus53BitsOf1s);
        }

        public Double NextDouble(Boolean includeOne)
        {
            return includeOne ? compute53BitRandom(0, Inverse53BitsOf1s) : NextDouble();
        }

        public Double NextDoublePositive()
        {
            return compute53BitRandom(0.5, Inverse53BitsOf1s);
        }

        public Single NextSingle()
        {
            return (Single)NextDouble();
        }

        public Single NextSingle(Boolean includeOne)
        {
            return (Single)NextDouble(includeOne);
        }

        public Single NextSinglePositive()
        {
            return (Single)NextDoublePositive();
        }

        protected UInt32 GenerateUInt32()
        {
            UInt32 y;
            if (_mti >= N)
            {
                Int16 kk = 0;
                for (; kk < N - M; ++kk)
                {
                    y = (_mt[kk] & UpperMask) | (_mt[kk + 1] & LowerMask);
                    _mt[kk] = _mt[kk + M] ^ (y >> 1) ^ Mag01[y & 0x1];
                }
                for (; kk < N - 1; ++kk)
                {
                    y = (_mt[kk] & UpperMask) | (_mt[kk + 1] & LowerMask);
                    _mt[kk] = _mt[kk + (M - N)] ^ (y >> 1) ^ Mag01[y & 0x1];
                }
                y = (_mt[N - 1] & UpperMask) | (_mt[0] & LowerMask);
                _mt[N - 1] = _mt[M - 1] ^ (y >> 1) ^ Mag01[y & 0x1];
                _mti = 0;
            }

            y = _mt[_mti++];

            y ^= TemperingShiftU(y);

            y ^= TemperingShiftS(y) & TemperingMaskB;

            y ^= TemperingShiftT(y) & TemperingMaskC;

            y ^= TemperingShiftL(y);

            return y;

        }
        private const Int32 N = 624;

        private const Int32 M = 397;

        private const UInt32 MatrixA = 0x9908b0df;
        private const UInt32 UpperMask = 0x80000000;
        private const UInt32 LowerMask = 0x7fffffff;
        private const UInt32 TemperingMaskB = 0x9d2c5680;
        private const UInt32 TemperingMaskC = 0xefc60000;

        private static UInt32 TemperingShiftU(UInt32 y)
        {
            return (y >> 11);
        }

        private static UInt32 TemperingShiftS(UInt32 y)
        {
            return (y << 7);
        }

        private static UInt32 TemperingShiftT(UInt32 y)
        {
            return (y << 15);
        }

        private static UInt32 TemperingShiftL(UInt32 y)
        {
            return (y >> 18);
        }

        private readonly UInt32[] _mt = new UInt32[N];
        private Int16 _mti;
        private static readonly UInt32[] Mag01 = { 0x0, MatrixA };

        private void Init(UInt32 seed)
        {
            _mt[0] = seed & 0xffffffffU;
            for (_mti = 1; _mti < N; _mti++)
            {
                _mt[_mti] = (uint)(1812433253U * (_mt[_mti - 1] ^ (_mt[_mti - 1] >> 30)) + _mti);
                _mt[_mti] &= 0xffffffffU;
            }
        }

        private void Init(UInt32[] key)
        {
            Int32 i, j, k;

            Init(19650218U);
            Int32 keyLength = key.Length;
            i = 1; j = 0;
            k = (N > keyLength ? N : keyLength);
            for (; k > 0; k--)
            {
                _mt[i] = (uint)((_mt[i] ^ ((_mt[i - 1] ^ (_mt[i - 1] >> 30)) * 1664525U)) + key[j] + j);
                _mt[i] &= 0xffffffffU;
                i++; j++;
                if (i >= N)
                {
                    _mt[0] = _mt[N - 1]; i = 1;
                }
                if (j >= keyLength)
                    j = 0;
            }

            for (k = N - 1; k > 0; k--)
            {
                _mt[i] = (uint)((_mt[i] ^ ((_mt[i - 1] ^ (_mt[i - 1] >> 30)) * 1566083941U)) - i);
                _mt[i] &= 0xffffffffU;
                i++;
                if (i < N)
                {
                    continue;
                }
                _mt[0] = _mt[N - 1]; i = 1;
            }
            _mt[0] = 0x80000000U;
        }

        private const Double FiftyThreeBitsOf1s = 9007199254740991.0;

        private const Double Inverse53BitsOf1s = 1.0 / FiftyThreeBitsOf1s;

        private const Double OnePlus53BitsOf1s = FiftyThreeBitsOf1s + 1;

        private const Double InverseOnePlus53BitsOf1s = 1.0 / OnePlus53BitsOf1s;

        private Random rnd;

        private Double compute53BitRandom(Double translate, Double scale)
        {
            UInt64 a = (UInt64)GenerateUInt32() >> 5;
            UInt64 b = (UInt64)GenerateUInt32() >> 6;
            return ((a * 67108864.0 + b) + translate) * scale;
        }
    }
}
