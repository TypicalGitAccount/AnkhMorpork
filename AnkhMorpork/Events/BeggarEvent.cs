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
            outputProcessor.Output($"Pocket: { CurrencyConverter.PenniesToString(user.BalancePennies)}\n\n"  +
                $"A random beggar named {beggar.State.CharacterName} ({practiceName})\n" +
                "has been disturbing you for more than an hour already.\n" +
                $"It looks like if you don\'t give him alms ( {CurrencyConverter.PenniesToString(interactionCostPennies)} ), he will chase you to death..\n" +
                $"Give alms to {beggar.State.CharacterName}? (Enter 'Yes' or 'No')\n\n");
            var answ = GetUsersAnswer(inputProcessor, outputProcessor);
            if (answ == UserOption.Yes)
            {
                if (beggar.Interact(user) == InteractionResult.InteractionSuccessful)
                {
                    outputProcessor.Output($"{beggar.State.CharacterName} got his coins and went away.\n\n");
                    return true;
                }

                outputProcessor.Output($"{beggar.State.CharacterName} saw you're short on money.\n");
            }

            outputProcessor.Output("Beggar and his mates chased you on your way until you found your death...\n\n");
            return false;
        }
    }
}
