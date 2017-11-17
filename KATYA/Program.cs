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
                StartUpEvents.BuildDirectories();
                AvailableTasks.AddTask("TestTask1", AvailableTasks.TestTask1);
                AvailableTasks.AddTask("TestTask2", AvailableTasks.TestTask2);
                AvailableTasks.AddTask("TestTask3", AvailableTasks.TestTask3);
                AvailableTasks.AddTask("TestParameterizedTask", AvailableTasks.NonVoidTask, "hehehehehe");
                AvailableTasks.StartTask("TestTask3");
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
                    if(UserInput != "exit")
                    {
                        string PrimaryCommand = UserInput.Split(' ')[0];
                        string InstructionSet = UserInput.Remove(0, PrimaryCommand.Length).Trim();
                        if(PrimaryCommand == "speech")
                        {
                            KATYASpeech SpeechTools = new KATYASpeech();
                            SpeechTools.Speak(InstructionSet);
                        }
                        else if (PrimaryCommand == "cryptography")
                        {
                            KATYACryptography CryptographyTools = new KATYACryptography();
                            
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
