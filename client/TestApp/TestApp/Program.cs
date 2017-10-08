using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NETMapnik;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Map m = new Map(256, 256);
                Image i = new Image(256, 256);
                Mapnik.RegisterDatasource(System.IO.Path.Combine(Mapnik.Paths["InputPlugins"], "shape..input"));
                m.Load(@"..\..\test.xml");
                m.ZoomAll();
                m.Render(i);
                i.Save("output.png");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
