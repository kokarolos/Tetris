using System.Drawing;

namespace Models.Concrete
{
    public class BlueRicky :Rectangle
    {
        public override int Yposition { get; set; } = 150;
        public override Color Color { get; set; } = Color.Cyan;
        public BlueRicky()
        {
            GenerateBlueRicky();
        }

        public BlueRicky(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }
        //Creates Initial Ricky
        private void GenerateBlueRicky()
        {
            rects.Add(new Rectangle(Xposition, Yposition, Width, Height));
            rects.Add(new Rectangle(Xposition, rects[0].Yposition+Height , Width, Height));
            rects.Add(new Rectangle(rects[1].Xposition+Width, rects[1].Yposition , Width, Height));
            rects.Add(new Rectangle(rects[2].Xposition+Width, rects[1].Yposition , Width, Height));
        }
    }
}
