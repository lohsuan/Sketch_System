using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModelTests;

namespace DrawingModel.Tests
{
    /// <summary>
    ///  Number of test method in ModelTest: 26
    /// </summary>

    [TestClass()]
    public class ModelTests
    {
        Model _model;
        int _event;
        PrivateObject _modelPrivate;

        // TestInitialize
        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            _modelPrivate = new PrivateObject(_model);
        }

        // MockEventHandler
        private void MockEventHandler()
        {
            _event += 1;
        }

        // NotifyModelChangedTest
        [TestMethod()]
        public void NotifyModelChangedTest()
        {
            _event = 0;
            _model._modelChanged += MockEventHandler;

            _model.NotifyModelChanged();
            Assert.AreEqual(1, _event);
            _model.NotifyModelChanged();
            Assert.AreEqual(2, _event);
        }

        // NotifyShapeSelectedTest
        [TestMethod()]
        public void NotifyShapeSelectedTest()
        {
            _event = 0;
            _model._shapeSelected += MockEventHandler;

            _model.NotifyShapeSelected();
            Assert.AreEqual(1, _event);
            _model.NotifyShapeSelected();
            Assert.AreEqual(2, _event);
        }

        // NotifyShapeNotSelectedTest
        [TestMethod()]
        public void NotifyShapeNotSelectedTest()
        {
            _event = 0;
            _model._shapeNotSelected += MockEventHandler;

            _model.NotifyShapeNotSelected();
            Assert.AreEqual(1, _event);
            _model.NotifyShapeNotSelected();
            Assert.AreEqual(2, _event);
        }

        // ChangeShapeTest
        [TestMethod()]
        public void ChangeShapeTest()
        {
            Assert.AreEqual("DrawingModel.PointerState", _modelPrivate.GetFieldOrProperty("_mouseState").ToString());
            _model.ChangeShape("Rectangle");
            Assert.AreEqual("DrawingModel.DrawingState", _modelPrivate.GetFieldOrProperty("_mouseState").ToString());
        }

        // ChangeBadShapeTest
        [TestMethod()]
        public void ChangeBadShapeTest()
        {
            _model.ChangeShape("PointerState"); // no this shape

            Assert.AreEqual("DrawingModel.DrawingState", _modelPrivate.GetFieldOrProperty("_mouseState").ToString());
            _model.ChangeShape("Rectangle");
            Assert.AreEqual("DrawingModel.DrawingState", _modelPrivate.GetFieldOrProperty("_mouseState").ToString());
            _model.ChangeShape("Line");
            Assert.AreEqual("DrawingModel.DrawingLineState", _modelPrivate.GetFieldOrProperty("_mouseState").ToString());
        }

        // HandlePointerPressedTest
        [TestMethod()]
        public void HandlePointerPressedTest()
        {
            _model.HandlePointerPressed(0, 0);
            _model.HandlePointerPressed(-1, -1);
            Assert.AreEqual(false, _modelPrivate.GetFieldOrProperty("_isPressed"));

            _model.HandlePointerPressed(100, 200);
            Assert.AreEqual(true, _modelPrivate.GetFieldOrProperty("_isPressed"));
        }

        // HandlePointerMovedTest
        [TestMethod()]
        public void HandlePointerMovedTest()
        {
            _event = 0;
            _model.HandlePointerMoved(200, 300);
            Assert.AreEqual(0, _event);

            _model._modelChanged += MockEventHandler;
            _model.HandlePointerPressed(100, 200);
            _model.HandlePointerMoved(200, 300);

            Assert.AreEqual(1, _event);
        }

        // HandlePointerReleasedTest
        [TestMethod()]
        public void HandlePointerReleasedTest()
        {
            _event = 0;
            _model.HandlePointerReleased(200, 300);
            Assert.AreEqual(0, _event);

            _model._modelChanged += MockEventHandler;
            _model.HandlePointerPressed(100, 200);
            _model.HandlePointerMoved(200, 300);
            _model.HandlePointerReleased(200, 300);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(0, shapes.Count);
            Assert.AreEqual(3, _event);
        }

