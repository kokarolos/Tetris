using System.Drawing;

namespace Models.Concrete
{
    public class ClevelandZ : Shape
    {
        public override int Yposition { get; set; } = 150;

        public ClevelandZ()
        {
            _color = Color.Cyan;
            Create();
        }

        public ClevelandZ(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }

        //Creates Initial Ricky
        protected override void Create()
        {
            _rectangles.Add(new Rectangle(Xposition, Yposition, Width, Height));
            _rectangles.Add(new Rectangle(_rectangles[0].X+Width, Yposition, Width, Height));
            _rectangles.Add(new Rectangle(_rectangles[1].X , _rectangles[1].Y + Height, Width, Height));
            _rectangles.Add(new Rectangle(_rectangles[2].X + Width,Yposition + Width, Width, Height));
        }
    }
}
