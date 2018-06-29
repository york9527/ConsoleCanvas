using System.Collections.Generic;

namespace ConsoleCanvas.Shape
{
    public abstract class AbstractShape
    {
        public List<List<int>> Canvas { get; set; }


        public abstract List<List<int>> Draw(List<List<int>> canvas,string[] args);
        public abstract string GetSupportedCommand();
        public abstract string GetUserInputCharacter();

        public void DrawLine(int x1, int y1, int x2, int y2, int charachter)
        {
            if (x1 == x2)
            {
                DrawVerticalLine(x1, y1, y2, charachter);
            }
            else if (y1 == y2)
            {
                DrawHorizontalLine(x1, y1, x2 + 1, charachter);
            }
        }

        public void DrawVerticalLine(int x1, int y1, int y2, int charachter)
        {
            for (var i = y1; i < y2 + 1; i++)
            {
                Canvas[i][x1] = charachter;
            }
        }

        public void DrawHorizontalLine(int x1, int y1, int x2, int charachter)
        {
            var line = Canvas[y1];
            for (var i = x1; i < x2; i++)
            {
                line[i] = charachter;
            }
        }
    }
}
