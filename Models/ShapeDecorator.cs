using System;
using System.Collections.Generic;

namespace Models
{
    public sealed class ShapeDecorator : Shape
    {
        private Shape _shape;
        private List<Shape> _collindingShapes;

        public ShapeDecorator(Shape shape)
        {
            _collindingShapes = new List<Shape>();
            _shape = shape;
            if (IsCollingWithAnotherShape(_shape))
            {
                _collindingShapes.Add(_shape);
                Create();
            }
        }

        protected override void Create()
        {
            foreach (var shape in _collindingShapes)
            {
               //TODO: Stuck the tetris -> if colliding then create new Big Tetris adding all colliding rectangles to tetris 
            }
        }

        public bool IsCollingWithAnotherShape(Shape shape)
        {
            foreach (var collingShape in _collindingShapes)
            {
                if (Math.Abs(shape.XPosition - collingShape.XPosition) >= 1.0f || Math.Abs(shape.YPosition - collingShape.YPosition) >= 1.0f)
                {
                    return true;
                }
            }
            throw new InvalidOperationException();
        }
    }
}
