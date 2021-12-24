using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace DrawingModelUITest
{
    /// <summary>
    /// Please change display of the computer to 100% to execute codeing ui test
    /// Summary description for DrawingModelUITest
    /// number of total UI test: 3
    /// </summary>
    [CodedUITest]
    public class UITest
    {
        const string FILE_PATH = @"..\\..\\..\\DrawingForm\\bin\\Debug\\DrawingForm.exe";
        private const string APP_TITLE = "MainForm";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            RobotTest.Initialize(FILE_PATH, APP_TITLE);
        }

        // DrawLineTest
        [TestMethod]
        public void DrawSelectAndClearEachShapeTest()
        {
            // Rectangle
            RobotTest.ClickButton("Rectangle");
            RobotTest.AssertButtonEnable("Rectangle", false);
            RobotTest.MouseDraw(100, 100, 150, 150);
            RobotTest.AssertButtonEnable("Rectangle", true);
            RobotTest.MouseDraw(130, 130, 131, 131);
            RobotTest.AssertText("_shapeInfoLabel", "Selected : Rectangle(100, 100, 150, 150)");
            
            // Ellipse
            RobotTest.ClickButton("Ellipse");
            RobotTest.AssertButtonEnable("Ellipse", false);
            RobotTest.MouseDraw(300, 130, 450, 250);
            RobotTest.AssertButtonEnable("Ellipse", true);
            RobotTest.MouseDraw(340, 150, 340, 150);
            RobotTest.AssertText("_shapeInfoLabel", "Selected : Ellipse(300, 130, 450, 250)");

            // Line
            RobotTest.ClickButton("Line");
            RobotTest.AssertButtonEnable("Line", false);
            
            RobotTest.MouseDraw(130, 120, 200, 200);
            RobotTest.AssertButtonEnable("Line", false);

            RobotTest.MouseDraw(130, 120, 400, 200);
            RobotTest.AssertButtonEnable("Line", true);
         
            RobotTest.ClickButton("Clear");
        }

        // ClearTest
        [TestMethod]
        public void RedoUndoClearTest()
        {
            RobotTest.AssertButtonEnable("Undo", false);
            RobotTest.AssertButtonEnable("Redo", false);

            RobotTest.ClickButton("Ellipse");
            RobotTest.AssertButtonEnable("Ellipse", false);
            RobotTest.MouseDraw(175, 80, 325, 140);
            RobotTest.AssertButtonEnable("Ellipse", true);

            RobotTest.AssertButtonEnable("Undo", true);
            RobotTest.AssertButtonEnable("Redo", false);

            RobotTest.ClickButton("Undo");
            RobotTest.AssertButtonEnable("Undo", false);
            RobotTest.AssertButtonEnable("Redo", true);

            RobotTest.ClickButton("Redo");
            RobotTest.AssertButtonEnable("Undo", true);
            RobotTest.AssertButtonEnable("Redo", false);

            RobotTest.ClickButton("Clear");
            RobotTest.AssertButtonEnable("Undo", false);
            RobotTest.AssertButtonEnable("Redo", false);
        }

        // DrawingRobotAcceptanceTest
        [TestMethod]
        public void DrawingRobotAcceptanceTest()
        {
            RobotTest.ClickButton("Ellipse");
            RobotTest.MouseDraw(200, 150, 400, 250);

            RobotTest.ClickButton("Rectangle");
            RobotTest.MouseDraw(140, 173, 173, 223);

            RobotTest.ClickButton("Rectangle");
            RobotTest.MouseDraw(445, 173, 471, 223);

            RobotTest.ClickButton("Line");
            RobotTest.MouseDraw(150, 190, 300, 200);

            RobotTest.ClickButton("Line");
            RobotTest.MouseDraw(450, 190, 300, 200);

            RobotTest.ClickButton("Ellipse");
            RobotTest.MouseDraw(262, 166, 289, 188);

            RobotTest.ClickButton("Ellipse");
            RobotTest.MouseDraw(324, 166, 348, 190);

            RobotTest.ClickButton("Ellipse");
            RobotTest.MouseDraw(252, 200, 363, 238);

            RobotTest.ClickButton("Clear");
        }

        // Cleanup
        [TestCleanup()]
        public void Cleanup()
        {
            RobotTest.CleanUp();
        }

    }
}