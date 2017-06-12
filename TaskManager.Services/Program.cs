using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Context;
using TaskManager.Domain.Entities;

namespace TaskManager.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlConnection connection = new SqlConnection("Data source = Admin-PC\\SQLEXPRESS; Integrated security = true");
            //SqlCommand command = new SqlCommand("create database TaskManager", connection);
            //connection.Open();
            //command.ExecuteNonQuery();
            //connection.Close();
            TaskManagerContext context = new TaskManagerContext("Data source = Admin-PC\\SQLEXPRESS; Database = TaskManager; Integrated security = true");
            //SqlConnection connection = new SqlConnection("Data source = Admin-PC\\SQLEXPRESS; Integrated security = true");
            //connection.Open();
            //connection.Close();

            Repository<User> repUser = new Repository<User>(context);
            repUser.AddItem(new User()
            {
                FIO = "Пингвин",
                Login = "Pingvin"
            });

            var users = context.Users.ToList();
            foreach (var user in users)
            {
                Console.WriteLine(user.FIO);
            }
            Console.ReadLine();
        }
    }
}
