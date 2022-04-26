using Ankh_Morpork.Entities;
using Ankh_Morpork.GameTools;
using Ankh_Morpork.IO;
using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;
using System;

namespace Ankh_Morpork.Events
{
    public class BeggarEvent : GuildCharacterEvent
    {
        protected BeggarRewardPennies randomPractice()
        {
            Array values = Enum.GetValues(typeof(BeggarRewardPennies));
            return (BeggarRewardPennies)values.GetValue(rand.Next(values.Length));
        }

        public override GuildCharacter GenerateGuildCharacter()
        {
            var name = randomName();
            var practice = randomPractice();
            var practiceName = practice.ToString();
            var practiceReward = (int)practice;
            return new Beggar(name, practiceName, practiceReward);
        }

        public override bool Run(GameTools.User user, InputProcessor inputProcessor, OutputProcessor outputProcessor)
        {
            var beggar = GenerateGuildCharacter();
            var interactionCostPennies = beggar.State.InteractionCostPennies;
            var practiceName = ((BeggarState)beggar.State).PracticeName;
            outputProcessor.Output(string.Format(Resources.Events.ResourceManager.GetString("UserBalanceOutput"),
                CurrencyConverter.PenniesToString(user.BalancePennies)));
            outputProcessor.Output(string.Format(Resources.Events.ResourceManager.GetString("BeggarEventWelcome"),
                beggar.State.CharacterName, practiceName, CurrencyConverter.PenniesToString(interactionCostPennies),
                beggar.State.CharacterName));

            var answ = GetUsersAnswer(inputProcessor, outputProcessor);
            if (answ == UserOption.Yes)
            {
                if (beggar.Interact(user) == InteractionResult.InteractionSuccessful)
                {
                    outputProcessor.Output(string.Format(Resources.Events.ResourceManager.GetString("BeggarEventSuccess"),
                        beggar.State.CharacterName));
                    return true;
                }

                outputProcessor.Output(Resources.Events.ResourceManager.GetString("BeggarEventNotEnoughMoney"));
            }

            outputProcessor.Output(string.Format(Resources.Events.ResourceManager.GetString("BeggarEventFail"),
                        beggar.State.CharacterName));
            return false;
        }
    }
}
