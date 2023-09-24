using System;
using System.Windows;
using System.Windows.Media;

namespace DropIcons
{
    /// <summary>
    /// Theme Color Picker
    /// </summary>
    public partial class Picker : Window
    {
        public Picker()
        {
            InitializeComponent();

            // Convertir a Brush el color actual del tema y aplicarlo
            // como selección por defecto del ColorPicker
            string curColor = Application.Current.Resources["Primary"].ToString();
            PickerControl.SelectedBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(curColor));
        }

        private void Default_Click(object sender, RoutedEventArgs e)
        {
            PickerControl.SelectedBrush.Color = (Color)ColorConverter.ConvertFromString("#9280FF");
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            // Cambiar el color del tema con el Brush seleccionado
            Config.colorBrush = PickerControl.SelectedBrush;
            Config.HEX = PickerControl.SelectedBrush.Color.ToString();
            Config.SetTheme();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PickerControl_SelectedColorChanged(object sender, HandyControl.Data.FunctionEventArgs<Color> e)
        {
            // Detectar si se aplicar un color semitransparente,
            // y de ser así, eliminar el alpha.
            string hex8 = PickerControl.SelectedBrush.Color.ToString();
            int alpha = PickerControl.SelectedBrush.Color.A;

            if (alpha < 146)
            {
                string hex6 = hex8.Substring(0, hex8.Length - 2);
                Console.WriteLine(hex6);
                PickerControl.SelectedBrush.Color = (Color)ColorConverter.ConvertFromString(hex6);
            }
        }
    }
}
