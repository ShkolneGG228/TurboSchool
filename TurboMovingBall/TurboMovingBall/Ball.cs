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
    public class Ball:System.Windows.Forms.Control
    {
        PictureBox picbox = new PictureBox();
        int speedX;
        int speedY;
        bool isMoving;
        bool isToLeft;
        bool isToTop;

        public Ball() { }
        public Ball(int SpeedX,int SpeedY,bool IsMoving,bool IsToLeft,bool IsToTop,PictureBox Picbox)
        {
            speedX = SpeedX;speedY = SpeedY;isMoving = IsMoving;isToLeft = IsToLeft;isToTop = IsToTop;picbox = Picbox;
        }
        public PictureBox Picbox
        {
            set { picbox = value; }
            get { return picbox; }
        }
        public int SpeedX
        {
            set { speedX = value; }
            get { return speedX; }
        }
        public int SpeedY
        {
            set { speedY = value; }
            get { return speedY; }
        }
        public bool IsMoving
        {
            set { isMoving = value; }
            get { return isMoving; }
        }
        public bool IsToLeft
        {
            set { isToLeft = value; }
            get { return isToLeft; }
        }
        public bool IsToTop
        {
            set { isToTop = value; }
            get { return isToTop; }
        }

        /*private void timer1_Tick(object sender, EventArgs e)
        {
            picbox.Left += speedX;
            picbox.Top += speedY;
            if (picbox.Location.X > 320 - 32)
            {
                speedX *= -1;
                IsToLeft = true;
            }
            if (picbox.Location.X < 0) { speedX *= -1; IsToLeft = false; }

            if (picbox.Location.Y > 320 - 32)
            {
                speedY *= -1;
                IsToTop = true;
            }
            if (picbox.Location.Y < 0) { speedY *= -1; IsToTop = false; }
        }*/

        public void ini(Panel fm)
        {
            Random rnd = new Random();
            int sw = rnd.Next(1, 4);
            picbox.BackColor = Color.Transparent;

            switch (sw)
            {
                case 1:
                    {
                        picbox.Image = Properties.Resources.red;
                    }
                    break;

                case 2:
                    {
                        picbox.Image = Properties.Resources.blue;
                    }
                    break;

                case 3:
                    {
                        picbox.Image = Properties.Resources.green;
                    }
                    break;
            }
            picbox.Location = new Point(rnd.Next(50,fm.Width-50), rnd.Next(50,fm.Height-50));
            picbox.Name = "Picbox";
            picbox.Size = new Size(32, 32);
            picbox.TabIndex = 0;
            picbox.TabStop = false;
            picbox.Parent = fm;
            System.Drawing.Drawing2D.GraphicsPath gp = BuildTransparencyPath(picbox.Image);
            picbox.Region = new Region(gp);
        }

        public static System.Drawing.Drawing2D.GraphicsPath BuildTransparencyPath(Image im)
        {
            int x;
            int y;
            Bitmap bmp = new Bitmap(im);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            Color mask = bmp.GetPixel(0, 0);

            for (x = 0; x <= bmp.Width - 1; x++)
            {
                for (y = 0; y <= bmp.Height - 1; y++)
                {
                    if (!bmp.GetPixel(x, y).Equals(mask))
                    {
                        
                        gp.AddRectangle(new Rectangle(x, y, 1, 1));
                    }
                }
            }
            bmp.Dispose();
            return gp;
        }
    }
}
