using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class MainForm : Form
    {
        private const string CANVAS = "canvas";
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();
        List<Button> _shapesButton = new List<Button>();
        ToolStripButton _undo;
        ToolStripButton _redo;

        public MainForm()
        {
            InitializeComponent();
            PrepareCanvas();

            // prepare presentation model and model
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _model._modelChanged += HandleModelChanged;
            _model._shapeSelected += HandleShapeSelected;
            _model._shapeNotSelected += HandleShapeNotSelected;

            _shapesButton.Add(_rectangle);
            _shapesButton.Add(_ellipse);
            _shapesButton.Add(_line);
            PrepareUndoRedoToolStrip();
        }

        // PrepareUndoRedoToolStrip
        private void PrepareUndoRedoToolStrip()
        {
            // ToolStrip for Redo and Undo buttons
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Parent = this;
            _undo = new ToolStripButton("Undo", null, UndoHandler);
            _undo.Enabled = false;
            toolStrip.Items.Add(_undo);
            _redo = new ToolStripButton("Redo", null, RedoHandler);
            _redo.Enabled = false;
            toolStrip.Items.Add(_redo);
        }

        // PrepareCanvas
        private void PrepareCanvas()
        {
            _canvas.IsAccessible = true;
            _canvas.AccessibleName = CANVAS;
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;

            Controls.Add(_canvas);
        }

        //HandleShapeButtonClick
        public void HandleShapeButtonClick(object sender, EventArgs e)
        {
            foreach (Button button in _shapesButton)
                button.Enabled = true;
            Button pressedButton = (Button)sender;
            pressedButton.Enabled = false;
            _model.ChangeShape(pressedButton.Text);
        }

        // HandleClearButtonClick
        public void HandleClearButtonClick(object sender, EventArgs e)
        {
            foreach (Button button in _shapesButton)
                button.Enabled = true;
            _model.Clear();
        }

        // HandleCanvasPressed
        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _model.HandlePointerPressed(e.X, e.Y);
        }

        // HandleCanvasReleased
        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            foreach (Button button in _shapesButton)
                button.Enabled = true;
            _model.HandlePointerReleased(e.X, e.Y);
            _line.Enabled = _model.IsLineButtonEnabled();
        }

        // HandleCanvasMoved
        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _model.HandlePointerMoved(e.X, e.Y);
        }

        // HandleCanvasPaint
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        // HandleModelChanged
        public void HandleModelChanged()
        {
            _redo.Enabled = _model.IsRedoEnabled();
            _undo.Enabled = _model.IsUndoEnabled();
            Invalidate(true);
        }

        // HandleShapeSelected
        public void HandleShapeSelected()
        {
            _shapeInfoLabel.Text = _model.GetShapeInfo();
        }

        // HandleShapeNotSelected
        public void HandleShapeNotSelected()
        {
            _shapeInfoLabel.Text = null;
        }

        // UndoHandler
        void UndoHandler(Object sender, EventArgs e)
        {
            _model.Undo();
            HandleModelChanged();
        }

        // RedoHandler
        void RedoHandler(Object sender, EventArgs e)
        {
            _model.Redo();
            HandleModelChanged();
        }
    }
}
