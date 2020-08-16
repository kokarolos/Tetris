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
        public Form1()
        {
            InitializeComponent();
            shapes = CreateInitialShapeStack();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            InitializeTimers();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawGridSystem(e);
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
