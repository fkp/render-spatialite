using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppUI
{
    class Location
    {
        double _centreX;
        double _centreY;
        double _width;
        double _height;

        public Location(double centreX, double centreY, double width, double height)
        {
            _centreX = centreX;
            _centreY = centreY;
            _width = width;
            _height = height;
        }

        public double CentreX { get { return _centreX; } }
        public double CentreY { get { return _centreY; } }
        public double Width { get { return _width; } }
        public double Height { get { return _height; } }

        public void ZoomIn(double factor = 2)
        {
            _width /= factor;
            _height /= factor;
        }

        public void ZoomOut(double factor = 2)
        {
            _width *= factor;
            _height *= factor;
        }

        public void MoveX(double increment)
        {
            _centreX += increment;
        }

        public void MoveY(double increment)
        {
            _centreY += increment;
        }

        public double MinX { get { return _centreX - (_width / 2); } }
        public double MinY { get { return _centreY - (_height / 2); } }
        public double MaxX { get { return _centreX + (_width / 2); } }
        public double MaxY { get { return _centreY + (_height / 2); } }
    }
}
