using System.Collections.Generic;
using System.Drawing;

namespace Models.Concrete
{
    public class Teewee :Rectangle
    {
        public override Color Color { get; set; } = Color.Red;

        public Teewee()
        {
            GenerateTeewee();
        }

        public Teewee(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }

        //Creates Initial Teewee
        private void GenerateTeewee()
        {
            for (int i = 0; i <= 3; i++)
            {
                rects.Add(new Rectangle(Xposition + i * 10, Yposition + Width, Width, Height));
            }
            rects.Add(new Rectangle(rects[1].Xposition +5 , rects[1].Yposition - Height, Width, Height));
        }
    }
}
