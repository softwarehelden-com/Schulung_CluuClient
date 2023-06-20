using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleSolutionTag1.Services;

internal class ConsoleIntInputReader : IIntInputReader
{
    async Task<int> IIntInputReader.ReadAsync(CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync("Zahl eingeben:");

        string inputAsString = await Console.In.ReadLineAsync().ConfigureAwait(false);

        return int.TryParse(inputAsString, out int value) ? value : 0;
    }
}