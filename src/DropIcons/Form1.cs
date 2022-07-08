using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DropIcons
{
    public partial class Form1 : Form
    {
        public List<BitmapData> bitmaps = new List<BitmapData>();

        private Point curLocation;

        // This trick is used for invalidating folder caches...
        private bool triggerInvalidating = false;

        public Form1()
        {
            Config.GetTheme();
            InitializeComponent();
            Font = CursorFont.NotoSans8;
            Convert.Font = CursorFont.NotoSans9;
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
            return ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp";
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

        private void RemoveAll()
        {
            Img1.Image = null;
            Img2.Image = null;
            Img3.Image = null;

            for (int i = bitmaps.Count - 1; i >= 0; i--)
            {
                BitmapData data = bitmaps[i];
                bitmaps.Remove(data);
                data.bitmap.Dispose();
            }

            NoImages.Text = Properties.Resources.AddImages;
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
                    if (img != null)
                        img.Dispose();
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
                    Img1.Image = bmp0.bitmap;
            }

            if (bitmaps.Count > 1)
            {
                BitmapData bmp1 = bitmaps[1];
                if (bmp1 != null)
                    Img2.Image = bmp1.bitmap;
            }

            if (bitmaps.Count > 2)
            {
                BitmapData bmp2 = bitmaps[2];
                if (bmp2 != null)
                    Img3.Image = bmp2.bitmap;
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

            NoImages.Text = count;
            string no = bitmaps.Count.ToString();
            Console.WriteLine(no + " Images to convert - " + no + " Imágenes para convertir");
        }

        private void Theme()
        {
            Convert.Inactive1 = Config.custom;
            Convert.Inactive2 = Config.custom;
            Convert.Active1 = Config.customH;
            Convert.Active2 = Config.customH;
            SlideFolder.ForeColor = Config.custom;
            SlideTiny.ForeColor = Config.custom;
            Decoration.BackColor = Config.custom;
        }

        // Events: ↓ ↓ ↓

        private void Form1_Load(object sender, EventArgs e)
        {
            Theme();

            // Menú para TopMost
            Config.menu.MenuItems.Add(Config.item);
            Config.item.Click += TopMost_Click;
            Config.TopMost(this);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button is MouseButtons.Right)
            {
                Config.item.Text = Config.isTopMost ? Properties.Resources.DisableTopMost : Properties.Resources.EnableTopMost;
                Config.menu.Show(this, new Point(e.X, e.Y));
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            curLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Mover la ventana sin borde con ayuda de MouseDown
            if (e.Button == MouseButtons.Left)
            {
                int x = e.Location.X - curLocation.X;
                int y = e.Location.Y - curLocation.Y;
                Location = new Point(Location.X + x, Location.Y + y);
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (string path in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    if (CheckIfExist(path)) { }
                    else if (CheckIfImage(path))
                        AddImage(Image.FromFile(path), path);
                }

                PreviewCount();
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && CheckIfCompatible((string[])e.Data.GetData(DataFormats.FileDrop)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (triggerInvalidating)
            {
                triggerInvalidating = false;
                Utility.InvalidateExplorerCache();
                Text = "Drop Icons";
            }
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            if (!bitmaps.Any())
            {
                return;
            }

            switch (SlideFolder.IsOn)
            {
                // Guardar en la misma carpeta
                case true:
                    Loading.Visible = true;
                    Application.DoEvents();
                    SaveIcons();
                    Console.WriteLine("Icons saved in the same folder - Iconos guardados en la misma carpeta");
                    RemoveAll();
                    Loading.Visible = false;
                    break;

                // Guardar en la carpeta elegida
                case false:                    
                    FolderBrowserEx.FolderBrowserDialog FBrowser = new FolderBrowserEx.FolderBrowserDialog
                    {
                        Title = Properties.Resources.SelectAFolder,
                        AllowMultiSelect = false,
                    };

                    try
                    {
                        Config.TopDialog(this); // Desabilita el TopMost para que el Dialog esté encima
                        DialogResult savedialog = FBrowser.ShowDialog();

                        if (savedialog == DialogResult.OK)
                        {
                            Config.TopDialog(this); // Habilita el TopMost
                            Loading.Visible = true;
                            string result = FBrowser.SelectedFolder;
                            Application.DoEvents();
                            SaveIcons(result);
                            Console.WriteLine("Icons saved in " + result + " - Iconos guardados en " + result);
                            RemoveAll();
                            Loading.Visible = false;
                        }
                        else if (savedialog == DialogResult.Cancel)
                        {
                            Config.TopDialog(this); // Habilita el TopMost
                        }
                    }
                    catch
                    {
                        // Si el programa se cierra, no hacer nada.
                    }
                    break;
            }
        }

        private void Info_Click(object sender, EventArgs e)
        {
            using (About about = new About())
            { 
                Info.Image = Properties.Resources.info_circle;
                _ = about.ShowDialog();
            }
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            RemoveAll();
            Console.WriteLine("Images removed - Imágenes eliminadas");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddImages_Click(object sender, EventArgs e)
        {
            // Label para agregar imágenes si no funciona el Drag and Drop
            if (NoImages.Text.ToString() == Properties.Resources.AddImages)
            {
                if (_openDiag.ShowDialog() == DialogResult.OK)
                {
                    foreach (string path in _openDiag.FileNames)
                    {
                        if (CheckIfImage(path))
                            AddImage(Image.FromFile(path), path);
                    }

                    PreviewCount();
                }
            }
        }

        private void NoImages_MouseEnter(object sender, EventArgs e)
        {
            if (NoImages.Text.ToString() == Properties.Resources.AddImages)
                NoImages.Cursor = Cursors.Hand;
        }

        private void NoImages_MouseLeave(object sender, EventArgs e)
        {
            if (NoImages.Text.ToString() == Properties.Resources.AddImages)
                NoImages.Cursor = Cursors.Default;
        }

        private void TopMost_Click(object sender, EventArgs e)
        {
            Config.ChangeTopMost(this);
        }

        #region Button Effect
        private void Info_MouseDown(object sender, MouseEventArgs e)
        {
            Info.Image = Properties.Resources.info_circle_72;
        }

        private void Info_MouseUp(object sender, MouseEventArgs e)
        {
            Info.Image = Properties.Resources.info_circle;
        }

        private void Reload_MouseDown(object sender, MouseEventArgs e)
        {
            Reload.Image = Properties.Resources.refresh_alt_72;
        }

        private void Reload_MouseUp(object sender, MouseEventArgs e)
        {
            Reload.Image = Properties.Resources.refresh_alt;
        }

        private void Exit_MouseDown(object sender, MouseEventArgs e)
        {
            Exit.Image = Properties.Resources.x_circle_72;
        }

        private void Exit_MouseUp(object sender, MouseEventArgs e)
        {
            Exit.Image = Properties.Resources.x_circle;
        }
        #endregion

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CursorFont.DisposeAll();
            Config.DisposeAll();
        }
    }
}