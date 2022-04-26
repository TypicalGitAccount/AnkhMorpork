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
            outputProcessor.Output(string.Format(Resources.Events.ResourceManager.GetString("UserBalanceOutput"),
                CurrencyConverter.PenniesToString(user.BalancePennies)));
            outputProcessor.Output(string.Format(Resources.Events.ResourceManager.GetString("ThieveEventWelcome"),
                thieve.State.CharacterName, CurrencyConverter.PenniesToString(thieve.State.InteractionCostPennies)));
            var answ = GetUsersAnswer(inputProcessor, outputProcessor);
            if (answ == UserOption.Yes)
            {
                if (thieve.Interact(user) == InteractionResult.InteractionSuccessful)
                {
                    outputProcessor.Output(string.Format(Resources.Events.ResourceManager.GetString("ThieveEventSuccess"),
                thieve.State.CharacterName));
                    return true;
                }
                outputProcessor.Output(Resources.Events.ResourceManager.GetString("ThieveEventNotEnoughMoney"));
            }
            outputProcessor.Output(string.Format(Resources.Events.ResourceManager.GetString("ThieveEventFail"),
                thieve.State.CharacterName));
            return false;
        }
    }
}
