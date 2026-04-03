using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace AvaloniaApp1;

public class AppBootstrapper : BootstrapperBase
{
    public AppBootstrapper()
    {
        LogManager.GetLog = type => new DebugLog(type);
        _container = new SimpleContainer();
        _container.Instance(_container);

        Initialize();
        InitializeAsync();
    }

    private readonly SimpleContainer _container;

    private async void InitializeAsync()
    {
        await DisplayRootViewFor<ShellViewModel>();
    }

    protected override void Configure()
    {
        _container
            .Singleton<IWindowManager, WindowManager>()
            .Singleton<IEventAggregator, EventAggregator>();

        _container.PerRequest<ShellViewModel>();
    }

    protected override object GetInstance(Type service, string key)
    {
        return _container.GetInstance(service, key);
    }

    protected override IEnumerable<object> GetAllInstances(Type service)
    {
        return _container.GetAllInstances(service);
    }

    protected override void BuildUp(object instance)
    {
        _container.BuildUp(instance);
    }
}
