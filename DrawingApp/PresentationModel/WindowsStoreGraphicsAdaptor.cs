using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel;
using System;
using Windows.UI.Xaml;

namespace DrawingApp.PresentationModel
{
    class WindowsStoreGraphicsAdaptor : IGraphics
    {
        Canvas _canvas;
        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        // ClearAll
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        // DrawEllipse
        public void DrawEllipse(double x1, double y1, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Margin = new Windows.UI.Xaml.Thickness(x1, y1, 0, 0);
            ellipse.Width = width;
            ellipse.Height = height;
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(ellipse);

        }

        // DrawRectangle
        public void DrawRectangle(double x1, double y1, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Margin = new Windows.UI.Xaml.Thickness(x1, y1, 0, 0);
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(rectangle);
        }

        // FillEllipse
        public void FillEllipse(double x1, double y1, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Margin = new Windows.UI.Xaml.Thickness(x1, y1, 0, 0);
            ellipse.Width = width;
            ellipse.Height = height;
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Fill = new SolidColorBrush(Colors.Orange);
            _canvas.Children.Add(ellipse);
        }

        // FillRectangle
        public void FillRectangle(double x1, double y1, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Margin = new Windows.UI.Xaml.Thickness(x1, y1, 0, 0);
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.Fill = new SolidColorBrush(Colors.Yellow);
            _canvas.Children.Add(rectangle);
        }

        // DrawLine
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }

        // DrawBorder
        public void DrawBorder(double x1, double y1, double x2, double y2)
        {

            const int DASH_LENGTH = 4;
            const int DASH_GAP = 1;
            const int PEN_WIDTH = 2;

            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Margin = new Thickness(x1, y1, 0, 0);
            rectangle.Width = Math.Abs(x1 - x2);
            rectangle.Height = Math.Abs(y1 - y2);
            rectangle.Stroke = new SolidColorBrush(Colors.Red);
            rectangle.StrokeThickness = PEN_WIDTH;
            rectangle.StrokeDashArray = new DoubleCollection { DASH_LENGTH, DASH_GAP };
            _canvas.Children.Add(rectangle);

            DrawRactangleCap(x1, y1);
            DrawRactangleCap(x2, y1);
            DrawRactangleCap(x1, y2);
            DrawRactangleCap(x2, y2);
        }

        // DrawRactangleCap
        private void DrawRactangleCap(double x1, double y1)
        {
            const int POINT_OFFSET = 5;
            const int CIRCLE_RADIUS = 10;
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Margin = new Thickness(x1 - POINT_OFFSET, y1 - POINT_OFFSET, 0, 0);
            ellipse.Width = CIRCLE_RADIUS;
            ellipse.Height = CIRCLE_RADIUS;
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Fill = new SolidColorBrush(Colors.White);
            _canvas.Children.Add(ellipse);
        }
    }
}