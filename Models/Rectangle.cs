using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Models
{
    public class Rectangle : IDrawable
    {
        public virtual int Xposition { get; set; } = 250;
        public virtual int Yposition { get; set; } = 10;
        public int Width { get; set; } = 15;
        public int Height { get; set; } = 15;
        public virtual Color Color { get; set; }
        public List<Rectangle> rects { get; set; } = new List<Rectangle>();
        public Rectangle() { }

        public Rectangle(int Xposition, int Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Yposition;
        }

        public Rectangle(int xposition, int yposition, int width, int height) : this(xposition, yposition)
        {
            Width = width;
            Height = height;
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

        public void Movement()=>rects.ForEach(x => x.Yposition += 10);

    }
}
