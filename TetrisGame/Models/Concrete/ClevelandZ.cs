using System.Drawing;

namespace Models.Concrete
{
    public class ClevelandZ :Rectangle
    {
        public override int Yposition { get; set; } = 150;
        public override Color Color { get; set; } = Color.Cyan;
        public ClevelandZ()
        {
            GenerateClevelandZ();
        }

        public ClevelandZ(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }
        //Creates Initial Ricky
        private void GenerateClevelandZ()
        {
            rects.Add(new Rectangle(Xposition, Yposition, Width, Height));
            rects.Add(new Rectangle(rects[0].Xposition+Width, Yposition, Width, Height));
            rects.Add(new Rectangle(rects[1].Xposition , rects[1].Yposition + Height, Width, Height));
            rects.Add(new Rectangle(rects[2].Xposition + Width,Yposition + Width, Width, Height));
        }
    }
}
