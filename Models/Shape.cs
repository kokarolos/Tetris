using Enums;
using Models.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Models
{
    public abstract class Shape : IDrawable, IMoveable
    {
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }
        protected int _width;
        protected int _height;
        protected Color _color;
        protected float velocity { get; private set; }

        public List<Rectangle> _rectangles { get; }
        public Shape NextShape { get; set; }

        public Shape()
        {
            XPosition = Settings.ShapePositionX;
            YPosition = Settings.ShapePositionY;
            _width = Settings.ShapeWidth;
            _height = Settings.ShapeWidth;
            _rectangles = new List<Rectangle>();
            velocity = 1.0f;
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

        //Refactor this -> Delegate(?)
        //Check for Dictionary or Hash<KeyeventArgs,Direction>
        public void Move(KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Left))
            {
                OnShapeMovement(Direction.Left, State.Active);
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                OnShapeMovement(Direction.Right, State.Active);
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                OnShapeMovement(Direction.Down, State.Active);
            }
        }

        public void OnShapeMovement(Direction direction, State state)
        {
            for (int i = 0; i < _rectangles.Count; i++)
            {
                Rectangle temp;
                if (direction == Direction.Down && state == State.Active)
                {
                    velocity = 1.2f;
                    temp = _rectangles[i];
                    temp.Y += (int)(Settings.Speed * velocity);
                    _rectangles[i] = temp;
                }
                if (direction == Direction.Down && state == State.Active)
                {
                    velocity = 1.0f;
                    temp = _rectangles[i];
                    temp.Y += (int)(Settings.Speed * velocity);
                    _rectangles[i] = temp;
                }
                if (direction == Direction.Left && state == State.Active)
                {
                    velocity = 1.0f;
                    temp = _rectangles[i];
                    temp.X -= (int)(Settings.Speed * velocity);
                    _rectangles[i] = temp;
                }
                if (direction == Direction.Right && state == State.Active)
                {
                    velocity = 1.0f;
                    temp = _rectangles[i];
                    temp.X += (int)(Settings.Speed * velocity);
                    _rectangles[i] = temp;
                }
                if (direction == Direction.Down && state == State.Idle)
                {
                    velocity = 0f;
                    temp = _rectangles[i];
                    temp.Y += (int)(Settings.Speed * velocity);
                    _rectangles[i] = temp;
                }
            }
        }

        public bool IsCollidingPictureBoxBottom(int pictureBoxBottom)
        {
            foreach (var rect in _rectangles)
            {
                if (Math.Abs(rect.Y - pictureBoxBottom) <= 30.0f)
                {
                    return true;
                }
            }
            return false;
        }

        //Refactor this
        public bool IsCollidingAnotherShape(List<Rectangle> nextShapeRectangles, List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                foreach (var rect in shape._rectangles)
                {
                    foreach (var rectangle in nextShapeRectangles)
                    {
                        if (rect.Y - rectangle.Y <= 30.0f)
                        {
                            return true;
                        }

                    }
                }
            }
            return false;
        }

        private void StabilizeShapeBottom(List<Rectangle> rectangles, int pictureBoxBottom)
        {
            //IF shape.x is below pictureboxbottom then set shape.x to pictureboxbottom x
            Rectangle temp = new Rectangle();
            for (int i = 0; i < _rectangles.Count; i++)
            {
                temp.Y = pictureBoxBottom - Settings.ShapeHeight;
                temp = _rectangles[i];
                _rectangles[i] = temp;
            }
        }

        public void Rotate(KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Space))
            {
                int tempX = XPosition;
                XPosition = -YPosition;
                YPosition = tempX;
            }
        }
    }
}
