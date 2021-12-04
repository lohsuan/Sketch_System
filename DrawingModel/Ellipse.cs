using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Ellipse : Shape
    {
        // Draw
        public override void Draw(IGraphics graphics)
        {
            CheckPointX();
            CheckPointY();
            graphics.FillEllipse(_x, _y, _width, _height);
            graphics.DrawEllipse(_x, _y, _width, _height);
        }
    }
}
