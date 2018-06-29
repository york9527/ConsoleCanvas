using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleCanvas.Shape;

namespace ConsoleCanvas
{
    public class ShapeFactory
    {
        private Dictionary<string,AbstractShape> _shapeDic;

        public ShapeFactory()
        {
            _shapeDic = Init();
        }

        public AbstractShape GetShape(string command)
        {
            return _shapeDic[command];
        }

        static Dictionary<string, AbstractShape> Init()
        {
            var dic = new Dictionary<string, AbstractShape>();
            var type = typeof(AbstractShape);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract).ToList();

            foreach (var t in types)
            {
                var instance = (AbstractShape)Activator.CreateInstance(t);
                dic[instance.GetSupportedCommand()] = instance;
            }

            return dic;
        }
    }
}
