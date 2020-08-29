using Enums;
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
    //Investigate if decorator will help me
    //TODO : Calculate shape's _width , _height Correctly;

    public partial class Form1 : Form
    {
        Shape shape;
        List<Shape> shapes = new List<Shape>();

        public Form1()
        {
            InitializeComponent();
            shape = ShapeFactory.CreateRandomShape();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            InitializeTimers();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            DrawGridSystem(e);
            //var shape = ShapeFactory.CreateRandomShape();
            //var shapeTop = shape.GetTop();
            //var shapeBottom = shape.GetBottom();
            //Graphics g = e.Graphics;
            //SolidBrush b = new SolidBrush(Color.Yellow);
            //var p1 = new Point(shapeBottom);
            //var p2 = new Point(shapeTop);
            //g.DrawLine(new Pen(b), p1, p2);
            shape.Draw(e);
            shapes.ForEach(shape => shape.Draw(e));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            shape.Move(e);
        }

        private void respawnShapeTimer_Tick(object sender, EventArgs e)
        {
            if (shape.IsCollidingPictureBoxBottom(pictureBox1.Bottom) ||
                shape.IsCollidingAnotherShape(shapes))
            {
                shape.OnShapeMovement(Direction.Down, State.Idle);
                shapes.Add(shape);
                shape.NextShape = ShapeFactory.CreateRandomShape();
                shape = shape.NextShape;
            }
            else
            {
                shape.OnShapeMovement(Direction.Down, State.Active);
            }
            pictureBox1.Invalidate();
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
