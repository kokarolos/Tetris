using Models;
using Models.Concrete;
using Models.Factory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisGame
{
    //TODO: if shape collides -> add it to ShapeDecorator to build Tetris


    public partial class Form1 : Form
    {
        //Stack<Shape> shapes;
        Shape shape;
        ShapeDecorator _shapeDecorator;
        List<Shape> shapes = new List<Shape>();

        public Form1()
        {
            InitializeComponent();
            shapes = CreateInitialShapes();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            InitializeTimers();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawGridSystem(e);
            shape.Draw(e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            shape.Move(e);
        }

        private void respawnShapeTimer_Tick(object sender, EventArgs e)
        {
           // while(shape.IsColliding(pictureBox1.Bottom))
           // {
           //     shape.OnShapeMovement(Direction.Down);
           // }
           // if (shape.IsColliding(pictureBox1.Bottom))
           // {
           //     shape = ShapeFactory.CreateRandomShape();
           // }


            pictureBox1.Invalidate();
        }

        private List<Shape> CreateInitialShapes()
        {
            //shapes = new Stack<Shape>();
            for (int i = 0; i < 1; i++)
            {
                shapes.Add(ShapeFactory.CreateRandomShape());
                shape = shapes[i];
            }
            return shapes;
        }

        private void InitializeTimers()
        {
            Timer respawnShapeTimer = new Timer
            {
                Interval = Settings.RefreshRate
            };
            respawnShapeTimer.Tick += respawnShapeTimer_Tick;
            frameRefreshTimer.Start();
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

        private void scoreLabel_Click(object sender, EventArgs e)
        {
            //ScoreLabel
        }
    }
}
