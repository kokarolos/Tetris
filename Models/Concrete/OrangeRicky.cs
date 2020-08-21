using System.Drawing;

namespace Models.Concrete
{
    public class OrangeRicky : ShapeDecorator
    {
        public OrangeRicky()
        {
            _color = Color.Orange;
            Create();
        }

        public OrangeRicky(Shape shape) : base(shape)
        {
            _shape = shape;
        }

        //Creates Initial Ricky
        protected override void Create()
        {
            for (int i = 0; i <= 4; i++)
            {
                if (i == 4)
                {
                    _rectangles.Add(new Rectangle(_rectangles[3].X + 10, _rectangles[3].Y - _width, _width, _height));
                }
                _rectangles.Add(new Rectangle(XPosition + i * 10, YPosition + _width, _width, _height));
            }
        }
    }
}
