using System.Drawing;
using System.Windows.Forms;

namespace Control_Work.UserControls
{
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        public Image img
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }
        public string txt
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public void button1_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}
