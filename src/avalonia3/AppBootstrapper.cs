using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows;
using Avalonia.Controls.ApplicationLifetimes;
using Caliburn.Micro;

namespace Avalonia3;

public class AppBootstrapper : BootstrapperBase
{
    public AppBootstrapper()
    {
        LogManager.GetLog = type => new DebugLog(type);
        _container = new SimpleContainer();
        _container.Instance(_container);

        Initialize();
    }

    private readonly SimpleContainer _container;

    protected override void OnStartup(object sender, ControlledApplicationLifetimeStartupEventArgs e)
    {
        dynamic settings = new ExpandoObject();
        settings.Width = 800;
        settings.Height = 500;
        (DisplayRootViewFor<ShellViewModel>(settings)).ConfigureAwait(false);
    }

    protected override void Configure()
    {
        _container
            .Singleton<IWindowManager, WindowManager>()
            .Singleton<IEventAggregator, EventAggregator>();

        _container
            .PerRequest<ShellViewModel>();
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
