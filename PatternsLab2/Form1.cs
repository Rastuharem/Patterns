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
        CommandManager CM = CommandManager.GetInstance();
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

            new InitCommand(AllCurves, g1, g2, SVG).Ecexute();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonEnabler++;
            EnablingButtonsCheck();

            Random rnd = new Random();
            Point startPoint, endPoint, controlPoint1, controlPoint2;

            startPoint = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
            endPoint = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
            controlPoint1 = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
            controlPoint2 = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));

            curCurve = new Bezier(startPoint, endPoint, controlPoint1, controlPoint2);

            new AddCommand(curCurve, AllCurves, g1, g2, SVG).Ecexute();

            RefreshCount();
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
            ICurve reversedCurve = new FragmentDecorator(AllCurves[AllCurves.Count - 1], 1, 0);
            new ChangeCommand(reversedCurve, AllCurves, g1, g2, SVG).Ecexute();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ICurve movedCurve = new MoveToDecorator(AllCurves[AllCurves.Count - 1], new Point(0, 0));
            new ChangeCommand(movedCurve, AllCurves, g1, g2, SVG).Ecexute();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            AllCurves[AllCurves.Count - 2].GetPoint(1, out IPoint whereToMoveDot);
            ICurve movingCurve = new MoveToDecorator(AllCurves[AllCurves.Count - 1], whereToMoveDot);
            new ChangeCommand(movingCurve, AllCurves, g1, g2, SVG).Ecexute();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            ButtonEnabler++;
            EnablingButtonsCheck();

            Random rnd = new Random();
            List<ICurve> Curves = new List<ICurve>();

            for (int i = 0; i < 3; i++)
            {
                IPoint startPoint = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
                IPoint endPoint = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
                IPoint controlPoint1 = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
                IPoint controlPoint2 = new Point(rnd.Next(-pictureBox1.Width / 2, pictureBox1.Width / 2), rnd.Next(-pictureBox1.Height / 2, pictureBox1.Height / 2));
                Curves.Add(new Bezier(startPoint, endPoint, controlPoint1, controlPoint2));
            }
            new AddCommand(new CurveChain(Curves), AllCurves, g1, g2, SVG).Ecexute();

            RefreshCount();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            UndoOperation();
        }

        private void EnablingButtonsCheck()
        {
            if (ButtonEnabler >= 1)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button8.Enabled = true;
            }
            if (ButtonEnabler >= 2)
            {
                button6.Enabled = true;
            }
            if (ButtonEnabler == 0)
            {
                button8.Enabled = false;
            }
        }
        private void RefreshCount()
        {
            int count = 0;
            foreach (var curve in AllCurves)
            {
                curve.Iterate(i => count++);
            }
            textBox1.Text = "Текущее кол-во прямых = " + count.ToString();
        }
        private void UndoOperation()
        {
            if (CM.GetCommands()[CM.GetCommands().Count - 1] is AddCommand)
            {
                ButtonEnabler--;
                EnablingButtonsCheck();
            }
            CM.Undo();
        }
    }
}