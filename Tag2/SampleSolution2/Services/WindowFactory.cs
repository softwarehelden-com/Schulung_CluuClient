using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace SampleSolutionWpf.Services;

internal class WindowFactory<T> : IWindowFactory<T> where T : Window
{
    private readonly IServiceProvider serviceProvider;

    public WindowFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    T IWindowFactory<T>.Create()
    {
        return ActivatorUtilities.CreateInstance<T>(this.serviceProvider);
    }
}
