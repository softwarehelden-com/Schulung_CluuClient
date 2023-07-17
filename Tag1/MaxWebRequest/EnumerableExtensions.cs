using System.Collections.Concurrent;

namespace MaxWebRequest;

internal static class EnumerableExtensions
{
    public static async Task ForEachAsync<T>(this IEnumerable<T> source, int dop, Func<T, Task> body, CancellationToken cancellationToken)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (body == null)
        {
            throw new ArgumentNullException(nameof(body));
        }

        async Task run(IEnumerator<T> partition, CancellationToken ct)
        {
            using (partition)
            {
                while (partition.MoveNext())
                {
                    await body(partition.Current).ConfigureAwait(false);

                    ct.ThrowIfCancellationRequested();
                }
            }
        }

        await Task.WhenAll(
            from partition in Partitioner.Create(source).GetPartitions(dop)
            select run(partition, cancellationToken)
        ).ConfigureAwait(false);
    }
}
