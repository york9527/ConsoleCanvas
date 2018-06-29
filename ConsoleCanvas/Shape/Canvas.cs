using System.Collections.Generic;
using ConsoleCanvas.Config;
using ConsoleCanvas.Extentions;

namespace ConsoleCanvas.Shape
{
    public class Canvas:AbstractShape
    {
        private static int _width;
        private static int _height;


        public override List<List<int>> Draw(List<List<int>> canvas, string[] args)
        {
            Canvas = canvas;

            var width = args[1].ToInt();
            var height = args[2].ToInt();
            Init(width, height);
            DrawHorizontalLine(0, 0, _width, (int) DrawCharacter.H_LINE);
            DrawHorizontalLine(0, height + 1, _width, (int) DrawCharacter.H_LINE);
            DrawVerticalLine(0, 1, height, (int) DrawCharacter.V_LINE);
            DrawVerticalLine(width + 1, 1, height, (int) DrawCharacter.V_LINE);
            return Canvas;
        }

        public override string GetUserInputCharacter()
        {
            return string.Empty;
        }

        public override string GetSupportedCommand()
        {
            return "C";
        }

        private void Init(int width, int height)
        {
            _width = width + 2;
            _height = height + 2;
            for (var i = 0; i < _height; i++)
            {
                var line = new List<int>();
                for (var j = 0; j < _width; j++)
                {
                    line.Add((int) DrawCharacter.ONE_SPACE);
                }

                Canvas.Add(line);
            }
        }
    }
}
