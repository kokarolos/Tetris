using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Models
{
    public class Hero : Rectangle, IDrawable
    {
        public List<Rectangle> rects { get; set; } = new List<Rectangle>();
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

        public void Draw(PaintEventArgs e)
        {
            foreach (var item in rects)
            {
                Graphics g = e.Graphics;
                SolidBrush b = new SolidBrush(Color);
                g.FillRectangle(b, item.Xposition, item.Yposition, item.Width, item.Height);
            }
        }

        public void Movement()
        {
            foreach (var item in rects)
            {
                item.Yposition += item.Yposition + 1;
            }
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
