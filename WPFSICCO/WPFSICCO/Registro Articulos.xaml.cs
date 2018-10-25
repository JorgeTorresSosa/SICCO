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
        OpenFileDialog op = new OpenFileDialog();
        ASCIIEncoding encoding = new ASCIIEncoding();
        bool aRCHIVO_Seleccionado=false, Registrado = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hecho.IsOpen = true;

        }

        private void BotonExaminar_Click(object sender, RoutedEventArgs e)
        {
           
            
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            { 
                aRCHIVO_Seleccionado = true;
                ImagenArticulo.Source = new BitmapImage(new Uri(op.FileName));
                
            }

        }

        private void BotonAceptar_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void RegistarArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (aRCHIVO_Seleccionado)
            {
                //string Source = op.FileName;
                //MessageBox.Show(Source);
                //string distination = @"C:\Users\Elian Cruz\source\repos\JorgeTorresSosa\SICCO\WPFSICCO\WPFSICCO\Assets\";
                //File.Copy(Source, distination);

                if (Tipo.SelectedIndex == 0)
                {
                    string postdata = "NOM=" + NombreArticulo.Text + "&TIP=" + Tipo.SelectedIndex + "&CAT=" + Categoria.SelectedIndex + "&DES=" + Descripcion.Text + "&PREC=" + Precio.Text;
                    byte[] data = encoding.GetBytes(postdata);
                    WebRequest request = WebRequest.Create("http://sicconviene.com/img.php");
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
                    //MessageBox.Show(lectura_php);
                    if (lectura_php.Contains("Registrado_bien"))
                    {
                        Registrado = true;
                    }
                    leer.Close();
                    stream.Close();
                    if (Registrado)
                    {
                        Hecho.IsOpen = true;
                    }
                    else
                    {
                        MessageBox.Show("No se registró");
                    }
                }
                else if(Tipo.SelectedIndex==1)
                {
                    string postdata = "NOM=" + NombreArticulo.Text + "&MAT=" + Categoria.SelectedIndex + "&COS=" + Precio.Text + "&HOR=" + HoraInicio.Text + "-" + HoraFin.Text + "&DES=" + Descripcion.Text;
                    byte[] data = encoding.GetBytes(postdata);
                    WebRequest request = WebRequest.Create("http://sicconviene.com/img_2.php");
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
                    //MessageBox.Show(lectura_php);
                    if (lectura_php.Contains("Registrado_bien"))
                    {
                        Registrado = true;
                    }
                    leer.Close();
                    stream.Close();
                    if (Registrado)
                    {
                        Hecho.IsOpen = true;
                    }
                    else
                    {
                        MessageBox.Show("No se registró");
                    }
                }
            

                
                
            }
            
        }
    }
}
