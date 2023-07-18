using System.Windows;

namespace SampleSolutionWpf.Services;

public interface IWindowFactory<T> where T : Window
{
    T Create();
}
