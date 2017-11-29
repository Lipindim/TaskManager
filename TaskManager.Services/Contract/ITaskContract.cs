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
        [OperationContract]
        Task GetTask(int taskID);

        [OperationContract]
        List<Task> GetTasks(int userId);

        [OperationContract]
        void AddTask(Task newTask);

        [OperationContract]
        void CancelTask(int taskID);

        [OperationContract]
        void ChangePercentComplete(int taskID, int percent);

        [OperationContract]
        void AddComment(string text, int taskID, int userID);

        [OperationContract]
        List<Comment> GetComments(int taskID);

        [OperationContract]
        List<Alert> GetAlerts(int userID);

        [OperationContract]
        List<StatusHistory> GetStatusHistories(int taskID);
    }
}
