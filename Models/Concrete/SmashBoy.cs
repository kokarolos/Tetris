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

        public Smashboy(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }

        //Creates Initial Cube
        protected override void Create()
        {
            _rectangles.Add(new Rectangle(Xposition, Yposition, Width, Height)); //Initial Rectangle
            for (int i = 1; i <= 3; i++)
            {
                _rectangles.Add(new Rectangle(_rectangles[0].X + Width, _rectangles[0].Y, Width, Height)); //Secondary Rectangle
                if (i == 2)
                {
                    _rectangles.Add(new Rectangle(_rectangles[0].X, _rectangles[0].Y + Height, Width, Height));
                }
                if (i == 3)
                {
                    _rectangles.Add(new Rectangle(_rectangles[1].X, _rectangles[1].Y + Height, Width, Height));
                }
            }
        }
    }
}