        // DrawingRectangleTest
        [TestMethod()]
        public void DrawingRectangleTest()
        {
            _model.ChangeShape("Rectangle");
            _model.HandlePointerPressed(100, 200);
            _model.HandlePointerMoved(200, 300);
            _model.HandlePointerReleased(200, 300);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);
        }

        // ClearTest
        [TestMethod()]
        public void ClearTest()
        {
            _model.ChangeShape("Rectangle");
            _model.HandlePointerPressed(100, 200);
            _model.HandlePointerMoved(200, 300);
            _model.HandlePointerReleased(200, 300);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);

            _model.Clear();

            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(0, shapes.Count);
        }

        // DrawRectangleTest
        [TestMethod()]
        public void DrawRectangleTest()
        {
            _model.ChangeShape("Rectangle");
            _model.HandlePointerPressed(100, 200);
            _model.HandlePointerMoved(200, 300);
            _model.HandlePointerReleased(200, 300);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);
            MockIGraphicsAdaptor mockIGraphicsAdaptor = new MockIGraphicsAdaptor();
            _model.Draw(mockIGraphicsAdaptor);
            Assert.AreEqual(2, mockIGraphicsAdaptor.GetCount());
        }

        // DrawReversedRectangleTest
        [TestMethod()]
        public void DrawReversedRectangleTest()
        {
            _model.ChangeShape("Rectangle");
            _model.HandlePointerPressed(100, 200);
            _model.HandlePointerMoved(50, 100);
            _model.HandlePointerReleased(50, 100);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual(100, shapes[0].X1, 0.01);
            Assert.AreEqual(200, shapes[0].Y1, 0.01);
            Assert.AreEqual(50, shapes[0].X2, 0.01);
            Assert.AreEqual(100, shapes[0].Y2, 0.01);

            MockIGraphicsAdaptor mockIGraphicsAdaptor = new MockIGraphicsAdaptor();
            _model.Draw(mockIGraphicsAdaptor);
            Assert.AreEqual(2, mockIGraphicsAdaptor.GetCount());
        }

        // DrawRectangleHintTest
        [TestMethod()]
        public void DrawRectangleHintTest()
        {
            _model.ChangeShape("Rectangle");
            _model.HandlePointerPressed(100, 200);
            _model.HandlePointerMoved(200, 300);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(0, shapes.Count);

            MockIGraphicsAdaptor mockIGraphicsAdaptor = new MockIGraphicsAdaptor();
            _model.Draw(mockIGraphicsAdaptor);
            Assert.AreEqual(2, mockIGraphicsAdaptor.GetCount());
        }

        // DrawEllipseTest
        [TestMethod()]
        public void DrawEllipseTest()
        {
            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(100, 200);
            _model.HandlePointerMoved(200, 300);
            _model.HandlePointerReleased(200, 300);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);

            MockIGraphicsAdaptor mockIGraphicsAdaptor = new MockIGraphicsAdaptor();
            _model.Draw(mockIGraphicsAdaptor);
            Assert.AreEqual(2, mockIGraphicsAdaptor.GetCount());
        }

        // DrawEllipseAndClearTest
        [TestMethod()]
        public void DrawEllipseAndClearTest()
        {
            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(100, 200);
            _model.HandlePointerMoved(200, 300);
            _model.HandlePointerReleased(200, 300);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);

            MockIGraphicsAdaptor mockIGraphicsAdaptor = new MockIGraphicsAdaptor();
            _model.Draw(mockIGraphicsAdaptor);
            Assert.AreEqual(2, mockIGraphicsAdaptor.GetCount());

            mockIGraphicsAdaptor.ClearAll();
            Assert.AreEqual(0, mockIGraphicsAdaptor.GetCount());
        }


        // DrawEllipseAndClearTest
        [TestMethod()]
        public void DrawNothingTest()
        {
            _model.HandlePointerPressed(100, 200);
            _model.HandlePointerMoved(200, 300);
            _model.HandlePointerReleased(200, 300);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(0, shapes.Count);

            MockIGraphicsAdaptor mockIGraphicsAdaptor = new MockIGraphicsAdaptor();
            _model.Draw(mockIGraphicsAdaptor);
            Assert.AreEqual(0, mockIGraphicsAdaptor.GetCount());

            mockIGraphicsAdaptor.ClearAll();
            Assert.AreEqual(0, mockIGraphicsAdaptor.GetCount());
        }

        // DrawShapeTest
        [TestMethod()]
        public void DrawShapeTest()
        {
            Shape shape = new Shape();
            MockIGraphicsAdaptor mockIGraphicsAdaptor = new MockIGraphicsAdaptor();
            shape.Draw(mockIGraphicsAdaptor);

            Assert.AreEqual(0, mockIGraphicsAdaptor.GetCount());
        }

        // CheckIsExistingShapeIsClickedTest
        [TestMethod()]
        public void CheckIsExistingShapeIsClickedTest()
        {
            _event = 0;
            _model._shapeSelected += MockEventHandler;

            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(100, 200);
            _model.HandlePointerMoved(200, 300);
            _model.HandlePointerReleased(200, 300);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);

            _model.CheckIsShapeIsClicked(150, 250);
            Shape selectedShape = (Shape)_modelPrivate.GetFieldOrProperty("_selectedShape");
            Assert.AreEqual(shapes[0], selectedShape);
            Assert.AreEqual(1, _event);
            
            MockIGraphicsAdaptor mockIGraphicsAdaptor = new MockIGraphicsAdaptor();
            _model.Draw(mockIGraphicsAdaptor);
            Assert.AreEqual(3, mockIGraphicsAdaptor.GetCount()); // DrawEllipse, FillEllipse, DrawBorder
        }

        // CheckNoShapeIsClickedTest
        [TestMethod()]
        public void CheckNoShapeIsClickedTest()
        {
            _event = 0;
            _model._shapeNotSelected += MockEventHandler;
            _model.ChangeShape("Ellipse");
            
            Assert.AreEqual(1, _event);

            _model.HandlePointerPressed(100, 200);
            _model.HandlePointerMoved(200, 300);
            _model.HandlePointerReleased(200, 300);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);

            _model.CheckIsShapeIsClicked(250, 250);
            Shape selectedShape = (Shape)_modelPrivate.GetFieldOrProperty("_selectedShape");
            Assert.AreEqual(null, selectedShape);
            Assert.AreEqual(2, _event);
        }

        // GetShapeInfoTest
        [TestMethod()]
        public void GetShapeInfoTest()
        {
            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(100, 200);
            _model.HandlePointerMoved(200, 300);
            _model.HandlePointerReleased(200, 300);
            _model.CheckIsShapeIsClicked(150, 250);

            Assert.AreEqual("Selected : Ellipse(100, 200, 200, 300)", _model.GetShapeInfo());
        }

        // DrawTwoEllipsesAndOneLineTest
        [TestMethod()]
        public void DrawTwoEllipsesAndOneLineTest()
        {
            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(100, 100);
            _model.HandlePointerMoved(200, 200);
            _model.HandlePointerReleased(200, 200);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);

            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(300, 300);
            _model.HandlePointerMoved(500, 500);
            _model.HandlePointerReleased(500, 500);

            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(2, shapes.Count);

            _model.ChangeShape("Line");
            _model.HandlePointerPressed(410, 430);
            _model.HandlePointerMoved(120, 180);
            _model.HandlePointerReleased(120, 180);

            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(3, shapes.Count);

            MockIGraphicsAdaptor mockIGraphicsAdaptor = new MockIGraphicsAdaptor();
            _model.Draw(mockIGraphicsAdaptor);
            Assert.AreEqual(5, mockIGraphicsAdaptor.GetCount());
        }

        // DrawNotSutibleLineTest
        [TestMethod()]
        public void DrawNotSutibleLineTest()
        {
            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(100, 100);
            _model.HandlePointerMoved(200, 200);
            _model.HandlePointerReleased(200, 200);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);

            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(300, 300);
            _model.HandlePointerMoved(500, 500);
            _model.HandlePointerReleased(500, 500);

            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(2, shapes.Count);

            _model.ChangeShape("Line"); // no end shape line
            _model.HandlePointerPressed(150, 150);
            _model.HandlePointerMoved(600, 600);
            _model.HandlePointerReleased(600, 600);

            _model.ChangeShape("Line"); // no start shape line
            _model.HandlePointerPressed(10, 30);
            _model.HandlePointerMoved(120, 180);
            
            MockIGraphicsAdaptor mockIGraphicsAdaptor = new MockIGraphicsAdaptor();
            _model.Draw(mockIGraphicsAdaptor);
            Assert.AreEqual(5, mockIGraphicsAdaptor.GetCount());

            _model.HandlePointerReleased(120, 180);

            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(2, shapes.Count);

            mockIGraphicsAdaptor = new MockIGraphicsAdaptor();
            _model.Draw(mockIGraphicsAdaptor);
            Assert.AreEqual(4, mockIGraphicsAdaptor.GetCount());
        }

        // IsLineButtonEnabledTest
        [TestMethod()]
        public void IsLineButtonEnabledTest()
        {
            Assert.IsTrue(_model.IsLineButtonEnabled());
            _model.ChangeShape("Line");
            Assert.IsFalse(_model.IsLineButtonEnabled());
            _model.HandlePointerPressed(120, 180);
            Assert.IsFalse(_model.IsLineButtonEnabled());
            _model.HandlePointerMoved(410, 430);
            Assert.IsFalse(_model.IsLineButtonEnabled());
            _model.HandlePointerReleased(410, 430);
            Assert.IsFalse(_model.IsLineButtonEnabled()); // draw line again
        }

        // DeleteLastShapeTest
        [TestMethod()]
        public void DeleteLastShapeTest()
        {
            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(100, 100);
            _model.HandlePointerMoved(200, 200);
            _model.HandlePointerReleased(200, 200);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);

            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(300, 300);
            _model.HandlePointerMoved(500, 500);
            _model.HandlePointerReleased(500, 500);

            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(2, shapes.Count);

            _model.DeleteLastShape();

            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);
        }

        // UndoTest
        [TestMethod()]
        public void UndoTest()
        {
            _model.Undo();

            Assert.IsFalse(_model.IsUndoEnabled());
            Assert.IsFalse(_model.IsRedoEnabled());

            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(100, 100);
            _model.HandlePointerMoved(200, 200);
            _model.HandlePointerReleased(200, 200);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);
            Assert.IsTrue(_model.IsUndoEnabled());
            Assert.IsFalse(_model.IsRedoEnabled());

            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(300, 300);
            _model.HandlePointerMoved(500, 500);
            _model.HandlePointerReleased(500, 500);

            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(2, shapes.Count);
            Assert.IsTrue(_model.IsUndoEnabled());
            Assert.IsFalse(_model.IsRedoEnabled());

            _model.Undo();

            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);
            Assert.IsTrue(_model.IsUndoEnabled());
            Assert.IsTrue(_model.IsRedoEnabled());

            _model.Undo();

            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(0, shapes.Count);
            Assert.IsFalse(_model.IsUndoEnabled());
            Assert.IsTrue(_model.IsRedoEnabled());
        }

        // RedoTest
        [TestMethod()]
        public void RedoTest()
        {
            _model.Redo();

            Assert.IsFalse(_model.IsUndoEnabled());
            Assert.IsFalse(_model.IsRedoEnabled());

            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(100, 100);
            _model.HandlePointerMoved(200, 200);
            _model.HandlePointerReleased(200, 200);

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);
            Assert.IsTrue(_model.IsUndoEnabled());
            Assert.IsFalse(_model.IsRedoEnabled());

            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(300, 300);
            _model.HandlePointerMoved(500, 500);
            _model.HandlePointerReleased(500, 500);

            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(2, shapes.Count);
            Assert.IsTrue(_model.IsUndoEnabled());
            Assert.IsFalse(_model.IsRedoEnabled());

            _model.Undo();

            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);
            Assert.IsTrue(_model.IsUndoEnabled());
            Assert.IsTrue(_model.IsRedoEnabled());

            _model.Redo();

            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(2, shapes.Count);
            Assert.IsTrue(_model.IsUndoEnabled());
            Assert.IsFalse(_model.IsRedoEnabled());
        }

        // IsSelectedTest
        [TestMethod()]
        public void IsSelectedTest()
        {
            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(100, 100);
            _model.HandlePointerMoved(200, 200);
            _model.HandlePointerReleased(200, 200);

            _model.HandlePointerPressed(150, 150);
            _model.HandlePointerMoved(155, 155);
            _model.HandlePointerReleased(155, 155);

            Assert.IsTrue(_model.IsSelected());

            _model.HandlePointerPressed(300, 300);
            _model.HandlePointerMoved(300, 300);
            _model.HandlePointerReleased(300, 300);

            Assert.IsFalse(_model.IsSelected());
        }

        // MoveShapeUndoAndRedoTest
        [TestMethod()]
        public void MoveShapeUndoAndRedoTest()
        {
            // draw
            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(100, 100);
            _model.HandlePointerMoved(200, 200);
            _model.HandlePointerReleased(200, 200);
            // select shape
            _model.HandlePointerPressed(150, 150);
            _model.HandlePointerMoved(155, 155);
            _model.HandlePointerReleased(155, 155);
            Assert.IsTrue(_model.IsSelected());
            // move shape
            _model.HandlePointerPressed(150, 150);
            _model.HandlePointerMoved(170, 170);
            _model.HandlePointerReleased(170, 170);
            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(120, shapes[0].X1);
            Assert.AreEqual(120, shapes[0].Y1);
            Assert.AreEqual(220, shapes[0].X2);
            Assert.AreEqual(220, shapes[0].Y2);
            // undo move
            _model.Undo();
            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(100, shapes[0].X1);
            Assert.AreEqual(100, shapes[0].Y1);
            Assert.AreEqual(200, shapes[0].X2);
            Assert.AreEqual(200, shapes[0].Y2);
            // redo move
            _model.Redo();
            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(120, shapes[0].X1);
            Assert.AreEqual(120, shapes[0].Y1);
            Assert.AreEqual(220, shapes[0].X2);
            Assert.AreEqual(220, shapes[0].Y2);
        }

        // SaveAndLoadTest
        [TestMethod()]
        public void SaveAndLoadTest()
        {
            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(100, 100);
            _model.HandlePointerMoved(200, 200);
            _model.HandlePointerReleased(200, 200);

            _model.ChangeShape("Ellipse");
            _model.HandlePointerPressed(300, 300);
            _model.HandlePointerMoved(500, 500);
            _model.HandlePointerReleased(500, 500);

            _model.ChangeShape("Line");
            _model.HandlePointerPressed(410, 430);
            _model.HandlePointerMoved(120, 180);
            _model.HandlePointerReleased(120, 180);

            _model.Save();

            List<Shape> shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual("Ellipse 100 100 200 200", shapes[0].GetShapeOutputFormat());
            Assert.AreEqual(0, shapes[0].OrderIndex);
            Assert.AreEqual("Line 0 0 0 0 1 0", shapes[2].GetShapeOutputFormat());
            Assert.AreEqual(2, shapes[2].OrderIndex);

            _model.Clear();

            _model.Load();
            shapes = (List<Shape>)_modelPrivate.GetFieldOrProperty("_shapes");
            Assert.AreEqual(3, shapes.Count);
            Assert.AreEqual(100, shapes[0].X1);
            Assert.AreEqual(100, shapes[0].Y1);
            Assert.AreEqual(200, shapes[0].X2);
            Assert.AreEqual(200, shapes[0].Y2);
        }
    }
}