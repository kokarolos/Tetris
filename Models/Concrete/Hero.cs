using System.Drawing;

namespace Models
{
    public class Hero : Rectangle
    {
        public override Color Color { get; set; } = Color.Red;

        public Hero()
        {
            GenerateHero();
        }

        public Hero(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }

        //Creates Initial Hero
        private void GenerateHero()
        {
            for(int i =0; i<=4; i++)
            {
                rects.Add(new Rectangle(Xposition + i*10, Yposition + Width, Width, Height));
            }
        }
    }
}
