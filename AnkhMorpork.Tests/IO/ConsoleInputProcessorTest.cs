using Ankh_Morpork.IO;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Ankh_Morpork.Tests.IO
{
    [TestFixture]
    public class ConsoleInputProcessorTest
    {
        private ConsoleInputProcessor InputProcessor;

        [SetUp]
        public void SetUp()
        {
            InputProcessor = new ConsoleInputProcessor();
        }

        private static IEnumerable<List<object>> ValidateInputCorrectInputTestCases
        {
            get 
            {
                yield return new List<object> { "123", typeof(int), (Func<object, bool>)((val) =>
                {
                    int.TryParse((string)val, out int result);
                    return result == 123;
                })};
                yield return new List<object> { "      13,5 ", typeof(decimal), (Func<object, bool>)((val) => { 
                    decimal.TryParse((string)val, out decimal result);
                    return result > 12.5m;
                })};
                yield return new List<object> { "some     string", typeof(string), null };
                yield return new List<object> { "  false ", typeof(bool), null };
            }
        }

        [TestCaseSource(nameof(ValidateInputCorrectInputTestCases))]
        public void ValidateInput_CorrectInput_ReturnsTrue(List<object> args)
        {
            var input = (string)args[0];
            var typeToValidate = (Type)args[1];
            var check = (Func<object, bool>)args[2];

            bool result = InputProcessor.ValidInput(input, typeToValidate, check);

            Assert.IsTrue(result);
        }

        private static IEnumerable<List<object>> ValidateInputWrongInputTestCases()
        {
            yield return new List<object> { "1          a2 3", typeof(int), null };
            yield return new List<object> { "        3 ", typeof(int), (Func<object, bool>)((val) =>
                {
                    int.TryParse((string)val, out int result);
                    return result > 10;
                })};
            yield return new List<object> { "   asd ,     5", typeof(decimal), null };
            yield return new List<object> { "     fal       se ", typeof(bool), null };
        }

        [TestCaseSource(nameof(ValidateInputWrongInputTestCases))]
        public void ValidateInput_WrongInput_ReturnsFalse(List<object> args)
        {
            var input = (string)args[0];
            var typeToValidate = (Type)args[1];
            var check = (Func<object, bool>)args[2];

            var result = InputProcessor.ValidInput(input, typeToValidate, check);

            Assert.IsFalse(result);
        }
    }
}
