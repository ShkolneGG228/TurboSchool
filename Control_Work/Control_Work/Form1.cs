using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Drawing.Drawing2D;

namespace Control_Work
{
    public partial class Form1 : Form
    {
        public int score;
        Font text;float size;FontFamily currentfont;
        FontFamily[] family = FontFamily.Families;
        public Form1()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = 200;
            timer.Tick += (sender, e) =>
            {
                text = new Font(currentfont,size);
                label9.Font = text;
                if (checkBox1.Checked) text = new Font(label9.Font, FontStyle.Bold);
                if (checkBox2.Checked) text = new Font(label9.Font, FontStyle.Underline);
                if (checkBox1.Checked && checkBox2.Checked) text = new Font(label9.Font, FontStyle.Underline | FontStyle.Bold);
                label9.Font = text;
            };
            timer.Start();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(204, 55, 55);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(22,22,22);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(22, 22, 22);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(FontFamily font in family)
            {
                comboBox1.Items.Add(font.GetName(1).ToString());
            }
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 10;
            label9.Font = text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentfont = family[comboBox1.SelectedIndex]; 
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = float.Parse(comboBox2.SelectedItem.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label9.Text = textBox1.Text;
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = tabPage2.CreateGraphics();
            g.FillEllipse(Brushes.Blue, tabPage2.Width / 2-250, tabPage2.Height / 2-250, 500, 500);
            g.FillRectangle(Brushes.DimGray, tabPage2.Width / 2+30, tabPage2.Height / 2 - 60, 600, 120);
            Point[] p = new Point[3];
            p[0].X = tabPage2.Width / 2+30;
            p[0].Y = tabPage2.Height / 2-120;
            p[1].X = tabPage2.Width / 2+30;
            p[1].Y = tabPage2.Height / 2 +120;
            p[2].X = tabPage2.Width / 2-100;
            p[2].Y = tabPage2.Height / 2;
            g.FillPolygon(Brushes.DimGray, p);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string status="asdsad";
            if (radioButton2.Checked) { score++; }
            if (radioButton6.Checked) { score++; }
            if (radioButton8.Checked) { score++; }
            if (radioButton12.Checked) { score++; }
            if (radioButton21.Checked) { score++; }
            if (radioButton18.Checked) { score++; }
            if (radioButton13.Checked) { score++; }
            if (checkBox3.Checked) { score++; }
            if (checkBox5.Checked) { score++; }
            if (checkBox7.Checked) { score++; }
            if (checkBox4.Checked) { score--; }
            if (checkBox6.Checked) { score--; }
            if (checkBox8.Checked) { score--; }
            //
            if (checkBox14.Checked) { score++; }
            if (checkBox11.Checked) { score++; }
            if (checkBox12.Checked) { score--; }
            if (checkBox10.Checked) { score--; }
            if (checkBox16.Checked) { score++; }
            if (checkBox17.Checked) { score++; }
            if (checkBox20.Checked) { score--; }
            if (checkBox18.Checked) { score--; }
            if (checkBox19.Checked) { score--; }
            if (checkBox15.Checked) { score--; }

            switch (score)
            {
                case 5:
                case 6:
                case 7:
                    {
                        status = "Стоит еще подучить";
                    }break;

                case 8:
                case 9:
                case 10:
                case 11:
                    {
                        status = "Хорошо";
                    }break;

                case 12:
                case 13:
                case 14:
                    {
                        status = "Отлично";
                    }break;
                default:
                    {
                        status = "Плохо";
                    }break;
            }


            MessageBox.Show(status+", "+score+"/14");
            score = 0;
        }

        public void button4_Click(object sender, EventArgs e)
        {
            score = 0;
            foreach (RadioButton RB in panel6.Controls.OfType<RadioButton>())
            {
                RB.Checked = false;
            }
            foreach (RadioButton RB in panel7.Controls.OfType<RadioButton>())
            {
                RB.Checked = false;
            }
            foreach (RadioButton RB in panel8.Controls.OfType<RadioButton>())
            {
                RB.Checked = false;
            }
            foreach (RadioButton RB in panel9.Controls.OfType<RadioButton>())
            {
                RB.Checked = false;
            }
            foreach (CheckBox RB in panel10.Controls.OfType<CheckBox>())//
            {
                RB.Checked = false;
            }
            foreach (RadioButton RB in panel11.Controls.OfType<RadioButton>())
            {
                RB.Checked = false;
            }
            foreach (CheckBox RB in panel12.Controls.OfType<CheckBox>())//
            {
                RB.Checked = false;
            }
            foreach (CheckBox RB in panel13.Controls.OfType<CheckBox>())//
            {
                RB.Checked = false;
            }
            foreach (RadioButton RB in panel14.Controls.OfType<RadioButton>())
            {
                RB.Checked = false;
            }
            foreach (RadioButton RB in panel15.Controls.OfType<RadioButton>())
            {
                RB.Checked = false;
            }
            tabControl2.SelectedTab = tabPage4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
