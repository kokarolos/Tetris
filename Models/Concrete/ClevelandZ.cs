using System.Drawing;

namespace Models.Concrete
{
    public class ClevelandZ : Shape
    {
        public ClevelandZ()
        {
            _color = Color.Cyan;
            Create();
        }

        //Creates Initial Ricky
        protected override void Create()
        {
            _rectangles.Add(new Rectangle(XPosition, YPosition, _width, _height));
            _rectangles.Add(new Rectangle(_rectangles[0].X + _width, YPosition, _width, _height));
            _rectangles.Add(new Rectangle(_rectangles[1].X, _rectangles[1].Y + _height, _width, _height));
            _rectangles.Add(new Rectangle(_rectangles[2].X + _width, YPosition + _width, _width, _height));
        }
    }
}
