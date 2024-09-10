using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Caliburn.Micro;

namespace WpfApp1
{
    internal class StudentViewModel : Screen
    {
        public StudentViewModel()
        {
            _timer = new DispatcherTimer(DispatcherPriority.Background) { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += Timer_Tick;
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
            Trace.TraceInformation("StudentViewModel.OnViewLoaded()");
        }

        protected override async Task OnInitializingAsync(CancellationToken cancellationToken)
        {
            await base.OnInitializingAsync(cancellationToken);
            Trace.TraceInformation("StudentViewModel.OnInitializingAsync()");
        }

        protected override async Task OnInitializedAsync(CancellationToken cancellationToken)
        {
            await base.OnInitializedAsync(cancellationToken);
            Trace.TraceInformation("StudentViewModel.OnInitializedAsync()");
        }

        protected override async Task OnActivatingAsync(CancellationToken cancellationToken)
        {
            await base.OnActivatingAsync(cancellationToken);

            Trace.TraceInformation("StudentViewModel.OnActivatingAsync()");
        }

        protected override async Task OnActivatedAsync(CancellationToken cancellationToken)
        {
            await base.OnActivatedAsync(cancellationToken);

            _timer.Start();
            Trace.TraceInformation("StudentViewModel.OnActivatedAsync()");
        }

        protected override async Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            await base.OnDeactivateAsync(close, cancellationToken);

            _timer.Stop();
            Trace.TraceInformation("StudentViewModel.OnDeactivateAsync()");
        }
    }
}
