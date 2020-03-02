using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskListRefactored.Models;

namespace TaskListRefactored.Repositories
{
    public class TaskListRepository : ITaskListRepository
    {
        private readonly TaskListDbContext _context;
        public TaskListRepository(TaskListDbContext context)
        {
            _context = context;
        }

        public UserTask GetTask(int taskId)
        {
            return _context.UserTask.FirstOrDefault(t => t.Id == taskId);
        }

        public List<UserTask> GetTasks(string userId)
        {
            return _context.UserTask.Where(u => u.UserId == userId).ToList();
        }

        public void CreateTask(UserTask task)
        {
            _context.UserTask.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(UserTask task)
        {
            _context.UserTask.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            var task = GetTask(taskId);
            _context.UserTask.Remove(task);
            _context.SaveChanges();
        }
    }
}
