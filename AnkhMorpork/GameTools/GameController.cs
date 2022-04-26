using Ankh_Morpork.Entities;
using Ankh_Morpork.Events;
using Ankh_Morpork.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ankh_Morpork.GameTools
{
    public class GameController {
        public List<Type> GameEvents { get; private set; }
        public User User { get; private set; }
        public InputProcessor InputProcessor { get; private set; }
        public OutputProcessor OutputProcessor { get; private set; }

        public GameController(InputProcessor input, OutputProcessor output)
        {
            User = new User();
            InputProcessor = input;
            OutputProcessor = output;
            GameEvents = Assembly.GetAssembly(typeof(GuildCharacterEvent)).GetTypes()
            .Where(t => t.IsSubclassOf(typeof(GuildCharacterEvent))).ToList();
        }

        private GuildCharacterEvent GenerateEvent()
        {
            var rand = new Random();
            var randIndex = rand.Next(GameEvents.Count());
            return (GuildCharacterEvent)GameEvents[randIndex].GetConstructor(new Type[] { }).Invoke(new object[] { });
        }


        private void WelcomeWord()
        {
            OutputProcessor.Output(Resources.GameController.ResourceManager.GetString("WelcomeWord"));
        }

        private void EndWord()
        {
            OutputProcessor.Output(string.Format(Resources.GameController.ResourceManager.GetString("FinalWord") , User.Moves));
        }

        public void StartGame() {
            WelcomeWord();
            var runtime = true;
            while (runtime) {
                runtime = GenerateEvent().Run(User, InputProcessor, OutputProcessor);
                User.Moves += 1;
            }
            EndWord();
        }
    }
}
