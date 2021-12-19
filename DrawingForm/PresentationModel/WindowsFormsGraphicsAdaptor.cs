using System.Windows.Forms;
using System.Drawing;
using DrawingModel;
using System;

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

        // DrawEllipse
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // DrawBorder
        public void DrawBorder(double x1, double y1, double x2, double y2)
        {
            const int PEN_WIDTH = 2;
            Pen pen = new Pen(Color.Red, PEN_WIDTH);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            double startPointX = x1 < x2 ? x1 : x2;
            double startPointY = y1 < y2 ? y1 : y2;
            double width = Math.Abs(x1 - x2);
            double height = Math.Abs(y1 - y2);

            _graphics.DrawRectangle(pen, (float)startPointX, (float)startPointY, (float)width, (float)height);
            DrawEndCap(x1, y1, x2, y2);
        }

        // DrawEndCap
        private void DrawEndCap(double x1, double y1, double x2, double y2)
        {
            const int CIRCLE_OFFSET = 4;
            const int CIRCLE_RADIUS = 8;
            _graphics.FillEllipse(new SolidBrush(Color.White), (int)(x1 - CIRCLE_OFFSET), (int)(y1 - CIRCLE_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.FillEllipse(new SolidBrush(Color.White), (int)(x2 - CIRCLE_OFFSET), (int)(y1 - CIRCLE_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.FillEllipse(new SolidBrush(Color.White), (int)(x1 - CIRCLE_OFFSET), (int)(y2 - CIRCLE_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.FillEllipse(new SolidBrush(Color.White), (int)(x2 - CIRCLE_OFFSET), (int)(y2 - CIRCLE_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.DrawEllipse(Pens.Black, (int)(x1 - CIRCLE_OFFSET), (int)(y1 - CIRCLE_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.DrawEllipse(Pens.Black, (int)(x2 - CIRCLE_OFFSET), (int)(y1 - CIRCLE_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.DrawEllipse(Pens.Black, (int)(x1 - CIRCLE_OFFSET), (int)(y2 - CIRCLE_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.DrawEllipse(Pens.Black, (int)(x2 - CIRCLE_OFFSET), (int)(y2 - CIRCLE_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
        }
    }
}