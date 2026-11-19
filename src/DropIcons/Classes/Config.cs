using HandyControl.Themes;
using HandyControl.Tools;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Application = System.Windows.Application;

namespace DropIcons
{
    /// <summary>
    /// Config.ini
    /// </summary>
    internal class Config
    {
        internal static bool isIntalled;
        internal static string iniPath;
        internal static string[] iniLines;
        internal static bool restart = false;

        internal static void CheckPath()
        {
            // Busca el archivo ini en la misma carpeta para saber si
            // Drop Icons está instalado o no, incluso si se tiene una
            // versión instalada y otra portable
            isIntalled = !File.Exists("Config.ini");

            // Establece las rutas de ini y dat, dependiendo de lo anterior
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Drop Icons";
            iniPath = isIntalled ? appdata + "\\Config.ini" : "Config.ini";
            iniLines = File.ReadAllLines(iniPath);

            Console.WriteLine("Drop Icons is installed? " + isIntalled + " - ¿Drop Icons está instalado? " + isIntalled + " - Drop Icons ist installiert? " + isIntalled);
        }

        /// <summary>
        /// iniLines[1]: LanguageㅤㅤiniLines[2]: TopmostㅤㅤiniLines[5]: Colorㅤ
        /// iniLines[8]: SizeㅤㅤiniLines[11]: StartupPositionㅤㅤiniLines[12]: Margin
        /// </summary>
        private static string GetIniValue(string line)
        {
            int separator = line.IndexOf('=');
            return line.Substring(separator + 1).Trim();
        }

        #region Language
        internal static string currentLan, selecLan;

        internal static void Language()
        {
            // Modificar el idioma de la aplicación en base a Config.ini y establecer
            // el idioma actual en un string para no volveer a leer el archivo

            string lang = GetIniValue(iniLines[1]);

            switch (lang)
            {
                case "en":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("");
                    break;
                case "es":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es-419");
                    break;
                case "de":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
                    break;
                case "zh":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
                    break;
                case "fr":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
                    break;
                case "ca":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ca");
                    break;
                case "pt":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");
                    break;
            }

            currentLan = lang;
            selecLan = lang;
            Console.WriteLine("Current language: " + currentLan + " - Idioma actual: " + currentLan + " - Aktuelle Sprache: " + currentLan);
        }

        internal static void CheckLanguage()
        {
            // Si el idioma seleccionado no es el mismo que el actual,
            // cambiarlo y modificar el archivo .ini
            if (selecLan != currentLan)
            {
                iniLines[1] = iniLines[1].Replace(currentLan, selecLan);
                File.WriteAllLines(iniPath, iniLines);

                switch (selecLan)
                {
                    case "en":
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("");
                        break;
                    case "es":
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es-419");
                        break;
                    case "de":
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
                        break;
                    case "zh":
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
                        break;
                    case "fr":
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
                        break;
                    case "ca":
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ca");
                        break;
                    case "pt":
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");
                        break;
                }

                currentLan = selecLan;

                Console.WriteLine("Selected language: " + selecLan + " - Idioma seleccionado: " + selecLan + " - Gewählte Sprache: " + selecLan);
                restart = true;
            }
        }
        #endregion

        #region Theme
        internal static string HEX;
        internal static SolidColorBrush colorBrush;
        internal static string winvers;

        internal static void GetTheme()
        {
            // Obtiene el color HEX de Config.ini
            HEX = GetIniValue(iniLines[5]);

            // Crear brush de nuevo color y aplicarlo al tema
            colorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(HEX));
            ThemeManager.Current.AccentColor = colorBrush;
            Application.Current.Resources["Primary"] = colorBrush;
        }

        internal static void SetTheme()
        {
            // Establece un nuevo color del tema, remplazando dígitos
            iniLines[5] = iniLines[5].Replace(iniLines[5], HEX);
            File.WriteAllLines(iniPath, iniLines);

            // Crear brush de nuevo color y aplicarlo al tema
            ThemeManager.Current.AccentColor = colorBrush;
            Application.Current.Resources["Primary"] = colorBrush;
        }

