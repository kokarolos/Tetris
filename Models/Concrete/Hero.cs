using System.Drawing;

namespace Models
{
    public class Hero : Shape
    {
        //public override Color Color { get; set; } = Color.Red;

        public Hero()
        {
            Create();
        }
        //Creates Initial Hero
        protected override void Create()
        {
            for (int i = 0; i <= 4; i++)
            {
                _rectangles.Add(new Rectangle(XPosition + i * 10, YPosition + _width, _width, _height));
            }
        }
    }
}
