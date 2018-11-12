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
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Specialized;
using SICCO.ViewModels;
using SICCO.Views;

namespace SICCO
{
    public partial class Pantalla_inicio : Window
    {
        
        public Pantalla_inicio()
        {
            InitializeComponent();
            DataContext = new UserCategorias();
        }

        private void AbrirMenu_Click(object sender, RoutedEventArgs e)
        {
            AbrirMenu.Visibility = Visibility.Collapsed;
            CerrarMenu.Visibility = Visibility.Visible;

        }

        private void CerrarMenu_Click(object sender, RoutedEventArgs e)
        {
            AbrirMenu.Visibility = Visibility.Visible;
            CerrarMenu.Visibility = Visibility.Collapsed;

        }


        ///////// Menu //////////// 
        private void BtnPerfil_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new UserPerfilUsuario();
        }

        private void BtnAgregarArticulo_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new UserRegistroArticulos();
            BtnAgregarArticulo.IsSelected = false;

        }

        private void BtnMisCompras_Selected(object sender, RoutedEventArgs e)
        {
            BtnMisCompras.IsSelected = false;
        }

        private void BtnMisArticulos_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCategorias_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new UserCategorias();
            BtnCategorias.IsSelected = false;
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Buscar_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                Clase_php.Busqueda = Buscar.Text;
                DataContext = new UserResultadoBusqueda();


            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BotonSalirCuenta_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.usuario = "";
            Properties.Settings.Default.Save();
            Properties.Settings.Default.contraseña = "";
            Properties.Settings.Default.Save();
            Properties.Settings.Default.recordar = false;
            Properties.Settings.Default.Save();
            MainWindow ingresar = new MainWindow();
            ingresar.Show();
            this.Close();
        }
    }
}
