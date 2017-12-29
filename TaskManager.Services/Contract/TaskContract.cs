using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using TaskManager.Domain.Entities;
using TaskManager.Helper;

namespace TaskManager.Services.Contract
{
    public class TaskContract : ITaskContract
    {

        private Repository<Task> taskRepository;
        public Repository<Task> TaskRepository
        {
            get
            {
                if (taskRepository == null)
                {
                    taskRepository = new Repository<Task>(GlobalSettings.Context);
                }
                return taskRepository;
            }

            set
            {
                taskRepository = value;
            }
        }

        private Repository<Alert> alertRepository;
        public Repository<Alert> AlertRepository
        {
            get
            {
                if (alertRepository == null)
                {
                    alertRepository = new Repository<Alert>(GlobalSettings.Context);
                }
                return alertRepository;
            }

            set
            {
                alertRepository = value;
            }
        }

        private Repository<Comment> commentRepository;
        public Repository<Comment> CommentRepository
        {
            get
            {
                if (commentRepository == null)
                {
                    commentRepository = new Repository<Comment>(GlobalSettings.Context);
                }
                return commentRepository;
            }

            set
            {
                commentRepository = value;
            }
        }

        private Repository<StatusHistory> statusHistoryRepository;
        public Repository<StatusHistory> StatusHistoryRepository
        {
            get
            {
                if (statusHistoryRepository == null)
                {
                    statusHistoryRepository = new Repository<StatusHistory>(GlobalSettings.Context);
                }
                return statusHistoryRepository;
            }

            set
            {
                statusHistoryRepository = value;
            }
        }

        public UserContract UserContract
        {
            get
            {
                if (userContract == null)
                {
                    userContract = new UserContract();
                }
                return userContract;
            }

            set
            {
                userContract = value;
            }
        }
        private UserContract userContract;

        public void AddComment(string text, int taskID, int userID)
        {
            CommentRepository.AddItem(new Comment()
            {
                TaskID = taskID,
                Text = text,
                UserID = userID,
                TimeCreated = DateTime.Now
            });
        }

        public void AddTask(Task newTask)
        {
            newTask.ManagerID = newTask.Manager.ID;
            newTask.CreatorID = newTask.Creator.ID;
            newTask.ExecutorID = newTask.Executor.ID;
            newTask.Manager = null;
            newTask.Executor = null;
            newTask.Creator = null;
            TaskRepository.AddItem(newTask);
        }

        public void CancelTask(int taskID)
        {
            Task task = TaskRepository.GetItem(x => x.ID == taskID);
            task.CurrentStatus = Status.Canceled;
            taskRepository.SaveChanges();

            CreateAlert(AlertType.Canceled, taskID, task.ExecutorID, task.ManagerID);
        }

        public void ChangePercentComplete(int taskID, int percent)
        {
            Task task = TaskRepository.GetItem(x => x.ID == taskID);
            task.PersentComplete = percent;
            TaskRepository.SaveChanges();

            if (percent >= 100)
            {
                CreateAlert(AlertType.Executed, taskID, task.CreatorID, task.ManagerID);
            }
        }

        public List<Comment> GetComments(int taskID)
        {
            return CommentRepository.GetItems().Include(x => x.User).Where(x => x.TaskID == taskID).ToList();
        }

        public Task GetTask(int taskID)
        {
            return TaskRepository.GetItem(x => x.ID == taskID);
        }

        public List<Task> GetTasks(int userId)
        {
            List<Task> tasks = TaskRepository.GetItems().Include(x => x.Manager).Include(x => x.Creator).Include(x => x.Executor).Where(x => x.ManagerID == userId || x.ExecutorID == userId || x.CreatorID == userId).ToList();
            foreach (var task in tasks)
            {
                Status oldStatus = task.CurrentStatus;
                task.ChangeStatus();
                if (oldStatus != task.CurrentStatus)
                {
                    StatusHistoryRepository.AddItem(new StatusHistory()
                    {
                        Status = task.CurrentStatus,
                        TaskID = task.ID,
                        TimeActivated = DateTime.Now
                    });
                }
            }
            TaskRepository.SaveChanges();
            return tasks;
        }

        public void CreateAlert(AlertType alertType, int taskID, params int[] usersID)
        {
            foreach (var userID in usersID.Distinct())
            {
                AlertRepository.AddItem(new Alert()
                {
                    AlertType = AlertType.Executed,
                    TaskID = taskID,
                    UserID = userID
                });
            } 
        }

        public List<Alert> GetAlerts(int userID)
        {
            List<Alert> alerts = AlertRepository.GetItems(x => x.UserID == userID && !x.Delivered);
            foreach (var alert in alerts)
            {
                alert.Delivered = true;
            }
            AlertRepository.SaveChanges();
            return alerts;
        }

        public List<StatusHistory> GetStatusHistories(int taskID)
        {
            return StatusHistoryRepository.GetItems(x => x.TaskID == taskID);
        }

        public void UpdateTask(Task currentTask)
        {
            Task existTask = GetTask(currentTask.ID);
            ReflectionHelper.CopyFields(currentTask, existTask,"Executor", "Creator", "Manager");
            TaskRepository.SaveChanges();
        }
    }
}
