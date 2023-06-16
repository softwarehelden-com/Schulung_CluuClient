namespace WinFormsThreadingDemo;

public interface ICalcService
{
    Task<double> SqrtAsync(double number);
}
