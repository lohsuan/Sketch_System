using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel;
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
    }
}