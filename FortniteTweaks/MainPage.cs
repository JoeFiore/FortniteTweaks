using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace FortniteTweaks
{
    public partial class keyboardPack : Form
    {
        // ----------------------------------------------------------------------
        // 1. FIELDS (Cleaned to only include what's needed for UI/Logic)
        // ----------------------------------------------------------------------

        // Define the starting and ending RGB values
        private Color initialColor = Color.FromArgb(100, 100, 100); // Your custom dark gray
        private Color hoverColor = Color.Red;                     // Target red color

        // Variables to store the current R, G, B values during the fade
        private int currentR;
        private int currentG;
        private int currentB;

        // Flag to track whether we are fading IN (to red) or OUT (to gray)
        private bool fadingIn = false;

        // --- Windows API Imports for Dragging the Form ---
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        // --------------------------------------------------

        // ----------------------------------------------------------------------
        // 2. CONSTRUCTOR AND INITIALIZATION (Cleaned)
        // ----------------------------------------------------------------------
        public keyboardPack()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Shown += Form1_Load;
        }
        private void OpenWebLink(string url)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("The link URL is not set.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Use Process.Start with UseShellExecute = true to launch the default browser
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                // This catches errors like if the browser fails to launch or the link is invalid
                MessageBox.Show($"Could not open the link: {url}\nError: {ex.Message}",
                                "Browser Launch Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        

        // ----------------------------------------------------------------------
        // 3. CORE UTILITY FUNCTIONS
        // ----------------------------------------------------------------------

        /// <summary>
        /// Executes a local batch file relative to the application's base directory.
        /// </summary>
        /// <param name="relativePath">e.g., "LunchboxTweaks\\keyboard_pack.bat"</param>
        private void RunLocalBatchFile(string relativePath)
        {
            // Build the full path to the batch file based on the executable's location
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            // 1. Check if the file exists before attempting to run
            if (!File.Exists(fullPath))
            {
                MessageBox.Show(
                    $"Batch file not found. Please ensure the file '{relativePath}' exists next to the program's executable.",
                    "File Missing Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // 2. Configure how the batch file will be launched
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    // Use /C to execute the command and terminate. Quotes handle spaces in the path.
                    Arguments = $"/C \"{fullPath}\"",

                    // Set WorkingDirectory to the directory containing the batch file 
                    // in case the batch file needs to access other files locally.
                    WorkingDirectory = Path.GetDirectoryName(fullPath),

                    UseShellExecute = true,
                    CreateNoWindow = false // Show the command prompt window
                };

                Process.Start(startInfo);

                // Show confirmation message
                MessageBox.Show(
                    $"{Path.GetFileName(relativePath)} script has been launched. Please check the command window for completion.",
                    "Script Running",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error running script: {Path.GetFileName(relativePath)}\nDetails: {ex.Message}",
                    "Execution Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void PlaySound(string soundFileName)
        {
            try
            {
                SoundPlayer player = new SoundPlayer(soundFileName);
                player.Play();
            }
            catch (Exception)
            {
                // Silence sound errors
            }
        }

        // ----------------------------------------------------------------------
        // 4. LOAD/SHOWN HANDLER (Replaced download logic with disclaimer)
        // ----------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            string disclaimerText =
                "*** CRITICAL WARNING AND DISCLAIMER ***\n\n" +
                "This application makes deep, system-level modifications (Registry edits, Service changes, Network stack changes).\n\n" +
                "RISK: Tweaks can potentially cause system instability, driver issues, or other software conflicts.\n\n" +
                "SAFETY: It is highly recommended that you:\n" +
                "1. Create a System Restore Point before proceeding.\n" +
                "2. Use the 'Reset' buttons to revert changes if necessary.\n\n" +
                "Do you accept these terms and wish to proceed?";

            DialogResult result = MessageBox.Show(
                disclaimerText,
                "Fortnite Tweaks - Legal Disclaimer",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (result == DialogResult.No)
            {
                Application.Exit();
            }
        }

        // ----------------------------------------------------------------------
        // 5. BUTTON CLICK HANDLERS (Simplified to use the RunLocalBatchFile helper)
        // ----------------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            RunLocalBatchFile("LunchboxTweaks\\keyboard_pack.bat");
        }

        private void controllerPack_Click(object sender, EventArgs e)
        {
            RunLocalBatchFile("LunchboxTweaks\\controller_pack.bat");
        }

        private void controllerZeroDelay_Click(object sender, EventArgs e)
        {
            RunLocalBatchFile("LunchboxTweaks\\controller_0_delay.bat");
        }

        private void keyboardZeroDelay_Click(object sender, EventArgs e)
        {
            RunLocalBatchFile("LunchboxTweaks\\keyboard_0_delay.bat");
        }

        private void stutterandFPSsafe_Click(object sender, EventArgs e)
        {
            RunLocalBatchFile("LunchboxTweaks\\stutter_safe.bat");
        }

        private void stutterandFPSaggressive_Click(object sender, EventArgs e)
        {
            RunLocalBatchFile("LunchboxTweaks\\stutter_aggressive.bat");
        }

        private void networkTweaks_Click(object sender, EventArgs e)
        {
            RunLocalBatchFile("LunchboxTweaks\\network_chooser.bat");
        }

        private void performanceModeAdvanced_Click(object sender, EventArgs e)
        {
            RunLocalBatchFile("LunchboxTweaks\\cleanup_advanced.bat");
        }

        private void fortniteConfigTweaks_Click(object sender, EventArgs e)
        {
            RunLocalBatchFile("LunchboxTweaks\\fortnite_config.bat");
        }

        private void applyAllTweaks_Click(object sender, EventArgs e)
        {
            RunLocalBatchFile("LunchboxTweaks\\apply_all_tweaks.bat");
        }

        private void resetAdvancedTweaks_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "WARNING: This will reset services and registry keys to the state recorded BEFORE the advanced tweaks were applied. Are you absolutely sure you want to proceed?",
                "Confirm Advanced Tweak Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );
            if (result == DialogResult.Yes)
            {
                RunLocalBatchFile("LunchboxTweaks\\reset_advanced_tweaks.bat");
            }
            else
            {
                MessageBox.Show("Advanced Tweak Reset cancelled by user.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void resetAllTweaks_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "WARNING: This will reset all applied tweaks (registry, network, services) to their recorded backup state or Windows defaults. Are you ABSOLUTELY sure you want to proceed?",
                "Confirm Master Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );
            if (result == DialogResult.Yes)
            {
                RunLocalBatchFile("LunchboxTweaks\\reset_all_tweaks.bat");
            }
            else
            {
                MessageBox.Show("Master Reset cancelled by user.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "WARNING: This will restart your PC!",
                "Are you sure you want to contiune?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );
            if (result == DialogResult.Yes)
            {
                RunLocalBatchFile("LunchboxTweaks\\restart_pc.bat");
            }
            else
            {
                MessageBox.Show("PC restart cancelled!", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void otherTweaks_Click(object sender, EventArgs e)
        {
            // You had logic here to open a sub-form named 'OtherTweaks'.
            // The Setup.bat is still called locally.
            RunLocalBatchFile("OtherTweaks\\Setup.bat");

          // Assuming 'OtherTweaks' is a form you have defined elsewhere:
          OtherTweaks open = new OtherTweaks(); 
          open.ShowDialog();
        }


        // ----------------------------------------------------------------------
        // 6. UI/MISC HANDLERS (Kept from your original code)
        // ----------------------------------------------------------------------

        private void pictureBox1_Click(object sender, EventArgs e) { /* ... */ }
        private void pictureBox2_Click(object sender, EventArgs e) { /* ... */ }
        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
        private void pnl1TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            fadingIn = true;
            currentR = initialColor.R;
            currentG = initialColor.G;
            currentB = initialColor.B;
            // Assuming 'colorFadeTimer' is your Timer control
            // colorFadeTimer.Start(); 
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            fadingIn = false;
            // colorFadeTimer.Start();
        }
        private void colorFadeTimer_Tick(object sender, EventArgs e)
        {
            Color targetColor = fadingIn ? hoverColor : initialColor;
            int step = 15;

            if (currentR < targetColor.R) currentR = Math.Min(currentR + step, targetColor.R);
            if (currentR > targetColor.R) currentR = Math.Max(currentR - step, targetColor.R);
            if (currentG < targetColor.G) currentG = Math.Min(currentG + step, targetColor.G);
            if (currentG > targetColor.G) currentG = Math.Max(currentG - step, targetColor.G);
            if (currentB < targetColor.B) currentB = Math.Min(currentB + step, targetColor.B);
            if (currentB > targetColor.B) currentB = Math.Max(currentB - step, targetColor.B);

            // Assuming 'btnClose' is your button control
            // btnClose.BackColor = Color.FromArgb(currentR, currentG, currentB);

            // if (currentR == targetColor.R && currentG == targetColor.G && currentB == targetColor.B)
            // {
            //     colorFadeTimer.Stop();
            // }
        }

        private void quit_Click(object sender, EventArgs e) { Application.Exit(); }
        private void credits_Click(object sender, EventArgs e) 
        {
            Info_Credits open = new Info_Credits();
            open.ShowDialog();
        }
        private void openDiscordServer_Click(object sender, EventArgs e)
        {  // The Discord link you want to send the user to
            const string DiscordInviteLink = "https://discord.gg/YourCustomInvite";

            // Open the link
            OpenWebLink(DiscordInviteLink);

    // NOTE: Your original code had a sound effect that was likely called here
    // hoverSoundDiscord(sender, e); // If you want to keep the sound effect
        }
        private void label3_Click(object sender, EventArgs e) { /* ... */ }
        private void closeButton_Click(object sender, EventArgs e) { Application.Exit(); }
        private void minimizeButton_Click(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }
        private void hoverSound(object sender, EventArgs e) { PlaySound("Sounds\\hover.wav"); }
        private void hoverSoundDiscord(object sender, EventArgs e) { PlaySound("Sounds\\join-discord-server-hover.wav"); }
        private void unhoverSoundDiscord(object sender, EventArgs e) { PlaySound("Sounds\\join-discord-server-unhovered.wav"); }
        private void applyDiscordButton(object sender, MouseEventArgs e) { PlaySound("Sounds\\join-discord-server-hovered.wav"); }
        private void applySound(object sender, MouseEventArgs e) { PlaySound("Sounds\\apply.wav"); }
    }
}