using System;

namespace Ankh_Morpork.IO
{
    /// <summary>
    /// Provides output to user
    /// </summary>
    public abstract class OutputProcessor
    {
        public virtual void Output(string data) { throw new NotImplementedException(); }
    }
}
