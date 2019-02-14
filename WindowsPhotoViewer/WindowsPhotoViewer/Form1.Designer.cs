namespace WindowsPhotoViewer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VidItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StrokaSostItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HalfButton = new System.Windows.Forms.ToolStripMenuItem();
            this.NormalButton = new System.Windows.Forms.ToolStripMenuItem();
            this.DoubleButton = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SaveBtn = new System.Windows.Forms.ToolStripButton();
            this.PicBtn = new System.Windows.Forms.ToolStripButton();
            this.DelBtn = new System.Windows.Forms.ToolStripButton();
            this.Half = new System.Windows.Forms.ToolStripButton();
            this.Normal = new System.Windows.Forms.ToolStripButton();
            this.Double = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SizeStLab = new System.Windows.Forms.ToolStripStatusLabel();
            this.PathStLab = new System.Windows.Forms.ToolStripStatusLabel();
            this.NewSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.HalflBtnCtx = new System.Windows.Forms.ToolStripMenuItem();
            this.NormalBtnCtx = new System.Windows.Forms.ToolStripMenuItem();
            this.DoubleBtnCtx = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileItem,
            this.VidItem,
            this.HelpItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1004, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileItem
            // 
            this.FileItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.SaveAsItem,
            this.CloseItem,
            this.выходToolStripMenuItem});
            this.FileItem.Name = "FileItem";
            this.FileItem.Size = new System.Drawing.Size(48, 20);
            this.FileItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // SaveAsItem
            // 
            this.SaveAsItem.Enabled = false;
            this.SaveAsItem.Name = "SaveAsItem";
            this.SaveAsItem.Size = new System.Drawing.Size(180, 22);
            this.SaveAsItem.Text = "Сохранить как";
            this.SaveAsItem.Click += new System.EventHandler(this.SaveAsItem_Click);
            // 
            // CloseItem
            // 
            this.CloseItem.Enabled = false;
            this.CloseItem.Name = "CloseItem";
            this.CloseItem.Size = new System.Drawing.Size(153, 22);
            this.CloseItem.Text = "Закрыть";
            this.CloseItem.Click += new System.EventHandler(this.CloseItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // VidItem
            // 
            this.VidItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StrokaSostItem,
            this.PanelItem,
            this.HalfButton,
            this.NormalButton,
            this.DoubleButton});
            this.VidItem.Name = "VidItem";
            this.VidItem.Size = new System.Drawing.Size(39, 20);
            this.VidItem.Text = "Вид";
            // 
            // StrokaSostItem
            // 
            this.StrokaSostItem.Checked = true;
            this.StrokaSostItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StrokaSostItem.Name = "StrokaSostItem";
            this.StrokaSostItem.Size = new System.Drawing.Size(196, 22);
            this.StrokaSostItem.Text = "Строка состояния";
            this.StrokaSostItem.Click += new System.EventHandler(this.StrokaSostItem_Click);
            // 
            // PanelItem
            // 
            this.PanelItem.Checked = true;
            this.PanelItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PanelItem.Name = "PanelItem";
            this.PanelItem.Size = new System.Drawing.Size(196, 22);
            this.PanelItem.Text = "Панель инструментов";
            this.PanelItem.Click += new System.EventHandler(this.PanelItem_Click);
            // 
            // HalfButton
            // 
            this.HalfButton.Enabled = false;
            this.HalfButton.Name = "HalfButton";
            this.HalfButton.Size = new System.Drawing.Size(196, 22);
            this.HalfButton.Text = "Половина размера";
            this.HalfButton.Click += new System.EventHandler(this.HalfButton_Click);
            // 
            // NormalButton
            // 
            this.NormalButton.Enabled = false;
            this.NormalButton.Name = "NormalButton";
            this.NormalButton.Size = new System.Drawing.Size(196, 22);
            this.NormalButton.Text = "Нормальный размер";
            this.NormalButton.Click += new System.EventHandler(this.NormalButton_Click);
            // 
            // DoubleButton
            // 
            this.DoubleButton.Enabled = false;
            this.DoubleButton.Name = "DoubleButton";
            this.DoubleButton.Size = new System.Drawing.Size(196, 22);
            this.DoubleButton.Text = "Двойной размер";
            this.DoubleButton.Click += new System.EventHandler(this.DoubleButton_Click);
            // 
            // HelpItem
            // 
            this.HelpItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.HelpItem.Name = "HelpItem";
            this.HelpItem.Size = new System.Drawing.Size(68, 20);
            this.HelpItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveBtn,
            this.PicBtn,
            this.DelBtn,
            this.Half,
            this.Normal,
            this.Double});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1004, 35);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SaveBtn
            // 
            this.SaveBtn.AutoSize = false;
            this.SaveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("SaveBtn.Image")));
            this.SaveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(32, 32);
            this.SaveBtn.Text = "Save as Image";
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // PicBtn
            // 
            this.PicBtn.AutoSize = false;
            this.PicBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PicBtn.Image = ((System.Drawing.Image)(resources.GetObject("PicBtn.Image")));
            this.PicBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PicBtn.Name = "PicBtn";
            this.PicBtn.Size = new System.Drawing.Size(32, 32);
            this.PicBtn.Text = "Open Image";
            this.PicBtn.Click += new System.EventHandler(this.PicBtn_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DelBtn.Enabled = false;
            this.DelBtn.Image = ((System.Drawing.Image)(resources.GetObject("DelBtn.Image")));
            this.DelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(23, 32);
            this.DelBtn.Text = "Delete Image";
            this.DelBtn.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Half
            // 
            this.Half.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Half.Enabled = false;
            this.Half.Image = ((System.Drawing.Image)(resources.GetObject("Half.Image")));
            this.Half.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Half.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Half.Name = "Half";
            this.Half.Size = new System.Drawing.Size(23, 32);
            this.Half.Text = "Половина размера";
            this.Half.Click += new System.EventHandler(this.HalfSizeBtn_Click);
            // 
            // Normal
            // 
            this.Normal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Normal.Enabled = false;
            this.Normal.Image = ((System.Drawing.Image)(resources.GetObject("Normal.Image")));
            this.Normal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Normal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Normal.Name = "Normal";
            this.Normal.Size = new System.Drawing.Size(23, 32);
            this.Normal.Text = "Нормальный размер";
            this.Normal.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // Double
            // 
            this.Double.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Double.Enabled = false;
            this.Double.Image = ((System.Drawing.Image)(resources.GetObject("Double.Image")));
            this.Double.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Double.Name = "Double";
            this.Double.Size = new System.Drawing.Size(23, 32);
            this.Double.Text = "Двойной размер";
            this.Double.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SizeStLab,
            this.PathStLab,
            this.NewSize});
            this.statusStrip1.Location = new System.Drawing.Point(0, 750);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1004, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // SizeStLab
            // 
            this.SizeStLab.BackColor = System.Drawing.Color.White;
            this.SizeStLab.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.SizeStLab.Name = "SizeStLab";
            this.SizeStLab.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.SizeStLab.Size = new System.Drawing.Size(25, 17);
            // 
            // PathStLab
            // 
            this.PathStLab.BackColor = System.Drawing.Color.White;
            this.PathStLab.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
            this.PathStLab.Name = "PathStLab";
            this.PathStLab.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.PathStLab.Size = new System.Drawing.Size(25, 25);
            // 
            // NewSize
            // 
            this.NewSize.BackColor = System.Drawing.Color.White;
            this.NewSize.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
            this.NewSize.Name = "NewSize";
            this.NewSize.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.NewSize.Size = new System.Drawing.Size(25, 25);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPEG|*.JPG|PNG|*.PNG|GIF|*.GIF|BMP|*.BMP|All files (*.*)|*.";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "JPEG|*.JPG|PNG|*.PNG|GIF|*.GIF|BMP|*.BMP|All files (*.*)|*.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 691);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(46, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 58);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HalflBtnCtx,
            this.NormalBtnCtx,
            this.DoubleBtnCtx});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 70);
            // 
            // HalflBtnCtx
            // 
            this.HalflBtnCtx.Enabled = false;
            this.HalflBtnCtx.Name = "HalflBtnCtx";
            this.HalflBtnCtx.Size = new System.Drawing.Size(191, 22);
            this.HalflBtnCtx.Text = "Половина размера";
            this.HalflBtnCtx.Click += new System.EventHandler(this.HalflBtnCtx_Click);
            // 
            // NormalBtnCtx
            // 
            this.NormalBtnCtx.Enabled = false;
            this.NormalBtnCtx.Name = "NormalBtnCtx";
            this.NormalBtnCtx.Size = new System.Drawing.Size(191, 22);
            this.NormalBtnCtx.Text = "Нормальный размер";
            this.NormalBtnCtx.Click += new System.EventHandler(this.NormalBtnCtx_Click);
            // 
            // DoubleBtnCtx
            // 
            this.DoubleBtnCtx.Enabled = false;
            this.DoubleBtnCtx.Name = "DoubleBtnCtx";
            this.DoubleBtnCtx.Size = new System.Drawing.Size(191, 22);
            this.DoubleBtnCtx.Text = "Двойной размер";
            this.DoubleBtnCtx.Click += new System.EventHandler(this.DoubleBtnCtx_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(1004, 772);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Picewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsItem;
        private System.Windows.Forms.ToolStripMenuItem CloseItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VidItem;
        private System.Windows.Forms.ToolStripMenuItem HelpItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SaveBtn;
        private System.Windows.Forms.ToolStripButton PicBtn;
        private System.Windows.Forms.ToolStripMenuItem StrokaSostItem;
        private System.Windows.Forms.ToolStripMenuItem PanelItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton DelBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SizeStLab;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripStatusLabel PathStLab;
        private System.Windows.Forms.ToolStripStatusLabel NewSize;
        private System.Windows.Forms.ToolStripButton Half;
        private System.Windows.Forms.ToolStripButton Normal;
        private System.Windows.Forms.ToolStripButton Double;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HalflBtnCtx;
        private System.Windows.Forms.ToolStripMenuItem NormalBtnCtx;
        private System.Windows.Forms.ToolStripMenuItem DoubleBtnCtx;
        private System.Windows.Forms.ToolStripMenuItem HalfButton;
        private System.Windows.Forms.ToolStripMenuItem NormalButton;
        private System.Windows.Forms.ToolStripMenuItem DoubleButton;
    }
}

