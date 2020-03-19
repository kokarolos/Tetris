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
            for (int i = 0; i <= 3; i++)
            {
                rects.Add(new Rectangle(rects[0].Xposition + Height, Yposition , Width, Height));
            }
        }
    }
}
