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
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.Win32;
using System.Collections.Specialized;


namespace WPFSICCO
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Cargardatos();
        }

        void Cargardatos()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postdata = "NCO=" + Clase_php.No_Control_Usuario;
            byte[] data = encoding.GetBytes(postdata);
            WebRequest request = WebRequest.Create("http://sicconviene.com/REG_CONEX_1.php");
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
}
