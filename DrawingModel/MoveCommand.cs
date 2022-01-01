using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class MoveCommand : ICommand
    {
        Shape _shape;
        double _oldX1;
        double _oldX2;
        double _oldY1;
        double _oldY2;
        double _newX1;
        double _newX2;
        double _newY1;
        double _newY2;

        public MoveCommand(Shape shape, Position oldPosition, Position newPosition)
        {
            _shape = shape;
            _oldX1 = oldPosition.X1;
            _oldY1 = oldPosition.Y1;
            _oldX2 = oldPosition.X2;
            _oldY2 = oldPosition.Y2;
            _newX1 = newPosition.X1;
            _newY1 = newPosition.Y1;
            _newX2 = newPosition.X2;
            _newY2 = newPosition.Y2;
        }

        // Execute
        public void Execute()
        {
            _shape.MoveShape(_newX1, _newY1, _newX2, _newY2);
        }

        // ReverseExecute
        public void ReverseExecute()
        {
            _shape.MoveShape(_oldX1, _oldY1, _oldX2, _oldY2);
        }
    }
}
