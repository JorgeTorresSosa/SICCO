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

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

       
    }
}
