using Models;
using Models.Concrete;
using Models.Factory;
using System;
using System.Windows.Forms;

namespace TetrisGame
{
    //Done : All models are drawn correctly;


    //TODO : Hard Refactor :
    // Fix inheritance ripple effect -> rectangle -> to all conrete classes
    // favor composition over inheritance, example. BlueRicky has rectangle not is a rectangle.
    // TODO 2 : Create Factory so i can generate every 5 sec new shapes 
    // TODO fix some shapes movement as they dont move 
    //TODO bluericky bug
    //TODO :Fix bug of clz
    //Refactor 19-25 lns
    //TODO : Movement fix

    public partial class Form1 : Form
    {

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
            Shape randomShape = ShapeFactory.Create();
            randomShape.Draw(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate(); 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void DrawAllModels(PaintEventArgs e)
        {
            //For testing purposes;
        }

    }
}
