using AltoControls;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace DropIcons
{
    /// <summary>
    /// Each options data
    /// </summary>
    public class OptionsData
    {
        public List<Size> sizes = new List<Size>();
        public bool keepAspect;

        public static OptionsData FromSlideButton(SlideButton box)
        {
            OptionsData data = new OptionsData();
            switch (box.IsOn)
            {
                // Icono con dimensiones de 16px a 256px
                case false:
                    data.sizes.Add(new Size(16, 16));
                    data.sizes.Add(new Size(32, 32));
                    data.sizes.Add(new Size(48, 48));
                    data.sizes.Add(new Size(64, 64));
                    data.sizes.Add(new Size(128, 128));
                    data.sizes.Add(new Size(256, 256));
                    data.keepAspect = true;
                    return data;

                // Icono (tiny) con dimensiones de 16px a 48px
                default:
                    data.sizes.Add(new Size(16, 16));
                    data.sizes.Add(new Size(32, 32));
                    data.sizes.Add(new Size(48, 48));
                    data.keepAspect = true;
                    return data;
            }
        }
    }
    /// <summary>
    /// Stored individual bitmap data
    /// </summary>
    public class BitmapData
    {
        public Image bitmap;
        public string path;
        public string name;

        public int iteration;

        public string GetImagePath()
        {
            if (iteration == 0)
                return Path.ChangeExtension(path, ".ico");
            else
                return Path.ChangeExtension(path, null) + iteration.ToString() + ".ico";
        }

        public string GetImagePath(string directory)
        {
            return Path.Combine(directory, Path.GetFileName(GetImagePath()));
        }
    }
}

