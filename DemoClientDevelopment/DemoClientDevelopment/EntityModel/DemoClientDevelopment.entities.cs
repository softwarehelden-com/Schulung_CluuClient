#pragma warning disable
// Cluu Version: 6.0.8



// Dependency-Injection for DemoClientDevelopment.EntityModel
namespace DemoClientDevelopment.EntityModel
{
    using static Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions;
    using static Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions;

    /// <summary>
    /// Adds the cluu entities and actions to the service configuration builder.
    /// </summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal static class CluuEntitiesServiceConfigurationBuilderExtensions
    {
        public static Cluu.Hosting.ICluuServiceConfigurationBuilder TryAddEntityActions(this Cluu.Hosting.ICluuServiceConfigurationBuilder cluu)
        {
            var s = cluu.Services;
            s.TryAddTransient<DemoClientDevelopment.EntityModel.Actions.IGetStreamInvokeAction, DemoClientDevelopment.EntityModel.Actions.GetStreamInvokeAction>();

            return cluu;
        }
    }
}

// Actions for DemoClientDevelopment.EntityModel
namespace DemoClientDevelopment.EntityModel.Actions
{
    using static Cluu.IBackboneProviderInvokeExtensions;

    /// <summary>Abstraction for the GetStreamInvokeAction.</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal interface IGetStreamInvokeAction
    {
        /// <summary>Invokes the action async.</summary>
        System.Threading.Tasks.Task<System.IO.Stream> InvokeAsync(System.Threading.CancellationToken cancellationToken);
    }
   
    /// <summary>DemoClientDevelopment.AddIns.Demo.GetStream</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed class GetStreamInvokeAction : IGetStreamInvokeAction
    {
        private readonly Cluu.Backbone.ICluuBackboneProvider backboneProvider;

        public const string ActionName = "DemoClientDevelopment.AddIns.Demo.GetStream";

        public GetStreamInvokeAction(Cluu.Backbone.ICluuBackboneProvider backboneProvider)
        {
            this.backboneProvider = backboneProvider;
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task<System.IO.Stream> InvokeAsync(System.Threading.CancellationToken cancellationToken)
        {
            return await this.backboneProvider.InvokeWithResponseStreamAsync(ActionName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>Invokes the action async. This method uses Cluu.CluuBackboneAccess.Current which is obsolete. Use dependency injection instead.</summary>
        [System.Obsolete("This method uses Cluu.CluuBackboneAccess.Current which is obsolete. Use dependency injection instead.")]
        public static async System.Threading.Tasks.Task<System.IO.Stream> StaticInvokeAsync(System.Threading.CancellationToken cancellationToken)
        {
            return await Cluu.CluuBackboneAccess.Current.InvokeWithResponseStreamAsync(ActionName, cancellationToken).ConfigureAwait(false);
        }
    }
}

#pragma warning restore
