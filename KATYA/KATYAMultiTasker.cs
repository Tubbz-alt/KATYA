using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
namespace KATYA
{
    public class KATYAMultiTasker
    {
        public Dictionary<string, KATYATask> AvailableTasks { get; set; }
        public Dictionary<string,string> InstallDirectories { get; set; }
        public KATYAMultiTasker()
        {
            AvailableTasks = new Dictionary<string, KATYATask>();
        }
        public StatusObject AddTask (string TaskName, Action<object> ParameterizedTask, object ParameterizedTaskInput)
        {
            StatusObject SO = new StatusObject();
            try
            {
                KATYATask NewTask = new KATYATask(ParameterizedTask, ParameterizedTaskInput);
                AvailableTasks.Add(TaskName, NewTask);
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "MULTITASKER_ADDTASK");
            }
            return SO;
        }
        public StatusObject AddTask(string TaskName, Action NonParameterizedTask)
        {
            StatusObject SO = new StatusObject();
            try
            {
                KATYATask NewTask = new KATYATask(NonParameterizedTask);
                AvailableTasks.Add(TaskName, NewTask);
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "MULTITASKER_ADDTASK");
            }
            return SO;
        }
        public StatusObject StartTask(string TaskName)
        {
            StatusObject SO = new StatusObject();
            try
            {
                SO = AvailableTasks[TaskName].Start();
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "MULTITASKER_STARTTASK");
            }
            return SO;
        }
        public StatusObject StartAllTasks()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject StopTask(string TaskName)
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject StopAllTasks()
        {
            StatusObject SO = new StatusObject();
            try
            {
                foreach(KeyValuePair<string, KATYATask> AvailableTask in AvailableTasks)
                {
                    AvailableTask.Value.Abort();
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "MULTITASKER_STOPALLTASKS");
            }
            return SO;
        }

        /*Sample Threads*/
        public void TestTask1()
        {
            while (true)
            {
                Console.WriteLine("Thread1");
                Thread.Sleep(1000);
            }
        }
        public void TestTask2()
        {
            while (true)
            {
                Console.WriteLine("Thread2");
                Thread.Sleep(2000);
            }
        }
        public void TestTask3()
        {
            while (true)
            {
                Console.WriteLine("Thread3");
                Thread.Sleep(3000);
            }
        }
        public void NonVoidTask(object Hello)
        {
            while (true)
            {
                //Console.WriteLine("Parameterized Task 1 {0}", Hello);
                Thread.Sleep(500);
            }
            
        }
    }
}
