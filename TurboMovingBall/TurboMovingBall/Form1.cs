using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurboMovingBall
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        List<Ball> ball = new List<Ball>();
        public Form1()
        {
            InitializeComponent();
            
        }
        
        public bool IsRandom;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            for(int i = 0; i < ball.Count; i++)
            {
                ball[i].SpeedX = trackBar1.Value;
                if (ball[i].IsToLeft) { ball[i].SpeedX *= -1; }
            }        
            label3.Text = Convert.ToString(trackBar1.Value);
            //DateTime data = new DateTime();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            for(int i = 0; i < ball.Count; i++)
            {
                ball[i].SpeedY = trackBar2.Value;
                if (ball[i].IsToTop) { ball[i].SpeedY *= -1; }
            }
            label4.Text = trackBar2.Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < ball.Count; i++)
            {
                ball[i].Picbox.Left += ball[i].SpeedX;
                ball[i].Picbox.Top += ball[i].SpeedY;
                
                if (ball[i].Picbox.Location.X > panel1.Width - 32)
                {
                    ball[i].SpeedX *= -1;
                    ball[i].IsToLeft = true;
                }
                if (ball[i].Picbox.Location.X < 0) { ball[i].SpeedX *= -1; ball[i].IsToLeft = false; }

                if (ball[i].Picbox.Location.Y > panel1.Height - 32)
                {
                    ball[i].SpeedY *= -1;
                    ball[i].IsToTop = true;
                }
                
                if (ball[i].Picbox.Location.Y < 0) { ball[i].SpeedY *= -1; ball[i].IsToTop = false; }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled == true) { timer1.Stop();button1.Text = "Пуск"; }else { timer1.Start();button1.Text = "Стоп"; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ball.Add(new Ball());
            label5.Text = ball.Count.ToString();
            panel1.Controls.Add(ball[ball.Count-1]);
            ball[ball.Count-1].ini(panel1);
            if (!IsRandom)
            {
                trackBar1_Scroll(sender, e);
                trackBar2_Scroll(sender, e);
            }else
            {
                ball[ball.Count - 1].SpeedX = rnd.Next(1, 10);
                ball[ball.Count - 1].SpeedY = rnd.Next(1, 10);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*trackBar1_Scroll(sender,e);
            trackBar2_Scroll(sender, e);*/
            button3_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ball.Count > 0)
            {
                int at = rnd.Next(0, ball.Count);
                ball[at].Picbox.Dispose();
                ball.RemoveAt(at);
            }
            
            label5.Text = Convert.ToString(ball.Count);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < ball.Count; i++)
            {
                ball[i].SpeedX = rnd.Next(1, 10);
                ball[i].SpeedY = rnd.Next(1, 10);
            }
            label3.Text = "скорость на каждом шаре рандомная";
            label4.Text = "скорость на каждом шаре рандомная";
            IsRandom = true;
        }
    }
}
