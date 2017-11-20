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
            KATYAMultiTasker AvailableTasks = new KATYAMultiTasker();
            /*Start all Threads*/
            try
            {
                AvailableTasks.AddTask("hello", AvailableTasks.TestDelegateToRun);
                AvailableTasks.AddTask("fuck", AvailableTasks.TestParameterizedDelegateToRun, "fuck");
                KATYATask<StatusObject> testTask = new KATYATask<StatusObject>();
                
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
                            KATYAWeb WebTools = new KATYAWeb("http://localhost/testercfm/dump.cfm");
                            WebTools.AddPostParameters("hello", "world");
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
                AvailableTasks.StopAllTasks();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
