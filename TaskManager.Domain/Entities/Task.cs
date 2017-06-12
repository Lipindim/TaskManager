﻿using System;
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
    public class Task: BaseEntity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int ExecutorID { get; set; }
        [DataMember]
        public int ManagerID { get; set; }
        [DataMember]
        public int CreatorID { get; set; }
        [DataMember]
        public DateTime TimeStart { get; set; }
        [DataMember]
        public DateTime TimeFinish { get; set; }
        [DataMember]
        public int PersentComplete { get; set; }
        [DataMember]
        public Status CurrentStatus { get; set; }

        [DataMember]
        [ForeignKey("ExecutorID")]
        public User Executor { get; set; }

        [DataMember]
        [ForeignKey("ManagerID")]
        public User Manager { get; set; }

        [DataMember]
        [ForeignKey("CreatorID")]
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
