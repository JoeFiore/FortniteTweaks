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
            disableWinTelemetry = new Button();
            windowsIOTweaks = new Button();
            windowsPowerPlan = new Button();
            blockWindowsUpdates = new Button();
            generalWindowsSettings = new Button();
            debloatWindows = new Button();
            rebloatWindows = new Button();
            debloatStartup = new Button();
            cpuTweaks = new Button();
            cleanTempFiles = new Button();
            menuKillTime = new Button();
            msiUtlity = new Button();
            back = new Button();
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
            // disableWinTelemetry
            // 
            disableWinTelemetry.BackColor = Color.White;
            disableWinTelemetry.BackgroundImage = Properties.Resources.graident;
            disableWinTelemetry.FlatStyle = FlatStyle.Flat;
            disableWinTelemetry.Font = new Font("Impact", 13F);
            disableWinTelemetry.Location = new Point(12, 171);
            disableWinTelemetry.Name = "disableWinTelemetry";
            disableWinTelemetry.Size = new Size(305, 32);
            disableWinTelemetry.TabIndex = 4;
            disableWinTelemetry.Text = "Disable Windows Telemetry";
            disableWinTelemetry.UseVisualStyleBackColor = false;
            disableWinTelemetry.Click += win_telemetry_Click;
            // 
            // windowsIOTweaks
            // 
            windowsIOTweaks.BackColor = Color.White;
            windowsIOTweaks.BackgroundImage = Properties.Resources.graident;
            windowsIOTweaks.FlatStyle = FlatStyle.Flat;
            windowsIOTweaks.Font = new Font("Impact", 13F);
            windowsIOTweaks.Location = new Point(12, 226);
            windowsIOTweaks.Name = "windowsIOTweaks";
            windowsIOTweaks.Size = new Size(305, 32);
            windowsIOTweaks.TabIndex = 5;
            windowsIOTweaks.Text = "Windows iO Tweaks";
            windowsIOTweaks.UseVisualStyleBackColor = false;
            windowsIOTweaks.Click += windowsIOTweaks_Click;
            // 
            // windowsPowerPlan
            // 
            windowsPowerPlan.BackColor = Color.White;
            windowsPowerPlan.BackgroundImage = Properties.Resources.graident;
            windowsPowerPlan.FlatStyle = FlatStyle.Flat;
            windowsPowerPlan.Font = new Font("Impact", 13F);
            windowsPowerPlan.Location = new Point(12, 285);
            windowsPowerPlan.Name = "windowsPowerPlan";
            windowsPowerPlan.Size = new Size(305, 32);
            windowsPowerPlan.TabIndex = 6;
            windowsPowerPlan.Text = "Windows Power Plan";
            windowsPowerPlan.UseVisualStyleBackColor = false;
            windowsPowerPlan.Click += windowsPowerPlan_Click;
            // 
            // blockWindowsUpdates
            // 
            blockWindowsUpdates.BackColor = Color.White;
            blockWindowsUpdates.BackgroundImage = Properties.Resources.graident;
            blockWindowsUpdates.FlatStyle = FlatStyle.Flat;
            blockWindowsUpdates.Font = new Font("Impact", 13F);
            blockWindowsUpdates.Location = new Point(12, 343);
            blockWindowsUpdates.Name = "blockWindowsUpdates";
            blockWindowsUpdates.Size = new Size(305, 32);
            blockWindowsUpdates.TabIndex = 7;
            blockWindowsUpdates.Text = "Block Windows Updates";
            blockWindowsUpdates.UseVisualStyleBackColor = false;
            blockWindowsUpdates.Click += blockWindowsUpdates_Click;
            // 
            // generalWindowsSettings
            // 
            generalWindowsSettings.BackColor = Color.White;
            generalWindowsSettings.BackgroundImage = Properties.Resources.graident;
            generalWindowsSettings.FlatStyle = FlatStyle.Flat;
            generalWindowsSettings.Font = new Font("Impact", 13F);
            generalWindowsSettings.Location = new Point(12, 394);
            generalWindowsSettings.Name = "generalWindowsSettings";
            generalWindowsSettings.Size = new Size(305, 32);
            generalWindowsSettings.TabIndex = 8;
            generalWindowsSettings.Text = "General Windows Settings";
            generalWindowsSettings.UseVisualStyleBackColor = false;
            generalWindowsSettings.Click += generalWindowsSettings_Click;
            // 
            // debloatWindows
            // 
            debloatWindows.BackColor = Color.White;
            debloatWindows.BackgroundImage = Properties.Resources.graident;
            debloatWindows.FlatStyle = FlatStyle.Flat;
            debloatWindows.Font = new Font("Impact", 13F);
            debloatWindows.Location = new Point(12, 443);
            debloatWindows.Name = "debloatWindows";
            debloatWindows.Size = new Size(305, 32);
            debloatWindows.TabIndex = 9;
            debloatWindows.Text = "Debloat Windows";
            debloatWindows.UseVisualStyleBackColor = false;
            debloatWindows.Click += debloatWindows_Click;
            // 
            // rebloatWindows
            // 
            rebloatWindows.BackColor = Color.White;
            rebloatWindows.BackgroundImage = Properties.Resources.graident;
            rebloatWindows.FlatStyle = FlatStyle.Flat;
            rebloatWindows.Font = new Font("Impact", 13F);
            rebloatWindows.Location = new Point(12, 493);
            rebloatWindows.Name = "rebloatWindows";
            rebloatWindows.Size = new Size(305, 32);
            rebloatWindows.TabIndex = 10;
            rebloatWindows.Text = "Rebloat Windows";
            rebloatWindows.UseVisualStyleBackColor = false;
            rebloatWindows.Click += rebloatWindows_Click;
            // 
            // debloatStartup
            // 
            debloatStartup.BackColor = Color.White;
            debloatStartup.BackgroundImage = Properties.Resources.graident;
            debloatStartup.FlatStyle = FlatStyle.Flat;
            debloatStartup.Font = new Font("Impact", 13F);
            debloatStartup.Location = new Point(12, 543);
            debloatStartup.Name = "debloatStartup";
            debloatStartup.Size = new Size(305, 32);
            debloatStartup.TabIndex = 11;
            debloatStartup.Text = "Debloat Startup";
            debloatStartup.UseVisualStyleBackColor = false;
            debloatStartup.Click += debloatStartup_Click;
            // 
            // cpuTweaks
            // 
            cpuTweaks.BackColor = Color.White;
            cpuTweaks.BackgroundImage = Properties.Resources.graident;
            cpuTweaks.FlatStyle = FlatStyle.Flat;
            cpuTweaks.Font = new Font("Impact", 13F);
            cpuTweaks.Location = new Point(12, 594);
            cpuTweaks.Name = "cpuTweaks";
            cpuTweaks.Size = new Size(305, 32);
            cpuTweaks.TabIndex = 12;
            cpuTweaks.Text = "CPU Tweaks";
            cpuTweaks.UseVisualStyleBackColor = false;
            cpuTweaks.Click += cpuTweaks_Click;
            // 
            // cleanTempFiles
            // 
            cleanTempFiles.BackColor = Color.White;
            cleanTempFiles.BackgroundImage = Properties.Resources.graident;
            cleanTempFiles.FlatStyle = FlatStyle.Flat;
            cleanTempFiles.Font = new Font("Impact", 13F);
            cleanTempFiles.Location = new Point(12, 641);
            cleanTempFiles.Name = "cleanTempFiles";
            cleanTempFiles.Size = new Size(305, 32);
            cleanTempFiles.TabIndex = 13;
            cleanTempFiles.Text = "Clean Temp Files";
            cleanTempFiles.UseVisualStyleBackColor = false;
            cleanTempFiles.Click += cleanTempFiles_Click;
            // 
            // menuKillTime
            // 
            menuKillTime.BackColor = Color.White;
            menuKillTime.BackgroundImage = Properties.Resources.graident;
            menuKillTime.FlatStyle = FlatStyle.Flat;
            menuKillTime.Font = new Font("Impact", 13F);
            menuKillTime.Location = new Point(347, 171);
            menuKillTime.Name = "menuKillTime";
            menuKillTime.Size = new Size(305, 32);
            menuKillTime.TabIndex = 14;
            menuKillTime.Text = "Menu Kill Time";
            menuKillTime.UseVisualStyleBackColor = false;
            menuKillTime.Click += menuKillTime_Click;
            // 
            // msiUtlity
            // 
            msiUtlity.BackColor = Color.White;
            msiUtlity.BackgroundImage = Properties.Resources.graident;
            msiUtlity.FlatStyle = FlatStyle.Flat;
            msiUtlity.Font = new Font("Impact", 13F);
            msiUtlity.Location = new Point(347, 226);
            msiUtlity.Name = "msiUtlity";
            msiUtlity.Size = new Size(305, 32);
            msiUtlity.TabIndex = 15;
            msiUtlity.Text = "MSI Utility";
            msiUtlity.UseVisualStyleBackColor = false;
            msiUtlity.Click += msiUtlity_Click;
            // 
            // back
            // 
            back.BackColor = Color.Red;
            back.FlatStyle = FlatStyle.Flat;
            back.Font = new Font("Impact", 13F);
            back.Location = new Point(917, 641);
            back.Name = "back";
            back.Size = new Size(64, 32);
            back.TabIndex = 16;
            back.Text = "BACK";
            back.UseVisualStyleBackColor = false;
            back.Click += back_Click;
            // 
            // OtherTweaks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(993, 694);
            Controls.Add(back);
            Controls.Add(msiUtlity);
            Controls.Add(menuKillTime);
            Controls.Add(cleanTempFiles);
            Controls.Add(cpuTweaks);
            Controls.Add(debloatStartup);
            Controls.Add(rebloatWindows);
            Controls.Add(debloatWindows);
            Controls.Add(generalWindowsSettings);
            Controls.Add(blockWindowsUpdates);
            Controls.Add(windowsPowerPlan);
            Controls.Add(windowsIOTweaks);
            Controls.Add(disableWinTelemetry);
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
        private Button disableWinTelemetry;
        private Button windowsIOTweaks;
        private Button windowsPowerPlan;
        private Button blockWindowsUpdates;
        private Button generalWindowsSettings;
        private Button debloatWindows;
        private Button rebloatWindows;
        private Button debloatStartup;
        private Button cpuTweaks;
        private Button cleanTempFiles;
        private Button menuKillTime;
        private Button msiUtlity;
        private Button back;
    }
}