#pragma warning disable
// Cluu Version: 6.0.8

using Cluu.AddIn;
using Cluu.Hosting;
using DemoClientDevelopment.Actions.Actions.Demo;

namespace DemoClientDevelopment.Actions
{
    /// <summary>
    /// Adds the cluu add ins to the service configuration builder.
    /// </summary>
    internal static class CluuAddInActionServiceConfigurationBuilderExtensions
    {
        public static ICluuServiceConfigurationBuilder TryAddCluuAddInActions(this ICluuServiceConfigurationBuilder cluu)
        {
            cluu.TryAddCluuServerStreamingAction<IGetStreamAction, GetStreamAction>("DemoClientDevelopment.AddIns.Demo.GetStream");

            return cluu;
        }
    }

    /// <summary>DemoClientDevelopment.AddIns.Demo.GetStream</summary>
    internal interface IGetStreamAction : ICluuServerStreamingAction
    {
    }



}
#pragma warning restore
