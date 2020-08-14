using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Models
{
    public abstract class Shape : IDrawable , IMoveable
    {
        public virtual int Xposition { get; set; } = 250;
        public virtual int Yposition { get; set; } = 10;
        public int Width { get; set; } = 15;
        public int Height { get; set; } = 15;
        protected Color _color;

        protected List<Rectangle> _rectangles;

        public Shape()
        {
            _rectangles = new List<Rectangle>();
        }

        public void Draw(PaintEventArgs e)
        {
            foreach (var rectangle in _rectangles)
            {
                Graphics g = e.Graphics;
                SolidBrush b = new SolidBrush(_color);
                g.FillRectangle(b, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            }
        }
        public void Move()=>_rectangles.ForEach(x => x.Y += 10);

        protected abstract void Create();
    }
}
