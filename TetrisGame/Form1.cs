using Models;
using Models.Factory;
using System;
using System.Collections.Generic;
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
            Timer frameRefreshTimer = new Timer
            {
                Interval = 1000 / 10
            };
            frameRefreshTimer.Tick += frameRefreshTimer_Tick;
            frameRefreshTimer.Start();

            Timer respawnShapeTimer = new Timer();
            respawnShapeTimer.Interval = 5000 / 10;
            respawnShapeTimer.Tick += respawnShapeTimer_Tick;
            respawnShapeTimer.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(e);
                shapes.Pop();
            }
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
    }
}
