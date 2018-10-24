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
using System.Reflection;
using System.Globalization;
using System.Text.RegularExpressions;
using Correo;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Http;
using Microsoft.Win32;
using System.Collections.Specialized;
using System.IO;

namespace WPFSICCO
{

    /// <summary>
    /// Lógica de interacción para PaginaRegistrarse.xaml
    /// </summary>
    public partial class PaginaRegistrarse : Window
    {
        WebClient aa = new WebClient();
        int clasificador = 1;
        public PaginaRegistrarse()
        {
            InitializeComponent();
        }     

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
   
        private void CrearCuenta(object sender, RoutedEventArgs e)
        {
            

            if (CajaNombre.Text == "" || CajaApellidoPaterno.Text == "" || CajaApellidoMaterno.Text == "")
            {
                msgText.Text = "Apellidos o nombre en blanco";
                Hecho.IsOpen = true;
            }
            else
            {
                int n;
                bool isNumeric = int.TryParse(CajaEdad.Text, out n);
                if (CajaEdad.Text == "" || isNumeric == false)
                {
                    msgText.Text = "Edad no valida";
                    Hecho.IsOpen = true;
                }
                else
                {
                    isNumeric = int.TryParse(NoControl.Text, out n);
                    if (NoControl.Text == "" || isNumeric == false)
                    {
                        msgText.Text = "Numero de control no valido";
                        Hecho.IsOpen = true;
                    }
                    else
                    {
                        if (CajaEspecialidad.Text == "" || CajaSemestre.Text == "" || CajaEspecialidad.SelectedIndex == 0 || CajaSemestre.SelectedIndex == 0)
                        {
                            msgText.Text = "Especialidad o semestre no seleccionado";
                            Hecho.IsOpen = true;
                        }
                        else
                        {
                            RegexUtilities utilities = new RegexUtilities();
                            if (utilities.IsValidEmail(CorreoElc.Text) == false)
                            {
                                msgText.Text = "Correo electronico no valido";
                                Hecho.IsOpen = true;
                            }
                            else
                            {
                                if (UsuarioRegistro.Text == "")
                                {
                                    msgText.Text = "Nombre de usuario no valido";
                                    Hecho.IsOpen = true;
                                }
                                else
                                    if (Contra.Password == "" || Contra.Password != ConfContra.Password)
                                    {
                                        msgText.Text = "Las contraseñas no coinciden";
                                        Hecho.IsOpen = true;
                                    }
                                    else
                                    {
                                        RegistrarenDB();
                                    }
                                }
                            }
                        }
                    }
                }
            RegistrarenDB();
        }
        

        void RegistrarenDB()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postdata = "NOM=" + CajaNombre.Text + "&AP=" + CajaApellidoPaterno.Text + "&AM=" + CajaApellidoMaterno.Text + "&ESP=" + CajaEspecialidad.SelectedIndex + "&SEM=" + CajaSemestre.Text + "&NCO=" + NoControl.Text + "&ED=" + CajaEdad.Text + "&NUS=" + UsuarioRegistro.Text + "&PSS=" + Contra.Password + "&MAIL=" + CorreoElc.Text;
            byte[] data = encoding.GetBytes(postdata);
            //"NU=" + txt_NombreUsuario.Text +
            WebRequest request = WebRequest.Create("https://sicco58.000webhostapp.com/REG_CONEX_1.php");
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
            MessageBox.Show(lectura_php);
            leer.Close();
            stream.Close();
            msgText.Text = "Usuario registrado correctamente";
            if (lectura_php.Contains("Registros_generados"))
            {
                if (msgText.Text == "Usuario registrado correctamente")
                {
                    MainWindow pantalla = new MainWindow();
                    pantalla.Show();
                    this.Close();
                }
            }
            else if (lectura_php.Contains("usuario ya registrado"))
            {
                MessageBox.Show("Uusario ya registrado");
            }


        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            
        }

        private void ConfContra_MouseEnter(object sender, MouseEventArgs e)
        {
            if (clasificador == 1)
            {
                EyeOff.Kind = MaterialDesignThemes.Wpf.PackIconKind.Eye;
                clasificador = -1;
                ConfContra.Visibility = System.Windows.Visibility.Collapsed;
                ConfContraV.Visibility = System.Windows.Visibility.Visible;
                Contra.Visibility = System.Windows.Visibility.Collapsed;
                ContraV.Visibility = System.Windows.Visibility.Visible;
                ContraV.Focus();
                ConfContraV.Focus();
            }
            else if (clasificador == -1)
            {
                EyeOff.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOff;
                clasificador = 1;
                ConfContra.Visibility = System.Windows.Visibility.Visible;
                ConfContraV.Visibility = System.Windows.Visibility.Collapsed;
                Contra.Visibility = System.Windows.Visibility.Visible;
                ContraV.Visibility = System.Windows.Visibility.Collapsed;
                Contra.Focus();
                ConfContra.Focus();
            }

        }

        private void BotonAceptar_Click(object sender, RoutedEventArgs e)
        {
            if(msgText.Text == "Usuario registrado correctamente")
            {
                MainWindow pantallaMainWindow_Form = new MainWindow();
                pantallaMainWindow_Form.Show();
                this.Close();
            }
            
        }
    }
}
