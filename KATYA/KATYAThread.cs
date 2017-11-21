using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace KATYA
{
    public class KATYAThread
    {
        private Action NonParameterizedThread { get; set; }
        private Action<object> ParameterizedThread { get; set; }
        private bool IsParameterized { get; set; }
        private object ParameterizedThreadInput { get; set; }
        private Thread CurrentThread { get; set; }
        public KATYAThread(Action NonParameterizedThread)
        {
            this.IsParameterized = false;
            this.NonParameterizedThread = NonParameterizedThread;
            this.ParameterizedThreadInput = null;
        }
        public KATYAThread(Action<object> ParameterizedThread)
        {
            this.IsParameterized = true;
            this.ParameterizedThread = ParameterizedThread;
            this.ParameterizedThreadInput = null;
        }
        public KATYAThread(Action<object> ParameterizedThread, object ParameterizedThreadInput)
        {
            this.IsParameterized = true;
            this.ParameterizedThread = ParameterizedThread;
            this.ParameterizedThreadInput = ParameterizedThreadInput;
        }
        public bool SetParameterizedThreadInput(object ParameterizedThreadInput)
        {
            this.ParameterizedThreadInput = ParameterizedThreadInput;
            return true;
        }
        public StatusObject Start()
        {
            StatusObject SO = new StatusObject();
            try
            {
                if (this.IsParameterized)
                {
                    this.CurrentThread = new Thread(new ParameterizedThreadStart(ParameterizedThread));
                    this.CurrentThread.Start(ParameterizedThreadInput);
                }
                else
                {
                    this.CurrentThread = new Thread(new ThreadStart(NonParameterizedThread));
                    this.CurrentThread.Start();
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "THREAD_START");
            }
            return SO;
        }
        public StatusObject Stop()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "THREAD_STOP");
            }
            return SO;
        }
    }
}
