using System;
using System.Text.RegularExpressions;

namespace Ankh_Morpork.IO
{
    /// <summary>
    /// Recieve and validate user input from console
    /// </summary>
    public class ConsoleInputProcessor : InputProcessor
    {
        /// <summary>
        /// Try to parse given type from string input
        /// </summary>
        internal bool Is(Type typeToValidate, string input)
        {
            if (typeToValidate == typeof(string))
                return true;
            
            var temp = Activator.CreateInstance(typeToValidate);
            var method = typeToValidate.GetMethod("TryParse",
                new[] 
                {
                    typeof (string),
                    Type.GetType(string.Format("{0}&", typeToValidate.FullName))
                }
            );

            return (bool)method.Invoke(null, new object[] { input, temp });
        }
        /// <summary>
        /// To get and validate user input from string
        /// </summary>
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
