using System;

namespace Ankh_Morpork
{
    public abstract class InputProcessor
    {
        public virtual string GetInput() { throw new NotImplementedException(); }
        public virtual bool ValidInput(string input, Type typeToValidate, Func<object, bool> check) { throw new NotImplementedException(); }
    }
}
