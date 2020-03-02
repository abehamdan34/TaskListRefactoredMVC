using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskListRefactored.Models;
using TaskListRefactored.Repositories;

namespace TaskListRefactored.Controllers
{
    public class TaskListController : Controller
    {
        //taking the context and turning it into a repo and calling the repo for readability for larger projects (Best Practice)
        //repos contain all the methods for the controllers to allow the controllers to only contain Iactionresults.
        private readonly ITaskListRepository _taskListRepository;
        public TaskListController(ITaskListRepository taskListRepository)
        {
            _taskListRepository = taskListRepository;
        }

        public IActionResult Index()
        {
            var user = User.Identity.Name;
            return View(_taskListRepository.GetTasks(User.Identity.Name));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new UserTask();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(UserTask task)
        {
            var user = User.Identity.Name;
            task.UserId = user;

            _taskListRepository.CreateTask(task);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int taskId)
        {
            var task = _taskListRepository.GetTask(taskId);
            return View(task);
        } 

        [HttpPost]
        public IActionResult Edit(UserTask task)
        {
            _taskListRepository.UpdateTask(task);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int taskId)
        {
            _taskListRepository.DeleteTask(taskId);
            return RedirectToAction("Index");
        }
    }
}