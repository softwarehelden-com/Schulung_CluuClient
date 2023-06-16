internal static class Program
{
    public static void Main(string[] args)
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("Hallo Softwarehelden");
        }

        var writer = new TextWriter(new MyConsole());

        writer.Write("Hallo Softwarehelden", 100);
    }

    public interface IConsole
    {
        void WriteLine(string value);
    }

    public class MyConsole : IConsole
    {
        void IConsole.WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }

    public class TextWriter
    {
        private readonly IConsole console;

        public TextWriter(IConsole console)
        {
            this.console = console;
        }

        public void Write(string text, int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.console.WriteLine(text);
            }
        }
    }
}