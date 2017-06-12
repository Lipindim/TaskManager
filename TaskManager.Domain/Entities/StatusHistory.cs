using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities.Base;

namespace TaskManager.Domain.Entities
{
    [DataContract]
    public class StatusHistory: BaseEntity
    {
        [DataMember]
        public int TaskID { get; set; }
        [DataMember]
        public Status Status { get; set; }
        [DataMember]
        public DateTime TimeActivated { get; set; }

        [DataMember]
        [ForeignKey("TaskID")]
        public Task Task { get; set; }
    }
}
