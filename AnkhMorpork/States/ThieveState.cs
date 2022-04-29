using Ankh_Morpork.PredefinedData;
using System;

namespace Ankh_Morpork.States
{
    public class ThieveState : GuildCharacterState
    {
        private static int theftsCounter = 0;

        public static int TheftsHappened
        {
            get
            {
                return theftsCounter;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("theftsCounter can\'t be < 0!");

                theftsCounter = value;
            }
        }
        public ThieveState(string name) : base(name, (int)Thieves.DefaultFeePennies) { }
    }
}
