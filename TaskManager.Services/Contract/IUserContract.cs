using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Services.Contract
{
    [ServiceContract]
    public interface IUserContract
    {
        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        void AddUser(User newUser);

        [OperationContract]
        void DeleteUser(int id);

        [OperationContract]
        void UpdateUser(User newUser);

        [OperationContract]
        void ChooseBoss(User boss);

        [OperationContract]
        User GetBoss();

        
    }
}
