using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Http.Results;
using System.Web.Http;
using TaskManager.Service.Controllers;
using TaskManager.Model;

namespace TaskManager.Test
{
    public class TaskManagerControllerTest
    {

        [Test]
        public void Test_GetAllTasks()
        {
            TaskManagerController tc = new TaskManagerController();
            var result = tc.GetAllTasks();
            var actual = result as OkNegotiatedContentResult<List<Task>>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }

        [Test]
        public void Test_GetTaskByID()
        {
            TaskManagerController tc = new TaskManagerController();
            IHttpActionResult result = tc.GetTaskByID("935aa37e-d2e4-4beb-8114-da47f033c507");
            var actual = result as OkNegotiatedContentResult<Task>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }


        [Test]
        public void Test_PostTask()
        {
            TaskManagerController tc = new TaskManagerController();
            Task taskToAdd = new Task();
            taskToAdd.Task_Name = "Task from Unit Test Project";
            taskToAdd.Priority = 50;
            taskToAdd.Start_Date = DateTime.Now;
            taskToAdd.End_Date = DateTime.Now.AddDays(2);
            taskToAdd.Status = 1;
            IHttpActionResult result = tc.PostTask(taskToAdd);
            var actual = result as OkNegotiatedContentResult<Task>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }

        [Test]
        public void Test_UpdateTask()
        {
            TaskManagerController tc = new TaskManagerController();
            Task taskToAdd = new Task();
            taskToAdd.Task_ID = "935aa37e-d2e4-4beb-8114-da47f033c507";
            taskToAdd.Task_Name = "Task updated from API Unit Test Project";
            taskToAdd.Priority = 50;
            taskToAdd.Start_Date = DateTime.Now;
            taskToAdd.End_Date = DateTime.Now.AddDays(5);
            taskToAdd.Status = 1;
            IHttpActionResult result = tc.UpdateTask(taskToAdd);
            var actual = result as OkNegotiatedContentResult<Task>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }

        [Test]
        public void Test_DeleteTask()
        {
            TaskManagerController tc = new TaskManagerController();
            IHttpActionResult result = tc.DeleteTask("43d098a9-6627-4b25-bbf8-fc22093727da");
            var actual = result as OkNegotiatedContentResult<bool>;
            Assert.AreEqual(actual.Content, true);
        }
    }
}
