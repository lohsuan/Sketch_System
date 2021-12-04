using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shape
    {
        protected double _x;
        protected double _y;
        protected double _width;
        protected double _height;

        //Draw
        public virtual void Draw(IGraphics graphics)
        {

        }

        // CheckPointX
        protected void CheckPointX()
        {
            if (X2 < X1)
            {
                _x = X2;
                _width = X1 - X2;
            }
            else
            {
                _x = X1;
                _width = X2 - X1;
            }
        }

        // CheckPointY
        protected void CheckPointY()
        {
            if (Y2 < Y1)
            {
                _y = Y2;
                _height = Y1 - Y2;
            }
            else
            {
                _y = Y1;
                _height = Y2 - Y1;
            }
        }

        public double X1
        {
            get; set;
        }

        public double X2
        {
            get; set;
        }

        public double Y1
        {
            get; set;
        }

        public double Y2
        {
            get; set;
        }
    }
}
