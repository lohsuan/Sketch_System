using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class DrawingLineState : IState
    {
        Model _model;
        ShapeFactory _shapeFactory = new ShapeFactory();
        Shape _hintShape = new Shape();
        Shape _startLinkShape = null;
        Shape _endLinkShape = null;
        double _firstPointX;
        double _firstPointY;

        public DrawingLineState(Model model, string shapeType)
        {
            _model = model;
            _hintShape = _shapeFactory.CreateShape(shapeType);
        }

        // PressPointer
        public void PressPointer(double x1, double y1)
        {
            _firstPointX = x1;
            _firstPointY = y1;
            _hintShape.X1 = _firstPointX;
            _hintShape.Y1 = _firstPointY;
            _model.SetHintShape(_hintShape);
            _startLinkShape = _model.CheckLinkLineStartShape(x1, y1);
        }

        // MovePointer
        public void MovePointer(double x2, double y2)
        {
            _hintShape.X2 = x2;
            _hintShape.Y2 = y2;
            _model.SetHintShape(_hintShape);
        }

        // ReleasePointer
        public void ReleasePointer(double x2, double y2)
        {
            if (_startLinkShape != null)
            {
                _endLinkShape = _model.PrepareLinkLine(x2, y2);
                if (_endLinkShape != null)
                {
                    DrawSuccessLine();
                }
            }
            _startLinkShape = null;
            _endLinkShape = null;
        }

        // DrawSuccessLine
        private void DrawSuccessLine()
        {
            _hintShape = new Line(_startLinkShape, _endLinkShape);
            _model.FinishDraw(_hintShape);
        }
    }
}
