using System;

namespace Ankh_Morpork.IO
{
    public abstract class OutputProcessor
    {
        public virtual void Output(string data) { throw new NotImplementedException(); }
    }
}
