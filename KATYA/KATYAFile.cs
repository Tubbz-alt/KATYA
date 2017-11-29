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
    }
}
