using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisGame
{

    public partial class Form1 : Form
    {
        readonly Cube cube = new Cube();


        public Form1()
        {
            InitializeComponent();
            // KeyDown += new KeyEventHandler(Form1_KeyDown);
            Timer timer1 = new Timer();
            timer1.Interval = (1000/10);
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            cube.Draw(e); //recursive
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cube.Movement(); // <= Updates  timer1.Interval seconds
            pictureBox1.Invalidate(); //<= timer1.Interval seconds it will re-draw the picturebox UPDATED surface
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {}
    }
}
