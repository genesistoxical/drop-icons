using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace DropIcons
{
    /// <summary>
    /// Config.ini & Colors.dat
    /// </summary>
    internal class Config
    {
        internal static bool isIntalled;
        internal static string iniPath, datPath;
        internal static string[] iniLines;
        internal static bool Restart = false;

        internal static void CheckPath()
        {
            // Busca el archivo ini en la misma carpeta para saber si
            // Drop Icons está instalado o no, incluso si se tiene una
            // versión instalada y otra portable
            isIntalled = !File.Exists("Config.ini");

            // Establece las rutas de ini y dat, dependiendo de lo anterior
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Drop Icons";
            iniPath = isIntalled ? appdata + "\\Config.ini" : "Config.ini";
            datPath = isIntalled ? appdata + "\\Colors.dat" : "Colors.dat";
            iniLines = File.ReadAllLines(iniPath);

            Console.WriteLine("Drop Icons is installed? " + isIntalled + " - ¿Drop Icons está instalado? " + isIntalled);
        }

        internal static void Restarting(FormClosingEventArgs e)
        {
            // Condicional que ayuda a que no se inicie dos veces la aplicacion
#if !DEBUG
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
               Application.Restart();
            }
#endif
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
            }

            Console.WriteLine("Current language: " + currentLan + " - Idioma actual: " + currentLan);
        }

        internal static void CheckLanguage()
        {
            // Si el idioma seleccionado no es el mismo que el actual
            // modificar el archivo .ini para cambiarlo
            if (selecLan == currentLan == false)
            {
                switch (selecLan)
                {
                    case "en":
                        iniLines[1] = iniLines[1].Replace("es", "en");
                        File.WriteAllLines(iniPath, iniLines);
                        break;

                    case "es":
                        iniLines[1] = iniLines[1].Replace("en", "es");
                        File.WriteAllLines(iniPath, iniLines);
                        break;
                }

                Console.WriteLine("Selected language: " + selecLan + " - Idioma seleccionado: " + selecLan);
                Restart = true;
            }
        }
        #endregion

        #region TopMost
        internal static ContextMenu menu = new ContextMenu();

        internal static MenuItem item = new MenuItem();

        internal static bool isTopMost;

        internal static void TopMost(Form form)
        {
            // Modificar la propiedad TopMost en base a Config.ini y
            // establecer el valor en un bool para no volver a leer el archivo 
            if (iniLines[2].Contains("TopMost = true"))
            {
                form.TopMost = true;
                isTopMost = true;
            }
            else
            {
                isTopMost = false;
            }
        }

        internal static void ChangeTopMost(Form form)
        {
            // Cambiar la propiedad de TopMost en el form
            // y actualizar el archivo Config.ini
            switch (isTopMost)
            {
                case false:
                    form.TopMost = true;
                    isTopMost = true;
                    iniLines[2] = iniLines[2].Replace("false", "true");
                    File.WriteAllLines(iniPath, iniLines);
                    break;

                default:
                    form.TopMost = false;
                    isTopMost = false;
                    iniLines[2] = iniLines[2].Replace("true", "false");
                    File.WriteAllLines(iniPath, iniLines);
                    break;
            }

            Console.WriteLine("TopMost " + isTopMost.ToString());
        }

        internal static void TopDialog(Form form)
        {
            if (isTopMost)
            {
                form.TopMost = !form.TopMost;
            }
        }
        #endregion

        #region Theme
        internal static int R, G, B;

        internal static Color customH, custom;

        internal static void GetTheme()
        {
            // Obtiene los valores de R G B desde
            // Config.ini y lo conviertes a int
            R = int.Parse(iniLines[5]);
            G = int.Parse(iniLines[6]);
            B = int.Parse(iniLines[7]);

            // Crea los colores para aplicarlos
            custom = Color.FromArgb(255, R, G, B);
            customH = Color.FromArgb(229, R, G, B);
        }

        internal static void SetTheme()
        {
            // Establece un nuevo color del tema, remplazando dígitos
            Regex digits = new Regex(@"\d{1,}");
            iniLines[5] = digits.Replace(iniLines[5], R.ToString());
            iniLines[6] = digits.Replace(iniLines[6], G.ToString());
            iniLines[7] = digits.Replace(iniLines[7], B.ToString());

            File.WriteAllLines(iniPath, iniLines);
            Restart = true;
        }

        internal static void SaveColors(ColorDialog colordialog)
        {
            // Obtener los colores personalizados y guardarlos
            // en el archivo Colors.dat
            int[] customs = (int[])colordialog.CustomColors.Clone();
            string[] list = new string[16];

            for (int i = 0; i < 16; i++)
            {
                list[i] = customs[i].ToString();
                File.WriteAllLines(datPath, list);
            }
        }
        #endregion

        #region DisposeAll
        internal static void DisposeAll()
        {
            menu.Dispose();
            item.Dispose();
        }
        #endregion
    }
}