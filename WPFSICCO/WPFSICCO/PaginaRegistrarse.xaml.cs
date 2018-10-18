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

namespace WPFSICCO
{

    /// <summary>
    /// Lógica de interacción para PaginaRegistrarse.xaml
    /// </summary>
    public partial class PaginaRegistrarse : Window
    {
        WebClient aa = new WebClient();
        bool PrimeraVez = false;
        int valor = 1;
        int clasificador = 1;
        public PaginaRegistrarse()
        {
            InitializeComponent();
        }
        //MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=base; SslMode=none");

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        void Comprobacion_USIARIO()
        {
          /*   con.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "Select * from usuario where Nombre_usuarios='" + UsuarioRegistro.Text + "' and Correo='" + CorreoElc.Text + "'";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                DataTable Tabla = new DataTable();
                MySqlDataAdapter Adaptar_Tipo = new MySqlDataAdapter(comando);
                Adaptar_Tipo.Fill(Tabla);
                valor = Convert.ToInt32(Tabla.Rows.Count.ToString());              
        
    */}

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
        //    MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=base; SslMode=none");
            
            string Nombre, AP, AM, NUS, PSS, MAIL,C_PSS, N_CO_LENGHT;
            int ESP=0, SEM, ED, NCO;
                                        //Los comentarios significan el nombre de la variable en la DB
            Nombre = CajaNombre.Text;   //Nombre
            AP = CajaApellidoPaterno.Text;//Apellido_Paterno
            AM = CajaApellidoMaterno.Text;//Apellido_Materno
            NCO = Int32.Parse(NoControl.Text);//No_Control----Primary Key
            NUS = UsuarioRegistro.Text;//Nombre_usuarios
            PSS = Contra.Password;//Contraseña
            MAIL = CorreoElc.Text;//Correo
            C_PSS = ConfContra.Password;//
            ED = Int32.Parse(CajaEdad.Text);//Edad
            SEM = Int32.Parse(CajaSemestre.Text);//Semestre
            N_CO_LENGHT = NoControl.Text;//Confirmacion de la contraseña
        
            ESP = CajaEspecialidad.SelectedIndex;

            NameValueCollection a = new NameValueCollection();
            a.Add("Nombre", CajaNombre.Text);
            a.Add("Apellido_Paterno", CajaApellidoPaterno.Text);
            a.Add("Apellido_Materno", CajaApellidoMaterno.Text);
            a.Add("Especialidad", CajaEspecialidad.SelectedIndex.ToString());
            a.Add("Semestre", CajaSemestre.Text);
            a.Add("No_Control", NoControl.Text);
            a.Add("Edad", CajaEdad.Text);
            a.Add("Nombre_usuarios", UsuarioRegistro.Text);
            a.Add("Contraseña", Contra.Password);
            a.Add("Correo", CorreoElc.Text);
            byte[] insertuser = aa.UploadValues("https://sicco58.000webhostapp.com/REG_CONEX_1.php", "POST", a);
            msgText.Text = "Usuario registrado correctamente";


            /*MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "Insert into usuario(Nombre, Apellido_Paterno, Apellido_Materno, Especialidad, Semestre, No_Control, Edad, Nombre_usuarios, Contraseña, Correo) values('" + Nombre + "', '" + AP + "', '" + AM + "',"+ESP+","+SEM+","+NCO+","+ED+",'" + NUS + "', '" + PSS + "', '" + MAIL + "')";
            comando.Connection = con;
            try
            {
                con.Open();
                comando.ExecuteNonQuery();
                msgText.Text = "Usuario registrado correctamente";
                Hecho.IsOpen = true;
               
            }
            catch (Exception ex)
            {
                msgText.Text = "Error:" + ex;
                Hecho.IsOpen = true;

            }
            
    */

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
                MainWindow pantalla = new MainWindow();
                pantalla.Show();
                this.Close();
            }
            
        }
    }
}
