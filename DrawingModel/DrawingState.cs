using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class DrawingState : IState
    {
        Model _model;
        ShapeFactory _shapeFactory = new ShapeFactory();
        Shape _hintShape = new Shape();
        double _firstPointX;
        double _firstPointY;

        public DrawingState(Model model, string shapeType)
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
            _model.FinishDraw(_hintShape);
        }
    }
}
