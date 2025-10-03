namespace FortniteTweaks
{
    partial class OtherTweaks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OtherTweaks));
            pictureBox2 = new PictureBox();
            btnClose = new Button();
            pnl1TitleBar = new Panel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnl1TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.TitleBar;
            pictureBox2.Location = new Point(1, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(149, 31);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.BackgroundImageLayout = ImageLayout.Center;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Image = Properties.Resources.XIcon;
            btnClose.Location = new Point(953, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 31);
            btnClose.TabIndex = 0;
            btnClose.TabStop = false;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pnl1TitleBar
            // 
            pnl1TitleBar.BackColor = SystemColors.WindowFrame;
            pnl1TitleBar.Controls.Add(pictureBox2);
            pnl1TitleBar.Controls.Add(btnClose);
            pnl1TitleBar.Dock = DockStyle.Top;
            pnl1TitleBar.Location = new Point(0, 0);
            pnl1TitleBar.Name = "pnl1TitleBar";
            pnl1TitleBar.Size = new Size(993, 30);
            pnl1TitleBar.TabIndex = 2;
            pnl1TitleBar.MouseDown += pnl1TitleBar_MouseDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.OtherTweaksTitle;
            pictureBox1.Location = new Point(247, -102);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(483, 251);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // OtherTweaks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(993, 694);
            Controls.Add(pnl1TitleBar);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "OtherTweaks";
            Text = "Form2";
            Load += OtherTweaks_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnl1TitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox2;
        private Button btnClose;
        private Panel pnl1TitleBar;
        private PictureBox pictureBox1;
    }
}