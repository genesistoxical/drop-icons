using System;
using System.Windows.Forms;

namespace DropIcons
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Config.CheckPath();
            Config.Language();
            CursorFont.SetFont();
            CursorFont.HandCursorFix();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());            
        }
    }
}
