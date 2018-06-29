using System.Collections.Generic;
using ConsoleCanvas.Config;
using ConsoleCanvas.Extentions;

namespace ConsoleCanvas.Shape
{
    public class FillShape:AbstractShape
    {
        private string _userInputCharacter;

        public override List<List<int>> Draw(List<List<int>> canvas, string[] args)
        {
            Canvas = canvas;
            DrawCommandB(args[1].ToInt(), args[2].ToInt(), args[3]);
            return Canvas;
        }

        public override string GetSupportedCommand()
        {
            return "B";
        }

        public override string GetUserInputCharacter()
        {
            return _userInputCharacter;
        }

        private void DrawCommandB(int x, int y, string s)
        {
            _userInputCharacter=s;
            if (!IsPointEmpty(x, y))
            {
                return;
            }
            FillAllNeighbor(x, y);
        }

        private void FillAllNeighbor(int x, int y)
        {
            SetPointUserInput(x, y);
            var count = GetNoSpaceNeighborCount(x, y);
            if (count == 8)
            {
                return;
            }

            for (var i = x-1; i <= x+1; i++)
            {
                for (var j = y-1; j <= y+1; j++)
                {
                    if (IsPointExist(i, j))
                    {
                        if (IsPointEmpty(i, j))
                        {
                            SetPointUserInput(i,j);
                            FillAllNeighbor(i,j);
                        }
                    }
                }
            }

        }

        private bool IsPointEmpty(int x, int y)
        {
            return Canvas[y][x] == (int) DrawCharacter.ONE_SPACE;
        }

        private void SetPointUserInput(int x, int y)
        {
            if (IsPointExist(x, y))
            {
                Canvas[y][x]=(int) DrawCharacter.USER_INPUT;
            }
        }

        private int GetNoSpaceNeighborCount(int x, int y)
        {
            var isToReturn = 0;
            for (var i = x-1; i <= x+1; i++)
            {
                for (var j = y-1; j <= y+1; j++)
                {
                    if (IsPointExist(i, j))
                    {
                        if (i == x && j == y)
                            continue;

                        if (!IsPointEmpty(i,j))
                        {
                            isToReturn++;
                        }
                    }
                    else
                    {
                        isToReturn++;
                    }
                }
            }

            return isToReturn;
        }

        private bool IsPointExist(int x, int y)
        {
            var isXValid = (x >= 1) && x <= (Canvas[0].Count - 2);
            var isYValid = (y >= 1) && (y <= Canvas.Count - 2);
            return isXValid && isYValid;
        }
    }
}
