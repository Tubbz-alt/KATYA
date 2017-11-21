using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace KATYA
{
    public class KATYAMultiThreader
    {
        public Dictionary<string, KATYAThread> AvailableThreads { get; set; }
        public KATYAMultiThreader()
        {
            this.AvailableThreads = new Dictionary<string, KATYAThread>();
        }
        public StatusObject AddThread(string ThreadName, Action NonParameterizedThread)
        {
            StatusObject SO = new StatusObject();
            try
            {
                KATYAThread NewThread = new KATYAThread(NonParameterizedThread);
                AvailableThreads.Add(ThreadName, NewThread);
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "MULTITHREADER_ADDTHREAD");
            }
            return SO;
        }
        public StatusObject AddThread(string ThreadName, Action<object> ParameterizedThread, object ParameterizedThreadInput)
        {
            StatusObject SO = new StatusObject();
            try
            {
                KATYAThread NewThread = new KATYAThread(ParameterizedThread, ParameterizedThreadInput);
                AvailableThreads.Add(ThreadName, NewThread);
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "MULTITHREADER_ADDTHREAD");
            }
            return SO;
        }
        public StatusObject StartThread(string ThreadName)
        {
            StatusObject SO = new StatusObject();
            try
            {
                SO = AvailableThreads[ThreadName].Start();
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "MULTITHREADER_STARTTHREAD");
            }
            return SO;
        }
        public StatusObject StartThreads(string ThreadNames, char Delimiter)
        {
            StatusObject SO = new StatusObject();
            try
            {
                List<string> ThreadNameList = ThreadNames.Split(Delimiter).ToList();
                Dictionary<string, StatusObject> ThreadStartStatuses = new Dictionary<string, StatusObject>();
                foreach(string ThreadName in ThreadNameList)
                {
                    AvailableThreads[ThreadName].Start();
                }
                SO.UDDynamic = ThreadStartStatuses;
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "MULTITHREADER_STARTTHREADS");
            }
            return SO;
        }
        public StatusObject StartAllThreads()
        {
            StatusObject SO = new StatusObject();
            try
            {
                Dictionary<string, StatusObject> ThreadStartStatuses = new Dictionary<string, StatusObject>();
                foreach(KeyValuePair<string, KATYAThread> AvailableThread in AvailableThreads)
                {
                    AvailableThread.Value.Start();
                }
                SO.UDDynamic = ThreadStartStatuses;
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "MULTITHREADER_STARTALLTHREADS");
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
                Console.WriteLine("Parameterized Task 1 {0}", Hello);
                Thread.Sleep(500);
            }
        }
    }
}
