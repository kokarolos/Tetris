using Models.Concrete;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Models
{
    public abstract class Shape : IDrawable, IMoveable
    {
        public int _xPosition { get; }
        public int _yPosition { get; }
        protected int _width;
        protected int _height;
        protected Color _color;
        public List<Rectangle> _rectangles { get; }

        public Shape()
        {
            _xPosition = Settings.ShapePositionX;
            _yPosition = Settings.ShapePositionY;
            _width = Settings.ShapeWidth;
            _height = Settings.ShapeWidth;
            _rectangles = new List<Rectangle>();
        }
        protected abstract void Create();

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
            if (e.KeyCode.Equals(Keys.Left))
            {
                OnShapeMovement(Direction.Left);
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                OnShapeMovement(Direction.Right);
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                OnShapeMovement(Direction.Down);
            }
        }

        public void OnShapeMovement(Direction direction)
        {
            for (int i = 0; i < _rectangles.Count; i++)
            {
                Rectangle temp = _rectangles[i];
                temp.Y += Settings.Speed;
                _rectangles[i] = temp;

                if(direction == Direction.Down)
                {
                    temp = _rectangles[i];
                    temp.Y += Settings.Speed;
                    _rectangles[i] = temp;
                }
                if (direction == Direction.Left)
                {
                    temp = _rectangles[i];
                    temp.X -= Settings.Speed;
                    _rectangles[i] = temp;
                }
                if (direction == Direction.Right)
                {
                    temp = _rectangles[i];
                    temp.X += Settings.Speed;
                    _rectangles[i] = temp;
                }

            }
        }

        //TODO: Check For collision
        public bool IsColliding(int pictureBoxBottom)
        {
            int bottom = 0;
            foreach (var rect in _rectangles)
            {
                if (bottom <= rect.Bottom)
                {
                    bottom = rect.Bottom;
                }
            }
            return bottom > pictureBoxBottom;
        }

        private void Rotate()
        {
            //
        }
    }
}
