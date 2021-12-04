using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Ellipse : Shape
    {
        private double _x;
        private double _y;
        private double _width;
        private double _height;

        // Draw
        public override void Draw(IGraphics graphics)
        {
            CheckPointX();
            CheckPointY();
            graphics.FillEllipse(_x, _y, _width, _height);
            graphics.DrawEllipse(_x, _y, _width, _height);
        }

        //ConvertPointX
        private void CheckPointX()
        {
            if (_x2 < _x1)
            {
                _x = _x2;
                _width = _x1 - _x2;
            }
            else
            {
                _x = _x1;
                _width = _x2 - _x1;
            }
        }

        //ConvertPointY
        private void CheckPointY()
        {
            if (_y2 < _y1)
            {
                _y = _y2;
                _height = _y1 - _y2;
            }
            else
            {
                _y = _y1;
                _height = _y2 - _y1;
            }
        }
    }
}
