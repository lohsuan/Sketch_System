using System.Windows.Forms;
using System.Drawing;
using DrawingModel;
namespace DrawingForm.PresentationModel
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        // ClearAll
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        // DrawRectangle
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // FillRectangle
        public void FillRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.FillRectangle(Brushes.Yellow, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // DrawEllipse
        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // FillEllipse
        public void FillEllipse(double x1, double y1, double x2, double y2)
        {
            _graphics.FillEllipse(Brushes.Orange, (float)x1, (float)y1, (float)x2, (float)y2);
        }
    }
}