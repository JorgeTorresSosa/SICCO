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
       
        public static string id, precio, descripcion, nombre, precio1 = "35", precio2 = "18", precio3 = "3", precio4 = "1.50";
        public static Image imagen = new Image();
        Image[] imagenes = new Image[4];
        TextBlock[] nombres = new TextBlock[4];
        TextBlock[] descripciones = new TextBlock[4];
        TextBlock[] ids = new TextBlock[4];
        int contador = 1, limite = 4, i;
        public UserResultadoBusqueda(string id, string resultado)
        {
            InitializeComponent();
            imagenes[0] = imagen1;
            imagenes[1] = imagen2;
            imagenes[2] = imagen3;
            imagenes[3] = imagen4;
            nombres[0] = Nombre1;
            nombres[1] = Nombre2;
            nombres[2] = Nombre3;
            nombres[3] = Nombre4;
            descripciones[0] = Descricpcion1;
            descripciones[1] = Descricpcion2;
            descripciones[2] = Descricpcion3;
            descripciones[3] = Descricpcion4;
        }

        

        private void BotonHome_Click(object sender, RoutedEventArgs e)
        {
             contador = 0;
             while(contador<4)
             {
                 imagenes[contador].Source = new BitmapImage(new Uri(@"C:\Users\tosoj\Desktop\Fotos\Instagram\IMG_20180629_201403_209.jpg"));
                 descripciones[contador].Text = contador.ToString();
                 nombres[contador].Text = contador.ToString();
                 nombres[contador].Tag = contador.ToString();
                 contador++;
             }
            limite = 4;
        }

        private void BotonSiguiente_Click(object sender, RoutedEventArgs e)
        {
             i = 0;
             while( contador<limite)
             {
                 imagenes[i].Source = new BitmapImage(new Uri(@"C:\Users\tosoj\Desktop\Fotos\Instagram\IMG_20180629_201403_209.jpg"));
                 descripciones[i].Text = contador.ToString();
                 nombres[i].Text = contador.ToString();
                 nombres[i].Tag = contador.ToString();
                 contador++;
                 i++;
             }
             limite += 4;
             i = 0;
        }




        private void BotonAtras_Click(object sender, RoutedEventArgs e)
        {
            i = 3;
            limite -= 4;
            while (contador < limite)
             {
                 imagenes[i].Source = new BitmapImage(new Uri(@"C:\Users\tosoj\Desktop\Fotos\Instagram\IMG_20180629_201403_209.jpg"));
                 descripciones[i].Text = contador.ToString();
                 nombres[i].Text = contador.ToString();
                 nombres[i].Tag = contador.ToString();
                 contador--;
                 i--;
             }
             
             
        }

        private void Nombre4_Click(object sender, RoutedEventArgs e)
        {
            id = Id4.Text;
            nombre = Nombre4.Text;
            descripcion = Descricpcion4.Text;
            precio = precio4;
          
        }

        private void Nombre3_Click(object sender, RoutedEventArgs e)
        {
            id = Id3.Text;
            nombre = Nombre3.Text;
            descripcion = Descricpcion3.Text;
            precio = precio3;
            
        }

        private void Nombre2_Click(object sender, RoutedEventArgs e)
        {
            id = Id2.Text;
            nombre = Nombre2.Text;
            descripcion = Descricpcion2.Text;
            precio = precio2;
            
        }

        private void Nombre1_Click(object sender, RoutedEventArgs e)
        {
            id = Id1.Text;
            nombre = Nombre1.Text;
            descripcion = Descricpcion1.Text;
            precio = precio1;
            
        }
    }
}
