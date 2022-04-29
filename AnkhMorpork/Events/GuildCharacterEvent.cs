using Ankh_Morpork.Entities;
using Ankh_Morpork.IO;
using Ankh_Morpork.PredefinedData;
using System;
using System.Text;

namespace Ankh_Morpork.Events
{
    public abstract class GuildCharacterEvent
    {
        protected Random rand = new Random();

        protected string randomName()
        {
            var vowels = "aeoui";
            var consonants = "bcdfghjklmnpqrtsvwxz";
            var length = rand.Next(2, 10);
            var name = new StringBuilder(length);
            var vowel = false;

            for (int i = 0; i < length; i++, vowel = !vowel)
            {
                if (vowel)
                {
                    name.Append(vowels[rand.Next(0, vowels.Length - 1)]);
                }
                else
                {
                    name.Append(consonants[rand.Next(0, consonants.Length - 1)]);
                }
            }
            name[0] = char.ToUpper(name[0]);
            return name.ToString();
        }

        protected int randomInteractionCost()
        {
            return rand.Next(1, (int)PredefinedData.User.StartBalancePennies/2);
        }

        /// <summary>
        /// To generate npc according to event type
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public virtual GuildCharacter GenerateGuildCharacter() { throw new NotImplementedException(); }

        internal bool ValidUserAnswer(InputProcessor inputProcessor, string input)
        {
            return inputProcessor.ValidInput(input, typeof(string), (val) =>
            {
                var value = (string)val;
                return !string.IsNullOrEmpty(value) && (value == UserOption.Yes.ToString()
                || value == UserOption.No.ToString());
            });
        }

        internal UserOption GetUsersAnswer(InputProcessor inputProcessor, OutputProcessor outputProcessor)
        {
            var input = inputProcessor.GetInput();
            bool inputAccepted = false;

            while (!inputAccepted)
            {
                if (!ValidUserAnswer(inputProcessor, input))
                {
                    outputProcessor.Output($"Input is not valid, please anter '{UserOption.Yes}' or '{UserOption.No}'!\n");
                    input = inputProcessor.GetInput();
                }
                else
                {
                    inputAccepted = true;
                }
            }

            if (input == UserOption.Yes.ToString())
                return UserOption.Yes;

            return UserOption.No;
        }


        /// <summary>
        /// Event entry point
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public virtual bool Run(GameTools.User user, InputProcessor inputProcessor, OutputProcessor outputProcessor)
        { throw new NotImplementedException(); } 
    }
}
