using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using TaskManager.Model;
using TaskManager.Service.Controllers;

namespace TaskManager.Test.Controllers
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
            IHttpActionResult result = tc.GetTaskByID("17677100-7c23-47a5-ad97-9004318d400e");
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
            taskToAdd.Task_ID = "17677100-7c23-47a5-ad97-9004318d400e";
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
            IHttpActionResult result = tc.DeleteTask("a46a3531-594c-4f55-9a2a-060fa0f43e5f");
            var actual = result as OkNegotiatedContentResult<bool>;
            Assert.AreEqual(actual.Content, true);
        }
    }
}
