using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace KATYA
{
    public partial class KATYAFile
    {
        public StatusObject ReadAllText()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "FILE_READALLTEXT");
            }
            return SO;
        }
        public StatusObject ReadAllText(params Func<string, StatusObject>[] TextProcessingAlgorithms)
        {
            StatusObject SO = new StatusObject();
            try
            {
                StreamReader TargetFile = new StreamReader(this.FilePath);
                string TargetFileText = TargetFile.ReadToEnd();
                foreach(Func<string,StatusObject> TextProcessingAlgorithm in TextProcessingAlgorithms)
                {
                    StatusObject SO_ExecutedTextProcessingAlgorithm = TextProcessingAlgorithm(TargetFileText);
                    if(SO_ExecutedTextProcessingAlgorithm.Status == StatusCode.FAILURE)
                    {
                        Console.WriteLine("Error while executing TextProcessingAlgorithm {0}", TextProcessingAlgorithm.GetType().Name);
                        Console.WriteLine(SO_ExecutedTextProcessingAlgorithm.ErrorStackTrace);
                    }
                }
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "FILE_TEXTPROCESSING_READALLTEXT");
            }
            return SO;
        }
        
        public StatusObject ReadTextByLine()
        {
            StatusObject SO = new StatusObject();
            try
            {
                FileStream TargetFile = File.Open(this.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                BufferedStream TargetFileStream = new BufferedStream(TargetFile);
                StreamReader TargetFileStreamReader = new StreamReader(TargetFileStream);
                string Line;
                while ((Line = TargetFileStreamReader.ReadLine()) != null)
                {
                    Console.WriteLine(Line);
                }
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "FILE_READTEXTBYLINE");
            }
            return SO;
        }
        public StatusObject ReadTextByLine(params Func<string, StatusObject>[] LineProcessingAlgorithms)
        {
            StatusObject SO = new StatusObject();
            try
            {
                FileStream TargetFile = File.Open(this.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                BufferedStream TargetFileStream = new BufferedStream(TargetFile);
                StreamReader TargetFileStreamReader = new StreamReader(TargetFileStream);
                string Line;
                while ((Line=TargetFileStreamReader.ReadLine()) != null)
                {
                    Console.WriteLine(Line);
                }
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "FILE_TEXTPROCESSING_READTEXTBYLINE");
            }
            return SO;
        }
        public StatusObject WriteToTextFile()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch (Exception e)
            {

            }
            return SO;
        }
        public StatusObject TestTextProcessingAlgorithm(string Input)
        {
            StatusObject SO = new StatusObject();
            try
            {
                Console.WriteLine(Input);
            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject TabDelimitedToSqlInsert(int ColumnCount, string Input, bool FirstLineIsHeader)
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
    }
}
