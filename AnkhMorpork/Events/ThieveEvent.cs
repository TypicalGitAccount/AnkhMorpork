using Ankh_Morpork.Entities;
using Ankh_Morpork.GameTools;
using Ankh_Morpork.IO;
using Ankh_Morpork.PredefinedData;

namespace Ankh_Morpork.Events
{
    public class ThieveEvent : GuildCharacterEvent
    {
        public override GuildCharacter GenerateGuildCharacter()
        {
            return new Thieve(randomName());
        }

        public override bool Run(GameTools.User user, InputProcessor inputProcessor, OutputProcessor outputProcessor)
        {
            var thieve = GenerateGuildCharacter();
            outputProcessor.Output($"Pocket: {CurrencyConverter.PenniesToString(user.BalancePennies)}\n\n"
                + $"There's a thieve {thieve.State.CharacterName} on the way\n" +
                "and your back is against the wall!\n" +
            $"Thieve's demand is {CurrencyConverter.PenniesToString(thieve.State.InteractionCostPennies)} $\n" + 
            "Your only way to survive is to pay off...\n" +
            "Give the money? (Enter 'Yes' or 'No')\n\n");
            var answ = GetUsersAnswer(inputProcessor, outputProcessor);
            if (answ == UserOption.Yes)
            {
                if (thieve.Interact(user) == InteractionResult.InteractionSuccessful)
                {
                    outputProcessor.Output($"Thieve {thieve.State.CharacterName} spared your life today.\n");
                    return true;
                }
                outputProcessor.Output($"There was not enough money to save your life..\n");
            }
            outputProcessor.Output($"You were killed by {thieve.State.CharacterName}\n\n");
            return false;
        }
    }
}
