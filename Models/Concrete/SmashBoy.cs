using System.Drawing;

namespace Models
{
    public class Smashboy : Shape
    {
        public Smashboy()
        {
            _color = Color.BlanchedAlmond;
            Create();
        }

        //Creates Initial Cube
        protected override void Create()
        {
            _rectangles.Add(new Rectangle(XPosition, YPosition, _width, _height)); //Initial Rectangle
            for (int i = 1; i <= 3; i++)
            {
                _rectangles.Add(new Rectangle(_rectangles[0].X + _width, _rectangles[0].Y, _width, _height)); //Secondary Rectangle
                if (i == 2)
                {
                    _rectangles.Add(new Rectangle(_rectangles[0].X, _rectangles[0].Y + _height, _width, _height));
                }
                if (i == 3)
                {
                    _rectangles.Add(new Rectangle(_rectangles[1].X, _rectangles[1].Y + _height, _width, _height));
                }
            }
        }
    }
}
