using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities.Base;

namespace TaskManager.Domain.Entities
{
    [DataContract]
    public class Task: BaseEntity, INotifyPropertyChanged
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public int ExecutorID { get; set; }
        [DataMember]
        public int ManagerID { get; set; }
        [DataMember]
        public int CreatorID { get; set; }
        [DataMember]
        public DateTime TimeCreate { get; set; }
        [DataMember]
        public DateTime TimeStart { get; set; }
        [DataMember]
        public DateTime TimeFinish { get; set; }

        
        private int persentComplete;
        [DataMember]
        public int PersentComplete
        {
            get
            {
                return persentComplete;
            }

            set
            {
                persentComplete = value;
                ChangeActivate("PersentComplete");
            }
        }


        [DataMember]
        public Status CurrentStatus { get; set; }

        private User executor;

        [DataMember]
        [ForeignKey("ExecutorID")]
        public User Executor
        {
            get
            {
                return executor;
            }

            set
            {
                executor = value;
                ChangeActivate("Executor");
            }
        }

        private void ChangeActivate(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [DataMember]
        [ForeignKey("ManagerID")]
        public User Manager { get; set; }

        [DataMember]
        [ForeignKey("CreatorID")]
        public User Creator { get; set; }
        
        [NotMapped]
        public double PassedTime
        {
            get
            {
                return (DateTime.Now - TimeStart).TotalDays / (TimeFinish - TimeStart).TotalDays * 100;
            }
        }
        [NotMapped]
        public bool CreateAccess
        {
            get
            {
                return ID == 0;
            }
        }

        [NotMapped]
        public int AccessorID { get; set; }

        [NotMapped]
        public bool ManagerAccess
        {
            get
            {
                return ManagerID == AccessorID;
            }
        }

        [NotMapped]
        public double Lag
        {
            get
            {
                return PassedTime - PersentComplete;
            }
        }

        

        public Task()
        {
        }

        public Task(bool newTask)
        {
            if (newTask)
            {
                Executor = new User() { FIO = "Выберите исполнителя" };
                TimeStart = DateTime.Now;
                TimeFinish = DateTime.Now.AddDays(1);
                Name = "Заголовок";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChangeStatus()
        {
            if (this.CurrentStatus == Status.Completed || this.CurrentStatus == Status.Canceled)
            {
                return;
            }
            if (TimeStart < DateTime.Now  && DateTime.Now < TimeFinish && this.persentComplete < 100)
            {
                this.CurrentStatus = Status.Executing;
            }
            if (TimeFinish < DateTime.Now && this.PersentComplete < 100)
            {
                this.CurrentStatus = Status.Overdue;
            }
            if (this.PersentComplete >= 100)
            {
                this.CurrentStatus = Status.Completed;
            }
        }
    }


    public enum Status
    {
        Planing,
        Executing,
        Completed,
        Canceled,
        Overdue
    }
}
