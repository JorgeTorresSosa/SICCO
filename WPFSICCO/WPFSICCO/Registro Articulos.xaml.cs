using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;




namespace WPFSICCO
{
    /// <summary>
    /// Lógica de interacción para Registro_Articulos.xaml
    /// </summary>
    public partial class Registro_Articulos : Window
    {
        public Registro_Articulos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hecho.IsOpen = true;

        }

        private void BotonExaminar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ImagenArticulo.Source = new BitmapImage(new Uri(op.FileName));
            }

        }

        private void BotonAceptar_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void RegistarArticulo_Click(object sender, RoutedEventArgs e)
        {
            Hecho.IsOpen = true;
        }
    }
}
