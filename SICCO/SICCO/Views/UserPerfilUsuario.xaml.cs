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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace SICCO.Views
{
    /// <summary>
    /// Lógica de interacción para UserPerfilUsuario.xaml
    /// </summary>
    public partial class UserPerfilUsuario : UserControl
    {
        public UserPerfilUsuario()
        {
            InitializeComponent();
        }

        private void HyperFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                FotoPerfil.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void BotonCambiarContra_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EnviarDatos_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
