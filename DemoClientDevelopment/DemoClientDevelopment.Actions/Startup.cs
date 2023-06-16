using Cluu.AddIn;
using Cluu.Hosting;
using Microsoft.Extensions.Hosting;

namespace DemoClientDevelopment.Actions
{
    /// <summary>
    /// Builds the service Provider used by the application.
    /// </summary>
    [CluuAlwaysRunning]
    public class Startup : IStartup
    {
        ///<inheritdoc/>
        void IStartup.ConfigureServices(HostBuilderContext ctx, ICluuServiceConfigurationBuilder cluu)
        {
            // Services des generierten Codes hinzufügen
            cluu.TryAddCluuAddInActions();
        }
    }
}
