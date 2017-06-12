using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities.Base;

namespace TaskManager.Domain.Entities
{
    public class StatusHistory: BaseEntity
    {
        public int TaskID { get; set; }
        public Status Status { get; set; }
        public DateTime TimeActivated { get; set; }

        [ForeignKey("TaskID")]
        public Task Task { get; set; }
    }
}
