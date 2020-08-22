using System.Drawing;

namespace Models.Concrete
{
    public class Teewee : Shape
    {
        public Teewee()
        {
            _color = Color.Red;
            Create();
        }

        //Creates Initial Teewee
        protected override void Create()
        {
            for (int i = 0; i <= 3; i++)
            {
                _rectangles.Add(new Rectangle(XPosition + i * 10, YPosition + _width, _width, _height));
            }
            _rectangles.Add(new Rectangle(_rectangles[1].X + 5, _rectangles[1].Y - _height, _width, _height));
        }
    }
}
