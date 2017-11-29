using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace KATYA
{
    public partial class KATYAFile
    {
        public StatusObject DrawSomething()
        {
            StatusObject SO = new StatusObject();
            try
            {
                Bitmap bmp = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(bmp);
                g.FillRectangle(Brushes.Green, 0, 0, 50, 50);
                g.Dispose();
                bmp.Save(this.FilePath, System.Drawing.Imaging.ImageFormat.Png);
                bmp.Dispose();
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "FILE_IMAGEPROCESSING_DRAWSOMETHING");
            }
            return SO;
        }
    }
}
