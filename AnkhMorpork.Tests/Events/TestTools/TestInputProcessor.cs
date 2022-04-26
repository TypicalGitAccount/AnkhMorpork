using Ankh_Morpork.IO;
using System.Collections.Generic;
using System;

namespace Ankh_Morpork.Tests.Events
{
    public class TestInputProcessor : ConsoleInputProcessor
    {
        private List<string> preparedInput = new List<string>();
        private int preparedInputCurIndex = 0;

        public void AddUserInput(string input)
        {
            preparedInput.Add(input);
        }

        public override string GetInput()
        {
            if (preparedInputCurIndex == preparedInput.Count)
                throw new IndexOutOfRangeException("No more input prepared!\n");

            return preparedInput[preparedInputCurIndex++];
        }
    }
}
