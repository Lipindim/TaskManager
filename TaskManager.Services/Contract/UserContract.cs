using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Helper;

namespace TaskManager.Services.Contract
{
    public class UserContract : IUserContract
    {
        private Repository<User> userRepository;

        public Repository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new Repository<User>(GlobalSettings.Context);
                }
                return userRepository;
            }

            set
            {
                userRepository = value;
            }
        }

        public void AddUser(User newUser)
        {
            UserRepository.AddItem(newUser);
        }

        public void DeleteUser(int id)
        {
            User user = UserRepository.GetItem(x => x.ID == id);
            UserRepository.RemoveItem(user);
        }

        public User GetUser(int id)
        {
            return UserRepository.GetItem(x => x.ID == id);
        }

        public List<User> GetUsers()
        {
            return UserRepository.GetItems();
        }

        public void UpdateUser(User newUser)
        {
            User existUser = UserRepository.GetItem(x => x.ID == newUser.ID);
            ReflectionHelper.CopyFields(newUser, existUser, "Password", "ManagerID", "Manager");
            UserRepository.SaveChanges();
        }
    }
}
