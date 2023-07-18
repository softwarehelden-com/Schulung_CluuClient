namespace WinFormsThreadingDemo;

internal class CalcService : ICalcService
{
    async Task<double> ICalcService.SqrtAsync(double number)
    {
        // UI-Hänger durch Synchronous Completion
        //await Task.CompletedTask.ConfigureAwait(false);

        //Thread.Sleep(5000);

        await Task.Delay(1000).ConfigureAwait(false);

        return Math.Sqrt(number);
    }
}
