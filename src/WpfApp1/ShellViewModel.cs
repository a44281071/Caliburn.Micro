using System.Diagnostics;
using System.Windows.Threading;
using Caliburn.Micro;

namespace WpfApp1;

public class ShellViewModel : Screen, IShell
{
    public ShellViewModel()
    {
        timer = new DispatcherTimer(DispatcherPriority.Background) { Interval = TimeSpan.FromSeconds(1) };
        timer.Tick += Timer_Tick;

        DisplayName = "main window.";
    }

    private readonly DispatcherTimer timer;

    public string Message { get; set; } = "";

    private void Timer_Tick(object? sender, EventArgs e)
    {
        Message = Random.Shared.NextDouble().ToString();
    }
    protected override Task OnInitializingAsync(CancellationToken cancellationToken)
    {
        return base.OnInitializingAsync(cancellationToken);
    }
    protected override async Task OnActivatingAsync(CancellationToken cancellationToken)
    {
        await base.OnActivatingAsync(cancellationToken);

        Trace.TraceInformation("OnActivatingAsync()");
    }

    protected override async Task OnActivatedAsync(CancellationToken cancellationToken)
    {
        await base.OnActivatedAsync(cancellationToken);

        timer.Start();
        Trace.TraceInformation("OnActivatingAsync()");
    }

    protected override async Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
    {
        await base.OnDeactivateAsync(close, cancellationToken);

        timer.Stop();
        Trace.TraceInformation("OnDeactivateAsync()");
    }
}
