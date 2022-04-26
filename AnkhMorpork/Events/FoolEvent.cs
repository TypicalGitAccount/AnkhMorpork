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
        protected FoolRewardPennies randomPractice()
        {
            Array values = Enum.GetValues(typeof(FoolRewardPennies));
            return (FoolRewardPennies)values.GetValue(rand.Next(values.Length));
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
            var rewardPennies = fool.State.InteractionCostPennies;
            outputProcessor.Output(string.Format(Resources.Events.ResourceManager.GetString("UserBalanceOutput"),
                CurrencyConverter.PenniesToString(user.BalancePennies)));
            outputProcessor.Output(string.Format(Resources.Events.ResourceManager.GetString("FoolEventWelcome"),
                fool.State.CharacterName, practiceName, CurrencyConverter.PenniesToString(rewardPennies)));
            var answ = GetUsersAnswer(inputProcessor, outputProcessor);
            if (answ == UserOption.Yes)
            {
                fool.Interact(user);
                outputProcessor.Output(Resources.Events.ResourceManager.GetString("FoolEventSuccess"));
            }
            else
            {
                outputProcessor.Output(string.Format(Resources.Events.ResourceManager.GetString("FoolEventFail"),
                    fool.State.CharacterName));
            }
            return true;
        }
    }
}
