using System.Drawing;

namespace Models.Concrete
{
    public class OrangeRicky : Shape
    {
        public OrangeRicky()
        {
            _color = Color.Orange;
            Create();
        }

        //Creates Initial Ricky
        protected override void Create()
        {
            for (int i = 0; i <= 4; i++)
            {
                if (i == 4)
                {
                    _rectangles.Add(new Rectangle(_rectangles[3].X + 13, _rectangles[3].Y - _width, _width, _height));
                }
                _rectangles.Add(new Rectangle(XPosition + i * 13, YPosition + _width, _width, _height));
            }
        }
    }
}
