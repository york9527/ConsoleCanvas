using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleCanvas.Config;
using ConsoleCanvas.Shape;

namespace ConsoleCanvas
{
    class Program
    {
        static void Main(string[] args)
        {
            var canvas=new Canvas();
            canvas.Run();
        }
    }
}