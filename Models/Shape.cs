using Enums;
using Models.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Models
{
    public abstract class Shape : IDrawable, IMoveable
    {
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }
        protected int _width
        {
            get => _rectangles.Sum(x => x.X);
        }
        protected int _height
        {
            get => _rectangles.Sum(x => x.Y);
        }
        protected Color _color;
        protected float _velocity { get; private set; }
        public List<Rectangle> _rectangles { get; }
        public Shape NextShape { get; set; }
        //public int Top { get; }
        //public int Bottom { get; }


        public Shape()
        {
            XPosition = Settings.ShapePositionX;
            YPosition = Settings.ShapePositionY;
            _rectangles = new List<Rectangle>();
            _velocity = 1.0f;
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
                    _velocity = 1.2f;
                    temp = _rectangles[i];
                    temp.Y += (int)(Settings.Speed * _velocity);
                    _rectangles[i] = temp;
                }
                if (direction == Direction.Down && state == State.Active)
                {
                    temp = _rectangles[i];
                    temp.Y += (int)(Settings.Speed * _velocity);
                    _rectangles[i] = temp;
                }
                if (direction == Direction.Left && state == State.Active)
                {
                    temp = _rectangles[i];
                    temp.X -= (int)(Settings.Speed * _velocity);
                    _rectangles[i] = temp;
                }
                if (direction == Direction.Right && state == State.Active)
                {
                    temp = _rectangles[i];
                    temp.X += (int)(Settings.Speed * _velocity);
                    _rectangles[i] = temp;
                }
                if (direction == Direction.Down && state == State.Idle)
                {
                    _velocity = 0f;
                    temp = _rectangles[i];
                    temp.Y += (int)(Settings.Speed * _velocity);
                    _rectangles[i] = temp;
                }
            }
        }

        public bool IsCollidingPictureBoxBottom(int pictureBoxBottom)
        {

            foreach (var rectangle in _rectangles)
            {
                if (Math.Abs(rectangle.Bottom - pictureBoxBottom) <= 5.0f)
                {
                    return true;
                }
            }

            return false;
        }

        //Refactor this
        public bool IsCollidingAnotherShape(List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                if (shape.GetTop() - this.GetTop() <= 30.0f && shape.GetBottom() - this.GetBottom() <= 30.0f)
                {
                    return true;
                }
            }
            return false;
        }
        public int GetBottom()
        {
            int lowestPoint = 0;
            for (int i = _rectangles.Count - 1; i >= 1; i--)
            {
                var currentRectangle = _rectangles[i].X;
                var nextRectangle = _rectangles[i - 1].X;
                if (currentRectangle >= nextRectangle)
                {
                    lowestPoint = currentRectangle;
                }
                else
                {
                    lowestPoint = _rectangles[0].X;
                }
            }
            return lowestPoint;
        }
        public int GetTop()
        {
            int highestPoint = 0;
            for (int i = _rectangles.Count - 1; i >= 1; i--)
            {
                var currentRectangle = _rectangles[i].Y;
                var nextRectangle = _rectangles[i - 1].Y;
                if (currentRectangle <= nextRectangle)
                {
                    highestPoint = currentRectangle;
                }
                else
                {
                    highestPoint = _rectangles[0].Y;
                }
            }
            return highestPoint;
        }
    }
}
