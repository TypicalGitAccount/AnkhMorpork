using Ankh_Morpork.Entities;
using Ankh_Morpork.GameTools;
using Ankh_Morpork.IO;
using Ankh_Morpork.PredefinedData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Ankh_Morpork.Events
{
    public class AssasinEvent : GuildCharacterEvent
    { 
        protected int randomMinRewardPennies()
        {
            return rand.Next((int)AssasinRewardPennies.MinRewardPennies, (int)AssasinRewardPennies.MaxRewardPennies);
        }

        protected int randomMaxRewardPennies(int minRewardPennies)
        {
            return rand.Next(minRewardPennies, (int)AssasinRewardPennies.MaxRewardPennies);
        }

        public override GuildCharacter GenerateGuildCharacter()
        {
            var random = new Random();
            var rewardMin = randomMinRewardPennies();
            var rewardMax = randomMaxRewardPennies(rewardMin);
            var name = randomName();
            var isOccupied = random.Next(2) == 1;
            return new Assasin(rewardMin, rewardMax, name, isOccupied);
        }

        protected HashSet<GuildCharacter> GenerateAssasinsGang()
        {
            HashSet<GuildCharacter> result = new HashSet<GuildCharacter>();
            var length = rand.Next((int)AssasinGang.MinMembers, (int)AssasinGang.MaxMembers);
            for (int i = 0; i < length; i++)
                result.Add(GenerateGuildCharacter());

            return result;
        }

        internal bool ValidRewardInput(InputProcessor inputProcessor, string input)
        {
            return inputProcessor.ValidInput(input, typeof(decimal), (val) =>
            {
                decimal value;
                try
                {
                    decimal.TryParse(input, NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("en-US"), out value);
                }
                catch (Exception)
                {
                    return false;
                }
                
                return value > 0;
            });
        }

        internal decimal GetGuesssedRewardDollars(InputProcessor inputProcessor, OutputProcessor outputProcessor)
        {
            var inputAccepted = false;
            var input = inputProcessor.GetInput();
            while(!inputAccepted)
            {
                if (!ValidRewardInput(inputProcessor, input))
                {
                    outputProcessor.Output(Resources.Events.ResourceManager.GetString("AssasinEventWrongReward"));
                    input = inputProcessor.GetInput();
                }
                else
                {
                    inputAccepted = true;
                }
            }
            decimal.TryParse(input, out decimal result);
            return result;
        } 

        public override bool Run(GameTools.User user, InputProcessor inputProcessor, OutputProcessor outputProcessor)
        {
            outputProcessor.Output(string.Format(Resources.Events.ResourceManager.GetString("UserBalanceOutput"),
                CurrencyConverter.PenniesToString(user.BalancePennies)));
            var assasinGang = GenerateAssasinsGang();
            outputProcessor.Output(Resources.Events.ResourceManager.GetString("AssasinEventWelcome"));
            var answ = GetUsersAnswer(inputProcessor, outputProcessor);
            if (answ == UserOption.Yes)
            {
                outputProcessor.Output(Resources.Events.ResourceManager.GetString("AssasinEventRewardGuessWelcome"));
                var guessedRewardPennies = CurrencyConverter.DollarsToPennies(GetGuesssedRewardDollars(inputProcessor, outputProcessor));
                
                foreach (var assasin in assasinGang)
                {
                    assasin.State.InteractionCostPennies = guessedRewardPennies;
                    if (assasin.Interact(user) == InteractionResult.InteractionSuccessful)
                    {
                        outputProcessor.Output(Resources.Events.ResourceManager.GetString("AssasinEventSuccess"));
                        return true;
                    }
                }
                outputProcessor.Output(Resources.Events.ResourceManager.GetString("AssasinEventRewardGuessedWrong"));
            }
            outputProcessor.Output(Resources.Events.ResourceManager.GetString("AssasinEventFail"));
            return false;
        }
    }
}
