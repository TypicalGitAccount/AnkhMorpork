using Ankh_Morpork.GameTools;
using Ankh_Morpork.IO;
using System;

namespace Ankh_Morpork
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var controller = new GameController(new ConsoleInputProcessor(), new ConsoleOutputProcessor());
            controller.StartGame();
        } 
    }
}
