using HandyControl.Themes;
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
        internal static string format = "";

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

        #region Language
        internal static string currentLan, selecLan;

        internal static void Language()
        {
            // Modificar el idioma de la aplicación en base a Config.ini y establecer
            // el idioma actual en un string para no volveer a leer el archivo
            switch (iniLines[1])
            {
                case "Language = en":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("");
                    currentLan = "en";
                    selecLan = "en";
                    break;
                case "Language = es":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es-419");
                    currentLan = "es";
                    selecLan = "es";
                    break;
                case "Language = de":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
                    currentLan = "de";
                    selecLan = "de";
                    break;
                case "Language = zh":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
                    currentLan = "zh";
                    selecLan = "zh";
                    break;
            }

            Console.WriteLine("Current language: " + currentLan + " - Idioma actual: " + currentLan + " - Aktuelle Sprache: " + currentLan);
        }

        internal static void CheckLanguage()
        {
            // Si el idioma seleccionado no es el mismo que el actual,
            // cambiarlo y modificar el archivo .ini
            if (selecLan != currentLan)
            {
                switch (selecLan)
                {
                    case "en":
                        iniLines[1] = iniLines[1].Replace(currentLan, "en");
                        File.WriteAllLines(iniPath, iniLines);
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("");
                        currentLan = "en";
                        break;
                    case "es":
                        iniLines[1] = iniLines[1].Replace(currentLan, "es");
                        File.WriteAllLines(iniPath, iniLines);
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es-419");
                        currentLan = "es";
                        break;
                    case "de":
                        iniLines[1] = iniLines[1].Replace(currentLan, "de");
                        File.WriteAllLines(iniPath, iniLines);
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
                        currentLan = "de";
                        break;
                    case "zh":
                        iniLines[1] = iniLines[1].Replace(currentLan, "zh");
                        File.WriteAllLines(iniPath, iniLines);
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
                        currentLan = "zh";
                        break;
                }

                Console.WriteLine("Selected language: " + selecLan + " - Idioma seleccionado: " + selecLan);
                restart = true;
            }

            Console.WriteLine("Selected language: " + selecLan + " - Idioma seleccionado: " + selecLan + " - Gewählte Sprache: " + selecLan);
            restart = true;
        }
        #endregion

        #region Theme
        internal static string HEX;
        internal static SolidColorBrush colorBrush;
        internal static string winvers;

        internal static void GetTheme()
        {
            // Obtiene el color HEX de Config.ini
            HEX = iniLines[5];

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
            if (iniLines[2].Contains("Topmost = true"))
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
        internal static void GetSize()
        {
            // Obtener la configuración del los tamaños que se incluirán
            // en el icono y establecer el valor en un string
            switch (iniLines[8])
            {
                case "Size = multiple":
                    format = "multiple";
                    break;

                case "Size = 256":
                    format = "256";
                    break;
            }
        }

        internal static void SetSize(string size)
        {
            // Aplicar la configuración del los tamaños que se incluirán
            // en el icono y actualizar el archivo Config.ini
            format = size;

            switch (size)
            {
                case "multiple":
                    iniLines[8] = iniLines[8].Replace("256", "multiple");
                    File.WriteAllLines(iniPath, iniLines);
                    break;

                case "256":
                    iniLines[8] = iniLines[8].Replace("multiple", "256");
                    File.WriteAllLines(iniPath, iniLines);
                    break;
            }

            Console.WriteLine("Format size: " + format + " - Formato de tamaño: " + format + " - Formatgröße: " + format);
        }
        #endregion
    }
}
