using System.Drawing;

namespace Models.Concrete
{
    public class RhodeIslandZ : ShapeDecorator
    {
        public RhodeIslandZ()
        {
            _color = Color.YellowGreen;
            Create();
        }

        public RhodeIslandZ(Shape shape) : base(shape)
        {
            _shape = shape;
        }

        protected override void Create()
        {
            _rectangles.Add(new Rectangle(XPosition, YPosition, _width, _height));
            _rectangles.Add(new Rectangle(_rectangles[0].X + _width, YPosition, _width, _height));
            _rectangles.Add(new Rectangle(XPosition, _rectangles[0].Y + _width, _height, _width));
            _rectangles.Add(new Rectangle(_rectangles[2].X - _width, _rectangles[2].Y, _height, _width));
        }
    }
}
