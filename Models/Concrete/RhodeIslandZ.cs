using System.Drawing;

namespace Models.Concrete
{
    public class RhodeIslandZ :Rectangle
    {
        public override int Yposition { get; set; } = 150;
        public override Color Color { get; set; } = Color.Cyan;
        public RhodeIslandZ()
        {
            GenerateClevelandZ();
        }

        public RhodeIslandZ(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }
        //Creates Initial 
        private void GenerateClevelandZ()
        {
            rects.Add(new Rectangle(Xposition, Yposition, Width, Height));
            rects.Add(new Rectangle(rects[0].Xposition + Width , Yposition, Width, Height));
            rects.Add(new Rectangle(Xposition, rects[0].Yposition + Width, Height, Width));
            rects.Add(new Rectangle(rects[2].Xposition-Width, rects[2].Yposition, Height, Width));
        }

    }
}
