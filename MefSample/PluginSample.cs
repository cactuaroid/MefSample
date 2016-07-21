using MefSample.Modularity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MefSample
{
    public class PluginSample
    {
        public static void Run()
        {
            var manager = new ModuleManager();
            manager.ShowAllModules();
        }
    }

    public class ModuleManager
    {
        [ImportMany]
        IEnumerable<IModule> m_modules = null;

        public ModuleManager()
        {
            MefManager.Container.ComposeParts(this);
        }

        public void ShowAllModules()
        {
            foreach (var module in m_modules)
            {
                Console.WriteLine(module.Name);
            }
        }
    }
}
