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
    /// About, Licenses, Theme, Format and Language
    /// </summary>
    public partial class About : Window
    {
        public bool icoisOpen = false;

        private void SV_info()
        {
            License.Text = File.ReadAllText(@"Docs\SharpVectors.txt");
            Description.Content = "SVG DOM and Rendering in C# for the .Net";
            ScrollView.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }

        private void DI_info()
        {
            License.Text = File.ReadAllText(@"Docs\Drop Icons.txt");
            Description.Content = Properties.Resources.UtilityToConvertImagesToIcons;
        }

        public About()
        {
            InitializeComponent();
        }

        private void Arrows(Label visibleArrw, Label opacityBtn)
        {
            // Oculta todas las flechas y restaura la opacidad
            // para mostrar y cambiar la opacidad de la que se indique
            Arrw_1.Visibility = Visibility.Hidden;
            Arrw_2.Visibility = Visibility.Hidden;
            Arrw_Folder.Visibility = Visibility.Hidden;
            Arrw_Handy.Visibility = Visibility.Hidden;
            Arrw_Iconizer.Visibility = Visibility.Hidden;
            Arrw_Teeny.Visibility = Visibility.Hidden;

            Btn_1.Opacity = 1;
            Btn_2.Opacity = 1;
            Btn_Folder.Opacity = 1;
            Btn_Handy.Opacity = 1;
            Btn_Iconizer.Opacity = 1;
            Btn_Teeny.Opacity = 1;

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
            Config.GetSize();

            switch (Config.format)
            {
                case "multiple":
                    Check_all.IsChecked = true; ;
                    break;

                case "256":
                    Check_256.IsChecked = true;
                    break;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Mover ventana sin bordes
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Btn_1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (Btn_1.Content)
            {
                case "Drop Icons":
                    DI_info();
                    break;
                case "SharpVectors":
                    SV_info();
                    break;
            }
            Arrows(Arrw_1, Btn_1);
        }

        private void Btn_2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (Btn_2.Content)
            {
                case "Noto Music":
                    License.Text = File.ReadAllText(@"Docs\Noto Music\OFL.txt");
                    Description.Content = "Global font collection for writing in all modern and ancient languages";
                    break;
                case "WinVersion":
                    License.Text = File.ReadAllText(@"Docs\WinVersion.txt");
                    Description.Content = "Windows 11 Version Detection";
                    break;
            }
            Arrows(Arrw_2, Btn_2);
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

        private void Link_Click(object sender, RoutedEventArgs e)
        {
            if (Arrw_2.Visibility == Visibility.Visible)
            {
                switch (Btn_2.Content)
                {
                    case "Noto Music":
                        _ = Process.Start("https://fonts.google.com/noto/specimen/Noto+Sans");
                        break;
                    case "WinVersion":
                        _ = Process.Start("https://github.com/shaovoon/win_version_detection");
                        break;
                }
            }
            else if (Arrw_Teeny.Visibility == Visibility.Visible)
            {
                _ = Process.Start("https://teenyicons.com/");
            }
            else if (Arrw_Iconizer.Visibility == Visibility.Visible)
            {
                _ = Process.Start("https://github.com/willnode/Iconizer");
            }
            else if (Arrw_1.Visibility == Visibility.Visible)
            {
                switch (Btn_1.Content)
                {
                    case "Drop Icons":
                        _ = Process.Start("https://genesistoxical.github.io/drop-icons/");
                        break;
                    case "SharpVectors":
                        _ = Process.Start("https://github.com/ElinamLLC/SharpVectors/");
                        break;
                }
                
            }
            else if (Arrw_Folder.Visibility == Visibility.Visible)
            {
                _ = Process.Start("https://github.com/evaristocuesta/FolderBrowserEx");
            }
            else if (Arrw_Handy.Visibility == Visibility.Visible)
            {
                _ = Process.Start("https://github.com/ghost1372/HandyControls");
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

        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
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
            if (Config.restart)
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
                Config.restart = false;
            }
        }

        private void Icons_Click(object sender, RoutedEventArgs e)
        {
            if (icoisOpen == false)
            {
                Icons.ContextMenu.IsOpen = true;
                icoisOpen = true;
            }
            else
            {
                Icons.ContextMenu.IsOpen = false;
                icoisOpen = false;
            }
        }

        private void Check_all_Click(object sender, RoutedEventArgs e)
        {
            Check_256.IsChecked = false;

            if (Check_all.IsChecked == false)
                Check_all.IsChecked = true;

            Config.SetSize("multiple");
        }

        private void Check_256_Click(object sender, RoutedEventArgs e)
        {
            Check_all.IsChecked = false;

            if (Check_256.IsChecked == false)
                Check_256.IsChecked = true;

            Config.SetSize("256");
        }

        private void Back_Next_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Btn_1.Content = "SharpVectors";
            Btn_2.Content = "WinVersion";
            Btn_Folder.Visibility = Visibility.Hidden;
            Btn_Handy.Visibility = Visibility.Hidden;
            Btn_Iconizer.Visibility = Visibility.Hidden;
            Btn_Teeny.Visibility = Visibility.Hidden;

            SV_info();
            Arrows(Arrw_1, Btn_1);

            if (Back_Next.Content.ToString() == Properties.Resources.Back)
            {
                Btn_1.Content = "Drop Icons";
                Btn_2.Content = "Noto Music";
                Btn_Folder.Visibility = Visibility.Visible;
                Btn_Handy.Visibility = Visibility.Visible;
                Btn_Iconizer.Visibility = Visibility.Visible;
                Btn_Teeny.Visibility = Visibility.Visible;
                Back_Next.Content = Properties.Resources.Next;

                DI_info();
            }
            else
            {
                Back_Next.Content = Properties.Resources.Back;
            }
        }

        private void IconsMenu_Closed(object sender, RoutedEventArgs e)
        {
            icoisOpen = false;
        }
    }
}