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
                            KATYAWebRequest test = new KATYAWebRequest(InstructionSet);
                            StatusObject SO_Get = test.Get();
                            if(SO_Get.Status == StatusCode.FAILURE)
                            {
                                Console.WriteLine(SO_Get.ErrorStackTrace);
                            }
                            StatusObject SO_Download = test.DownloadHeaderFiles();
                            if(SO_Download.Status == StatusCode.FAILURE)
                            {
                                Console.WriteLine(SO_Download.ErrorStackTrace);
                            }
                        }
                        else if (PrimaryCommand == "webpost")
                        {
                            
                        }
                        else if (PrimaryCommand == "task")
                        {
                            
                        }
                        else if (PrimaryCommand == "database")
                        {
                            List<string> InstructionParameters = InstructionSet.Split(' ').ToList();
                            string SecondaryCommand = InstructionParameters.ElementAtOrDefault(0);
                            string Server = InstructionParameters.ElementAtOrDefault(1);
                            string Database = InstructionParameters.ElementAtOrDefault(2);
                            string UserID = InstructionParameters.ElementAtOrDefault(3);
                            string Password = InstructionParameters.ElementAtOrDefault(4);
                            int TotalArguments = InstructionParameters.Count;
                            KATYASqlServerDatabase TargetDatabase = new KATYASqlServerDatabase(Server, Database, UserID, Password);
                            if (SecondaryCommand == "exportallssp")
                            {
                                StatusObject SO_ExtractStoredProcedures = TargetDatabase.ExtractStoredProcedures();
                                if (TargetDatabase.IsWinAuth())
                                {
                                    SO_ExtractStoredProcedures = TargetDatabase.ExtractStoredProcedures();
                                }
                                else if (TargetDatabase.IsSqlAuth())
                                {

                                }
                                if (SO_ExtractStoredProcedures.Status == StatusCode.FAILURE)
                                {
                                    Console.WriteLine(SO_ExtractStoredProcedures.ErrorStackTrace);
                                }
                            }
                            else if (SecondaryCommand == "exportssp")
                            {
                                StatusObject SO_ExtractStoredProcedures = TargetDatabase.ExtractStoredProcedures();
                                if (TargetDatabase.IsWinAuth())
                                {
                                    SO_ExtractStoredProcedures = TargetDatabase.ExtractStoredProcedures();
                                }
                                else if (TargetDatabase.IsSqlAuth())
                                {

                                }
                                if (SO_ExtractStoredProcedures.Status == StatusCode.FAILURE)
                                {
                                    Console.WriteLine(SO_ExtractStoredProcedures.ErrorStackTrace);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("{0} is not a recognized command", PrimaryCommand);
                        }
                        /*Batch Processing End*/
                        if (args.Length > 0)
                        {
                            UserInput = "exit";
                        }
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
