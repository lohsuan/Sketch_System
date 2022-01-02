using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Line : Shape
    {
        private Shape _startLinkShape = null;
        private Shape _endLinkShape = null;
        private const string SPACE = " ";

        public Line()
        {
            _startLinkShape = null;
            _endLinkShape = null;
        }

        public Line(Shape startLinkShape, Shape endLinkShape)
        {
            _startLinkShape = startLinkShape;
            _endLinkShape = endLinkShape;
        }

        // GetShapeOutputFormat
        public override string GetShapeOutputFormat()
        {
            return this.GetType().Name + SPACE + (int)X1 + SPACE + (int)Y1 + SPACE + (int)X2 + SPACE + (int)Y2 + SPACE + _startLinkShape.OrderIndex + SPACE + _endLinkShape.OrderIndex;
        }

        // Draw
        public override void Draw(IGraphics graphics)
        {
            if (_endLinkShape == null)
            {
                graphics.DrawLine(X1, Y1, X2, Y2);
            }
            else
            {
                graphics.DrawLine(_startLinkShape.GetCenterPointX(), _startLinkShape.GetCenterPointY(), _endLinkShape.GetCenterPointX(), _endLinkShape.GetCenterPointY());
            }
        }
    }
}
