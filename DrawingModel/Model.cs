﻿using System;
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
        public void HandlePointerPressed(double x1, double y1)
        {
            if (x1 > 0 && y1 > 0)
            {
                _firstPointX = x1;
                _firstPointY = y1;
                _hintShape.X1 = _firstPointX;
                _hintShape.Y1 = _firstPointY;
                _isPressed = true;
            }
        }

        // PointerMoved
        public void HandlePointerMoved(double x2, double y2)
        {
            if (_isPressed)
            {
                _hintShape.X2 = x2;
                _hintShape.Y2 = y2;
                NotifyModelChanged();
            }
        }

        // PointerReleased
        public void HandlePointerReleased(double x2, double y2)
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