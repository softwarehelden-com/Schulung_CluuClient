namespace WinFormsCluuDemo.Hosting;

public interface IFormFactory<T> where T : Form
{
    T Create();
}
