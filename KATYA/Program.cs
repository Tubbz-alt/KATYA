using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATYA
{
    class Program
    {
        static void Main(string[] args)
        {
            string StartupMode = "console";
            bool ProgramRunning = true;
            string UserInput = "";
            KATYARuntime StartUpEvents = new KATYARuntime();
            KATYAMultiTasker TaskManager = new KATYAMultiTasker();
            KATYAMultiThreader ThreadManager = new KATYAMultiThreader();
            /*Start all Threads*/
            try
            {
                StatusObject SO = new StatusObject();
                KATYACryptography CryptoTools = new KATYACryptography();
                KATYASqlServerDatabase newSqlServerDatabase = new KATYASqlServerDatabase("sql2008kl", "claims_dev", "sa", "password");
            }
            catch(Exception e)
            {
                
            }
            while (ProgramRunning)
            {
                try
                {
                    /*Batch Processing*/
                    if (args.Length > 0)
                    {
                        UserInput = String.Join(" ", args);
                    }
                    else
                    {
                        Console.Write("Command: ");
                        UserInput = Console.ReadLine();
                    }
                    if (UserInput != "exit")
                    {
                        string PrimaryCommand = UserInput.Split(' ')[0];
                        string InstructionSet = UserInput.Remove(0, PrimaryCommand.Length).Trim();
                        if (PrimaryCommand == "speech")
                        {
                            KATYASpeech SpeechTools = new KATYASpeech();
                            SpeechTools.Speak(InstructionSet);
                        }
                        else if (PrimaryCommand == "cryptography")
                        {
                            KATYACryptography CryptographyTools = new KATYACryptography();
                        }
                        else if (PrimaryCommand == "web")
                        {
                            KATYAWeb WebTools = new KATYAWeb("https://www.google.com/");
                            WebTools.HTTPGet();
                        }
                        else if (PrimaryCommand == "webpost")
                        {
                            KATYAWeb WebTools = new KATYAWeb("http://localhost/cfmtools/index.cfm");
                            WebTools.AddPostParameters("hello", "world");
                            WebTools.AddPostParameters("how", "world");
                            WebTools.GetURLEncodedString();
                            //Task<StatusObject> SO_PostRequest = WebTools.HTTPPostAsync();
                            WebTools.HTTPPost();
                        }
                        else if (PrimaryCommand == "task")
                        {
                            
                        }
                        else
                        {
                            Console.WriteLine("{0} is not a recognized command", PrimaryCommand);
                        }
                        Console.WriteLine(InstructionSet);
                    }
                    else
                    {
                        ProgramRunning = false;
                        UserInput = "";
                    }
                }
                catch(Exception e)
                {
                    ProgramRunning = true;
                    UserInput = "";
                    Console.WriteLine(e);
                }
            }
            /*End all running threads*/
            try
            {
                TaskManager.StopAllTasks();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
