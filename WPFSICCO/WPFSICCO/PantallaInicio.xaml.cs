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

namespace WPFSICCO
{
    public partial class PantallaInicio : Window
    {
        public PantallaInicio()
        {
            InitializeComponent();
        }

        private void AbrirMenu_Click(object sender, RoutedEventArgs e)
        {
            AbrirMenu.Visibility = Visibility.Collapsed;
            CerrarMenu.Visibility = Visibility.Visible ;
            BtnInfo.Visibility = Visibility.Visible;
        }

        private void CerrarMenu_Click(object sender, RoutedEventArgs e)
        {
            AbrirMenu.Visibility = Visibility.Visible;
            CerrarMenu.Visibility = Visibility.Collapsed;
            BtnInfo.Visibility = Visibility.Collapsed;
        }
    }
}
