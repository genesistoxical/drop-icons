using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DropIcons
{
    /// <summary>
    /// About, Licenses, Theme and Language
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void Arrows(Label visibleArrw, Label opacityBtn)
        {
            // Oculta todas las flechas y restaura la opacidad
            // para mostrar y cambiar la opacidad de la que se indique
            Arrw_Drop.Visibility = Visibility.Hidden;
            Arrw_Folder.Visibility = Visibility.Hidden;
            Arrw_Handy.Visibility = Visibility.Hidden;
            Arrw_Iconizer.Visibility = Visibility.Hidden;
            Arrw_Noto.Visibility = Visibility.Hidden;
            Arrw_Teeny.Visibility = Visibility.Hidden;
            Arrw_Win.Visibility = Visibility.Hidden;

            Btn_Drop.Opacity = 1;
            Btn_Folder.Opacity = 1;
            Btn_Handy.Opacity = 1;
            Btn_Iconizer.Opacity = 1;
            Btn_Noto.Opacity = 1;
            Btn_Teeny.Opacity = 1;
            Btn_Win.Opacity = 1;

            visibleArrw.Visibility = Visibility.Visible;
            opacityBtn.Opacity = 0.7;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Elegir el idioma, bordes redondeados y TopMost
            // dependiendo del archivo Config.ini
            if (Config.currentLan == "es")
            {
                Lang.Content = Properties.Resources.LanguageEspañol;
            }
            Config.RoundCorners(Backg, Border, Decoration);
            Config.Topmost(this);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Mover ventana sin bordes
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void DropIcons_btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            License.Text = File.ReadAllText(@"Docs\Drop Icons.txt");
            Description.Content = Properties.Resources.UtilityToConvertImagesToIcons;
            Arrows(Arrw_Drop, Btn_Drop);
        }

        private void Btn_Noto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            License.Text = File.ReadAllText(@"Docs\Noto Music\OFL.txt");
            Description.Content = "Global font collection for writing in all modern and ancient languages";
            Arrows(Arrw_Noto, Btn_Noto);
        }

        private void Btn_Teeny_MouseDown(object sender, MouseButtonEventArgs e)
        {
            License.Text = File.ReadAllText(@"Docs\Teenyicons.txt");
            Description.Content = "Tiny minimal 1px icons";
            Arrows(Arrw_Teeny, Btn_Teeny);
        }

        private void Btn_Folder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            License.Text = File.ReadAllText(@"Docs\FolderBrowserEx.txt");
            Description.Content = "Library to use the Folder Browser in .NET";
            Arrows(Arrw_Folder, Btn_Folder);
        }

        private void Btn_Iconizer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            License.Text = File.ReadAllText(@"Docs\Iconizer.txt");
            Description.Content = "Image to Icon Converter with High Quality Output";
            Arrows(Arrw_Iconizer, Btn_Iconizer);
        }

        private void Btn_Handy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            License.Text = File.ReadAllText(@"Docs\HandyControls.txt");
            Description.Content = "Based on HandyControl and includes more controls and features";
            Arrows(Arrw_Handy, Btn_Handy);
        }

        private void Btn_Win_MouseDown(object sender, MouseButtonEventArgs e)
        {
            License.Text = File.ReadAllText(@"Docs\WinVersion.txt");
            Description.Content = "Windows 11 Version Detection";
            Arrows(Arrw_Win, Btn_Win);
        }

        private void Link_Click(object sender, RoutedEventArgs e)
        {
            if (Arrw_Noto.Visibility == Visibility.Visible)
            {
                _ = Process.Start("https://fonts.google.com/noto/specimen/Noto+Sans");
            }
            else if (Arrw_Teeny.Visibility == Visibility.Visible)
            {
                _ = Process.Start("https://teenyicons.com/");
            }
            else if (Arrw_Iconizer.Visibility == Visibility.Visible)
            {
                _ = Process.Start("https://github.com/willnode/Iconizer");
            }
            else if (Arrw_Drop.Visibility == Visibility.Visible)
            {
                _ = Process.Start("https://genesistoxical.github.io/drop-icons/");
            }
            else if (Arrw_Folder.Visibility == Visibility.Visible)
            {
                _ = Process.Start("https://github.com/evaristocuesta/FolderBrowserEx");
            }
            else if (Arrw_Handy.Visibility == Visibility.Visible)
            {
                _ = Process.Start("https://github.com/ghost1372/HandyControls");
            }
            else if (Arrw_Win.Visibility == Visibility.Visible)
            {
                _ = Process.Start("https://github.com/shaovoon/win_version_detection");
            }
        }

        private void Caret_Click(object sender, RoutedEventArgs e)
        {
            string LangText = Lang.Content.ToString();

            switch (LangText)
            {
                case string _ when LangText.Contains("Español"):
                    Lang.Content = Properties.Resources.LanguageEnglish;
                    Config.selecLan = "en";
                    break;

                case string _ when LangText.Contains("English"):
                    Lang.Content = Properties.Resources.LanguageEspañol;
                    Config.selecLan = "es";
                    break;
            }
        }

        private void ChangeTheme_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Picker dlgextract = new Picker() { Owner = this };
            dlgextract.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            // Cambiar el idioma si es necesario
            Config.CheckLanguage();

            // Si el idioma cambió, se deberá "reiniciar" la ventana principal
            // para actualizar el idioma
            if (Config.Restart)
            {
                Console.WriteLine("Restarting - Reiniciando");
                MainWindow updatedMain = new MainWindow
                {
                    Owner = (MainWindow)Application.Current.MainWindow,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };
                updatedMain.Show();
                updatedMain.Owner = null;
                ((MainWindow)Application.Current.MainWindow).Close();
                Application.Current.MainWindow = updatedMain;
                Config.Restart = false;
            }
        }
    }
}