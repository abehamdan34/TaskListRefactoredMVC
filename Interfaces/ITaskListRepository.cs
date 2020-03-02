using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskListRefactored.Models;

namespace TaskListRefactored
{
    public interface ITaskListRepository
    {
        UserTask GetTask(int taskId);
        List<UserTask> GetTasks(string userId);
        void CreateTask(UserTask task);
        void UpdateTask(UserTask task);
        void DeleteTask(int taskId);
    }
}
