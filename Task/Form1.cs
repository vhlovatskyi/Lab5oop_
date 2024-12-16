using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Square square = new Square(180, 90, 60);
            square.MoveRight();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Circle circle = new Circle(150, 150, 50);
            circle.MoveRight();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rhomb rhomb = new Rhomb(200, 200, 80, 100);
            rhomb.MoveRight();
        }
    }
    abstract class Figure
    {
        protected int centerX;
        protected int centerY;

        public Figure(int centerX, int centerY)
        {
            this.centerX = centerX;
            this.centerY = centerY;
        }

        public abstract void DrawBlack();

        public abstract void HideDrawingBackGround();

        public void MoveRight()
        {
            for (int i = 0; i < 50; i++)
            {
                DrawBlack();
                System.Threading.Thread.Sleep(100);
                HideDrawingBackGround();
                centerX++;
            }
        }
    }


    class Square : Figure
    {
        private int sideLength;

        public Square(int centerX, int centerY, int sideLength) : base(centerX, centerY)
        {
            this.sideLength = sideLength;
        }

        private Point[] GetCurrPoints()
        {
            int half = sideLength / 2;
            return new Point[] {
            new Point(centerX - half, centerY - half),
            new Point(centerX - half, centerY + half),
            new Point(centerX + half, centerY + half),
            new Point(centerX + half, centerY - half),
        };
        }

        public override void DrawBlack()
        {
            Graphics graphics = Form1.ActiveForm.CreateGraphics();
            graphics.DrawPolygon(Pens.Black, GetCurrPoints());
        }

        public override void HideDrawingBackGround()
        {
            Graphics graphics = Form1.ActiveForm.CreateGraphics();
            graphics.DrawPolygon(new Pen(Form1.ActiveForm.BackColor), GetCurrPoints());
        }
    }


    class Circle : Figure
    {
        private int radius;

        public Circle(int centerX, int centerY, int radius) : base(centerX, centerY)
        {
            this.radius = radius;
        }

        public override void DrawBlack()
        {
            Graphics graphics = Form1.ActiveForm.CreateGraphics();
            graphics.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, radius * 2, radius * 2);
        }

        public override void HideDrawingBackGround()
        {
            Graphics graphics = Form1.ActiveForm.CreateGraphics();
            graphics.DrawEllipse(new Pen(Form1.ActiveForm.BackColor), centerX - radius, centerY - radius, radius * 2, radius * 2);
        }
    }

    class Rhomb : Figure
    {
        private int horDiagLen;
        private int vertDiagLen;

        public Rhomb(int centerX, int centerY, int horDiagLen, int vertDiagLen) : base(centerX, centerY)
        {
            this.horDiagLen = horDiagLen;
            this.vertDiagLen = vertDiagLen;
        }

        private Point[] GetCurrPoints()
        {
            return new Point[] {
            new Point(centerX, centerY - vertDiagLen / 2),
            new Point(centerX + horDiagLen / 2, centerY),
            new Point(centerX, centerY + vertDiagLen / 2),
            new Point(centerX - horDiagLen / 2, centerY),
        };
        }

        public override void DrawBlack()
        {
            Graphics graphics = Form1.ActiveForm.CreateGraphics();
            graphics.DrawPolygon(Pens.Black, GetCurrPoints());
        }

        public override void HideDrawingBackGround()
        {
            Graphics graphics = Form1.ActiveForm.CreateGraphics();
            graphics.DrawPolygon(new Pen(Form1.ActiveForm.BackColor), GetCurrPoints());
        }
    }

    
}
