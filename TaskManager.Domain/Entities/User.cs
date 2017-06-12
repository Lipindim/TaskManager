using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities.Base;

namespace TaskManager.Domain.Entities
{
    public class User: BaseEntity
    {
        public string FIO { get; set; }
        public string Post { get; set; }
        public bool IsManager { get; set; }
        public int? ManagerID { get; set; }
        public Role Role { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Subdivision { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public enum Role
    {
        Admin,
        User
    }
}
