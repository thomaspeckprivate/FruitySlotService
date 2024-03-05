using System.Numerics;

namespace PRNG
{
    public class PseudoRandom
    {
        // research for efficient calculation of PRNG using a linear congruential generator found here:
        // https://www.ams.org/journals/mcom/1999-68-225/S0025-5718-99-00996-5/S0025-5718-99-00996-5.pdf
        private const ulong MODULUS = 2147483647; // mod 2^31 - 1
        private const ulong MULTIPLIER = 1389796;
        private const ulong INCREMENT = 1;
        private ulong _seed { get; set; }

        public PseudoRandom()
        {
            _seed = (ulong)DateTime.Now.Ticks;
        }

        //For test data
        public PseudoRandom (ulong seed)
        {
            _seed = seed;
        }

        private ulong Next()
        {
            return ((MULTIPLIER * _seed) + INCREMENT) % MODULUS;
        }

        public bool GetBool()
        {
            return GetLong(0,2) == 0; 
        }

        public int GetInt(int lowerInclusive, int upperExclusive)
        {
            return (int)GetLong(lowerInclusive, upperExclusive);
        }

        public long GetLong(long lowerInclusive, long upperExclusive)
        {
            _seed = Next();
            if (lowerInclusive >= upperExclusive - 1)
            {
                throw new Exception($"EXCEPTION: Cannot return random value when lower and upper bounds overlap.");
            }
            return (((long)_seed % (upperExclusive - lowerInclusive)) + lowerInclusive);
        }

        public long GetLong(long upperExclusive)
        {
            return GetLong(0, upperExclusive);
        }
    }
}