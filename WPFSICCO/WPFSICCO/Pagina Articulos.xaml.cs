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
using System.IO;
namespace WPFSICCO
{
    /// <summary>
    /// Lógica de interacción para Pagina_Articulos.xaml
    /// </summary>
    public partial class Pagina_Articulos : Window
    {
        int id_articulo;

        public Pagina_Articulos(string id, string Nombre, string Descripcion, string precio)
        {
            InitializeComponent();
            IDArticulo.Text = "#" + id;
            id_articulo = int.Parse(id);
            PrecioAriculo.Text = "$" + precio;
            NombreArticulo.Text = Nombre;
            DescripcionArticulo.Text = Descripcion;
           
                //var fullPath = dialog.FileName;
                //var fileOnlyName = Path.GetFileName(fullPath);
                //File.Copy(fullPath, Path.Combine(newdir, fileOnlyName));
                switch (id_articulo)
                {
                    case 1:
                        ImagenPrin.Source = new BitmapImage(new Uri(@"C:\Users\tosoj\Source\Repos\JorgeTorresSosa\SICCO\WPFSICCO\WPFSICCO\Assets\img_1.jpg"));

                        NombreVendedor.Content = "Vendedor: Vendedor1";

                        break;
                    case 2:
                        ImagenPrin.Source = new BitmapImage(new Uri(@"C:\Users\tosoj\Source\Repos\JorgeTorresSosa\SICCO\WPFSICCO\WPFSICCO\Assets\img_2.jpg"));
                        NombreVendedor.Content = "Vendedor: Vendedor2";
                        break;
                    case 3:
                        ImagenPrin.Source = new BitmapImage(new Uri(@"C:\Users\tosoj\Source\Repos\JorgeTorresSosa\SICCO\WPFSICCO\WPFSICCO\Assets\img_3.jpg"));
                        NombreVendedor.Content = "Vendedor: Vendedor3";
                        break;
                    case 4:
                        ImagenPrin.Source = new BitmapImage(new Uri(@"C:\Users\tosoj\Source\Repos\JorgeTorresSosa\SICCO\WPFSICCO\WPFSICCO\Assets\img_4.jpg"));
                        NombreVendedor.Content = "Vendedor: Vendedor4 ";
                        break;
                    
                

                }
            switch (id_articulo)
            {
                case 1:

                    ImagenPrin.Source = new BitmapImage(new Uri(@"C:\Users\tosoj\Source\Repos\JorgeTorresSosa\SICCO\WPFSICCO\WPFSICCO\Assets\img_1.jpg"));
                    NombreVendedor.Content = "Vendedor: Vendedor1";

                    break;
                case 2:
                    ImagenPrin.Source = new BitmapImage(new Uri(@"C:\Users\tosoj\Source\Repos\JorgeTorresSosa\SICCO\WPFSICCO\WPFSICCO\Assets\img_2.jpg"));
                    NombreVendedor.Content = "Vendedor: Vendedor2";
                    break;
                case 3:
                    ImagenPrin.Source = new BitmapImage(new Uri(@"C:\Users\tosoj\Source\Repos\JorgeTorresSosa\SICCO\WPFSICCO\WPFSICCO\Assets\img_3.jpg"));
                    NombreVendedor.Content = "Vendedor: Vendedor3";
                    break;
                case 4:
                    ImagenPrin.Source = new BitmapImage(new Uri(@"C:\Users\tosoj\Source\Repos\JorgeTorresSosa\SICCO\WPFSICCO\WPFSICCO\Assets\img_4.jpg"));
                    NombreVendedor.Content = "Vendedor: Vendedor4 ";
                    break;
                
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}

