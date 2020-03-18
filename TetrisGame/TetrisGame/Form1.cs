using Models;
using System;
using System.Windows.Forms;

namespace TetrisGame
{

    public partial class Form1 : Form
    {
        readonly Cube cube = new Cube();
        readonly Hero hero = new Hero();

        public Form1()
        {
            InitializeComponent();
            // KeyDown += new KeyEventHandler(Form1_KeyDown);
            Timer timer1 = new Timer();
            //timer1.Interval = (1000/10);
            //timer1.Tick += timer1_Tick;
            //timer1.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            cube.Draw(e); 
            hero.Draw(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hero.Movement();
            cube.Movement(); 
            pictureBox1.Invalidate(); 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {}
    }
}
