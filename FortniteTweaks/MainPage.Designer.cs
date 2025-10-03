namespace FortniteTweaks
{
    partial class keyboardPack
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(keyboardPack));
            pictureBox1 = new PictureBox();
            pnl1TitleBar = new Panel();
            pictureBox2 = new PictureBox();
            btnClose = new Button();
            colorFadeTimer = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            controllerPack = new Button();
            controllerZeroDelay = new Button();
            keyboardZeroDelay = new Button();
            stutterandFPSsafe = new Button();
            stutterandFPSaggressive = new Button();
            networkTweaks = new Button();
            performanceModeAdvanced = new Button();
            fortniteConfigTweaks = new Button();
            resetAdvancedTweaks = new Button();
            resetAllTweaks = new Button();
            quit = new Button();
            applyAllTweaks = new Button();
            credits = new Button();
            button2 = new Button();
            otherTweaks = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnl1TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LUNCHBOXTITLE;
            pictureBox1.Location = new Point(150, -109);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(500, 294);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnl1TitleBar
            // 
            pnl1TitleBar.BackColor = SystemColors.WindowFrame;
            pnl1TitleBar.Controls.Add(pictureBox2);
            pnl1TitleBar.Controls.Add(btnClose);
            pnl1TitleBar.Dock = DockStyle.Top;
            pnl1TitleBar.Location = new Point(0, 0);
            pnl1TitleBar.Name = "pnl1TitleBar";
            pnl1TitleBar.Size = new Size(800, 30);
            pnl1TitleBar.TabIndex = 1;
            pnl1TitleBar.MouseDown += pnl1TitleBar_MouseDown;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.TitleBar;
            pictureBox2.Location = new Point(1, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(149, 31);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // btnClose
            // 
            btnClose.BackgroundImageLayout = ImageLayout.Center;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Image = Properties.Resources.XIcon;
            btnClose.Location = new Point(760, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 31);
            btnClose.TabIndex = 0;
            btnClose.TabStop = false;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // colorFadeTimer
            // 
            colorFadeTimer.Interval = 10;
            colorFadeTimer.Tick += colorFadeTimer_Tick;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.BackgroundImage = Properties.Resources.graident;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Impact", 13F);
            button1.Location = new Point(3, 208);
            button1.Name = "button1";
            button1.Size = new Size(305, 32);
            button1.TabIndex = 2;
            button1.Text = "Keyboard Pack (Shotugn, SMG, Bloom)";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // controllerPack
            // 
            controllerPack.BackColor = Color.White;
            controllerPack.BackgroundImage = Properties.Resources.graident;
            controllerPack.FlatStyle = FlatStyle.Flat;
            controllerPack.Font = new Font("Impact", 13F);
            controllerPack.Location = new Point(3, 249);
            controllerPack.Name = "controllerPack";
            controllerPack.Size = new Size(419, 32);
            controllerPack.TabIndex = 3;
            controllerPack.Text = "Controller Pack (Shotgun, SMG, Bloom, Stick Tweaks)";
            controllerPack.UseVisualStyleBackColor = false;
            controllerPack.Click += controllerPack_Click;
            // 
            // controllerZeroDelay
            // 
            controllerZeroDelay.BackColor = Color.White;
            controllerZeroDelay.BackgroundImage = Properties.Resources.graident;
            controllerZeroDelay.FlatStyle = FlatStyle.Flat;
            controllerZeroDelay.Font = new Font("Impact", 13F);
            controllerZeroDelay.Location = new Point(3, 290);
            controllerZeroDelay.Name = "controllerZeroDelay";
            controllerZeroDelay.Size = new Size(523, 32);
            controllerZeroDelay.TabIndex = 4;
            controllerZeroDelay.Text = "Controller 0 Delay (Registry + Windows Tweaks for the lowest Latency)";
            controllerZeroDelay.UseVisualStyleBackColor = false;
            controllerZeroDelay.Click += controllerZeroDelay_Click;
            // 
            // keyboardZeroDelay
            // 
            keyboardZeroDelay.BackColor = Color.White;
            keyboardZeroDelay.BackgroundImage = Properties.Resources.graident;
            keyboardZeroDelay.FlatStyle = FlatStyle.Flat;
            keyboardZeroDelay.Font = new Font("Impact", 13F);
            keyboardZeroDelay.Location = new Point(3, 331);
            keyboardZeroDelay.Name = "keyboardZeroDelay";
            keyboardZeroDelay.Size = new Size(523, 32);
            keyboardZeroDelay.TabIndex = 5;
            keyboardZeroDelay.Text = "Keyboard 0 Delay (Registry & Windows Tweaks for the lowest Latency)";
            keyboardZeroDelay.UseVisualStyleBackColor = false;
            keyboardZeroDelay.Click += keyboardZeroDelay_Click;
            // 
            // stutterandFPSsafe
            // 
            stutterandFPSsafe.BackColor = Color.White;
            stutterandFPSsafe.BackgroundImage = Properties.Resources.graident;
            stutterandFPSsafe.FlatStyle = FlatStyle.Flat;
            stutterandFPSsafe.Font = new Font("Impact", 13F);
            stutterandFPSsafe.Location = new Point(3, 372);
            stutterandFPSsafe.Name = "stutterandFPSsafe";
            stutterandFPSsafe.Size = new Size(176, 32);
            stutterandFPSsafe.TabIndex = 6;
            stutterandFPSsafe.Text = "Stutter and FPS (SAFE)";
            stutterandFPSsafe.UseVisualStyleBackColor = false;
            stutterandFPSsafe.Click += stutterandFPSsafe_Click;
            // 
            // stutterandFPSaggressive
            // 
            stutterandFPSaggressive.BackColor = Color.White;
            stutterandFPSaggressive.BackgroundImage = Properties.Resources.graident;
            stutterandFPSaggressive.FlatStyle = FlatStyle.Flat;
            stutterandFPSaggressive.Font = new Font("Impact", 13F);
            stutterandFPSaggressive.Location = new Point(3, 413);
            stutterandFPSaggressive.Name = "stutterandFPSaggressive";
            stutterandFPSaggressive.Size = new Size(231, 32);
            stutterandFPSaggressive.TabIndex = 7;
            stutterandFPSaggressive.Text = "Stutter and FPS (AGGRESSIVE)";
            stutterandFPSaggressive.UseVisualStyleBackColor = false;
            stutterandFPSaggressive.Click += stutterandFPSaggressive_Click;
            // 
            // networkTweaks
            // 
            networkTweaks.BackColor = Color.White;
            networkTweaks.BackgroundImage = Properties.Resources.graident;
            networkTweaks.FlatStyle = FlatStyle.Flat;
            networkTweaks.Font = new Font("Impact", 13F);
            networkTweaks.Location = new Point(3, 454);
            networkTweaks.Name = "networkTweaks";
            networkTweaks.Size = new Size(149, 32);
            networkTweaks.TabIndex = 8;
            networkTweaks.Text = "Network Tweaks";
            networkTweaks.UseVisualStyleBackColor = false;
            networkTweaks.Click += networkTweaks_Click;
            // 
            // performanceModeAdvanced
            // 
            performanceModeAdvanced.BackColor = Color.White;
            performanceModeAdvanced.BackgroundImage = Properties.Resources.graident;
            performanceModeAdvanced.FlatStyle = FlatStyle.Flat;
            performanceModeAdvanced.Font = new Font("Impact", 13F);
            performanceModeAdvanced.Location = new Point(3, 495);
            performanceModeAdvanced.Name = "performanceModeAdvanced";
            performanceModeAdvanced.Size = new Size(328, 32);
            performanceModeAdvanced.TabIndex = 9;
            performanceModeAdvanced.Text = "Cleanup / Performance Mode (Advanced)";
            performanceModeAdvanced.UseVisualStyleBackColor = false;
            performanceModeAdvanced.Click += performanceModeAdvanced_Click;
            // 
            // fortniteConfigTweaks
            // 
            fortniteConfigTweaks.BackColor = Color.White;
            fortniteConfigTweaks.BackgroundImage = Properties.Resources.graident;
            fortniteConfigTweaks.FlatStyle = FlatStyle.Flat;
            fortniteConfigTweaks.Font = new Font("Impact", 13F);
            fortniteConfigTweaks.Location = new Point(3, 536);
            fortniteConfigTweaks.Name = "fortniteConfigTweaks";
            fortniteConfigTweaks.Size = new Size(376, 32);
            fortniteConfigTweaks.TabIndex = 10;
            fortniteConfigTweaks.Text = "Fortnite Config Tweaks (GameUserSettings.ini)";
            fortniteConfigTweaks.UseVisualStyleBackColor = false;
            fortniteConfigTweaks.Click += fortniteConfigTweaks_Click;
            // 
            // resetAdvancedTweaks
            // 
            resetAdvancedTweaks.BackColor = Color.DarkRed;
            resetAdvancedTweaks.FlatStyle = FlatStyle.Flat;
            resetAdvancedTweaks.Font = new Font("Impact", 13F);
            resetAdvancedTweaks.ForeColor = SystemColors.AppWorkspace;
            resetAdvancedTweaks.Location = new Point(483, 208);
            resetAdvancedTweaks.Name = "resetAdvancedTweaks";
            resetAdvancedTweaks.Size = new Size(305, 32);
            resetAdvancedTweaks.TabIndex = 11;
            resetAdvancedTweaks.Text = "RESET ADVANCED TWEAKS";
            resetAdvancedTweaks.UseVisualStyleBackColor = false;
            resetAdvancedTweaks.Click += resetAdvancedTweaks_Click;
            // 
            // resetAllTweaks
            // 
            resetAllTweaks.BackColor = Color.DarkRed;
            resetAllTweaks.FlatStyle = FlatStyle.Flat;
            resetAllTweaks.Font = new Font("Impact", 13F);
            resetAllTweaks.ForeColor = SystemColors.AppWorkspace;
            resetAllTweaks.Location = new Point(483, 252);
            resetAllTweaks.Name = "resetAllTweaks";
            resetAllTweaks.Size = new Size(305, 32);
            resetAllTweaks.TabIndex = 12;
            resetAllTweaks.Text = "RESET ALL TWEAKS";
            resetAllTweaks.UseVisualStyleBackColor = false;
            resetAllTweaks.Click += resetAllTweaks_Click;
            // 
            // quit
            // 
            quit.BackColor = Color.Red;
            quit.FlatStyle = FlatStyle.Flat;
            quit.Font = new Font("Impact", 13F);
            quit.ForeColor = SystemColors.ButtonFace;
            quit.Location = new Point(711, 521);
            quit.Name = "quit";
            quit.Size = new Size(77, 32);
            quit.TabIndex = 13;
            quit.Text = "QUIT";
            quit.UseVisualStyleBackColor = false;
            quit.Click += quit_Click;
            // 
            // applyAllTweaks
            // 
            applyAllTweaks.BackColor = Color.PaleGreen;
            applyAllTweaks.FlatStyle = FlatStyle.Flat;
            applyAllTweaks.Font = new Font("Impact", 13F);
            applyAllTweaks.Location = new Point(483, 413);
            applyAllTweaks.Name = "applyAllTweaks";
            applyAllTweaks.Size = new Size(165, 32);
            applyAllTweaks.TabIndex = 14;
            applyAllTweaks.Text = "APPLY ALL TWEAKS";
            applyAllTweaks.UseVisualStyleBackColor = false;
            applyAllTweaks.Click += applyAllTweaks_Click;
            // 
            // credits
            // 
            credits.BackColor = Color.Aqua;
            credits.FlatStyle = FlatStyle.Flat;
            credits.Font = new Font("Impact", 13F);
            credits.Location = new Point(684, 521);
            credits.Name = "credits";
            credits.Size = new Size(21, 32);
            credits.TabIndex = 15;
            credits.Text = "i";
            credits.UseVisualStyleBackColor = false;
            credits.Click += credits_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Lavender;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Impact", 13F);
            button2.Location = new Point(567, 521);
            button2.Name = "button2";
            button2.Size = new Size(102, 32);
            button2.TabIndex = 16;
            button2.Text = "Restart PC";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // otherTweaks
            // 
            otherTweaks.BackColor = Color.LightCyan;
            otherTweaks.FlatStyle = FlatStyle.Flat;
            otherTweaks.Font = new Font("Impact", 13F);
            otherTweaks.Location = new Point(613, 320);
            otherTweaks.Name = "otherTweaks";
            otherTweaks.Size = new Size(165, 32);
            otherTweaks.TabIndex = 17;
            otherTweaks.Text = "Other Tweaks ->";
            otherTweaks.UseVisualStyleBackColor = false;
            otherTweaks.Click += otherTweaks_Click;
            // 
            // keyboardPack
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(800, 578);
            Controls.Add(otherTweaks);
            Controls.Add(button2);
            Controls.Add(credits);
            Controls.Add(applyAllTweaks);
            Controls.Add(quit);
            Controls.Add(resetAllTweaks);
            Controls.Add(resetAdvancedTweaks);
            Controls.Add(fortniteConfigTweaks);
            Controls.Add(performanceModeAdvanced);
            Controls.Add(networkTweaks);
            Controls.Add(stutterandFPSaggressive);
            Controls.Add(stutterandFPSsafe);
            Controls.Add(keyboardZeroDelay);
            Controls.Add(controllerZeroDelay);
            Controls.Add(controllerPack);
            Controls.Add(button1);
            Controls.Add(pnl1TitleBar);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "keyboardPack";
            Text = "Fortnite Tweaks";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnl1TitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel pnl1TitleBar;
        private Button btnClose;
        private PictureBox pictureBox2;
        private System.Windows.Forms.Timer colorFadeTimer;
        private Button button1;
        private Button controllerPack;
        private Button controllerZeroDelay;
        private Button keyboardZeroDelay;
        private Button stutterandFPSsafe;
        private Button stutterandFPSaggressive;
        private Button networkTweaks;
        private Button performanceModeAdvanced;
        private Button fortniteConfigTweaks;
        private Button resetAdvancedTweaks;
        private Button resetAllTweaks;
        private Button quit;
        private Button applyAllTweaks;
        private Button credits;
        private Button button2;
        private Button otherTweaks;
    }
}
