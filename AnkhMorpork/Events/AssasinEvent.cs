using Ankh_Morpork.Entities;
using Ankh_Morpork.GameTools;
using Ankh_Morpork.IO;
using Ankh_Morpork.PredefinedData;
using System;
using System.Collections.Generic;

namespace Ankh_Morpork.Events
{
    public class AssasinEvent : GuildCharacterEvent
    {
        protected int randomMinRewardCents()
        {
            return rand.Next((int)AssasinRewardCents.MinRewardCents, (int)AssasinRewardCents.MaxRewardCents);
        }

        protected int randomMaxRewardCents(int minRewardCents)
        {
            return rand.Next(minRewardCents, (int)AssasinRewardCents.MaxRewardCents);
        }

        public override GuildCharacter GenerateGuildCharacter()
        {
            var random = new Random();
            var rewardMin = randomMinRewardCents();
            var rewardMax = randomMaxRewardCents(rewardMin);
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
            return inputProcessor.ValidInput(input, typeof(double), (val) =>
            {
                double.TryParse((string)val, out double value);
                return value > 0;
            });
        }

        internal double GetGuesssedRewardDollars(InputProcessor inputProcessor, OutputProcessor outputProcessor)
        {
            var inputAccepted = false;
            var input = inputProcessor.GetInput();
            while(!inputAccepted)
            {
                if (!ValidRewardInput(inputProcessor, input))
                {
                    outputProcessor.Output("\nWrong input, please enter your reward (positiver number)!\n");
                    input = inputProcessor.GetInput();
                }
                else
                {
                    inputAccepted = true;
                }
            }

            double.TryParse(input, out double result);
            return result;
        } 

        public override bool Run(GameTools.User user, InputProcessor inputProcessor, OutputProcessor outputProcessor)
        {
            outputProcessor.Output($"Pocket: {CurrencyConverter.CentsToDollars(user.BalanceCents)}$\n\n");
            var assasinGang = GenerateAssasinsGang();
            outputProcessor.Output($"You bumped into a gang of Assasins! They say : \n" +
                "'Someone set a contract to kill you. But we can have a deal.\n" +
                "Show us your pocket, and if someone likes it's content and \n" +
                "has a free time to help you eliminate your assination orderer, we're good.'\n" +
                "Accept the offer? (Enter 'Yes' or 'No')\n\n");
            var answ = GetUsersAnswer(inputProcessor, outputProcessor);
            if (answ == UserOption.Yes)
            {
                outputProcessor.Output("\nSay your reward!(You have only 1 try to guess)\n");
                var guessedRewardCents = CurrencyConverter.DollarsToCents(GetGuesssedRewardDollars(inputProcessor, outputProcessor));
                
                foreach (var assasin in assasinGang)
                {
                    assasin.State.InteractionCostCents = guessedRewardCents;
                    if (assasin.Interact(user) == InteractionResult.InteractionSuccessful)
                    {
                        outputProcessor.Output($"You were lucky - assasins took the bribe\n" +
                            "and disappeared in the dark.\n\n");
                        return true;
                    }
                }
                outputProcessor.Output("Unfriendly people didn\'t like the reward you offered\n");
            }
            outputProcessor.Output("The gang beated you to death with tea bags..\n\n");
            return false;
        }
    }
}
