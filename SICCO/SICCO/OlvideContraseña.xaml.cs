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
using System.Net;
using System.Net.Mail;

namespace SICCO
{
    /// <summary>
    /// Lógica de interacción para OlvideContraseña.xaml
    /// </summary>
    public partial class OlvideContraseña : Window
    {
        public OlvideContraseña()
        {
            InitializeComponent();
        }

        private void BotonCorreo_Click(object sender, RoutedEventArgs e)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add("eliancruz998@gmail.com");
            msg.Subject = "olvidaste tu contraseña";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            msg.Body = "Es una prueba jaja";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress("cocksy58@gmail.com");

            SmtpClient cliente = new SmtpClient();
            cliente.Credentials = new NetworkCredential("cocksy58@gmail.com", "Sicco58@");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";
            try
            {
                cliente.Send(msg);
            }
            catch (Exception ex)
            {
                msgText.Text = "Error:" + ex;
                Hecho.IsOpen = true;
            }
            
            Hecho.IsOpen = true;
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BotonAceptar_Click(object sender, RoutedEventArgs e)
        {
            




        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
