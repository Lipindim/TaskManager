using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Client
{
    public class GlobalSettings
    {
        public static User CurrentUser { get; set; }
    }
}
