using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;

namespace DropIcons
{
    /// <summary>
    /// Convert Images to Icons
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<BitmapData> bitmaps = new List<BitmapData>();
        private readonly string tmp = Path.GetTempPath() + "dp-output\\";
        private bool svgdelete = false;

        // This trick is used for invalidating folder caches...
        private bool triggerInvalidating = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool CheckIfExist(string path)
        {
            return bitmaps.Any((x) => x.path == path);
        }

        private Bitmap[] GetImageSeries(Image master, OptionsData options)
        {
            Bitmap[] v = new Bitmap[options.sizes.Count];
            for (int i = 0; i < options.sizes.Count; i++)
            {
                v[i] = Utility.ResizeImage(master, options.sizes[i], options.keepAspect);
            }
            return v;
        }

        private static bool CheckIfCompatible(string[] paths)
        {
            return paths.Any((x) => CheckIfImage(x));
        }

        private static bool CheckIfImage(string path)
        {
            string ext = Path.GetExtension(path);
            return ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".jfif" || ext == ".svg" || ext == ".gif" || ext == ".bmp";
        }

        private void AddConvertedSVG(string path)
        {
            // Rasterizar SVG (a PNG) y guardarlos en una carpeta temporal
            svgdelete = true;

            WpfDrawingSettings settings = new WpfDrawingSettings
            {
                IncludeRuntime = true,
                TextAsGeometry = false
            };

            using (ImageSvgConverter converter = new ImageSvgConverter(settings)
            {
                EncoderType = ImageEncoderType.PngBitmap
            })
            {
                string name = Path.GetFileNameWithoutExtension(path) + ".png";
                converter.Convert(path, tmp + name);

                // Agregar los PNG de la carpeta temporal, conservando la ruta
                // original de los SVG
                AddImage(Image.FromFile(tmp + name), path);

                converter.Dispose();
            }
        }

        private void AddImage(Image bitmap, string path)
        {
            BitmapData data = new BitmapData()
            {
                bitmap = bitmap,
                path = path,
                name = Path.GetFileNameWithoutExtension(path)
            };

            bitmaps.Add(data);
        }

