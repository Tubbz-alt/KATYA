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
        public KATYAMultiTasker()
        {
            this.AvailableThreads = new Dictionary<string, Thread>();
        }
        public StatusObject AddVoidTask(string TaskName, Action VoidFunction)
        {
            StatusObject SO = new StatusObject();
            try
            {
                AvailableThreads.Add(TaskName, new Thread(new ThreadStart(VoidFunction)));
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "MULTITASKER_ADDTASK");
            }
            return SO;
        }
        public StatusObject AddParameterizedTask(string TaskName)
        {
            StatusObject SO = new StatusObject();
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
