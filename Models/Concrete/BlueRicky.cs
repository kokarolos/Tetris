﻿using System.Drawing;

namespace Models.Concrete
{
    public class BlueRicky : ShapeDecorator
    {
        public BlueRicky()
        {
            _color = Color.Blue;
            Create();
        }

        public BlueRicky(Shape shape) : base(shape)
        {
            _shape = shape;
        }

        //Creates Initial Ricky
        protected override void Create()
        {
            _rectangles.Add(new Rectangle(XPosition, YPosition, _width, _height));
            _rectangles.Add(new Rectangle(XPosition, _rectangles[0].Y + _height, _width, _height));
            _rectangles.Add(new Rectangle(_rectangles[1].X + _width, _rectangles[1].Y, _width, _height));
            _rectangles.Add(new Rectangle(_rectangles[2].X + _width, _rectangles[1].Y, _width, _height));
        }
    }
}
