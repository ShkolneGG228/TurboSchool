using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation
{
    public partial class Form1 : Form
    {
        List<Snow> snowsmall = new List<Snow>();
        List<Snow> snowsmiddle = new List<Snow>();
        List<Snow> snowslarge = new List<Snow>();
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DoubleBuffered = true;
            Graphics g = this.CreateGraphics();
            Brush vr = new SolidBrush(Color.FromArgb(255, 32, 32, 32));
            g.FillRectangle(vr, 0, 0, this.Width, this.Height);

        }

        public void DrawSnowMiddle()
        {
            for (int i = 0; i < rnd.Next(1, 7); i++)
            {
                int raduis = rnd.Next(4, 15);
                int speed = raduis;
                int x = rnd.Next(0, this.Width);
                int y = rnd.Next(-this.Height*3, -this.Height);
                snowsmiddle.Add(new Snow(speed, raduis, x, y));
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           DrawSnowMiddle();
        }
        int time = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Graphics G = this.CreateGraphics();
            G.Clear(Color.FromArgb(255, 140, 140, 140));
            //вставить сюда отрисовку дома !!!!!!!!!!!!!!!!!!!!!!!!!!
            G.FillRectangle(Brushes.LightGray, 250, this.Height-300, 300, 200);
            time++;

            if (time % 3 == 0) { DrawSnowMiddle(); }
            for(int i = 0; i < snowsmiddle.Count; i++)
            {
                DoubleBuffered = true;
                snowsmiddle[i].Y += snowsmiddle[i].Speed;
                G.FillEllipse(Brushes.White, snowsmiddle[i].X, snowsmiddle[i].Y, snowsmiddle[i].Raduis, snowsmiddle[i].Raduis);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(snowsmiddle.Count);
            for(int i = 0; i < snowsmiddle.Count; i++)
            {
                if (snowsmiddle[i].Y > this.Height) { snowsmiddle.RemoveAt(i);i--; }
            }
        }

    }
}
