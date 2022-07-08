using System;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DropIcons
{
    /// <summary>
    /// Hand cursor & custom font.
    /// </summary>
    internal class CursorFont
    {
        #region Hand Cursor
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        internal static extern IntPtr LoadCursor(IntPtr hInstance, int CursorName);

        internal static readonly Cursor Hand = new Cursor(LoadCursor(IntPtr.Zero, 32649));

        // Utiliza el cursor hand del usuario
        internal static void HandCursorFix()
        {
            typeof(Cursors).GetField("hand", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, Hand);
        }
        #endregion

        #region Font
        internal static readonly PrivateFontCollection pfc = new PrivateFontCollection();

        internal static Font NotoSans8;

        internal static Font NotoSans9;

        // Font personalizada para cada tamaño.
        internal static void SetFont()
        {
            pfc.AddFontFile(@"Docs\Noto Sans\NotoSans-Regular.ttf");
            NotoSans8 = new Font(pfc.Families[0], 8);
            NotoSans9 = new Font(pfc.Families[0], 9);
        }
        #endregion

        #region DisposeAll
        internal static void DisposeAll()
        {
            Hand.Dispose();
            NotoSans8.Dispose();
            NotoSans9.Dispose();
            pfc.Dispose();
        }
        #endregion
    }
}