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
namespace SICCO
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UTF8Encoding utf = new UTF8Encoding();
        int clasificador = -1;
        public MainWindow()
        {
            
            InitializeComponent();
            if (Properties.Settings.Default.recordar == true)
            {
                txt_NombreUsuario.Text = Properties.Settings.Default.usuario;
                txt_Contraseña.Password = Properties.Settings.Default.contraseña;
                Basededatos();
            }
            Pantalla_inicio pan = new Pantalla_inicio();
            pan.Show();
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

        private void Ingresar_Click(object sender, RoutedEventArgs e)
        {
            PaginaRegistrarse registro = new PaginaRegistrarse();
            registro.Show();
            this.Close();

        }

        private void OlvContr_Click(object sender, RoutedEventArgs e)
        {
            OlvideContraseña olvcontra = new OlvideContraseña();
            olvcontra.ShowDialog();
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


            string pss = txt_Contraseña.Password;
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postdata = "NU=" + txt_NombreUsuario.Text + "&pss=" + pss;
            byte[] data = encoding.GetBytes(postdata);
            WebRequest request = WebRequest.Create("http://sicconviene.com/ABRIR_CONEX.php");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();
            StreamReader leer = new StreamReader(stream);
            string lectura_php = leer.ReadToEnd();
            leer.Close();
            stream.Close();
            if (lectura_php.Contains("registros_generados"))
            {
                msgText.Text = "Ingresado correctamente";
                if (RecordarContra.IsChecked == true)
                {
                    Properties.Settings.Default.usuario = txt_NombreUsuario.Text;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.contraseña = txt_Contrasena.Text;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.recordar = true;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.usuario = "";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.contraseña = "";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.recordar = false;
                    Properties.Settings.Default.Save();
                }
            }
            if (Properties.Settings.Default.recordar == true)
            {
                Hecho.IsOpen = true;
            }
            else
            {
                Pantalla_inicio PantallaInicio_Form = new Pantalla_inicio();
                PantallaInicio_Form.Show();
                this.Close();
            }


        }

        private void BotonAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (msgText.Text == "Ingresado correctamente")
            {
                Pantalla_inicio PantallaInicio_Form = new Pantalla_inicio();
                PantallaInicio_Form.Show();
                this.Close();

            }
        }
    }
}