        internal static void RoundCorners(Border bg, Border border, Border deco)
        {
            // Desactivar bordes redondeados en las versiones METRO de Win
            if (winvers.Contains("10") || winvers.Contains("8"))
            {
                bg.CornerRadius = new CornerRadius(0, 0, 0, 0);
                border.CornerRadius = new CornerRadius(0, 0, 0, 0);
                deco.CornerRadius = new CornerRadius(0, 0, 0, 0);
            }
        }
        #endregion

        #region Topmost
        internal static bool isTopmost;

        internal static void Topmost(Window window)
        {
            // Modificar la propiedad TopMost en base a Config.ini y
            // establecer el valor en un bool para no volver a leer el archivo 
            string top = GetIniValue(iniLines[2]);

            if (top == "true")
            {
                window.Topmost = true;
                isTopmost = true;
            }
            else
            {
                isTopmost = false;
            }
        }

        internal static void ChangeTopmost(Window window)
        {
            // Cambiar la propiedad de TopMost en la ventana
            // y actualizar el archivo Config.ini
            switch (isTopmost)
            {
                case false:
                    window.Topmost = true;
                    isTopmost = true;
                    iniLines[2] = iniLines[2].Replace("false", "true");
                    File.WriteAllLines(iniPath, iniLines);
                    break;

                default:
                    window.Topmost = false;
                    isTopmost = false;
                    iniLines[2] = iniLines[2].Replace("true", "false");
                    File.WriteAllLines(iniPath, iniLines);
                    break;
            }

            Console.WriteLine("Topmost " + isTopmost.ToString());
        }
        #endregion

        #region Format
        internal static string format = "";

        internal static void GetSize()
        {
            // Obtener los tamaños que se incluirán en el icono
            format = GetIniValue(iniLines[8]);
        }

        internal static void SetSize(string size)
        {
            // Aplicar la configuración del los tamaños que se incluirán
            // en el icono y actualizar el archivo Config.ini
            string oldSize = format;
            format = size;
            iniLines[8] = iniLines[8].Replace(oldSize, size);
            File.WriteAllLines(iniPath, iniLines);

            Console.WriteLine("Format size: " + format + " - Formato de tamaño: " + format + " - Formatgröße: " + format);
        }
        #endregion

        #region Window
        internal static WindowPosition StartupPosition;
        internal static double WindowMargin = 56;

        internal enum WindowPosition
        {
            topleft,
            topright,
            bottomleft,
            bottomright,
            center
        }

        internal static void LoadWindowSettings()
        {
            // Carga la posición inicial y el margen de la ventana.
            string position = GetIniValue(iniLines[11]);

            if (Enum.TryParse(position, true, out WindowPosition parsedPosition) &&
                Enum.IsDefined(typeof(WindowPosition), parsedPosition))
            {
                StartupPosition = parsedPosition;
            }

            double margin = GetIniValue(iniLines[12]).ConvertToInt();
            WindowMargin = margin;
        }

        internal static void PositionWindow(Window window)
        {
            Rect area = SystemParameters.WorkArea;
            double margin = WindowMargin;

            switch (StartupPosition)
            {
                case WindowPosition.topleft:
                    window.Left = area.Left + margin;
                    window.Top = area.Top + margin;
                    break;

                case WindowPosition.topright:
                    window.Left = area.Right - window.ActualWidth - margin;
                    window.Top = area.Top + margin;
                    break;

                case WindowPosition.bottomleft:
                    window.Left = area.Left + margin;
                    window.Top = area.Bottom - window.ActualHeight - margin;
                    break;

                case WindowPosition.bottomright:
                    window.Left = area.Right - window.ActualWidth - margin;
                    window.Top = area.Bottom - window.ActualHeight - margin;
                    break;

                case WindowPosition.center:
                    window.Left = area.Left + (area.Width - window.ActualWidth) / 2;
                    window.Top = area.Top + (area.Height - window.ActualHeight) / 2;
                    break;
            }
        }

        #endregion

    }
}
