using System.Drawing;

namespace Models
{
    public class Hero : Shape
    {
        //public override Color Color { get; set; } = Color.Red;

        public Hero()
        {
            Create();
        }

        public Hero(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }

        //Creates Initial Hero
        protected override void Create()
        {
            for (int i = 0; i <= 4; i++)
            {
                _rectangles.Add(new Rectangle(Xposition + i * 10, Yposition + Width, Width, Height));
            }
        }
    }
}
