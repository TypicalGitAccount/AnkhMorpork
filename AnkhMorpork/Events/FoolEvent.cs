using Ankh_Morpork.Entities;
using Ankh_Morpork.GameTools;
using Ankh_Morpork.IO;
using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;
using System;

namespace Ankh_Morpork.Events
{
    public class FoolEvent : GuildCharacterEvent
    {
        protected FoolRewardCents randomPractice()
        {
            Array values = Enum.GetValues(typeof(FoolRewardCents));
            return (FoolRewardCents)values.GetValue(rand.Next(values.Length));
        }

        public override GuildCharacter GenerateGuildCharacter()
        {
            var name = randomName();
            var practice = randomPractice();
            var practiceName = practice.ToString();
            var practiceReward = (int)practice;
            return new Fool(name, practiceName, practiceReward);
        }

        public override bool Run(GameTools.User user, InputProcessor inputProcessor, OutputProcessor outputProcessor)
        {
            var fool = GenerateGuildCharacter();
            var practiceName = ((FoolState)fool.State).PracticeName;
            var reward = CurrencyConverter.CentsToDollars(fool.State.InteractionCostCents);
            outputProcessor.Output($"Pocket: { CurrencyConverter.CentsToDollars(user.BalanceCents)}$\n\n" +
                $"You met your highschool homie, {fool.State.CharacterName} ({practiceName})\n" +
                $"He offers you to join him and earn some money ({reward} $)\n" + 
                "Wanna join him? (Enter 'Yes' or 'No')\n\n");
            var answ = GetUsersAnswer(inputProcessor, outputProcessor);
            if (answ == UserOption.Yes)
            {
                fool.Interact(user);
                outputProcessor.Output("You had a great time fooling around and earn some money!\n\n");
            }
            else
            {
                outputProcessor.Output($"{fool.State.CharacterName} said that it will be sad for him\n" +
                "to joke around alone today and left.\n\n");
            }
            return true;
        }
    }
}
