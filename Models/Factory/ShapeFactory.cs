using System;
using System.Linq;
using System.Reflection;

namespace Models.Factory
{
    public class ShapeFactory
    {
        private static Random _random = new Random();

        public static Shape CreateRandomShape()
        {
            var shapeType = GetAllShapesType();
            return Activator.CreateInstance(shapeType[_random.Next(0,shapeType.Count())]) as Shape;
        }

        private static Type[] GetAllShapesType()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes().Where(t => typeof(Shape).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && !t.IsSealed).ToArray();
        }

    }
}
