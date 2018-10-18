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

namespace WPFSICCO
{
    /// <summary>
    /// Lógica de interacción para Pagina_Articulos.xaml
    /// </summary>
    public partial class Pagina_Articulos : Window
    {
        public Pagina_Articulos()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Imagen1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImagenPrin.Source = Imagen1.Source;
        }

        private void Imagen2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImagenPrin.Source = Imagen2.Source;
        }

        private void Imagen3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImagenPrin.Source = Imagen3.Source;
        }

        private void Imagen4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImagenPrin.Source = Imagen4.Source;
        }

        private void Imagen5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImagenPrin.Source = Imagen5.Source;
        }
    }
}
