using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using TaskManager.Domain.Entities;

namespace TaskManager.Services.Contract
{
    [ServiceContract]
    public interface ITaskContract
    {
        Task GetTask(int taskID);
        List<Task> GetTasks(int userId);
        void AddTask(Task newTask);
        void CancelTask(int taskID);
        void ChangePercentComplete(int taskID, int percent);
        void AddComment(string text, int taskID, int userID);
        List<Comment> GetComments(int taskID);
        List<Alert> GetAlerts(int userID);
        List<StatusHistory> GetStatusHistories(int taskID);
    }
}
