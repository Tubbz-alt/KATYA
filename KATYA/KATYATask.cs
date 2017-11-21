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
        private Action VoidNonParameterizedTask { get; set; }
        private Action<object> VoidParameterizedTask { get; set; }
        private bool IsParameterized { get; set; }
        private object ParameterizedTaskInput { get; set; }
        private Task CurrentTask { get; set; }
        public KATYATask(Action VoidNonParameterizedTask)
        {
            this.IsParameterized = false;
            this.VoidNonParameterizedTask = VoidNonParameterizedTask;
        }
        public KATYATask(Action<object> VoidParameterizedTask, object ParameterizedTaskInput)
        {
            this.IsParameterized = true;
            this.VoidParameterizedTask = VoidParameterizedTask;
        }
        public StatusObject Start()
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
        public bool SetObject(object ParameterizedTaskInput)
        {
            this.ParameterizedTaskInput = ParameterizedTaskInput;
            return true;
        }
    }
    public class KATYATask<T>
    {
        private Func<T> NonVoidNonParameterizedTask { get; set; }
        private Func<object, T> NonVoidParameterizedTask { get; set; }
        private object ParameterizedTaskInput { get; set; }
        public bool IsParameterized { get; set; }
        public KATYATask(Func<T> NonVoidNonParameterizedTask)
        {
            this.NonVoidNonParameterizedTask = NonVoidNonParameterizedTask;
        }
        public KATYATask(Func<object, T> NonVoidParameterizedTask, object ParameterizedTaskInput)
        {
            this.NonVoidParameterizedTask = NonVoidParameterizedTask;
            this.ParameterizedTaskInput = ParameterizedTaskInput;
            this.IsParameterized = true;
        }
        public StatusObject Start()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
        public StatusObject Abort()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
    }
}
