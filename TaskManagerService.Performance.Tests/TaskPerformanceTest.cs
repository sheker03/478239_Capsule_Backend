using System;
using NBench;
using TaskManagerService.API;
using TaskManagerService.API.Controllers;
using TaskManagerService.Model;

namespace TaskManagerService.Performance.Tests
{

    public class TaskPerformanceTest
    {

        [PerfBenchmark(Description = "Performace Test for GET", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestTaskCounter")]
        public void GetAllTasks_PassingTest()
        {
            TaskManagerController controller = new TaskManagerController();
            controller.GetAllTasks();
        }

        [PerfBenchmark(Description = "Performace Test for GET (By ID)", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestTaskCounter")]
        public void GetTaskByID_PassingTest()
        {
            TaskManagerController tc = new TaskManagerController();
            tc.GetTaskByID("17677100-7c23-47a5-ad97-9004318d400e");
        }

        [PerfBenchmark(Description = "Performace Test for POST", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestTaskCounter")]
        public void PostTask_PassingTest()
        {
            TaskManagerController tc = new TaskManagerController();
            Task taskToAdd = new Task()
            {
                Task_Name = "Task from Unit Test Project",
                Priority = 50,
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddDays(2),
                Status = 1
            };
            tc.PostTask(taskToAdd);

        }

        [PerfBenchmark(Description = "Performace Test for UPDATE", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestTaskCounter")]
        public void UpdateTask_PassingTest()
        {
            TaskManagerController tc = new TaskManagerController();
            Task taskToAdd = new Task();
            taskToAdd.Task_ID = "17677100-7c23-47a5-ad97-9004318d400e";
            taskToAdd.Task_Name = "Task from Unit Test Project";
            taskToAdd.Priority = 50;
            taskToAdd.Start_Date = DateTime.Now;
            taskToAdd.End_Date = DateTime.Now.AddDays(5);
            tc.UpdateTask(taskToAdd);

        }
    }
}
