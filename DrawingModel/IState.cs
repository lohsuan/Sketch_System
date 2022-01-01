using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    interface IState
    {
        // PressPointer
        void PressPointer(double x1, double y1);

        // MovePointer
        void MovePointer(double x2, double y2);

        // ReleasePointer
        void ReleasePointer(double x2, double y2);
    }
}
