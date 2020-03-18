using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    public class Rectangle
    {
        public int Xposition { get; set; } = 250;
        public int Yposition { get; set; } = 10;
        public int Width { get; set; } = 15;
        public int Height { get; set; } = 15;
        public virtual Color Color { get; set; }
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
    }
}
