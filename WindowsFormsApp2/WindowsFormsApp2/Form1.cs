using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Random rand;
        Graphics g;
        Pen myPenB;
        Pen myPenG;
        SolidBrush myBrush;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            myPenB = new Pen(Color.Black);
            myPenG = new Pen(Color.DarkGreen);
            myBrush = new SolidBrush(Color.Black);
            rand = new Random();
            //DrawFilledSquare(10, 10, 900);
            DrawLine(new Point(1250, 1350), 250, Math.PI * 1.5);
            //drawPolarStuff();
        }

        //Sierpinski carpet alt
        private void DrawSquare(float x, float y, float length)
        {
            g.DrawRectangle(myPenB, x, y, length, length);
            if (length > 20)
            {
                float offset = length / 3;
                DrawSquare(x, y, offset - 1);
                DrawSquare(x + offset, y, offset - 1);
                DrawSquare(x + 2 * offset, y, offset - 1);
                DrawSquare(x, y + offset, offset - 1);
                DrawSquare(x + 2 * offset, y + offset, offset - 1);
                DrawSquare(x, y + 2 * offset, offset - 1);
                DrawSquare(x + offset, y + 2 * offset, offset - 1);
                DrawSquare(x + 2 * offset, y + 2 * offset, offset - 1);
            }
        }

        //Sierpinski carpet
        private void DrawFilledSquare(int x, int y, int length)
        {
            int offset = length / 3;
            g.FillRectangle(myBrush, x+offset, y+offset, offset, offset);
            if (length > 11)
            {
                DrawFilledSquare(x,               y,               offset);
                DrawFilledSquare(x + offset,      y,               offset);
                DrawFilledSquare(x + 2 * offset,  y,               offset);
                DrawFilledSquare(x,               y + offset,      offset);
                DrawFilledSquare(x + 2 * offset,  y + offset,      offset);
                DrawFilledSquare(x,               y + 2 * offset,  offset);
                DrawFilledSquare(x + offset,      y + 2 * offset,  offset);
                DrawFilledSquare(x + 2 * offset,  y + 2 * offset,  offset);
            }
        }



        private int Factorial(int number)
        {
            if (number == 1)
                return 1;
            return number * (Factorial(number - 1));
        }

        private void DrawLine(Point start, float length, double angle)
        {
            var x = length * Math.Cos(angle);
            var y = length * Math.Sin(angle);

            var cond = rand.Next(1, 10);
            if (length < 10)
                return;

            g.DrawLine(length < 30 ? myPenG : myPenB, start.X, start.Y, start.X + (float)x, start.Y + (float)y);
            if (length > 4)
            {
                DrawLine(new Point((int)(start.X + x), (int)(start.Y + y)), length * (3f / 4f), angle - Math.PI / 8);
                DrawLine(new Point((int)(start.X + x), (int)(start.Y + y)), length * (3f / 4f), angle + Math.PI / 8);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }

        private void drawPolarStuff()
        {
            for (double theta = 0; theta < 360; theta = theta + 0.1)
            {
                drawPolarPoint(theta, theta + 0.1, 1 / (Math.Sin(theta) * Math.Cos(theta)));
            }
        }

        private void drawPolarPoint(double angle, double angle2, double radius)
        {
            var x = radius * Math.Cos(angle);
            var y = radius * Math.Sin(angle);
            var x2 = radius * Math.Cos(angle2);
            var y2 = radius * Math.Sin(angle2);

            g.DrawLine(myPenB, (float)(1200 + x), (float)(600 + y), (float)(1200 + x2), (float)(600 + y2));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drawPolarStuff();
        }
    }
}
