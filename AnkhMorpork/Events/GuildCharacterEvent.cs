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
                    name.Append(vowels[rand.Next(vowels.Length - 1)]);
                }
                else
                {
                    name.Append(consonants[rand.Next(consonants.Length - 1)]);
                }
            }
            name[0] = char.ToUpper(name[0]);
            return name.ToString();
        }

        protected int randomInteractionCost()
        {
            return rand.Next(1, (int)PredefinedData.User.StartBalancePennies/2);
        }

        public virtual GuildCharacter GenerateGuildCharacter() { throw new NotImplementedException(); }

        public bool ValidUserAnswer(InputProcessor inputProcessor, string input)
        {
            return inputProcessor.ValidInput(input, typeof(string), (val) =>
            {
                var value = (string)val;
                return value != null && !string.IsNullOrEmpty(value) && (value == UserOption.Yes.ToString()
                || value == UserOption.No.ToString());
            });
        }

        public UserOption GetUsersAnswer(InputProcessor inputProcessor, OutputProcessor outputProcessor)
        {
            var input = inputProcessor.GetInput();
            bool inputAccepted = false;

            while (!inputAccepted)
            {
                if (!ValidUserAnswer(inputProcessor, input))
                {
                    outputProcessor.Output(string.Format(Resources.Events.ResourceManager.GetString("UserInputNotValid"), 
                        UserOption.Yes.ToString(), UserOption.No.ToString()));
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

        public virtual bool Run(GameTools.User user, InputProcessor inputProcessor, OutputProcessor outputProcessor)
        { throw new NotImplementedException(); } 
    }
}
