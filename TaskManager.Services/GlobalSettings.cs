using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Context;

namespace TaskManager.Services
{
    public static class GlobalSettings
    {
        public static TaskManagerContext Context
        {
            get
            {
                return new TaskManagerContext("Data source = Admin-PC\\SQLEXPRESS; Database = TaskManager; Integrated security = true");
            }
        }
    }
}
