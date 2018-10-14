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

namespace WPFSICCO
{
    /// <summary>
    /// Lógica de interacción para PaginaRegistrarse.xaml
    /// </summary>
    public partial class PaginaRegistrarse : Window
    {
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(CajaNombre.Text!=null&CajaApellidoPaterno.Text!=null&CajaApellidoMaterno.Text!=null&NoControl.Text!=null&CorreoElc.Text!=null&UsuarioRegistro.Text!=null&ConfContra.Password!=null&Contra.Password!=null)
            {
                RegistrarenDB();
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
                switch(CajaEspecialidad.Text.ToLower())
                {
                    case "programacion":
                        ESP = 1;
                        break;
                    case "electronica":
                        ESP = 2;
                        break;
                    case "administracion":
                        ESP = 3;
                        break;
                    case "logistica":
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
    }
}
