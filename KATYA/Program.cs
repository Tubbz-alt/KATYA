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
            try
            {
                KATYARuntime StartUpEvents = new KATYARuntime();
                KATYAMultiTasker AvailableTasks = new KATYAMultiTasker();
                StartUpEvents.BuildDirectories();
                AvailableTasks.AddVoidTask("Hello", AvailableTasks.TestTask1);
                AvailableTasks.AddVoidTask("World", AvailableTasks.TestTask2);
                AvailableTasks.AddVoidTask("hahahah", AvailableTasks.TestTask3);
                AvailableTasks.AddParameterizedTask("huhu", AvailableTasks.NonVoidTask, "Hellworldhuhuu");
                AvailableTasks.StartAllThreads();
                AvailableTasks.StartAllThreads();
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
        }
    }
}
