using System.Drawing;

namespace Models.Concrete
{
    public class BlueRicky : Shape
    {
        public override int Yposition { get; set; } = 150;

        public BlueRicky()
        {
            _color = Color.Blue;
            Create();
        }

        public BlueRicky(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }

        //Creates Initial Ricky
        protected override void Create()
        {
            _rectangles.Add(new Rectangle(Xposition, Yposition, Width, Height));
            _rectangles.Add(new Rectangle(Xposition, _rectangles[0].Y + Height, Width, Height));
            _rectangles.Add(new Rectangle(_rectangles[1].X + Width, _rectangles[1].Y, Width, Height));
            _rectangles.Add(new Rectangle(_rectangles[2].X + Width, _rectangles[1].Y, Width, Height));
        }
    }
}
