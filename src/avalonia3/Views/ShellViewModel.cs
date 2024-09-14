using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Avalonia3;
public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
{
    public ShellViewModel()
    {
        EnsureItem(new StudentViewModel { DisplayName = "stu sam." });
        EnsureItem(new TeacherViewModel { DisplayName = "teacher john." });

        ActiveItem = Items[0];
    }
}
