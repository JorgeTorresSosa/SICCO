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
using System.Reflection;
using System.Globalization;
using System.Text.RegularExpressions;
using Email;




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

            RegexUtilities utilities = new RegexUtilities();
            if (utilities.IsValidEmail(CorreoElc.Text))
            {
                msgText.Text = "Operacion Satisfactoria";
                Hecho.IsOpen = true;
                
                this.Hide();

            }
            else
            {
                msgText.Text = "Error en el correo electronico";
                Hecho.IsOpen = true;
            }

        }

    }
}
