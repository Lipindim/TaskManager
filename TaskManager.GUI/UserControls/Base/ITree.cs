using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.GUI.UserControls.Base
{
    public interface ITree
    {
        void ChooseBoss(User boss);
        void addChildUser(User childUser);
        void deleteChildUser();
        List<User> UserList { get; set; }
    }
}
