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
    public class Comment: BaseEntity
    {
        [DataMember]
        public int TaskID { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public DateTime TimeCreated { get; set; }

        [DataMember]
        [ForeignKey("TaskID")]
        public Task Task { get; set; }

        [DataMember]
        [ForeignKey("UserID")]
        public User User { get; set; }

        public override string ToString()
        {
            return $"{User.FIO} ({TimeCreated.ToString("dd.MM.yyyy HH:mm")}) \n {Text}";
        }
    }
}
