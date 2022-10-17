using System;
using System.Drawing;
using System.Windows.Forms;

namespace PatternsLab2
{
    public partial class Form1 : Form
    {
        Graphics g1, g2;

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
            Random rnd = new Random();
            Point startPoint, endPoint, controlPoint1, controlPoint2;

            startPoint = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
            endPoint = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
            controlPoint1 = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
            controlPoint2 = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));

            Bezier curve = new Bezier(startPoint, endPoint, controlPoint1, controlPoint2);

            new VisualCurve(curve, new DrawByGraphicsStyle1(g1, 3)).Draw(1000);
            new VisualCurve(curve, new DrawByGraphicsStyle2(g2, 3)).Draw(50);

            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
