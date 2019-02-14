using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsPhotoViewer
{
    public partial class Form1 : Form
    {
        int H=0, W=0;
        int Hdown = 0, Wdown = 0;
        double pers=1;
        int Hcon, Wcon;
        string filename;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void OpenFile()
        {
            if(openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            filename = openFileDialog1.FileName;
            H = Image.FromFile(filename).Height;
            W = Image.FromFile(filename).Width;

            SizePic();
            pictureBox1.Image = Image.FromFile(filename);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Hcon = pictureBox1.Height;
            Wcon = pictureBox1.Width;
            H = Hcon;W = Wcon;
            SizeStLab.Text ="Исходный размер: "+ Image.FromFile(filename).Width.ToString() + " x " + Image.FromFile(filename).Height.ToString();
            PathStLab.Text = filename;


            SaveAsItem.Enabled = true;
            CloseItem.Enabled = true;
            SaveBtn.Enabled = true;
            DelBtn.Enabled = true;

            Normal.Enabled = false;
            Half.Enabled = true;
            Double.Enabled = true;

            NormalButton.Enabled = false;
            HalfButton.Enabled = true;
            DoubleButton.Enabled = true;

            NormalBtnCtx.Enabled = false;
            HalflBtnCtx.Enabled = true;
            DoubleBtnCtx.Enabled = true;

        }

        private void HalfSize()
        {
            H = Hcon / 2;
            W = Wcon / 2;
            SizePic();
        }

        private void AllSize()
        {
            W = Wcon;
            H = Hcon;
            SizePic();
        }
        private void DoubleSize()
        {
            W =Wcon* 2;H =Hcon* 2;
            SizePic();
        }

        private void SizePic()
        {
            
            pers = 1;
            if (W > panel1.Width || H>panel1.Height)
            {
                pictureBox1.Location = new Point(0, 0);
                if (W>panel1.Width) { pers = (double)panel1.Width / W; }
                
                if (H > panel1.Height) { pers = (double)panel1.Height / H; }
            }
            else { pictureBox1.Location = new Point(panel1.Width / 2 - W / 2, panel1.Height / 2 - H / 2); }
            
            NewSize.Text = pers.ToString();
            
            pictureBox1.Height = Convert.ToInt32(H * pers);
            pictureBox1.Width = Convert.ToInt32(W * pers);

            /*H = pictureBox1.Height;
            W = pictureBox1.Width;*/

            NewSize.Text = "Масштабированный размер : "+ pictureBox1.Width.ToString() + " x " + pictureBox1.Height.ToString();

        }

        private void SaveFile()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                Hdown = pictureBox1.Height;Wdown = pictureBox1.Width;
                Image img = ResizeImage(pictureBox1.Image, Wdown, Hdown);
                img.Save(saveFileDialog1.FileName);
            }
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void PicBtn_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void DeleteImage()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            SaveAsItem.Enabled = false;
            CloseItem.Enabled = false;
            SaveBtn.Enabled = false;
            DelBtn.Enabled = false;

            NormalButton.Enabled = false;
            HalfButton.Enabled = false;
            DoubleButton.Enabled = false;

            NormalBtnCtx.Enabled = false;
            HalflBtnCtx.Enabled = false;
            DoubleBtnCtx.Enabled = false;

            Half.Enabled = false;
            Normal.Enabled = false;
            Double.Enabled = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DeleteImage();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm newform = new AboutForm();
            newform.Show();
        }

        private void StrokaSostItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Enabled = !statusStrip1.Enabled;
            statusStrip1.Visible = !statusStrip1.Visible;
            StrokaSostItem.Checked =! StrokaSostItem.Checked;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            NewSize.Text = Convert.ToInt32(pictureBox1.Width) + " x " + Convert.ToInt32(pictureBox1.Height);
            SizePic();
        }

        private void PanelItem_Click(object sender, EventArgs e)
        {
            toolStrip1.Enabled = !toolStrip1.Enabled;
            toolStrip1.Visible = !toolStrip1.Visible;
            PanelItem.Checked = !PanelItem.Checked;
        }

        private void HalfSizeBtn_Click(object sender, EventArgs e)
        {
            HalfSize();
            Normal.Enabled = true;
            Half.Enabled = false;
            Double.Enabled = true;

            NormalButton.Enabled = true;
            HalfButton.Enabled = false;
            DoubleButton.Enabled = true;

            NormalBtnCtx.Enabled = true;
            HalflBtnCtx.Enabled = false;
            DoubleBtnCtx.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AllSize();
            Normal.Enabled = false;
            Half.Enabled = true;
            Double.Enabled = true;

            NormalButton.Enabled = false;
            HalfButton.Enabled = true;
            DoubleButton.Enabled = true;

            NormalBtnCtx.Enabled = false;
            HalflBtnCtx.Enabled = true;
            DoubleBtnCtx.Enabled = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DoubleSize();
            Normal.Enabled = true;
            Half.Enabled = true;
            Double.Enabled = false;

            NormalButton.Enabled = true;
            HalfButton.Enabled = true;
            DoubleButton.Enabled = false;

            NormalBtnCtx.Enabled = true;
            HalflBtnCtx.Enabled = true;
            DoubleBtnCtx.Enabled = false;
        }

        private void CloseItem_Click(object sender, EventArgs e)
        {
            DeleteImage();
            NormalButton.Enabled = false;
            HalfButton.Enabled = false;
            DoubleButton.Enabled = false;

            NormalBtnCtx.Enabled = false;
            HalflBtnCtx.Enabled = false;
            DoubleBtnCtx.Enabled = false;

            Half.Enabled = false;
            Normal.Enabled = false;
            Double.Enabled = false;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Point p = Cursor.Position; contextMenuStrip1.Show(p);}
        }

        private void HalfButton_Click(object sender, EventArgs e)
        {
            HalfSizeBtn_Click(sender, e);
        }

        private void NormalButton_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }

        private void HalflBtnCtx_Click(object sender, EventArgs e)
        {
            HalfSizeBtn_Click(sender, e);
        }

        private void NormalBtnCtx_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }

        private void DoubleBtnCtx_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }

        private void SaveAsItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void DoubleButton_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }

        private void Exit()
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены?",
                "Сообщение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result== DialogResult.Yes) { Application.Exit(); }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }
    }
}
