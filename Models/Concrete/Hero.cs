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
                _rectangles.Add(new Rectangle(_xPosition + i * 10, _yPosition + _width, _width, _height));
            }
        }
    }
}
