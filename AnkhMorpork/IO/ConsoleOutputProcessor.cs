using System;

namespace Ankh_Morpork.IO
{
    /// <summary>
    /// Provide output through console
    /// </summary>
    public class ConsoleOutputProcessor : OutputProcessor
    {
        public override void Output(string data)
        {
            Console.Write(data);
        }
    }
}
