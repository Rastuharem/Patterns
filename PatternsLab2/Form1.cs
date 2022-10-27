using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PatternsLab2
{
    public partial class Form1 : Form
    {
        Graphics g1, g2;
        DrawBySVG SVG = new DrawBySVG();
        ICurve curCurve;
        List<ICurve> AllCurves = new List<ICurve>();
        int ButtonEnabler = 0;

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g1 = pictureBox1.CreateGraphics();
            g1.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
            g1.ScaleTransform(1, -1);

            g2 = pictureBox2.CreateGraphics();
            g2.TranslateTransform(pictureBox2.Width / 2, pictureBox2.Height / 2);
            g2.ScaleTransform(1, -1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonEnabler++;

            Random rnd = new Random();
            Point startPoint, endPoint, controlPoint1, controlPoint2;

            startPoint = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
            endPoint = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
            controlPoint1 = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
            controlPoint2 = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));

            curCurve = new Bezier(startPoint, endPoint, controlPoint1, controlPoint2);
            AllCurves.Add(curCurve);

            new VisualCurve(curCurve, new DrawByGraphicsStyle1(g1, 3)).Draw(1000);
            new VisualCurve(curCurve, new DrawByGraphicsStyle2(g2, 3)).Draw(50);
            new VisualCurve(curCurve, SVG).Draw(50);

            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            if (ButtonEnabler >= 2)
            {
                button6.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string filename = "VisualCurve.svg";
            string result = SVG.GetResult();
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.Write(result);
            }
            MessageBox.Show("Файл успешно сохранен!");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            g2.Clear(Color.White);

            for (int i = 0; i < AllCurves.Count-1; i++)
            {
                new VisualCurve(AllCurves[i], new DrawByGraphicsStyle1(g1, 3)).Draw(1000);
                new VisualCurve(AllCurves[i], new DrawByGraphicsStyle2(g2, 3)).Draw(50);
            }

            ICurve reversedCurve = new FragmentDecorator(AllCurves[AllCurves.Count - 1], 1, 0);
            new VisualCurve(reversedCurve, new DrawByGraphicsStyle1(g1, 3)).Draw(1000);
            new VisualCurve(reversedCurve, new DrawByGraphicsStyle2(g2, 3)).Draw(50);

            AllCurves[AllCurves.Count - 1] = reversedCurve;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            g2.Clear(Color.White);

            for (int i = 0; i < AllCurves.Count - 1; i++)
            {
                new VisualCurve(AllCurves[i], new DrawByGraphicsStyle1(g1, 3)).Draw(1000);
                new VisualCurve(AllCurves[i], new DrawByGraphicsStyle2(g2, 3)).Draw(50);
            }

            ICurve movedCurve = new MoveToDecorator(AllCurves[AllCurves.Count - 1], new Point(0, 0));
            new VisualCurve(movedCurve, new DrawByGraphicsStyle1(g1, 3)).Draw(1000);
            new VisualCurve(movedCurve, new DrawByGraphicsStyle2(g2, 3)).Draw(50);

            AllCurves[AllCurves.Count - 1] = movedCurve;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            g2.Clear(Color.White);

            for (int i = 0; i < AllCurves.Count - 1; i++)
            {
                new VisualCurve(AllCurves[i], new DrawByGraphicsStyle1(g1, 3)).Draw(1000);
                new VisualCurve(AllCurves[i], new DrawByGraphicsStyle2(g2, 3)).Draw(50);
            }

            AllCurves[AllCurves.Count - 2].GetPoint(1, out IPoint whereToMoveDot);
            ICurve movingCurve = new MoveToDecorator(AllCurves[AllCurves.Count - 1], whereToMoveDot);
            new VisualCurve(movingCurve, new DrawByGraphicsStyle1(g1, 3)).Draw(1000);
            new VisualCurve(movingCurve, new DrawByGraphicsStyle2(g2, 3)).Draw(50);

            AllCurves[AllCurves.Count - 1] = movingCurve;
        }
    }
}
