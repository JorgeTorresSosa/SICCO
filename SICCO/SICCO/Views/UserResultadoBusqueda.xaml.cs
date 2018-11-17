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
    /// Lógica de interacción para UserResultadoBusqueda.xaml
    /// </summary>
    public partial class UserResultadoBusqueda : UserControl
    {
        string lectura_php;
        int ind;
        public static string id, precio, descripcion, nombre, precio1 = "35", precio2 = "18", precio3 = "3", precio4 = "1.50";
        public static Image imagen = new Image();
        Image[] imagenes = new Image[4];
        TextBlock[] nombres = new TextBlock[4];
        TextBlock[] descripciones = new TextBlock[4];
        TextBlock[] ids = new TextBlock[4];
        string[] queries = new string[4];
        string[] queries2 = new string[4];
        string[] queries3 = new string[4];
        int contador = 0, limite = 4, i;
        int contadortxt = 0;
        bool sdn=false;
        private void click_2(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UserPaginaArticulo();
        }

        public UserResultadoBusqueda()
        {
            InitializeComponent();
            if (Clase_php.PaginaArticulos)
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                string postdata = "descr=" + Clase_php.Busqueda;
                byte[] data = encoding.GetBytes(postdata);
                WebRequest request = WebRequest.Create("http://sicconviene.com/Busqueda.php");
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
                ind = Convert.ToInt32(lectura_php.Substring(2, 5));
                MessageBox.Show(lectura_php);
                Guarda_Arreglos();
            }
            else
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                string postdata = "CAT=" + Clase_php.Categoria;
                byte[] data = encoding.GetBytes(postdata);
                WebRequest request = WebRequest.Create("http://sicconviene.com/Busqueda_Categorias.php");
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
                ind = Convert.ToInt32(lectura_php.Substring(2, 5));
                MessageBox.Show(lectura_php);
                Guarda_Arreglos();

            }

        }
        bool ra = false;
        void Guarda_Arreglos()
        {
           

           

                StreamWriter file =
            new StreamWriter(@"C:\Datos\PryctSolorio.txt");
                file.WriteLine(lectura_php);
                file.Close();

                StreamReader Leer = new StreamReader(@"C:\Datos\PryctSolorio.txt");
            string linea = Leer.ReadLine();
            while (linea != null)
                {
                    if (linea.StartsWith("I"))
                    {
                        if (ra == false)
                        {
                            queries[contadortxt] = linea;
                        }
                            else if(ra==true & sdn==false)
                            {
                                queries2[contadortxt] = linea;
                            }
                                else 
                                {
                                    queries3[contadortxt] = linea;
                                }
                        contadortxt = contadortxt + 1;
                        if (contadortxt == 4)
                        {
                            if (ra==true)
                            {
                                sdn = true;
                            }
                            ra = true;
                            contadortxt = 0;
                        }
                    }
                linea = Leer.ReadLine();
            }
            Leer.Close();
            Desplegar();
        }

        void Desplegar()
        {
            int indice1 = contadortxt-1, indice2, indice3, indice4, indice5;
            if (ra == true)
            {
                 indice1 = 3;
            }            
            
            while (indice1>=0)
            {
                indice2 = queries[indice1].IndexOf("o");
                indice3 = queries[indice1].IndexOf("#");
                indice4 = queries[indice1].IndexOf("%");
                indice5 = queries[indice1].IndexOf("+");
                switch (indice1)
                {
                    case 1:
                        Nombre2.Text = queries[indice1].Substring(indice2 + 1, indice3 - 8);
                        Id2.Text= queries[indice1].Substring(indice5+1,indice4-(indice5+1));
                        Descricpcion2.Text = queries[indice1].Substring(indice3 + 3, (indice5 - (indice3 + 3)));
                        break;
                    case 2:
                        Nombre3.Text = queries[indice1].Substring(indice2 + 1, indice3 - 8);
                        Descricpcion3.Text = queries[indice1].Substring(indice3 + 3, (indice5 - (indice3 + 3)));
                        Id3.Text = queries[indice1].Substring(indice5 + 1, indice4 - (indice5 + 1));
                        break;
                    case 3:
                        Nombre4.Text = queries[indice1].Substring(indice2 + 1, indice3 - 8);
                        Descricpcion4.Text = queries[indice1].Substring(indice3 + 3, (indice5 - (indice3 + 3)));
                        Id4.Text = queries[indice1].Substring(indice5 + 1, indice4 - (indice5 + 1));
                        break;
                    case 0:
                        Nombre1.Text = queries[indice1].Substring(indice2 + 1, indice3 - 8);
                        Descricpcion1.Text = queries[indice1].Substring(indice3 + 3, (indice5 - (indice3 + 3)));
                        Id1.Text = queries[indice1].Substring(indice5 + 1, indice4 - (indice5 + 1));
                        break;
                    default:
                        Nombre1.Text = queries[indice1].Substring(indice2 + 1, indice3 - 8);
                        Descricpcion1.Text = queries[indice1].Substring(indice3 + 3, (indice5 - (indice3 + 3)));
                        Id1.Text = queries[indice1].Substring(indice5 + 1, indice4 - (indice5 + 1));
                        break;
                }
               
                
                indice1 = indice1 - 1;
            } 
            
        }

        void Desplegar2()
        {
            int indice1 = contadortxt-1, indice2, indice3, indice4, indice5;

            while (indice1 >= 0)
            {
                indice2 = queries2[indice1].IndexOf("o");
                indice3 = queries2[indice1].IndexOf("#");
                indice4 = queries2[indice1].IndexOf("%");
                indice5 = queries2[indice1].IndexOf("+");
                switch (indice1)
                {
                    case 1:
                        Nombre2.Text = queries2[indice1].Substring(indice2 + 1, indice3 - 8);
                        Id2.Text = queries2[indice1].Substring(indice5 + 1, indice4 - (indice5 + 1));
                        Descricpcion2.Text = queries2[indice1].Substring(indice3 + 3, (indice5 - (indice3 + 3)));
                        break;
                    case 2:
                        Nombre3.Text = queries2[indice1].Substring(indice2 + 1, indice3 - 8);
                        Descricpcion3.Text = queries2[indice1].Substring(indice3 + 3, (indice5 - (indice3 + 3)));
                        Id3.Text = queries2[indice1].Substring(indice5 + 1, indice4 - (indice5 + 1));
                        break;
                    case 3:
                        Nombre4.Text = queries2[indice1].Substring(indice2 + 1, indice3 - 8);
                        Descricpcion4.Text = queries2[indice1].Substring(indice3 + 3, (indice5 - (indice3 + 3)));
                        Id4.Text = queries2[indice1].Substring(indice5 + 1, indice4 - (indice5 + 1));
                        break;
                    case 0:
                        Nombre1.Text = queries2[indice1].Substring(indice2 + 1, indice3 - 8);
                        Descricpcion1.Text = queries2[indice1].Substring(indice3 + 3, (indice5 - (indice3 + 3)));
                        Id1.Text = queries2[indice1].Substring(indice5 + 1, indice4 - (indice5 + 1));
                        break;
                    default:
                        Nombre1.Text = queries2[indice1].Substring(indice2 + 1, indice3 - 8);
                        Descricpcion1.Text = queries2[indice1].Substring(indice3 + 3, (indice5 - (indice3 + 3)));
                        Id1.Text = queries2[indice1].Substring(indice5 + 1, indice4 - (indice5 + 1));
                        break;
                }


                indice1 = indice1 - 1;
            }
        }

        private void BotonHome_Click(object sender, RoutedEventArgs e)
        {

            Desplegar();
        }

        private void BotonSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (queries2[0] != null)
            {
                Desplegar2();
            }


        }




        private void BotonAtras_Click(object sender, RoutedEventArgs e)
        {
            if (queries2[0]!=null)
            {
                Desplegar2();
            }
           
             
             
        }

        private void Nombre4_Click(object sender, RoutedEventArgs e)
        {
            Clase_php.Id_Producto = Id4.Text;
            this.Content = new UserPaginaArticulo();
        }

        private void Nombre3_Click(object sender, RoutedEventArgs e)
        {
            Clase_php.Id_Producto = Id3.Text;
            this.Content = new UserPaginaArticulo();
        }

        private void Nombre2_Click(object sender, RoutedEventArgs e)
        {
            Clase_php.Id_Producto = Id2.Text;
            this.Content = new UserPaginaArticulo();
        }

        private void Nombre1_Click(object sender, RoutedEventArgs e)
        {
            Clase_php.Id_Producto = Id1.Text;
            this.Content = new UserPaginaArticulo();
        }
    }
}
