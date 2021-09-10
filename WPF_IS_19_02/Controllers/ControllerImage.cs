using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WPF_IS_19_02.View.ModelView;

namespace WPF_IS_19_02.Controllers
{
    public class ControllerImage
    {
        public static List<Image> GetImages()
        {
            string wanted_path = 
                Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

            wanted_path += @"\\Image";

            string[] allfolders = Directory.GetFiles(wanted_path); // список  файлов  в папке

            List<string> allfoldersJPG = allfolders.
                Where(c=> (c.EndsWith(".jpg")) ||( c.EndsWith(".jpeg")) || (c.EndsWith(".png"))).ToList();

            List<View.ModelView.Image> images = new List<Image>();

            foreach (var item in allfoldersJPG)
            {
                images.Add(new Image { ImagePath = item, NameImage = Path.GetFileName(item) }); ;
            }
            return images;
        }
    }
}
