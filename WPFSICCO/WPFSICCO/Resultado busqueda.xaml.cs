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
    /// Lógica de interacción para Resultado_busqueda.xaml
    /// </summary>
    public partial class Resultado_busqueda : Window
    {
        public static string id;
        Image[] imagenes = new Image[4];
        TextBlock[] nombres = new TextBlock[4];
        TextBlock[] descripciones = new TextBlock[4];
        TextBlock[] ids = new TextBlock[4];
        int contador=1, limite=4, i;        
        public Resultado_busqueda()
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

        void articulos()
        {
            Image[] imagenes = new Image[4];
            Object[] lasiamgenes = new Object[4];
            lasiamgenes[0] = imagen1;
            while ( contador<=limite)
            {

            }
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
            while (contador < limite)
            {
                imagenes[i].Source = new BitmapImage(new Uri(@"C:\Users\tosoj\Desktop\Fotos\Instagram\IMG_20180629_201403_209.jpg"));
                descripciones[i].Text = contador.ToString();
                nombres[i].Text = contador.ToString();
                nombres[i].Tag = contador.ToString();
                contador--;
                i--;
            }
            limite -= 4;
            i = 3;
        }

        private void Nombre4_Click(object sender, RoutedEventArgs e)
        {
            id = Id4.Text;
            Pagina_Articulos pagart = new Pagina_Articulos(id);
            pagart.Show();
        }

        private void Nombre3_Click(object sender, RoutedEventArgs e)
        {
            id = Id3.Text;
            Pagina_Articulos pagart = new Pagina_Articulos(id);
            pagart.Show();
        }

        private void Nombre2_Click(object sender, RoutedEventArgs e)
        {
            id = Id2.Text;
            Pagina_Articulos pagart = new Pagina_Articulos(id);
            pagart.Show();
        }

        private void Nombre1_Click(object sender, RoutedEventArgs e)
        {

            id = Id1.Text;
            Pagina_Articulos pagart = new Pagina_Articulos(id);
            pagart.Show();
        }
    }
}
