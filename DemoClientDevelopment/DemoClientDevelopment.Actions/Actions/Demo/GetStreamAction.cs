using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Cluu.AddIn;

namespace DemoClientDevelopment.Actions.Actions.Demo
{
    /// <summary>
    /// DemoClientDevelopment.AddIns.Demo.GetStream
    /// </summary>
    internal class GetStreamAction : IGetStreamAction
    {
        /// <inheritdoc/>
        Task<Stream> ICluuServerStreamingAction.InvokeAsync(CancellationToken cancellationToken)
        {
            _ = cancellationToken;

            return Task.FromResult<Stream>(
                new MemoryStream(new byte[] { 1, 2, 3 })
            );
        }
    }
}
