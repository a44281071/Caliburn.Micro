using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Avalonia3;

public class StudentViewModel : Screen
{
    private string? stuName;

    public string? StuName { get => stuName; set => Set(ref stuName, value); }

    public async Task RandomName()
    {
        await Task.Delay(100);
        StuName = Random.Shared.NextDouble().ToString();
    }

    public void ClearName() =>
        StuName = "";
}