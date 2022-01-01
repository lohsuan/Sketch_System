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
        bool _isPressed = false;
        List<Shape> _shapes = new List<Shape>();
        Shape _hintShape = new Shape();
        Shape _selectedShape = null;
        //Shape _startLinkShape = null;
        //Shape _endLinkShape = null;
        private IState _mouseState;
        private const string SHAPE = "Shape";
        private const string LINE = "Line";

        public Model()
        {
            SetPointerState();
        }

        // SetPointerState
        public void SetPointerState()
        {
            _mouseState = new PointerState(this);
        }

        // SetDrawingState
        public void SetDrawingState(string shapeType)
        {
            _mouseState = new DrawingState(this, shapeType);
        }

        // SetDrawingLineState
        public void SetDrawingLineState(string shapeType)
        {
            _mouseState = new DrawingLineState(this, shapeType);
        }

        // ChangeShape
        public void ChangeShape(string shapeType)
        {
            if (shapeType == LINE)
                SetDrawingLineState(shapeType);
            else
                SetDrawingState(shapeType);

            _selectedShape = null;
            NotifyShapeNotSelected();
            NotifyModelChanged();
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
                _mouseState.PressPointer(x1, y1);
                _isPressed = true;
                //if (_hintShape.GetType().Name == LINE)
                //{
                //    CheckLinkLineStartShape(x1, y1);
                //}
            }
        }

        // CheckLinkLineStartShape
        public Shape CheckLinkLineStartShape(double x1, double y1)
        {
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                if (_shapes[i].IsShapeClick(x1, y1))
                {
                    //_startLinkShape = _shapes[i];
                    return _shapes[i];
                }
            }
            return null;
        }

        // PointerMoved
        public void HandlePointerMoved(double x2, double y2)
        {
            if (_isPressed)
            {
                _mouseState.MovePointer(x2, y2);
                NotifyModelChanged();
            }
        }

        // PointerReleased
        public void HandlePointerReleased(double x2, double y2)
        {
            if (_isPressed)
                _mouseState.ReleasePointer(x2, y2);
            NotifyModelChanged();
            _isPressed = false;
        }

        // WriteBackHintShape
        public void SetHintShape(Shape hintShape)
        {
            _hintShape = hintShape;
        }

        // CheckLineButtonEnabled
        public bool IsLineButtonEnabled()
        {
            return _hintShape.GetType().Name != LINE;
        }

        // PrepareLinkLine
        public Shape PrepareLinkLine(double x2, double y2)
        {
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                if (_shapes[i].IsShapeClick(x2, y2))
                    return _shapes[i];
            }
            return null;
        }

        // FinishDraw
        public void FinishDraw(Shape hintShape)
        {
            _commandManager.Execute(new DrawCommand(this, hintShape));
            _hintShape = new Shape();
            SetPointerState();
        }

        // MovingShape
        public void MovingShape(double offsetX, double offsetY)
        {
            _selectedShape.MovingShape(offsetX, offsetY);
            NotifyModelChanged();
            NotifyShapeSelected();
        }

        // FinishDraw
        public void MoveShape(double offsetX, double offsetY)
        {
            Position oldPosition = _selectedShape.GetOldPosition(offsetX, offsetY);
            Position newPosition = _selectedShape.GetPosition();
            _commandManager.Execute(new MoveCommand(_selectedShape, oldPosition, newPosition));
            NotifyModelChanged();
            _selectedShape = null;
            NotifyShapeNotSelected();
        }

        // CheckIsShapeIsClicked
        public bool CheckIsShapeIsClicked(double clickedPointX, double clickedPointY)
        {
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                if (_shapes[i].IsShapeClick(clickedPointX, clickedPointY))
                {
                    _selectedShape = _shapes[i];
                    NotifyModelChanged();
                    NotifyShapeSelected();
                    return true;
                }
            }
            _selectedShape = null;
            NotifyModelChanged();
            NotifyShapeNotSelected();
            return false;
        }

        // DrawShape
        public void AddShape(Shape shape)
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
            NotifyModelChanged();
        }

        // Redo
        public void Redo()
        {
            _commandManager.Redo();
            _selectedShape = null;
            NotifyShapeNotSelected();
            NotifyModelChanged();
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
            {
                if (aShape.GetType().Name == LINE)
                    aShape.Draw(graphics);
            }
            foreach (Shape aShape in _shapes)
            {
                if (aShape.GetType().Name != LINE)
                    aShape.Draw(graphics);
            }
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

        // IsSelected
        public bool IsSelected()
        {
            return _selectedShape != null;
        }
    }
}