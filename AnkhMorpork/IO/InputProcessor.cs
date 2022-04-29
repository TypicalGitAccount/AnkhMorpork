using System;

namespace Ankh_Morpork
{
    /// <summary>
    /// Recieves and validates user input
    /// </summary>
    public abstract class InputProcessor
    {
        public virtual string GetInput() { throw new NotImplementedException(); }
        /// <summary>
        /// To parse given type from string and apply user given lambda
        /// </summary>
        /// <param name="input"></param>
        /// <param name="typeToValidate">Type which is parser from string</param>
        /// <returns>True if input is of given type and matches the lambda</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual bool ValidInput(string input, Type typeToValidate, Func<object, bool> check) { throw new NotImplementedException(); }
    }
}
