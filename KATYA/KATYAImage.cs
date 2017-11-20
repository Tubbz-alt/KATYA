using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
namespace KATYA
{
    public class KATYAImage
    {
        string FilePath { get; set; }
        string FileType { get; set; }
        public KATYAImage()
        {

        }
        public KATYAImage(string FilePath)
        {
            this.FilePath = FilePath;
        }
        public StatusObject GetPixels()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
    }
}
