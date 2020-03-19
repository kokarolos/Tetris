using Models.Concrete;
using System;
using System.Windows.Forms;

namespace TetrisGame
{

    public partial class Form1 : Form
    {
        //readonly Smashboy smashBoy = new Smashboy();
        //readonly Hero hero = new Hero();
        //readonly OrangeRicky orangeRicky = new OrangeRicky();
        //readonly Teewee teewee = new Teewee();
        readonly BlueRicky blueRicky = new BlueRicky();
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
            //smashBoy.Draw(e); 
            //hero.Draw(e);
            //orangeRicky.Draw(e);
            //teewee.Draw(e);
            blueRicky.Draw(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //hero.Movement();
            //cube.Movement(); 

            pictureBox1.Invalidate(); 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {}
    }
}
