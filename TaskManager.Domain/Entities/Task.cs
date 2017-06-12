using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities.Base;

namespace TaskManager.Domain.Entities
{
    public class Task: BaseEntity
    {
        public string Name { get; set; }
        public int ExecutorID { get; set; }
        public int ManagerID { get; set; }

        [ForeignKey("Creator")]
        public int CreatorID { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeFinish { get; set; }
        public int PersentComplete { get; set; }
        public Status CurrentStatus { get; set; }

        [ForeignKey("ExecutorID")]
        public User Executor { get; set; }
        [ForeignKey("ManagerID")]
        public User Manager { get; set; }
        
        public User Creator { get; set; }
    }

    public enum Status
    {
        Planing,
        Executing,
        Completed,
        Canceled,
        Ovedue
    }
}
