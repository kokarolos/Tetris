using System.Drawing;

namespace Models
{
    public class Smashboy : Rectangle
    {
        public override Color Color { get; set; } = Color.BlanchedAlmond;
        public Smashboy()
        {
            GenerateCube();
        }

        public Smashboy(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }

        //Creates Initial Cube
        private void GenerateCube()
        {
            rects.Add(new Rectangle(Xposition, Yposition,Width,Height)); //Initial Rectangle
            for (int i = 1; i <= 3; i++)
            {
                rects.Add(new Rectangle(rects[0].Xposition + Width, rects[0].Yposition, Width, Height)); //Secondary Rectangle
                if (i == 2)
                {
                    rects.Add(new Rectangle(rects[0].Xposition, rects[0].Yposition + Height, Width, Height));
                }
                if (i == 3)
                {
                    rects.Add(new Rectangle(rects[1].Xposition, rects[1].Yposition + Height, Width, Height));
                }
            }
        }
    }
}
