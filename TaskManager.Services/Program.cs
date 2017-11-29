using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Context;
using TaskManager.Domain.Entities;
using TaskManager.Services.Contract;

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
            ServiceHost service = new ServiceHost(typeof(UserContract));
            service.Open();

            ServiceHost serviceTask = new ServiceHost(typeof(TaskContract));
            serviceTask.Open();

            Console.ReadLine();
        }
    }
}
