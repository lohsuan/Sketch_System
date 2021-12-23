using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace DrawingModelUITest
{
    /// <summary>
    /// Please change display of the computer to 100% to execute codeing ui test
    /// Summary description for DrawingModelUITest
    /// number of total ui test: 5
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
        public void DrawEachShapeAndSelectTest()
        {
            // Rectangle
            RobotTest.ClickButton("Rectangle");
            RobotTest.AssertButtonEnable("Rectangle", false);
            RobotTest.MouseDraw(100, 100, 300, 300);
            RobotTest.AssertButtonEnable("Rectangle", true);
            RobotTest.MouseDraw(200, 200, 201, 201);
            RobotTest.AssertWindowsContainLabelText("Selected : Rectangle(100, 100, 300, 300)");
            
            // Ellipse
            RobotTest.ClickButton("Ellipse");
            RobotTest.AssertButtonEnable("Ellipse", false);
            RobotTest.MouseDraw(400, 130, 550, 250);
            RobotTest.AssertButtonEnable("Ellipse", true);
            RobotTest.MouseDraw(500, 150, 500, 150);
            RobotTest.AssertWindowsContainLabelText("Selected : Ellipse(400, 130, 550, 250)");
            
            // Line
            RobotTest.ClickButton("Line");
            RobotTest.AssertButtonEnable("Line", false);
            
            RobotTest.MouseDraw(130, 130, 200, 200);
            RobotTest.AssertButtonEnable("Line", false);

            RobotTest.MouseDraw(200, 200, 500, 500);
            RobotTest.AssertButtonEnable("Line", true);
         
            RobotTest.ClickButton("Clear");
        }

        // ClearTest
        [TestMethod]
        public void ClearTest()
        {
            RobotTest.ClickButton("Ellipse");
            RobotTest.AssertButtonEnable("Ellipse", false);
            RobotTest.MouseDraw(375, 80, 525, 140);
            RobotTest.AssertButtonEnable("Ellipse", true);

            RobotTest.ClickButton("Clear");
        }

        //// DrawingSnowManTest
        [TestMethod]
        public void DrawingSnowManTest()
        {
            RobotTest.ClickButton("Ellipse");
            RobotTest.MouseDraw(320, 240, 580, 500);
            RobotTest.ClickButton("Ellipse");
            RobotTest.MouseDraw(380, 130, 520, 270);

            RobotTest.ClickButton("Ellipse");
            RobotTest.MouseDraw(410, 175, 430, 195);
            RobotTest.ClickButton("Ellipse");
            RobotTest.MouseDraw(470, 175, 490, 195);

            RobotTest.ClickButton("Rectangle");
            RobotTest.MouseDraw(375, 80, 525, 140);
            RobotTest.ClickButton("Rectangle");
            RobotTest.MouseDraw(350, 140, 550, 160);
            RobotTest.ClickButton("Rectangle");
            RobotTest.MouseDraw(420, 215, 480, 245);

            RobotTest.ClickButton("Ellipse");
            RobotTest.MouseDraw(430, 300, 470, 340);
            RobotTest.ClickButton("Ellipse");
            RobotTest.MouseDraw(430, 360, 470, 400);

            RobotTest.ClickButton("Rectangle");
            RobotTest.MouseDraw(310, 200, 320, 360);
            RobotTest.ClickButton("Rectangle");
            RobotTest.MouseDraw(580, 200, 590, 360);

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