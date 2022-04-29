using System;

namespace Ankh_Morpork.IO
{
    public class ConsoleOutputProcessor : OutputProcessor
    {
        public override void Output(string data)
        {
            Console.Write(data);
        }
    }
}
