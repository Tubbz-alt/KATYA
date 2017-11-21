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
        public StatusObject AddTask<T>(string TaskName, Func<T> FunctionToPeform)
        {
            StatusObject SO = new StatusObject();
            try
            {
                Task<T> NewTask = new Task<T>(FunctionToPeform);
                NewTask.Start();
            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject AddTask<T>(string TaskName, Func<object, T> TaskToPerform, object TaskParameters)
        {
            StatusObject SO = new StatusObject();
            try
            {
                Task<T> NewTask = new Task<T>(TaskToPerform, TaskParameters);
                NewTask.Start();
            }
            catch (Exception e)
            {

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

        
        public StatusObject TestDelegateToRun()
        {
            StatusObject SO = new StatusObject();
            try
            {
                while (true)
                {
                    Console.WriteLine("hello from testdelegate");
                    Thread.Sleep(500);
                }
            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject TestParameterizedDelegateToRun(object Parameter)
        {
            StatusObject SO = new StatusObject();
            try
            {
                while (true)
                {
                    Console.WriteLine("{0} you", Parameter);
                    Thread.Sleep(250);
                }
            }
            catch (Exception e)
            {

            }
            return SO;
        }
    }
}
