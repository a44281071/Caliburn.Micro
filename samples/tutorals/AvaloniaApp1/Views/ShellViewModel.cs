using System;
using System.Collections.Generic;
using System.Text;
using Avalonia12Application1;
using Avalonia12Application1.Views;
using Caliburn.Micro;

namespace AvaloniaApp1;

public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
{
    public ShellViewModel()
    {
        Items.AddRange([new WelcomeViewModel(),new SettingsViewModel()]);
        ActiveItem = Items[0];
    }
}
