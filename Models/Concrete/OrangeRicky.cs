using System.Drawing;

namespace Models.Concrete
{
    public class OrangeRicky : Shape
    {
        public OrangeRicky()
        {
            _color = Color.Orange;
            Create();
        }

        public OrangeRicky(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }

        //Creates Initial Ricky
        protected override void Create()
        {
            for (int i = 0; i <= 4; i++)
            {
                if (i == 4)
                {
                    _rectangles.Add(new Rectangle(_rectangles[3].X + 10, _rectangles[3].Y - Width, Width, Height));
                }
                _rectangles.Add(new Rectangle(Xposition + i * 10, Yposition + Width, Width, Height));
            }
        }
    }
}
