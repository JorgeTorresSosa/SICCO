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
using Microsoft.Win32;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Specialized;

namespace SICCO.Views
{
    /// <summary>
    /// Lógica de interacción para UserPerfilUsuario.xaml
    /// </summary>
    public partial class UserPerfilUsuario : UserControl
    {
        string lectura_php = "";
        public UserPerfilUsuario()
        {
            InitializeComponent();
            ShowUserData();
        }
        bool cambiarcontra = false, datos=false;
        private void HyperFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                FotoPerfil.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        void ShowUserData()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postdata = "NCO=" + Clase_php.No_Control_Usuario;
            byte[] data = encoding.GetBytes(postdata);
            WebRequest request = WebRequest.Create("http://sicconviene.com/Perfil.php");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();
            StreamReader leer = new StreamReader(stream);
            lectura_php = leer.ReadToEnd();
            Compare();
        }
        void Compare()
        {
            if (cambiarcontra == true)
            {
                if (CajaContraNueva.Text == CajaConfContraNueva.Text)
                {
                    EnviarCambio_Contra();
                }
            }
            else if (datos == true)
            {
                CambiarDatos();
            }
            int indice1, indice2, indice3, indice4, indice5, indice6, indice7, indice8, indice9, indice10;
            indice1 = lectura_php.IndexOf("o");
            indice2 = lectura_php.IndexOf("@");
            indice3 = lectura_php.IndexOf("#");
            indice4 = lectura_php.IndexOf("$");
            indice5 = lectura_php.IndexOf("+");
            indice6 = lectura_php.IndexOf("/");
            indice7 = lectura_php.IndexOf("*");
            indice8 = lectura_php.IndexOf(";");
            indice9 = lectura_php.IndexOf("!");
            indice10 = lectura_php.IndexOf("%");
            CajaNombre.Text = lectura_php.Substring(indice1+1, (indice2-(indice1+1)))+" "+lectura_php.Substring(indice2+1, (indice3-(indice2+1)))+" "+lectura_php.Substring(indice3+1, (indice4-(indice3+1)));
             switch (lectura_php.Substring(indice4+1, (indice5-(indice4+1))))
               {
                   case ("1"):
                   CajaEspecialidad.SelectedIndex= 1;
                   break;
                   case ("2"):
                   CajaEspecialidad.SelectedIndex = 2;
                   break;
                   case ("3"):
                   CajaEspecialidad.SelectedIndex = 3;
                   break;
                   case ("4"):
                   CajaEspecialidad.SelectedIndex = 4;
                   break;
               }
           CajaSemestre.Text = lectura_php.Substring(indice5 + 1, (indice6 - (indice5 + 1)));
            
           N_US.Text= lectura_php.Substring(indice6 + 1, (indice7 - (indice6 + 1)));
            CajaEdad.Text= lectura_php.Substring(indice7 + 1, (indice8 - (indice7 + 1)));
            CajaNombreUsuario.Text= lectura_php.Substring(indice8 + 1, (indice9 - (indice8 + 1)));
            CajaCorreoElectronico.Text= lectura_php.Substring(indice10 + 1, (lectura_php.Length-4 - (indice10 + 1)));
            CajaContraVieja.Text= lectura_php.Substring(indice9 + 1, (indice10 - (indice9 + 1)));
               

        }

        void EnviarCambio_Contra()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postdata = "PSSWRD=" + CajaContraNueva.Text+"&OLDPSSWRD="+CajaContraVieja.Text;
            byte[] data = encoding.GetBytes(postdata);
            WebRequest request = WebRequest.Create("http://sicconviene.com/New_Password.php");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();
            StreamReader leer = new StreamReader(stream);
            lectura_php = leer.ReadToEnd();
            MessageBox.Show(lectura_php);
            ShowUserData();
        }

        void CambiarDatos()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postdata = "NOM=" + CajaNombre.Text + "&ESP=" + CajaEspecialidad.SelectedIndex+1+"&SEM=" + CajaSemestre.SelectedIndex +"&NCO="+Clase_php.No_Control_Usuario +"&ED="+CajaEdad.Text+"&NUS=" + CajaNombreUsuario.Text + "&MAIL="+CajaCorreoElectronico.Text;
            byte[] data = encoding.GetBytes(postdata);
            WebRequest request = WebRequest.Create("http://sicconviene.com/ChangeUser_Info.php");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();
            StreamReader leer = new StreamReader(stream);
            lectura_php = leer.ReadToEnd();
            MessageBox.Show(lectura_php);
            ShowUserData();
        }

        private void BotonCambiarContra_Click(object sender, RoutedEventArgs e)
        {
            EnviarCambio_Contra();
        }

        private void EnviarDatos_Click(object sender, RoutedEventArgs e)
        {
            CambiarDatos();
        }
    }
}
