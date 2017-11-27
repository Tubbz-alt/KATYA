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
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public KATYAFile(string FilePath)
        {
            this.FilePath = FilePath;
            this.FileType = Path.GetExtension(FilePath);
        }
        public StatusObject ReadAllText()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "FILE_READALLTEXT");
            }
            return SO;
        }
        public StatusObject ReadTextByLine()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "FILE_READTEXTBYLINE");
            }
            return SO;
        }
        public StatusObject ReadExcelByLine()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
        public StatusObject ProcessAllText()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "FILE_PROCESSALLTEXT");
            }
            return SO;
        }
        public StatusObject ProcessTextByLine()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "FILE_PROCESSTEXTBYLINE");
            }
            return SO;
        }
        
        public StatusObject WriteToTextFile()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
        public StatusObject WriteToCSV(params object[] Content)
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
