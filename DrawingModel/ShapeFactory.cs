using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class ShapeFactory
    {
        const string ELLIPSE = "Ellipse";
        const string RECTANGLE = "Rectangle";
        private const string LINE = "Line";

        // CreateShape
        public Shape CreateShape(string shapeType)
        {
            switch (shapeType)
            {
                case RECTANGLE:
                    return new Rectangle();
                case ELLIPSE:
                    return new Ellipse();
                case LINE:
                    return new Line();
                default:
                    return new Shape();
            }
        }
    }
}
