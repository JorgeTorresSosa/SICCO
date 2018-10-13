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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int a = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        int valor = 0;
        MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=base");

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Application.Current.Shutdown();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; database=base");
            con.Open();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "Select * from usuario where Nombre_usuarios='" + txt_NombreUsuario.Text + "' and Contraseña='" + txt_Contraseña.Password+ "'";
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

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PaginaRegistrarse Ir = new PaginaRegistrarse();
            this.Hide();
            Ir.Show();
        }
    }
}
