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
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Xaml;
using XamlGeneratedNamespace;
using System.Net;
using System.Net.Http;
using Microsoft.Win32;
using System.Collections.Specialized;
using System.IO;

namespace WPFSICCO
{
    
    public partial class MainWindow : Window
    {
        UTF8Encoding utf = new UTF8Encoding();
        int clasificador = -1;
        public MainWindow()
        {
            InitializeComponent();
        }
        WebClient Reg_DB = new WebClient();
        
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Ingresar_Click (object sender, RoutedEventArgs e)
        {
            PaginaRegistrarse registro = new PaginaRegistrarse();
            registro.Show();
            this.Close();
            
        }

        private void OlvContr_Click  (object sender, RoutedEventArgs e)
        {
            Pagina_Articulos articulos = new Pagina_Articulos();
            articulos.Show();
            this.Close();
        }

        private void Buttonn_Click_1(object sender, RoutedEventArgs e)
        {
            Basededatos();
        }

        private void txt_Contrasena_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (clasificador == 1)
            {
                EyeOff.Kind = MaterialDesignThemes.Wpf.PackIconKind.Eye;
                clasificador = -1;
                txt_Contraseña.Visibility = System.Windows.Visibility.Collapsed;
                txt_Contrasena.Visibility = System.Windows.Visibility.Visible;             
                txt_Contrasena.Focus();
            }
            else if (clasificador == -1)
            {
               EyeOff.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOff;
                clasificador = 1;
                txt_Contraseña.Visibility = System.Windows.Visibility.Visible;
                txt_Contrasena.Visibility = System.Windows.Visibility.Collapsed;
                txt_Contraseña.Focus();
            }
        }
        void Basededatos()
        {


            NameValueCollection coex_db = new NameValueCollection();
            coex_db.Add("Nombre_usuarios", txt_NombreUsuario.Text);
            coex_db.Add("Contraseña", txt_Contraseña.Password);
            byte[] insertuser = Reg_DB.UploadValues("https://sicco58.000webhostapp.com/ABRIR_CONEX.php", "POST", coex_db);


            byte[] html = Reg_DB.DownloadData("https://sicco58.000webhostapp.com/ABRIR_CONEX.php");
            string res = utf.GetString(html);

            /*if (res == "Exite al menos un registro")
            {
                Console.WriteLine("AHuevo");
                MessageBox.Show("Ya jaloooo");
                
            }
            else if (res == "No jaló")
            {
                Console.WriteLine("Llego mal pero llego");
                MessageBox.Show("No jaló");

            }
            else
            {
                Console.WriteLine("puta madre...");
                MessageBox.Show("ERROR");
            }
            */
            MessageBox.Show(res);
        }

        private void BotonAceptar_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
