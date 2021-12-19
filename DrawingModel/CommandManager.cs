using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class CommandManager
    {
        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();

        // Execute
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
        }

        // Undo
        public void Undo()
        {
            if (_undo.Count > 0)
            {
                ICommand command = _undo.Pop();
                _redo.Push(command);
                command.ReverseExecute();
            }
        }

        // Redo
        public void Redo()
        {
            if (_redo.Count > 0)
            {
                ICommand command = _redo.Pop();
                _undo.Push(command);
                command.Execute();
            }
        }

        // IsRedoEnabled
        public bool IsRedoEnabled()
        {
            return _redo.Count != 0;
        }

        // IsUndoEnabled
        public bool IsUndoEnabled()
        {
            return _undo.Count != 0;
        }

        // ClearAll
        public void ClearAll()
        {
            _undo.Clear();
            _redo.Clear();
        }
    }
}
