using NETMapnik;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace TestAppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Map _m;
        Location _location;

        public MainWindow()
        {
            InitializeComponent();

            Mapnik.RegisterDatasource(System.IO.Path.Combine(Mapnik.Paths["InputPlugins"], "sqlite..input"));
            Mapnik.RegisterDatasource(System.IO.Path.Combine(Mapnik.Paths["InputPlugins"], "shape..input"));
            Mapnik.RegisterSystemFonts();

            _m = new Map(700, 500);
            _location = new Location(325187, 673924, 500, 500);
            _m.Load(@"..\..\osm_27700_slim.xml");

            Render();
        }

        private void Render()
        {
            //m.ZoomAll();
            _m.ZoomToBox(_location.MinX, _location.MinY, _location.MaxX, _location.MaxY);

            using (var i = new NETMapnik.Image(700, 500))
            using (var iv = i.View(0, 0, 700, 500))
            {
                _m.Render(i);

                var decoder = new PngBitmapDecoder(new MemoryStream(iv.Encode("png")), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bitmapSource = decoder.Frames[0];
                mapImage.Source = bitmapSource;
            }
        }

        private void Button_Click_Out(object sender, RoutedEventArgs e)
        {
            _location.ZoomOut();
            Render();
        }

        private void Button_Click_In(object sender, RoutedEventArgs e)
        {
            _location.ZoomIn();
            Render();
        }

        private void Button_Click_Left(object sender, RoutedEventArgs e)
        {
            _location.MoveX(-_location.Width / 2);
            Render();
        }

        private void Button_Click_Right(object sender, RoutedEventArgs e)
        {
            _location.MoveX(_location.Width / 2);
            Render();
        }

        private void Button_Click_Up(object sender, RoutedEventArgs e)
        {
            _location.MoveY(_location.Height / 2);
            Render();
        }

        private void Button_Click_Down(object sender, RoutedEventArgs e)
        {
            _location.MoveY(-_location.Height / 2);
            Render();
        }
    }
}
