using MefSample.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MefSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MefManager.Initialize();

            Console.WriteLine("#1 Dependency Injection Sample");
            DependencyInjectionSample.Run();

            Console.WriteLine();
            Console.WriteLine("#2 Plugin Sample");
            PluginSample.Run();
        }
    }
}
