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
        public MainWindow()
        {
            InitializeComponent();

            Mapnik.RegisterDatasource(System.IO.Path.Combine(Mapnik.Paths["InputPlugins"], "sqlite..input"));

            Map m = new Map(256, 256);
            m.Load(@"..\..\test.xml");
            m.ZoomAll();

            var i = new NETMapnik.Image(256, 256);
            var iv = i.View(0, 0, 256, 256);
            m.Render(i);

            var decoder = new PngBitmapDecoder(new MemoryStream(iv.Encode("png")), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];

            mapImage.Source = bitmapSource;
        }
    }
}
