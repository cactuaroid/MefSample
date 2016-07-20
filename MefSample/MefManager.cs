using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace MefSample
{
    public class MefManager
    {
        public static CompositionContainer Container { get; private set; }

        public static void Initialize()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(Path.GetDirectoryName(typeof(Program).Assembly.Location)));

            //Create the CompositionContainer with the parts in the catalog
            Container = new CompositionContainer(catalog);
        }
    }
}
