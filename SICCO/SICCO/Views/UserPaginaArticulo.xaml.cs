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
    /// Lógica de interacción para UserPaginaArticulo.xaml
    /// </summary>
    public partial class UserPaginaArticulo : UserControl
    {
        public UserPaginaArticulo()
        {
            InitializeComponent();
           Cargar_Informacion_Articulo();
        }
        string lectura_php;
        void Cargar_Informacion_Articulo()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postdata = "ID_P=" + Clase_php.Id_Producto; ;
            byte[] data = encoding.GetBytes(postdata);
            WebRequest request = WebRequest.Create("http://sicconviene.com/ShowData_Article.php");
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
           
            Leer();
        }

        void Leer()
        {
            int indice1, indice2, indice3, indice4, indice5;
            indice1 = lectura_php.IndexOf("o");
            indice2 = lectura_php.IndexOf("$");
            indice3 = lectura_php.IndexOf("+");
            indice4 = lectura_php.IndexOf("%");
            indice5 = lectura_php.IndexOf("*");
            NombreArticulo.Text = lectura_php.Substring(indice1+1, (indice2-(indice1+1)));
            DescripcionArticulo.Text = lectura_php.Substring(indice2+1, (indice3-(indice2+1)));
            IDArticulo.Text = "Item: "+lectura_php.Substring(indice3+1, (indice4-(indice3+1)));
            PrecioAriculo.Text ="$"+ lectura_php.Substring(indice4+1, (indice5-(indice4+1)));
            NombreVendedor.Content = "Vendedor: " + lectura_php.Substring(indice5+1);

        }

        private void Regresar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
