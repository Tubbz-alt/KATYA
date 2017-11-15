using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace KATYA
{
    public class KATYARuntime
    {
        public Dictionary<string, string> InstallDirectories = new Dictionary<string, string>()
        {
            // Main Directory
            {"Main",@"{0}KATYA"}
        };
        public KATYARuntime()
        {

        }
        public StatusObject BuildDirectories()
        {
            StatusObject SO = new StatusObject();
            try
            {
                Assembly KATYA = Assembly.GetExecutingAssembly();
                Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            }
            catch(Exception e)
            {

            }
            return SO;
        }
    }
}
