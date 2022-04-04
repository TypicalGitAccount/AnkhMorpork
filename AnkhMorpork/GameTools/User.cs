using System;

namespace Ankh_Morpork.GameTools
{
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
        private int balanceCents;
        public int BalanceCents
        {
            get
            { 
                return balanceCents;
            }
            set
            {
                if (value < 0f)
                    throw new ArgumentOutOfRangeException("Balance can\'t be < 0!");

                balanceCents = value;
            }
        }

        public User(int startBalanceCents = (int)PredefinedData.User.StartBalanceCents)
        {
            Moves = 0;
            BalanceCents = startBalanceCents;
        }
    }
}
