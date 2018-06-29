using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCanvas.Config;

namespace ConsoleCanvas
{
    public class Canvas
    {
        private List<List<int>> _canvas = new List<List<int>>();
        private string _userInputCharacter;
        private string TIP = "Please enter the currect command.";
        private ShapeFactory _shapeFactory;

        public void Run()
        {
            _shapeFactory = new ShapeFactory();

            while (true)
            {
                Console.Write("enter command: ");
                var args = Console.ReadLine()?.Split(' ');
                try
                {
                    if (IsExit(args))
                    {
                        Environment.Exit(0);
                    }

                    ExecuteCommand(args);
                }
                catch (Exception)
                {
                    Console.WriteLine(TIP);
                }
            }
        }

        private bool IsExit(string[] args)
        {
            return args[0] == "Q";
        }

        private void ExecuteCommand(string[] args)
        {
            var shape = _shapeFactory.GetShape(args[0]);
            _canvas = shape.Draw(_canvas, args);

            if (!string.IsNullOrWhiteSpace(shape.GetUserInputCharacter()))
            {
                _userInputCharacter = shape.GetUserInputCharacter();
            }
            PrintThePicture();
        }



        private void PrintThePicture()
        {
            foreach (var line in _canvas)
            {
                foreach (var point in line)
                {
                    switch ((DrawCharacter)point)
                    {
                        case DrawCharacter.H_LINE:
                            Console.Write(DrawElementConfig.H_LINE);
                            break;
                        case DrawCharacter.ONE_SPACE:
                            Console.Write(DrawElementConfig.ONE_SPACE);
                            break;
                        case DrawCharacter.V_LINE:
                            Console.Write(DrawElementConfig.V_LINE);
                            break;
                        case DrawCharacter.POINT:
                            Console.Write(DrawElementConfig.POINT);
                            break;
                        case DrawCharacter.USER_INPUT:
                            Console.Write(_userInputCharacter);
                            break;
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
