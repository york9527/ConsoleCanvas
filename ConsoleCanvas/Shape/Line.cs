using System.Collections.Generic;
using ConsoleCanvas.Config;
using ConsoleCanvas.Extentions;

namespace ConsoleCanvas.Shape
{
    public class Line:AbstractShape
    {

        public override List<List<int>> Draw(List<List<int>> canvas, string[] args)
        {
            Canvas=canvas;
            DrawCommandL(args[1].ToInt(), args[2].ToInt(), args[3].ToInt(), args[4].ToInt());
            return Canvas;
        }

        public void DrawCommandL(int x1, int y1, int x2, int y2)
        {
            DrawLine(x1, y1, x2, y2, (int) DrawCharacter.POINT);
        }

        public override string GetSupportedCommand()
        {
            return "L";
        }

        public override string GetUserInputCharacter()
        {
            return string.Empty;
        }


    }
}
