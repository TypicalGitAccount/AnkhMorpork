using Ankh_Morpork.IO;

namespace Ankh_Morpork.Tests.Events
{
    public class TestOutputProcessor : OutputProcessor
    {
        public string TestOutput { get; set; }

        public override void Output(string data)
        {
            TestOutput = data;
        }
    }
}
