using System.Drawing;

namespace Models.Concrete
{
    public class RhodeIslandZ :Shape
    {
        public override int Yposition { get; set; } = 150;

        public RhodeIslandZ()
        {
            _color = Color.Cyan;
            Create();
        }

        public RhodeIslandZ(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }

        protected override void Create()
        {
            _rectangles.Add(new Rectangle(Xposition, Yposition, Width, Height));
            _rectangles.Add(new Rectangle(_rectangles[0].X + Width, Yposition, Width, Height));
            _rectangles.Add(new Rectangle(Xposition, _rectangles[0].Y + Width, Height, Width));
            _rectangles.Add(new Rectangle(_rectangles[2].X - Width, _rectangles[2].Y, Height, Width));
        }
    }
}
