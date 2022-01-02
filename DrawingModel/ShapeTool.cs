using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class ShapeTool
    {
        ShapeFactory _shapeFactory = new ShapeFactory();
        private const string ENTER = "\n";
        private const string CURRENT_DIRECTORY = "./";
        private const string SPACE = " ";
        private const int X1_INDEX = 2;
        private const int Y1_INDEX = 3;
        private const int X2_INDEX = 4;
        private const int Y2_INDEX = 5;
        private const int START_LINK_LINE_SHAPE_INDEX = 6;
        private const int END_LINK_LINE_SHAPE_INDEX = 7;
        private const char SEPARATOR_ENTER = '\n';
        private const char SEPARATOR_SPACE = ' ';
        private const string LINE = "Line";
        private const string UPLOAD_FILE_NAME = "shapes.txt";

        // SaveShapesToFile
        public void SaveShapesToFile(List<Shape> shapes)
        {
            string path = CURRENT_DIRECTORY + UPLOAD_FILE_NAME;
            string text = "";
            for (int i = 0; i < shapes.Count; i++)
            {
                shapes[i].OrderIndex = i;
                text += i + SPACE + shapes[i].GetShapeOutputFormat() + ENTER;
            }
            File.WriteAllText(path, text);
        }

        // TurnFileToShapes
        public void TurnFileToShapes(List<Shape> shapes)
        {
            string path = CURRENT_DIRECTORY + UPLOAD_FILE_NAME;
            string readText = File.ReadAllText(path);
            string[] shapeTextArray = readText.Split(SEPARATOR_ENTER);
            for (int i = 0; i < shapeTextArray.Length - 1; i++)
            {
                string[] shapeInfo = shapeTextArray[i].Split(SEPARATOR_SPACE);
                string shapeType = shapeInfo[1];
                Shape shape = _shapeFactory.CreateShape(shapeType);
                shape.SetPosition(Int32.Parse(shapeInfo[X1_INDEX]), Int32.Parse(shapeInfo[Y1_INDEX]), Int32.Parse(shapeInfo[X2_INDEX]), Int32.Parse(shapeInfo[Y2_INDEX]));
                if (shapeType == LINE)
                    shape = new Line(shapes[Int32.Parse(shapeInfo[START_LINK_LINE_SHAPE_INDEX])], shapes[Int32.Parse(shapeInfo[END_LINK_LINE_SHAPE_INDEX])]);
                shapes.Add(shape);
            }
        }
    }
}
