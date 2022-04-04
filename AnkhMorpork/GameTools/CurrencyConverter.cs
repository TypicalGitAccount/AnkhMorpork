using System;

namespace Ankh_Morpork.GameTools
{
    public static class CurrencyConverter
    {
        public static double CentsToDollars(int cents)
        {
            if (cents < 0)
                throw new ArgumentOutOfRangeException("cents parameter can\'t be < 0");

            return (double)cents / 100;
        }

        public static int DollarsToCents(double dollars)
        {
            if (dollars < 0)
                throw new ArgumentOutOfRangeException("dollars parameter can\'t be < 0");

            return (int)(dollars * 100);
        }
    }
}
