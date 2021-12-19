using System;
using System.Collections.Generic;
namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _shapeSelected;
        public delegate void ShapeSelectedEventHandler();
        public event ModelChangedEventHandler _shapeNotSelected;
        public delegate void ShapeNotSelectedEventHandler();

        CommandManager _commandManager = new CommandManager();
        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        List<Shape> _shapes = new List<Shape>();
        ShapeFactory _shapeFactory = new ShapeFactory();
        Shape _hintShape = new Shape();
        Shape _selectedShape = null;
        private const string SHAPE = "Shape";
        private const string LINE = "Line";

        // ChangeShape
        public void ChangeShape(string shapeType)
        {
            _hintShape = _shapeFactory.CreateShape(shapeType);
            _selectedShape = null;
            NotifyShapeNotSelected();
        }

        // CheckIsShapeIsClicked
        public void CheckIsShapeIsClicked(double clickedPointX, double clickedPointY)
        {
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                if (_shapes[i].IsShapeClick(clickedPointX, clickedPointY))
                {
                    _selectedShape = _shapes[i];
                    NotifyModelChanged();
                    NotifyShapeSelected();
                    return;
                }
            }
            _selectedShape = null;
            NotifyModelChanged();
            NotifyShapeNotSelected();
        }

        // GetShapeInfo
        public string GetShapeInfo()
        {
            return _selectedShape.GetShapeInfo();
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

            if (_isPressed && (_hintShape.GetType().Name != SHAPE))
            {
                //_shapes.Add(_hintShape);
                _commandManager.Execute(new DrawCommand(this, _hintShape));

                NotifyModelChanged();
                _hintShape = new Shape();
            }
            else if (_isPressed)
            {
                CheckIsShapeIsClicked(x2, y2);
            }
            _isPressed = false;
        }

        // DrawShape
        public void DrawShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        // DeleteLastShape
        public void DeleteLastShape()
        {
            _shapes.RemoveAt(_shapes.Count - 1);
        }

        // Undo
        public void Undo()
        {
            _commandManager.Undo();
            _selectedShape = null;
            NotifyShapeNotSelected();
        }

        // Redo
        public void Redo()
        {
            _commandManager.Redo();
            _selectedShape = null;
            NotifyShapeNotSelected();
        }

        // IsRedoEnabled
        public bool IsRedoEnabled()
        {
            return _commandManager.IsRedoEnabled();
        }

        // IsUndoEnabled
        public bool IsUndoEnabled()
        {
            return _commandManager.IsUndoEnabled();
        }

        // Clear
        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            _commandManager.ClearAll();
            _hintShape = new Shape();
            _selectedShape = null;
            NotifyModelChanged();
            NotifyShapeNotSelected();
        }

        // Draw
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape aShape in _shapes)
                aShape.Draw(graphics);
            if (_isPressed)
                _hintShape.Draw(graphics);
            if (_selectedShape != null)
                _selectedShape.DrawBorder(graphics);
        }

        // NotifyModelChanged
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        // NotifyShapeSelected
        public void NotifyShapeSelected()
        {
            if (_shapeSelected != null)
                _shapeSelected();
        }

        // NotifyShapeNotSelected
        public void NotifyShapeNotSelected()
        {
            if (_shapeNotSelected != null)
                _shapeNotSelected();
        }

        // GetHintShape
        public Shape GetHintShape()
        {
            return _hintShape;
        }
    }
}