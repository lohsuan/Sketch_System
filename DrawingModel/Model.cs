using System;
using System.Collections.Generic;
namespace DrawingModel
{
    class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        List<Shape> _shapes = new List<Shape>();
        Shape _hintShape = new Rectangle();
        const string ELLIPSE = "Ellipse";
        const string RECTANGLE = "Rectangle";

        // ChangeShape
        public void ChangeShape(string shapeType)
        {
            switch (shapeType)
            {
                case RECTANGLE:
                    _hintShape = new Rectangle();
                    break;
                case ELLIPSE:
                    _hintShape = new Ellipse();
                    break;
            }
        }

        // PointerPressed
        public void PointerPressed(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                _hintShape._x1 = _firstPointX;
                _hintShape._y1 = _firstPointY;
                _isPressed = true;
            }
        }

        // PointerMoved
        public void PointerMoved(double x, double y)
        {
            if (_isPressed)
            {
                _hintShape._x2 = x;
                _hintShape._y2 = y;
                NotifyModelChanged();
            }
        }

        // PointerReleased
        public void PointerReleased(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                _shapes.Add(_hintShape);
                NotifyModelChanged();
            }
        }

        // Clear
        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        // Draw
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape aShape in _shapes)
                aShape.Draw(graphics);
            if (_isPressed)
                _hintShape.Draw(graphics);
        }

        // NotifyModelChanged
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}