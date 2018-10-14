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
    }
}
