<Query Kind="Statements">
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <IncludeWinSDK>true</IncludeWinSDK>
</Query>

var intHolder = new AsyncLocal<int>();

intHolder.Value = 1;

await DoSomeWorkWithAwaitAsync();

intHolder.Value.Dump(); // 1

await TunnelTaskAsync();

intHolder.Value.Dump(); // 2

async Task DoSomeWorkWithAwaitAsync()
{
    intHolder.Value.Dump(); // 1

    intHolder.Value = 2;

    await Task.Delay(100);
}

Task TunnelTaskAsync()
{
    intHolder.Value.Dump(); // 1

    intHolder.Value = 2;

    return Task.Delay(100);
}