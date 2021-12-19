using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shape
    {
        private const string SELECTED = "Selected : ";
        private const string LEFT_BRACKET = "(";
        private const string RIGHT_BRACKET = ")";
        private const string COMMA = ",";
        protected double _x;
        protected double _y;
        protected double _width;
        protected double _height;

        //Draw
        public virtual void Draw(IGraphics graphics)
        {

        }

        //DrawBorder
        public void DrawBorder(IGraphics graphics)
        {
            graphics.DrawBorder(X1, Y1, X2, Y2);
        }

        // IsShapeClick
        public bool IsShapeClick(double clickedPointX, double clickPointY)
        {
            return ((clickedPointX - X1) * (clickedPointX - X2) <= 0) && ((clickPointY - Y1) * (clickPointY - Y2) <= 0);
        }

        // GetShapeInfo
        public string GetShapeInfo()
        {
            return SELECTED + this.GetType().Name + LEFT_BRACKET + X1 + COMMA + Y1 + COMMA + X2 + COMMA + Y2 + RIGHT_BRACKET;
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
