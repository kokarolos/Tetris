using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisGame
{
    public class Cube : Rectangle, IDrawable
    {
        
        public List<Rectangle> rects { get; set; } = new List<Rectangle>();
        public override Color Color { get; set; } = Color.BlanchedAlmond;

        public Cube()
        {
            GenerateCube();
        }

        public Cube(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }

        public void Draw(PaintEventArgs e) //Modularity
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

        //Creates Initial Cube
        private void GenerateCube()
        {
            rects.Add(new Rectangle(Xposition, Yposition,Width,Height)); //Initial Rectangle
            for (int i = 1; i <= 3; i++)
            {
                rects.Add(new Rectangle(rects[0].Xposition + Width, rects[0].Yposition, Width, Height)); //Secondary Rectangle
                if (i == 2)
                {
                    rects.Add(new Rectangle(rects[0].Xposition, rects[0].Yposition + Height, Width, Height));
                }
                if (i == 3)
                {
                    rects.Add(new Rectangle(rects[1].Xposition, rects[1].Yposition + Height, Width, Height));
                }
            }
        }
    }
}
