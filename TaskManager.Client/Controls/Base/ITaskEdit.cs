using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Domain.Entities;

namespace TaskManager.Client.Controls.Base
{
    public interface ITaskEdit
    {
        void SelectTask(Task task);
        event Action EditEnd;
    }
}
