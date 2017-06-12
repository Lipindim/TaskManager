using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities.Base;

namespace TaskManager.Domain.Entities
{
    public class Alert: BaseEntity
    {
        public int TaskID { get; set; }
        public int UserID { get; set; }
        public AlertType AlertType { get; set; }
        public bool Delivered { get; set; }

        [ForeignKey("TaskID")]
        public Task Task { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
    }

    public enum AlertType
    {
        Assigned,
        Executed,
        Canceled,
        Expired
    }
}
