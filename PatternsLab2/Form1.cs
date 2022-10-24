using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace PatternsLab2
{
    public partial class Form1 : Form
    {
        Graphics g1, g2;
        DrawBySVG SVG = new DrawBySVG();
        GraphicsState grState1, grState2;
        ICurve curCurve;

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
            grState1 = g1.Save();
            grState2 = g2.Save();

            Random rnd = new Random();
            Point startPoint, endPoint, controlPoint1, controlPoint2;

            startPoint = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
            endPoint = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
            controlPoint1 = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
            controlPoint2 = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));

            curCurve = new Bezier(startPoint, endPoint, controlPoint1, controlPoint2);

            new VisualCurve(curCurve, new DrawByGraphicsStyle1(g1, 3)).Draw(1000);
            new VisualCurve(curCurve, new DrawByGraphicsStyle2(g2, 3)).Draw(50);
            new VisualCurve(curCurve, SVG).Draw(50);

            //new VisualCurve(new FragmentDecorator(curCurve, 0.5, 0.7), new DrawByGraphicsStyle1(g1, 3)).Draw(1000);
            //new VisualCurve(new MoveToDecorator(curCurve, new Point(0, 0)), new DrawByGraphicsStyle1(g1, 3)).Draw(1000);

            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string filename = "VisualCurve.svg";
            string result = SVG.GetResult();
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.Write(result);
            }
            MessageBox.Show("Файл успешно сохранен!");
        }
    }
}
