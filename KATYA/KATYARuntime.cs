using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
namespace KATYA
{
    public class KATYARuntime
    {
        public Dictionary<string, string> InstallDirectories { get; set; }
        public KATYARuntime()
        {
            try
            {
                /*
                 Template: InstallDirectories.Add("", "");
                 */
                InstallDirectories = new Dictionary<string, string>();
                InstallDirectories.Add("Main", "Runtime");
                InstallDirectories.Add("StartupInstructions", @"Runtime\StartupInstructions");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public StatusObject BuildDirectories()
        {
            StatusObject SO = new StatusObject();
            try
            {
                foreach(KeyValuePair<string,string> InstallDirectory in InstallDirectories)
                {
                    Directory.CreateDirectory(InstallDirectory.Value);
                }
                
            }
            catch(Exception e)
            {

            }
            return SO;
        }
    }
}
