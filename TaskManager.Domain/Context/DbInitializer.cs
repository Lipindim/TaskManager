using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Context
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<TaskManagerContext>
    {
        protected override void Seed(TaskManagerContext context)
        {
            base.Seed(context);

            context.Users.AddRange(new List<User>()
            {
                new User() {FIO = "Липин Дмитрий Николаевич", Login = "LipinDN", IsManager = true, Password = "123456", Role = Role.Admin },//1
                new User() {FIO = "Иванов Иван Иванович", Login = "IvanonII", IsManager = true, Password = "123456", Role = Role.User, ManagerID = 1 }//2
            });
            context.SaveChanges();

            context.Tasks.AddRange(new List<Entities.Task>()
            {
                new Entities.Task() {CreatorID = 1, CurrentStatus = Status.Planing, ExecutorID = 2, ManagerID = 1, Name = "Сделать репозитории", TimeStart = DateTime.Now.AddDays(1), TimeFinish = DateTime.Now.AddDays(7)}
            });
            context.SaveChanges();

            context.Comments.Add(new Comment()
            {
                TaskID = 1,
                UserID = 1,
                Text = "Сделай это!",
                TimeCreated = DateTime.Now
            });

            context.StatusHistories.Add(new StatusHistory()
            {
                TaskID = 1,
                TimeActivated = DateTime.Now,
                Status = Status.Planing
            });

            context.Alerts.Add(new Alert()
            {
                AlertType = AlertType.Assigned,
                Delivered = false,
                TaskID = 1,
                UserID = 2
            });

            context.SaveChanges();
            
            
        }
    }
}
