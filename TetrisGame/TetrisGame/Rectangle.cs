using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisGame
{
    public class Rectangle : IDrawable
    {
        public int Xposition { get; set; } = 250; 
        public int Yposition { get; set; } = 10; 
        public int Width { get; set; } = 15;
        public int Height { get; set; } = 15;
        public Color Color { get; set; } = Color.BlanchedAlmond;
        public List<Rectangle> cube { get; set; } = new List<Rectangle>();
        public Rectangle()
        {
            GenerateCube();
        }

        public Rectangle(int Xposition, int Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Yposition;
        }

        public void Draw(PaintEventArgs e) //Modularity
        {
            foreach (var item in cube)
            {
                Graphics g = e.Graphics;
                SolidBrush b = new SolidBrush(Color);
                g.FillRectangle(b, item.Xposition, item.Yposition, item.Width, item.Height);
            }
        }
        public void Movement()
        {
            foreach (var item in cube)
            {
                item.Yposition += item.Yposition + 20; //-> oo 
            }
        }

        //Creates Initial Cube
        private void GenerateCube()
        {
            cube.Add(new Rectangle(Xposition, Yposition)); //Initial Rectangle
            for (int i = 1; i <= 3; i++)
            {
                cube.Add(new Rectangle(cube[0].Xposition + Width, cube[0].Yposition)); //Secondary Rectangle
                if (i == 2)
                {
                    cube.Add(new Rectangle(cube[0].Xposition, cube[0].Yposition + Height));
                }
                if (i == 3)
                {
                    cube.Add(new Rectangle(cube[1].Xposition, cube[1].Yposition + Height));
                }
            }
        }
    }
}