        private BitmapImage BitmapToSource(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                BitmapImage bmpImg = new BitmapImage();
                bmpImg.BeginInit();
                bmpImg.CacheOption = BitmapCacheOption.OnLoad;
                bmpImg.StreamSource = ms;
                bmpImg.EndInit();
                bmpImg.Freeze();
                bitmap.Dispose();
                return bmpImg;
            }
        }

        private void RemoveAll()
        {
            Img1.Source = null;
            Img2.Source = null;
            Img3.Source = null;

            for (int i = bitmaps.Count - 1; i >= 0; i--)
            {
                BitmapData data = bitmaps[i];
                bitmaps.Remove(data);
                data.bitmap.Dispose();
            }

            NoImages.Content = Properties.Resources.AddImages;

            // Si la conversión fue SVG a ICO, borrar carpeta temporal de PNG's
            if (svgdelete)
            {
                Directory.Delete(tmp, true);
                svgdelete = false;
            }
        }

        private void SaveIcons(string folder = default)
        {
            OptionsData options = OptionsData.FromSlideButton(SlideTiny);
            foreach (BitmapData data in bitmaps)
            {
                FileStream file;
                Bitmap[] images = GetImageSeries(data.bitmap, options);
                if (string.IsNullOrEmpty(folder))
                {
                    // Si está vacio, guardar en la misma carpeta
                    file = new FileStream(Utility.NextAvailableFilename(data.GetImagePath()), FileMode.CreateNew);
                }
                else
                {
                    // Guardar en la carpeta que se ha especificado
                    file = new FileStream(Utility.NextAvailableFilename(data.GetImagePath(folder)), FileMode.CreateNew);
                }

                Utility.SavePngsAsIcon(images, file);

                file.Dispose();
                foreach (Bitmap img in images)
                {
                    img?.Dispose();
                }
            }

            if (Directory.Exists(tmp))
            {
                foreach (FileInfo file in new DirectoryInfo(tmp).GetFiles())
                {
                    if (file.Extension == ".ico")
                    {
                        string source = tmp + file;
                        string dest = folder + file;
                        Console.WriteLine("output: " + dest + " - " + source);
                    }
                }
            }
        }

        private void PreviewCount()
        {
            // Agrega tres imágenes como previa
            if (bitmaps.Count > 0)
            {
                BitmapData bmp0 = bitmaps[0];
                if (bmp0 != null)
                    Img1.Source = BitmapToSource(new Bitmap(bmp0.bitmap));
            }

            if (bitmaps.Count > 1)
            {
                BitmapData bmp1 = bitmaps[1];
                if (bmp1 != null)
                    Img2.Source = BitmapToSource(new Bitmap(bmp1.bitmap));
            }

            if (bitmaps.Count > 2)
            {
                BitmapData bmp2 = bitmaps[2];
                if (bmp2 != null)
                    Img3.Source = BitmapToSource(new Bitmap(bmp2.bitmap));
            }

            // Muestra el número total de imágenes, restando 3 de la vista previa
            string hicons = (double.Parse(bitmaps.Count.ToString()) - double.Parse("3")).ToString();
            string count;

            switch (hicons)
            {
                case "0":
                    count = "3 " + Properties.Resources.Images;
                    break;

                case "-1":
                    count = "2 " + Properties.Resources.Images;
                    break;

                case "-2":
                    count = "1 " + Properties.Resources.Image;
                    break;

                case "1":
                    count = "+ 1 " + Properties.Resources.Image;
                    break;

                default:
                    count = ("+ " + hicons + " " + Properties.Resources.Images);
                    break;
            }

            NoImages.Content = count;
            string no = bitmaps.Count.ToString();
            Console.WriteLine(no + " Images to convert - " + no + " Imágenes para convertir");
        }

        // Events: ↓ ↓ ↓

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Config.RoundCorners(Backg, Border, Decoration);
            Config.Topmost(this);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Mover ventana sin bordes.
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && CheckIfCompatible((string[])e.Data.GetData(DataFormats.FileDrop)))
            {
                foreach (string path in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    if (CheckIfExist(path)) { }
                    else if (CheckIfImage(path))
                    {
                        string ext = Path.GetExtension(path);

                        if (ext == ".svg")
                        {
                            AddConvertedSVG(path); // Agregar SVG convertido a PNG
                        }
                        else
                        {
                            AddImage(Image.FromFile(path), path);
                        }
                    }
                }

                PreviewCount();
            }
            else
            {
                e.Effects = DragDropEffects.None;
                Console.WriteLine("No compatible");
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (triggerInvalidating)
            {
                triggerInvalidating = false;
                Utility.InvalidateExplorerCache();
            }
        }

        private async void Convert_Click(object sender, RoutedEventArgs e)
        {
            if (!bitmaps.Any())
            {
                return;
            }

            switch (SlideFolder.IsChecked)
            {
                // Guardar en la misma carpeta
                case true:
                    Loading.Visibility = Visibility.Visible;
                    await Task.Delay(1);
                    SaveIcons();
                    RemoveAll();
                    Loading.Visibility = Visibility.Hidden;
                    break;

                // Guardar en la carpeta elegida
                case false:
                    FolderBrowserEx.FolderBrowserDialog FBrowser = new FolderBrowserEx.FolderBrowserDialog
                    {
                        Title = "Select a Folder",
                        AllowMultiSelect = false,
                    };

                    System.Windows.Forms.DialogResult savedialog = FBrowser.ShowDialog();

                    if (savedialog == System.Windows.Forms.DialogResult.OK)
                    {
                        string result = FBrowser.SelectedFolder;
                        Loading.Visibility = Visibility.Visible;
                        await Task.Delay(1);
                        SaveIcons(result);
                        Console.WriteLine("Icons saved in " + result + " - Iconos guardados en " + result);
                        RemoveAll();
                        Loading.Visibility = Visibility.Hidden;
                    }
                    break;
            }
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            RemoveAll();
            Console.WriteLine("Images removed - Imágenes eliminadas");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddImages_MouseEnter(object sender, MouseEventArgs e)
        {
            if (NoImages.Content.ToString() == Properties.Resources.AddImages)
                NoImages.Cursor = Cursors.Hand;
        }

        private void AddImages_MouseLeave(object sender, MouseEventArgs e)
        {
            if (NoImages.Content.ToString() == Properties.Resources.AddImages)
                NoImages.Cursor = Cursors.Arrow;
        }

        private void AddImages_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Label para agregar imágenes si no funciona el Drag and Drop
            if (NoImages.Content.ToString() == Properties.Resources.AddImages)
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = Properties.Resources.ImageFiles + " (*.png, *.jpg, *.jpeg, *.jfif, *.svg, *.gif; *.bmp)|*.png;*.jpg;*.jpeg;*.jfif;*.svg;*.gif;*.bmp",
                    Multiselect = true
                };

                bool? result = dlg.ShowDialog();

                if (result == true)
                {
                    foreach (string path in dlg.FileNames)
                    {
                        if (CheckIfImage(path))
                        {
                            string ext = Path.GetExtension(path);

                            if (ext == ".svg")
                            {
                                AddConvertedSVG(path);
                            }
                            else
                            {
                                AddImage(Image.FromFile(path), path);
                            }
                        }
                    }

                    PreviewCount();
                }
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            About dlgextract = new About() { Owner = this };
            dlgextract.Show();
        }

        private void Topmost_Click(object sender, RoutedEventArgs e)
        {
            Config.ChangeTopmost(this);
        }

        private void Window_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Config.isTopmost)
            {
                MenuTopmost.Header = Properties.Resources.DisableTopmost;
            }
            else
            {
                MenuTopmost.Header = Properties.Resources.EnableTopmost;
            }
        }
    }
}