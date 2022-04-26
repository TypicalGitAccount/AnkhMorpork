using System;
using System.Text.RegularExpressions;

namespace Ankh_Morpork.IO
{
    public class ConsoleInputProcessor : InputProcessor
    {
        internal bool Is(Type typeToValidate, string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            if (typeToValidate == typeof(string))
                return true;
            
            var temp = Activator.CreateInstance(typeToValidate);
            var method = typeToValidate.GetMethod("TryParse",
                new[] 
                {
                    typeof (string),
                    Type.GetType($"{typeToValidate.FullName}&")
                }
            );

            return (bool)method.Invoke(null, new object[] { input, temp });
        }

        public override bool ValidInput(string input, Type typeToValidate, Func<object, bool> check = null)
        {
            if (check == null)
                return Is(typeToValidate, input);
            return Is(typeToValidate, input) && check(input);
        }

        public override string GetInput()
        {
            return Regex.Replace(Console.ReadLine(), @"\s+", "");
        }
    }
}
