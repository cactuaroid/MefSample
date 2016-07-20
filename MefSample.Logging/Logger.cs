using System;
using System.ComponentModel.Composition;
using System.Runtime.CompilerServices;

namespace MefSample.Logging
{
    [Export]
    public class Logger
    {
        public void Info(string content, [CallerMemberName]string caller = "")
        {
            Write("Info: " + caller + ": " + content);
        }

        public void Error(string content, [CallerMemberName]string caller = "")
        {
            Write("Error: " + caller + ": " + content);
        }

        private void Write(string content)
        {
            Console.WriteLine(DateTime.Now + " " + content);
        }
    }
}
