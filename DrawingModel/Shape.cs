using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shape
    {
        public double _x1;
        public double _y1;
        public double _x2;
        public double _y2;

        //Draw
        public virtual void Draw(IGraphics graphics)
        {

        }

    }
}
