using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Helper;
using System.Data.Entity;

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
            //var items = UserRepository.GetItems().Include(x => x.ChildUser).Include(x => x.Manager).ToList();
            return UserRepository.GetItems().Include(x => x.Manager).ToList();
        }

        public void UpdateUser(User newUser)
        {
            User existUser = UserRepository.GetItem(x => x.ID == newUser.ID);
            ReflectionHelper.CopyFields(newUser, existUser, "Password", "Manager");
            UserRepository.SaveChanges();
        }

        public void ChooseBoss(User boss)
        {
            foreach (User user in GetUsers())
            {
                if (user.ID == boss.ID)
                {
                    user.IsBoss = true;
                }
                else
                {
                    user.IsBoss = false;
                    user.ManagerID = null;
                    user.Manager = null;
                }
            }
            UserRepository.SaveChanges();
        }
        public User GetBoss()
        {
            return GetUsers().FirstOrDefault(x => x.IsBoss);
        }
    }
}
