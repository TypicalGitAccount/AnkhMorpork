using System;

namespace Ankh_Morpork.GameTools
{
    public static class CurrencyConverter
    {
        public static decimal PenniesToDollars(int cents)
        {
            if (cents < 0)
                throw new ArgumentOutOfRangeException("cents parameter can\'t be < 0");

            return (decimal)cents / 100;
        }

        public static int DollarsToPennies(decimal dollars)
        {
            if (dollars < 0)
                throw new ArgumentOutOfRangeException("dollars parameter can\'t be < 0");

            return (int)(dollars * 100);
        }

        public static string DollarsToString(decimal dollars)
        {
            if (dollars % 1 == 0)
                return $"{dollars} $";

            var pennies = dollars % 1;
            var afterZero = (pennies).ToString().Split(',')[1].Length;
            for (int i = 0; i < afterZero; i++)
                pennies *= 10;

            return $"{Math.Truncate(dollars)} $ {(int)pennies} p.";
        }

        public static string PenniesToString(int pennies)
        {
            return DollarsToString(PenniesToDollars(pennies));
        }
    }
}
