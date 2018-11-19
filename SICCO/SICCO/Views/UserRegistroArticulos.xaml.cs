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
using System.Reflection;

namespace SICCO.Views
{
    /// <summary>
    /// Lógica de interacción para UserRegistroArticulos.xaml
    /// </summary>
    public partial class UserRegistroArticulos : UserControl
    {
        public UserRegistroArticulos()
        {
            InitializeComponent();
        }
        /*FileStream fs;
        BinaryReader br;
        byte[] ImageData;*/
        OpenFileDialog op = new OpenFileDialog();
        byte[] data1;
        FileStream file;
        string path;
        ASCIIEncoding encoding = new ASCIIEncoding();
        bool aRCHIVO_Seleccionado = false, Registrado = false;
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
                using (var stream = new FileStream(op.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        using (StreamReader sr = new StreamReader(op.FileName))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                sr.BaseStream.CopyTo(ms);
                                data1 = ms.ToArray();
                            }
                        }
                    }
                    stream.Close();
                }
            }
            Random a = new Random();
            int NUM = a.Next(1, 1000000000);
            string executableLocation = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = "iew" + NUM + ".jpg";
            string xslLocation = System.IO.Path.Combine(executableLocation, path);
            path = @"\\" + path;
            using (file = new FileStream(xslLocation, FileMode.Create))
            {
                file.Write(data1, 0, data1.Count());
              
            }

        }

        private void BotonAceptar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegistarArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (aRCHIVO_Seleccionado)
            {
                if (Tipo.SelectedIndex == 0)
                {
                    string postdata = "NOM=" + NombreArticulo.Text + "&TIP=" + Tipo.SelectedIndex + "&CAT=" + Categoria.SelectedIndex + "&DES=" + Descripcion.Text + "&PREC=" + Precio.Text + "&NCO=" + Clase_php.No_Control_Usuario+ "&img=" +path;
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
                        string id = "";
                        Hecho.IsOpen = true;
                       
                    }
                    else
                    {
                        MessageBox.Show("No se registró");
                    }
                }
                else if (Tipo.SelectedIndex == 1)
                {
                    string postdata = "NOM=" + NombreArticulo.Text + "&MAT=" + Categoria.SelectedIndex + "&COS=" + Precio.Text + "&HOR=" + HoraInicio.Text + "-" + HoraFin.Text + "&DES=" + Descripcion.Text + "&NCO=" + Clase_php.No_Control_Usuario + "&img=" + path;
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
                        string busqueda = "";
                        Hecho.IsOpen = true;
                        
                    }
                    else
                    {
                        MessageBox.Show("Se registró");
                    }
                }




            }

        }
    }
}
        
    

