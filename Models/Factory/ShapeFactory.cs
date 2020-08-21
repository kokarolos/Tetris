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
            Type[] shapesType;
            shapesType = GetAllShapesType();
            try
            {
                return Activator.CreateInstance(shapesType[_random.Next(0, shapesType.Count())]) as Shape;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static Type[] GetAllShapesType()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes().Where(t => typeof(Shape).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && !t.IsSealed).ToArray();
        }

    }
}
