using Models.Concrete;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Models
{
    public abstract class Shape : IDrawable , IMoveable
    {
        protected int _xPosition;
        protected int _yPosition;
        protected int _width;
        protected int _height;
        protected Color _color;


        protected List<Rectangle> _rectangles;

        public Shape()
        {
            _xPosition = Settings.ShapePositionX;
            _yPosition = Settings.ShapePositionY;
            _width = Settings.ShapeWidth;
            _height = Settings.ShapeWidth;
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

        public void Move(KeyEventArgs e)
        {
            _rectangles.ForEach(x => x.Y += 100);
        }

        protected abstract void Create();
    }
}
