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
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Specialized;

namespace SICCO.Views
{
    /// <summary>
    /// Lógica de interacción para UserCategorias.xaml
    /// </summary>
    public partial class UserCategorias : UserControl
    {
        public UserCategorias()
        {
            InitializeComponent();
        }

        private void BotonArtes_Click(object sender, RoutedEventArgs e)
        {
            Clase_php.Categoria = 1;
            Clase_php.PaginaArticulos = false;
            this.Content = new UserResultadoBusqueda();
        }

        private void BotonCiencias_Click(object sender, RoutedEventArgs e)
        {
            Clase_php.Categoria = 2;
            Clase_php.PaginaArticulos = false;
            this.Content = new UserResultadoBusqueda();
        }

        private void BotonCursos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BotonMatematicas_Click(object sender, RoutedEventArgs e)
        {
            Clase_php.Categoria = 3;
            Clase_php.PaginaArticulos = false;
            this.Content = new UserResultadoBusqueda();
        }

        private void BotonPapeleria_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BotonOtros_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
