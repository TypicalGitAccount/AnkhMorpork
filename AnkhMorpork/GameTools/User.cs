using System;

namespace Ankh_Morpork.GameTools
{
    /// <summary>
    /// User data tracking unit
    /// </summary>
    public class User
    {
        private int moves;
        public int Moves
        {
            get
            { 
                return moves; 
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Moves parameter can't be < 0");

                moves = value;
            }
        }
        private int balancePennies;
        public int BalancePennies
        {
            get
            { 
                return balancePennies;
            }
            set
            {
                if (value < 0f)
                    throw new ArgumentOutOfRangeException("Balance can\'t be < 0!");

                balancePennies = value;
            }
        }

        public User(int startBalancePennies = (int)PredefinedData.User.StartBalancePennies)
        {
            Moves = 0;
            BalancePennies = startBalancePennies;
        }
    }
}
