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

    public partial class Form1 : Form
    {
        Shape shape;
        ShapeDecorator shapeDecorator;
        List<Shape> shapes = new List<Shape>();
        Rectangle tetris;

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
            //shape.Rotate(e); <- Fix Rotation
        }

        private void respawnShapeTimer_Tick(object sender, EventArgs e)
        {
            if (shape.IsColliding(pictureBox1.Bottom))
            {
                shape.OnShapeMovement(Direction.Down,State.Idle);
                shape.NextShape = ShapeFactory.CreateRandomShape();
                foreach (var rects in shape._rectangles)
                {
                    foreach (var nextShapeRects in shape.NextShape._rectangles)
                    {
                        tetris = Rectangle.Union(rects, nextShapeRects);
                    }
                }
                shapes.Add(shape);
            }
            else
            {
                shape.OnShapeMovement(Direction.Down,State.Active);
            }


            pictureBox1.Invalidate();
        }

        private List<Shape> CreateInitialShapes()
        {
            for (int i = 0; i < 5; i++)
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
