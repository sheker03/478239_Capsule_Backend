using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using TaskManager.Model;
using TaskManager.Service.Controllers;

namespace TaskManagerService.Test
{
    class TaskManagerControllerTest
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
            IHttpActionResult result = tc.GetTaskByID("ae55aae0-27fc-4951-b179-4b6779560855");
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
            taskToAdd.Task_ID = "ae55aae0-27fc-4951-b179-4b6779560855";
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
            IHttpActionResult result = tc.DeleteTask("60153446-f072-4d23-af32-845e80d45ea9");
            var actual = result as OkNegotiatedContentResult<bool>;
            Assert.AreEqual(actual.Content, true);
        }
    }
}
