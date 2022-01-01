using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class PointerState : IState
    {
        Model _model;
        double _firstPointX;
        double _firstPointY;
        double _tempX;
        double _tempY;

        public PointerState(Model model)
        {
            _model = model;
        }

        // PressPointer
        public void PressPointer(double x1, double y1)
        {
            _firstPointX = x1;
            _firstPointY = y1;
            _tempX = x1;
            _tempY = y1;
        }

        // MovePointer
        public void MovePointer(double x2, double y2)
        {
            if (_model.IsSelected())
            {
                _model.MovingShape(x2 - _tempX, y2 - _tempY);
                _tempX = x2;
                _tempY = y2;
            }
        }

        // ReleasePointer
        public void ReleasePointer(double x2, double y2)
        {
            if (_model.IsSelected() == false)
            {
                CheckIsShapeIsClicked(x2, y2);
            }
            else if (CheckIsShapeIsClicked(x2, y2))
            {
                _model.MoveShape(x2 - _firstPointX, y2 - _firstPointY);
            }
        }

        // CheckIsShapeIsClicked
        private bool CheckIsShapeIsClicked(double x2, double y2)
        {
            return _model.CheckIsShapeIsClicked(x2, y2);
        }
    }
}
