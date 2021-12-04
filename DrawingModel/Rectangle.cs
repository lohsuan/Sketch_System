using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Rectangle : Shape
    {
        // Draw
        public override void Draw(IGraphics graphics)
        {
            CheckPointX();
            CheckPointY();
            graphics.FillRectangle(_x, _y, _width, _height);
            graphics.DrawRectangle(_x, _y, _width, _height);
        }
    }
}
