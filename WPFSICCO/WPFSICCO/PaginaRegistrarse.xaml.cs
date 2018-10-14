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
using Email;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;


namespace WPFSICCO
{

    /// <summary>
    /// Lógica de interacción para PaginaRegistrarse.xaml
    /// </summary>
    public partial class PaginaRegistrarse : Window
    {
        int clasificador = 1;
        public PaginaRegistrarse()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=base; SslMode=none");

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void CrearCuenta (object sender, RoutedEventArgs e)
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
                if (CajaEdad.Text == "" || isNumeric == false )
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
                        if(CajaEspecialidad.Text == "" || CajaSemestre.Text == "" || CajaEspecialidad.SelectedIndex == 0 || CajaSemestre.SelectedIndex == 0)
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
                                if(UsuarioRegistro.Text == "")
                                {
                                    msgText.Text = "Nombre de usuario no valido";
                                    Hecho.IsOpen = true;
                                }
                                else
                                {
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
            }
           
            

        }

        void RegistrarenDB()
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=base; SslMode=none");
            
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
            
            
                //Comparación de la especialidad---Buscar cómo cambiar la cajaespecialidad y semestre por una combobox o algo parecido        
                switch(CajaEspecialidad.SelectedIndex)
                {
                    case 1:
                        ESP = 1;
                        break;
                    case 2:
                        ESP = 2;
                        break;
                    case 3:
                        ESP = 3;
                        break;
                    case 4:
                        ESP = 4;
                        break;
                    default:
                        Error();
                        break;
                    
                }
                //Verificación de la longitud del numero de control para validacion de longitud en mysql
                if(N_CO_LENGHT.Length>15)
                {
                    Error();
                }
                //error si la confirmacion de contraseña no coincide con la contraseña
                if(PSS != C_PSS)
                {
                    Error();
                }

                if(SEM<=6 & SEM>=1)
                {
                    Error();
                }

            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "Insert into usuario(Nombre, Apellido_Paterno, Apellido_Materno, Especialidad, Semestre, No_Control, Edad, Nombre_usuarios, Contraseña, Correo) values('" + Nombre + "', '" + AP + "', '" + AM + "',"+ESP+","+SEM+","+NCO+","+ED+",'" + NUS + "', '" + PSS + "', '" + MAIL + "')";
            comando.Connection = con;
            try
            {
                con.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario Registrado Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);

            }

        }
        void Error()
        {
            MessageBox.Show("Error al introducir un dato");
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MessageBox.Show("Abierto");
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error" + ex);
            }
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

       
    }
}
