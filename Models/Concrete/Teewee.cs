using System.Drawing;

namespace Models.Concrete
{
    public class Teewee :Shape
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
                _rectangles.Add(new Rectangle(Xposition + i * 10, Yposition + Width, Width, Height));
            }
            _rectangles.Add(new Rectangle(_rectangles[1].X + 5, _rectangles[1].Y - Height, Width, Height));
        }
    }
}
