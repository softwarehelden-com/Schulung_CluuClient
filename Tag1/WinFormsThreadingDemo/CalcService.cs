namespace WinFormsThreadingDemo;

internal class CalcService : ICalcService
{
    async Task<double> ICalcService.SqrtAsync(double number)
    {
        // Thread.Sleep(1000);

        await Task.Delay(1000).ConfigureAwait(false);

        return Math.Sqrt(number);
    }
}
