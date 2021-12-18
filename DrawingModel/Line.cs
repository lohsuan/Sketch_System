using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Line : Shape
    {
        //Shape _shape1;
        //Shape _shape2;

        // Draw
        public override void Draw(IGraphics graphics)
        {

            graphics.DrawLine(X1, Y1, X2, Y2);
        }
    }
}
