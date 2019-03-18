using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiTabControl
{
    public partial class Form1 : Form
    {
        RadioButton[][] radioButtons;
        TabControl tb;
        public Form1()
        {
            InitializeComponent();

            this.Text = "Multi TabControl";
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            tb = new TabControl();
            tb.Dock = DockStyle.Fill;

            TabPage[] tabPages = new TabPage[3];

             radioButtons = new RadioButton[][]
            {
                new RadioButton[]{new RadioButton(), new RadioButton(), new RadioButton()},
                new RadioButton[]{new RadioButton(), new RadioButton(), new RadioButton()},
                new RadioButton[]{new RadioButton(), new RadioButton(), new RadioButton()}
            };

            string[][] radioButtonsText = new string[][]
            {
                new string[]{"2005", "2000", "2003"},
                new string[]{"Первый вариант ответа(правильный)", "Второй вариант ответа", "Третий вариант ответа"},
                new string[]{"Первый вариант ответа", "Второй вариант ответа", "Третий вариант ответа(правильный)" }
            };
            
            string[] labelText = new string[3] {"В каком году был разработан C#?","Заголовок второго вопроса","Заголовок третьего вопроса"};

            for(int i = 0; i < 3; i++)
            {
                tabPages[i] = new TabPage("Вопрос "+(i+1));
                tabPages[i] = CreateTab(tabPages[i], labelText[i], radioButtons[i], radioButtonsText[i]);
                tb.TabPages.Add(tabPages[i]);
            }

            //кнопка результата на 3-ем tabpage
            Button endbutton = new Button
            {
                Text = "Результат!",
                Size = new Size(120, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(52, 52, 52),
                ForeColor = Color.White,
                Font = new Font("Monospace", 13, FontStyle.Italic)
            };
            endbutton.Location = new Point(this.Width/2 - endbutton.Width/2, 230);
            endbutton.Click += Endbutton_Click;
            tabPages[2].Controls.Add(endbutton);
            
            this.Controls.Add(tb);
        }

        private void Endbutton_Click(object sender, EventArgs e)
        {
            int score = 0;
            string status = "";
            if (radioButtons[0][1].Checked) { score++; }
            if (radioButtons[1][0].Checked) { score++; }
            if (radioButtons[2][2].Checked) { score++; }
            if (score != 3)
            {
                if (MessageBox.Show("Правильных ответов: " + score + " из 3\nПройти заново?", "Результат", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        foreach (RadioButton rd in radioButtons[i]) { rd.Checked = false; }
                    }
                    tb.SelectTab(0);
                    score = 0;
                }
            }
            else
            {
                MessageBox.Show("Отлично! 100% правильных ответов");
            }
        }

        private TabPage CreateTab(TabPage tab, string labelText, RadioButton[] radios, string[] radioText)
        {
            Label lb = new Label();
            lb = CreateLabel(lb, labelText);
            tab.Controls.Add(lb);

            int y = 0;
            for (int i = 0; i < 3; i++)
            {
                y += 45;
                Point p = new Point(25, 55+y);
                radios[i] = CreateRadioButton(radios[i], radioText[i], p);
                tab.Controls.Add(radios[i]);
            }

            return tab;
        }

        private RadioButton CreateRadioButton(RadioButton radio, string text, Point p)
        {
            radio.Text = text;
            radio.AutoSize = true;
            radio.Font = new Font("Monospace", 12, FontStyle.Regular);
            radio.Location = p;
            return radio;
        }

        private Label CreateLabel(Label lb, string text)
        {
            lb.Text = text;
            lb.Location = new Point(25, 25);
            lb.AutoSize = true;
            lb.MaximumSize = new Size(this.Width - 150, 30);
            
            lb.Font = new Font("Monospace", 18, FontStyle.Underline);
            return lb;
        }
    }
}
