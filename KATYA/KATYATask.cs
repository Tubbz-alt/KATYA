using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace KATYA
{
    public class KATYATask
    {
        private Action<object> ParameterizedTask { get; set; }
        private Action NonParameterizedTask { get; set; }
        private object ParameterizedTaskInput { get; set; }
        public bool IsParameterized { get; private set; }
        private Thread NewTaskThread { get; set; }
        public KATYATask(Action<object> ParameterizedTask, object ParameterizedTaskInput)
        {
            this.ParameterizedTask = ParameterizedTask;
            this.ParameterizedTaskInput = ParameterizedTaskInput;
            this.IsParameterized = true;
        }
        public KATYATask(Action NonParameterizedTask)
        {
            this.NonParameterizedTask = NonParameterizedTask;
            this.IsParameterized = false;
        }
        public StatusObject Start()
        {
            StatusObject SO = new StatusObject();
            try
            {
                if (IsParameterized)
                {
                    this.NewTaskThread = new Thread(new ParameterizedThreadStart(ParameterizedTask));
                    NewTaskThread.Start(ParameterizedTaskInput);
                }
                else
                {
                    this.NewTaskThread = new Thread(new ThreadStart(NonParameterizedTask));
                    NewTaskThread.Start();
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "TASK_START");
            }
            return SO;
        }
        public StatusObject Abort()
        {
            StatusObject SO = new StatusObject();
            try
            {
                this.NewTaskThread.Abort();
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "TASK_STOP");
            }
            return SO;
        }
    }
}
