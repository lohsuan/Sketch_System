using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel;

namespace DrawingModelTests
{
    /// <summary>
    /// mock IGraphics adapter for testing draw method in Model
    /// </summary>
    public class MockIGraphicsAdaptor : IGraphics
    {
        int _count = 0;

        // GetCount
        public int GetCount()
        {
            return _count;
        }

        // ClearAll
        public void ClearAll()
        {
            _count = 0;
        }

        // DrawRectangle
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _count++;
        }

        // FillRectangle
        public void FillRectangle(double x1, double y1, double x2, double y2)
        {
            _count++;
        }

        // DrawEllipse
        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            _count++;
        }

        // FillEllipse
        public void FillEllipse(double x1, double y1, double x2, double y2)
        {
            _count++;
        }
    }
}
