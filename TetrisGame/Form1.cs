using Models;
using Models.Concrete;
using System;
using System.Windows.Forms;

namespace TetrisGame
{
    //TODO : Hard Refactor :
    // Fix inheritance ripple effect -> rectangle -> to all conrete classes
    // favor composition over inheritance, example. BlueRicky has rectangle not is a rectangle.
    // TODO 2 : Create Factory so i can generate every 5 sec new shapes 
    // TODO fix some shapes movement as they dont move 
    //TODO bluericky bug
    //TODO :Fix bug of clz
    //Refactor 19-25 lns

    public partial class Form1 : Form
    {
        readonly Smashboy smashBoy = new Smashboy();
        readonly Hero hero = new Hero();
        readonly OrangeRicky orangeRicky = new OrangeRicky();
        readonly Teewee teewee = new Teewee();
        readonly BlueRicky blueRicky = new BlueRicky();
        readonly ClevelandZ clz = new ClevelandZ();
        readonly RhodeIslandZ riz = new RhodeIslandZ();

        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            Timer timer1 = new Timer();
            timer1.Interval = (1000/10);
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawAllModels(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            riz.Movement();
            hero.Movement();

            pictureBox1.Invalidate(); 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {}
        private void DrawAllModels(PaintEventArgs e)
        {
            //teewee 
            //orangeRicky
            //smashboy

            //smashBoy.Draw(e);
            //hero.Draw(e);
            //orangeRicky.Draw(e);
            //teewee.Draw(e);
            //blueRicky.Draw(e);
            //clz.Draw(e);
            //riz.Draw(e);
        }
    }
}
