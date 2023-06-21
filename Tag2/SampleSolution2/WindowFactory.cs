using System.Windows;

namespace SampleSolutionWpf;

public delegate T WindowFactory<T>() where T : Window;
