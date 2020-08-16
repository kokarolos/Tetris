using Models;
using Models.Concrete;
using Models.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TetrisGame
{
    //Done : All models are drawn correctly;
    //Randomly Respawning Shape objects;
    //Factory Method implemented;


    //TODO : Hard Refactor : -> kinda done
    //Select and 
    //Refactor 19-25 lns
    //TODO : Movement fix

    public partial class Form1 : Form
    {
        //Lifo 
        Stack<Shape> shapes;
        public Form1()
        {
            InitializeComponent();
            shapes = CreateInitialShapeStack();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            InitializeTimers();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var shape = shapes.Pop();
            shape.Draw(e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void DrawAllModels(PaintEventArgs e)
        {
            //For testing purposes;
        }

        private void respawnShapeTimer_Tick(object sender, EventArgs e)
        {
            pictureBox1_Paint(sender, e as PaintEventArgs);
        }

        private Stack<Shape> CreateInitialShapeStack()
        {
            shapes = new Stack<Shape>();
            for (int i = 0; i < 5; i++)
            {
                shapes.Push(ShapeFactory.Create());
            }
            return shapes;
        }

        private void frameRefreshTimer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void InitializeTimers()
        {
            Timer frameRefreshTimer = new Timer
            {
                Interval = Settings.RefreshRate
            };
            frameRefreshTimer.Tick += frameRefreshTimer_Tick;
            frameRefreshTimer.Start();

            Timer respawnShapeTimer = new Timer
            {
                Interval = Settings.RespawnRate
            };
            respawnShapeTimer.Tick += respawnShapeTimer_Tick;
            respawnShapeTimer.Start();
        }
    }
}
