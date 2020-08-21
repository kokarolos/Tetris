using System.Drawing;

namespace Models
{
    public class Hero : ShapeDecorator
    {
        public Hero()
        {
            _color = Color.Red;
            Create();
        }

        public Hero(Shape shape) : base(shape)
        {
            _shape = shape;
        }

        //Creates Initial Hero
        protected override void Create()
        {
            for (int i = 0; i <= 4; i++)
            {
                _rectangles.Add(new Rectangle(XPosition + i * 13, YPosition + _width, _width, _height));
            }
        }
    }
}
