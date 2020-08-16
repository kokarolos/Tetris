using Models;
using Models.Concrete;
using Models.Factory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisGame
{
    //TODO : Movement fix
    //TODO: Fix shape respawn time -> Set it to 10 sec
    //TODO Fix Grid System 


    public partial class Form1 : Form
    {
        Stack<Shape> shapes;
        List<Shape> usedShapes = new List<Shape>();
        public Form1()
        {
            InitializeComponent();
            shapes = CreateInitialShapeStack();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            InitializeTimers();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //DrawGridSystem(e);
            //var shape = shapes.Pop();
            //usedShapes.Add(shape);
            //shape.Draw(e);
            //frameRefreshTimer_Tick(sender, e, shape);

            Hero h = new Hero();
            h.Draw(e);
            respawnShapeTimer_Tick(sender, e, h);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                //Move x += 10;
                //if(x >= Window Width - 100){
                //  x= window width - 100
                //}

            }
            if(e.KeyData == Keys.Left)
            {
                // Move x-= 10;
            }
        }
        private void respawnShapeTimer_Tick(object sender, EventArgs e)
        {

        }

        private void respawnShapeTimer_Tick(object sender, EventArgs e,Shape s)
        {
            pictureBox1.Invalidate();
            s.Move(e as KeyEventArgs);
        }
        private void frameRefreshTimer_Tick(object sender, EventArgs e)
        {

        } 

        private void frameRefreshTimer_Tick(object sender, EventArgs e,Shape s)
        {
            s.Move(e as KeyEventArgs);
        }

        private Stack<Shape> CreateInitialShapeStack()
        {
            shapes = new Stack<Shape>();
            for (int i = 0; i < 50; i++)
            {
                shapes.Push(ShapeFactory.Create());
            }
            return shapes;
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
        private void DrawGridSystem(PaintEventArgs e)
        {
            var numOfCells = Settings.NumOfCells;
            var cellSize = Settings.CellSize;
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.White);

            for (var i = 0; i < numOfCells; ++i)
            {
                g.DrawLine(p, 0, i * cellSize, numOfCells * cellSize, i * cellSize);
            }
            for (var x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }
    }
}
