using Microsoft.Extensions.Logging;

namespace SampleSolutionTag1.Services;

internal class Calculator : ICalculator
{
    private readonly ILogger<Calculator> logger;

    public Calculator(ILogger<Calculator> logger)
    {
        this.logger = logger;
    }

    int ICalculator.Add(int x, int y)
    {
        int result = x + y;

        this.logger.LogInformation("Add {x} to {y}: {result}", x, y, result);

        return result;
    }

    int ICalculator.Substract(int x, int y)
    {
        int result = x - y;

        this.logger.LogInformation("Substract {y} from {x}: {result}", y, x, result);

        return result;
    }
}