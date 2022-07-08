using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DropIcons
{
    public partial class About : Form
    {
        private Point curLocation;

        private readonly Bitmap link = Properties.Resources.link;

        private readonly Bitmap linkH = Properties.Resources.link_72;

        public About()
        {
            InitializeComponent();
            Font = CursorFont.NotoSans8;
        }

        private void About_Load(object sender, EventArgs e)
        {
            // Mostrar si el programa está en English o Español
            if (Config.currentLan == "es")
            {
                Lang.Text = "Idioma: Español";
                Lang.Left = Lang.Location.X + 4;
                Caret.Location = new Point(Caret.Location.X + 4, Lang.Location.Y);
            }

            TopMost = Config.isTopMost;
            Decoration.BackColor = Config.custom;
        }

        private void About_MouseDown(object sender, MouseEventArgs e)
        {
            curLocation = e.Location;
        }

        private void About_MouseMove(object sender, MouseEventArgs e)
        {
            // Mover la ventana sin borde con ayuda de MouseDown
            if (e.Button == MouseButtons.Left)
            {
                int x = e.Location.X - curLocation.X;
                int y = e.Location.Y - curLocation.Y;
                Location = new Point(Location.X + x, Location.Y + y);
            }
        }

        private void DILabel_Click(object sender, EventArgs e)
        {
            License.Text = File.ReadAllText(@"Docs\Drop Icons.txt");
            LName.Text = "Drop Icons";
            switch (Config.currentLan)
            {
                case "en":
                    Description.Text = "Utility to convert images to icons (.ico)";
                    break;
                case "es":
                    Description.Text = "Aplicación para convertir imágenes a iconos (.ico)";
                    break;
            }
        }

        private void ILabel_Click(object sender, EventArgs e)
        {
            License.Text = File.ReadAllText(@"Docs\Iconizer.txt");
            LName.Text = "Iconizer";
            Description.Text = "Image to icon converter with high quality output";
        }

        private void ACLabel_Click(object sender, EventArgs e)
        {
            License.Text = File.ReadAllText(@"Docs\AltoControls.txt");
            LName.Text = "AltoControls";
            Description.Text = "Custom controls for .Net WinForm";
        }

        private void FBELabel_Click(object sender, EventArgs e)
        {
            License.Text = File.ReadAllText(@"Docs\FolderBrowserEx.txt");
            LName.Text = "FolderBrowserEx";
            Description.Text = "Library to use the Folder Browser in .NET";
        }

        private void NSLabel_Click(object sender, EventArgs e)
        {
            License.Text = File.ReadAllText(@"Docs\Noto Sans\OFL.txt");
            LName.Text = "Noto Sans";
            Description.Text = "Unmodulated (“sans serif”) design font collection";
        }

        private void TLabel_Click(object sender, EventArgs e)
        {
            License.Text = File.ReadAllText(@"Docs\Teenyicons.txt");
            LName.Text = "Teenyicons";
            Description.Text = "Tiny minimal 1px icons";
        }

        private void NSLink_Click(object sender, EventArgs e)
        {
            _ = System.Diagnostics.Process.Start("https://fonts.google.com/noto/specimen/Noto+Sans");
        }

        private void TLink_Click(object sender, EventArgs e)
        {
            _ = System.Diagnostics.Process.Start("https://github.com/teenyicons/teenyicons");
        }

        private void ACLink_Click(object sender, EventArgs e)
        {
            _ = System.Diagnostics.Process.Start("https://github.com/aalitor/AltoControls");
        }

        private void ILink_Click(object sender, EventArgs e)
        {
            _ = System.Diagnostics.Process.Start("https://github.com/willnode/Iconizer");
        }

        private void DILink_Click(object sender, EventArgs e)
        {
            _ = System.Diagnostics.Process.Start("https://genesistoxical.github.io/drop-icons/");
        }

        private void FBELink_Click(object sender, EventArgs e)
        {
            _ = System.Diagnostics.Process.Start("https://github.com/evaristocuesta/FolderBrowserEx");
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Caret_Click(object sender, EventArgs e)
        {
            string LangText = Lang.Text;

            switch (LangText)
            {
                case string _ when LangText.Contains("Español"):
                    Lang.Text = Properties.Resources.LanguageEnglish;
                    Config.selecLan = "en";
                    break;

                case string _ when LangText.Contains("English"):
                    Lang.Text = Properties.Resources.LanguageEspañol;
                    Config.selecLan = "es";
                    break;
            }
        }

        private void License_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void Theme_Click(object sender, EventArgs e)
        {
            // Obtener los colores de Colors.dat y aplicarlos
            string[] list = File.ReadAllLines(Config.datPath);
            int[] datcolors = new int[16];

            for (int i = 0; i < 16; i++)
            {
                datcolors[i] = int.Parse(list[i]);
                colorDialog.CustomColors = datcolors;
            }

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Cambiar el color del tema
                Config.R = colorDialog.Color.R;
                Config.G = colorDialog.Color.G;
                Config.B = colorDialog.Color.B;
                Decoration.BackColor = colorDialog.Color;
                Config.SetTheme();

                // Guardar colores personalizados
                Config.SaveColors(colorDialog);
            }
        }

        #region Button Effect
        private void DILink_MouseDown(object sender, MouseEventArgs e)
        {
            DILink.Image = linkH;
        }

        private void DILink_MouseUp(object sender, MouseEventArgs e)
        {
            DILink.Image = link;
        }

        private void FBELink_MouseDown(object sender, MouseEventArgs e)
        {
            FBELink.Image = linkH;
        }

        private void FBELink_MouseUp(object sender, MouseEventArgs e)
        {
            FBELink.Image = link;
        }

        private void ACLink_MouseDown(object sender, MouseEventArgs e)
        {
            ACLink.Image = linkH;
        }

        private void ACLink_MouseUp(object sender, MouseEventArgs e)
        {
            ACLink.Image = link;
        }

        private void ILink_MouseDown(object sender, MouseEventArgs e)
        {
            ILink.Image = linkH;
        }

        private void ILink_MouseUp(object sender, MouseEventArgs e)
        {
            ILink.Image = link;
        }

        private void TLink_MouseDown(object sender, MouseEventArgs e)
        {
            TLink.Image = linkH;
        }

        private void TLink_MouseUp(object sender, MouseEventArgs e)
        {
            TLink.Image = link;
        }

        private void NSLink_MouseDown(object sender, MouseEventArgs e)
        {
            NSLink.Image = linkH;
        }

        private void NSLink_MouseUp(object sender, MouseEventArgs e)
        {
            NSLink.Image = link;
        }

        private void Back_MouseDown(object sender, MouseEventArgs e)
        {
            Back.Image = Properties.Resources.arrow_left_circle_72;
        }

        private void Back_MouseUp(object sender, MouseEventArgs e)
        {
            Back.Image = Properties.Resources.arrow_left_circle;
        }

        private void Caret_MouseDown(object sender, MouseEventArgs e)
        {
            Caret.Image = Properties.Resources.caret_vertical_small_72;
        }

        private void Caret_MouseUp(object sender, MouseEventArgs e)
        {
            Caret.Image = Properties.Resources.caret_vertical_small;
        }
        #endregion

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cambiar el idioma si es necesario.
            Config.CheckLanguage();

            if (Config.Restart)
                Config.Restarting(e);
        }
    }
}