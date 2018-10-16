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

namespace WPFSICCO
{
    
    public partial class MainWindow : Window
    {
        int clasificador = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        int valor = 0;
        
        MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=cocsi; SslMode=none");

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
            this.Hide();
            
        }

        private void OlvContr_Click  (object sender, RoutedEventArgs e)
        {

        }


        private void Buttonn_Click_1(object sender, RoutedEventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=cocsi;SslMode=none");
            try
            {
                con.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "Select * from usuario where Nombre_usuarios='" + txt_NombreUsuario.Text + "' and Contraseña='" + txt_Contraseña.Password + "'";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                DataTable Tabla = new DataTable();
                MySqlDataAdapter Adaptar_Tipo = new MySqlDataAdapter(comando);
                Adaptar_Tipo.Fill(Tabla);
                valor = Convert.ToInt32(Tabla.Rows.Count.ToString());
                if (valor == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    MessageBox.Show("Bien");
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("error"+ex);
            }
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
    }
}
