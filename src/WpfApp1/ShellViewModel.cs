using System.Diagnostics;
using System.Windows.Threading;
using Caliburn.Micro;

namespace WpfApp1;

public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
{
    public ShellViewModel()
    {
        _timer = new DispatcherTimer(DispatcherPriority.Background) { Interval = TimeSpan.FromSeconds(1) };
        _timer.Tick += Timer_Tick;

        DisplayName = "main window.";
        EnsureItem(new StudentViewModel() { DisplayName = "student sam" });
        EnsureItem(new TeacherViewModel() { DisplayName = "teacher john" });
    }

    private readonly DispatcherTimer _timer;

    public string Message { get; set; } = "";

    private void Timer_Tick(object? sender, EventArgs e)
    {
        Message = Random.Shared.NextDouble().ToString();
    }

    protected override void OnViewLoaded(object view)
    {
        base.OnViewLoaded(view);
        Trace.TraceInformation("OnViewLoaded()");
    }

    protected override async Task OnInitializingAsync(CancellationToken cancellationToken)
    {
        await base.OnInitializingAsync(cancellationToken);
        Trace.TraceInformation("OnInitializingAsync()");
    }

    protected override async Task OnInitializedAsync(CancellationToken cancellationToken)
    {
        await base.OnInitializedAsync(cancellationToken);
        Trace.TraceInformation("OnInitializedAsync()");

        await ActivateItemAsync(Items.First());
    }

    protected override async Task OnActivatingAsync(CancellationToken cancellationToken)
    {
        await base.OnActivatingAsync(cancellationToken);

        Trace.TraceInformation("OnActivatingAsync()");
    }

    protected override async Task OnActivatedAsync(CancellationToken cancellationToken)
    {
        await base.OnActivatedAsync(cancellationToken);

        _timer.Start();
        Trace.TraceInformation("OnActivatedAsync()");
    }

    protected override async Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
    {
        await base.OnDeactivateAsync(close, cancellationToken);

        _timer.Stop();
        Trace.TraceInformation("OnDeactivateAsync()");
    }
}
