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
using Microsoft.Win32;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Specialized;


namespace WPFSICCO
{
    /// <summary>
    /// Lógica de interacción para Registro_Articulos.xaml
    /// </summary>
    public partial class Registro_Articulos : Window
    {
        public Registro_Articulos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hecho.IsOpen = true;

        }

        private void BotonExaminar_Click(object sender, RoutedEventArgs e)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ImagenArticulo.Source = new BitmapImage(new Uri(op.FileName));
                FileStream Lectura_img = new FileStream(op.FileName, FileMode.Open, FileAccess.Read);
                byte[] Long_imagen = new byte[Lectura_img.Length];
                Lectura_img.Read(Long_imagen, 0, Convert.ToInt32(Lectura_img.Length));
                Lectura_img.Close();

                string postdata = "img=" + Long_imagen;
                byte[] data = encoding.GetBytes(postdata);
                //"NU=" + txt_NombreUsuario.Text +
                WebRequest request = WebRequest.Create("https://sicco58.000webhostapp.com/img.php");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();

                WebResponse response = request.GetResponse();
                stream = response.GetResponseStream();
                StreamReader leer = new StreamReader(stream);
                string lectura_php = leer.ReadToEnd();

                leer.Close();
                stream.Close();
            }

        }

        private void BotonAceptar_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void RegistarArticulo_Click(object sender, RoutedEventArgs e)
        {
            Hecho.IsOpen = true;
        }
    }
}
