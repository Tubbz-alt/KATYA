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
        public Dictionary<string,Thread> AvailableThreads { get; set; }
        public Dictionary<string,Thread> AvailableParameterizedThreads { get; set; }
        public Dictionary<string,string> InstallDirectories { get; set; }
        public KATYAMultiTasker()
        {
            try
            {
                this.AvailableThreads = new Dictionary<string, Thread>();
                this.AvailableParameterizedThreads = new Dictionary<string, Thread>();
            }
            catch(Exception e)
            {
                this.AvailableThreads = new Dictionary<string, Thread>();
                this.AvailableParameterizedThreads = new Dictionary<string, Thread>();
            }
        }
        public StatusObject AddTask(Action<object> Task, object Input)
        {
            StatusObject SO = new StatusObject();
            try
            {
                Thread NewTask = new Thread(new ParameterizedThreadStart(Task));
                NewTask.Start(Input);
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "MULTITASKER_ADDTASK_01");
            }
            return SO;
        }
        public StatusObject AddTask(Action Task)
        {
            StatusObject SO = new StatusObject();
            try
            {
                Thread NewTask = new Thread(new ThreadStart(Task));
                NewTask.Start();
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "MULTITASKER_ADDTASK_02");
            }
            return SO;
        }
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
                Console.WriteLine("Parameterized Task 1 {0}", Hello);
                Thread.Sleep(500);
            }
            
        }
        public StatusObject StartAllThreads()
        {
            StatusObject SO = new StatusObject();
            try
            {
                foreach (KeyValuePair<string, Thread> AvailableThread in AvailableThreads)
                {
                    AvailableThread.Value.Start();
                }
            }
            catch(Exception e)
            {

            }
            return SO;
        }
    }
}
