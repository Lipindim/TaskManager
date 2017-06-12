using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities.Base;

namespace TaskManager.Domain.Entities
{
    [DataContract]
    public class User: BaseEntity
    {
        [DataMember]
        public string FIO { get; set; }
        [DataMember]
        public string Post { get; set; }
        [DataMember]
        public bool IsManager { get; set; }
        [DataMember]
        public int? ManagerID { get; set; }
        [DataMember]
        public Role Role { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Subdivision { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
    public enum Role
    {
        Admin,
        User
    }
}
