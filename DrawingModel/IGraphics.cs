using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public interface IGraphics
    {
        // ClearAll
        void ClearAll();

        // DrawLine
        void DrawLine(double x1, double y1, double x2, double y2);

        // DrawRectangle
        void DrawRectangle(double x1, double y1, double width, double height);

        // FillRectangle
        void FillRectangle(double x1, double y1, double width, double height);

        // DrawEllipse
        void DrawEllipse(double x1, double y1, double width, double height);

        // FillEllipse
        void FillEllipse(double x1, double y1, double width, double height);
    }
}
