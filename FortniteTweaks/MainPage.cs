using System.Diagnostics;
using System.Drawing; // Make sure this is at the top of the file
using System.IO;
using System.Windows.Forms; // Ensure this is present for MessageBox
namespace FortniteTweaks
{
    public partial class keyboardPack : Form

    {
        private void ExecuteBatchFile(string filePath, bool waitForExit)
        {
            // 1. Basic check to ensure the file exists before attempting to run
            if (!File.Exists(filePath))
            {
                MessageBox.Show($"Script not found: {Path.GetFileName(filePath)}\nPath: {filePath}", "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Configure how the batch file will be launched
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                // The /C argument tells cmd.exe to execute the following string as a command and then terminate.
                // We enclose the filePath in quotes in case there are spaces in the path.
                Arguments = $"/C \"{filePath}\"",

                // UseShellExecute = false is generally better when running CMD/scripts
                UseShellExecute = false,

                // Setting to false means the user will see the command prompt window.
                // This is important for tweaks so the user can see the progress/output 
                // and handle the 'pause' command at the end of the batch file.
                CreateNoWindow = false
            };

            // 3. Execute the batch file
            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    if (waitForExit && process != null)
                    {
                        // This line is essential for the setup script and most tweaks.
                        // It pauses the C# execution until the command window is closed (i.e., the script is done).
                        process.WaitForExit();
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch exceptions like "access denied" or failure to start the process
                MessageBox.Show($"Error running script: {Path.GetFileName(filePath)}\nDetails: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        // ... (other code, like your public Form1() constructor)
        public keyboardPack()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(40, 40, 40);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Define the full disclaimer text
            string disclaimerText =
                "*** CRITICAL WARNING AND DISCLAIMER ***\n\n" +
                "This application makes deep, system-level modifications (Registry edits, Service changes, Network stack changes).\n\n" +
                "RISK: Tweaks can potentially cause system instability, driver issues, or other software conflicts.\n\n" +
                "SAFETY: It is highly recommended that you:\n" +
                "1. Create a System Restore Point before proceeding.\n" +
                "2. Use the 'Reset' buttons to revert changes if necessary.\n\n" +
                "Do you accept these terms and wish to proceed?";

            // Show the disclaimer with Yes/No options
            DialogResult result = MessageBox.Show(
                disclaimerText,
                "Fortnite Tweaks - Legal Disclaimer",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, // Use a Warning or Error icon to draw attention
                MessageBoxDefaultButton.Button2 // Default to 'No' for safety
            );

            // If the user clicks 'No', close the application immediately.
            if (result == DialogResult.No)
            {
                this.Close(); // Close the form, which shuts down the application
            }

            // If the user clicks 'Yes', the application loads normally.
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // This command closes the current form (your application)
        }

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
            colorFadeTimer.Start();
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            fadingIn = false;
            colorFadeTimer.Start();
        }

        private void colorFadeTimer_Tick(object sender, EventArgs e)
        {

            // 1. Determine the target color based on whether we are fading in or out
            Color targetColor = fadingIn ? hoverColor : initialColor;

            // 2. Set the speed of the fade (higher number = faster fade)
            int step = 15;

            // 3. Adjust Red component
            if (currentR < targetColor.R) currentR = Math.Min(currentR + step, targetColor.R);
            if (currentR > targetColor.R) currentR = Math.Max(currentR - step, targetColor.R);

            // 4. Adjust Green component
            if (currentG < targetColor.G) currentG = Math.Min(currentG + step, targetColor.G);
            if (currentG > targetColor.G) currentG = Math.Max(currentG - step, targetColor.G);

            // 5. Adjust Blue component
            if (currentB < targetColor.B) currentB = Math.Min(currentB + step, targetColor.B);
            if (currentB > targetColor.B) currentB = Math.Max(currentB - step, targetColor.B);

            // 6. Apply the new color to the button
            btnClose.BackColor = Color.FromArgb(currentR, currentG, currentB);

            // 7. Check if the fade is complete and stop the timer
            if (currentR == targetColor.R && currentG == targetColor.G && currentB == targetColor.B)
            {
                colorFadeTimer.Stop();
            }
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string batchFileName = "LunchboxTweaks\\keyboard_pack.bat";
            string programToRun = "cmd.exe";

            // CHANGE IS HERE: Use /k (Execute and Keep) instead of /c (Execute and Close)
            string arguments = $"/c \"{batchFileName}\"";

            try
            {
                // Start the process
                ProcessStartInfo startInfo = new ProcessStartInfo(programToRun, arguments);

                // IMPORTANT: We must also change the window creation settings to allow the CMD window to show
                // If we set CreateNoWindow = true, the user will never see the window, even with /k.
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true; // UseShellExecute = true works better when showing the window

                Process.Start(startInfo);

                MessageBox.Show("Keyboard Pack script has been launched. Please check the command window for completion ", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName}. Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void controllerPack_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "LunchboxTweaks\\controller_pack.bat";

            // 2. Define the process environment
            string programToRun = "cmd.exe";

            // Use /c (Execute and Close) so the CMD window closes after the 'pause' command is satisfied
            string arguments = $"/c \"{batchFileName}\"";

            try
            {
                // Start the process, allowing the command window to be visible
                ProcessStartInfo startInfo = new ProcessStartInfo(programToRun, arguments);
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;

                Process.Start(startInfo);

                MessageBox.Show("Controller Pack script has been launched. Please check the command window for completion ", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optional: Let the user know the script has started
                // You can remove this if the CMD window is sufficient feedback.
                // MessageBox.Show("Controller Pack script launched. Please press a key in the command window when finished.", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void controllerZeroDelay_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "LunchboxTweaks\\controller_0_delay.bat";

            // 2. Define the process environment
            string programToRun = "cmd.exe";

            // Use /c (Execute and Close). The CMD window will close after the 'pause' command is finished.
            string arguments = $"/c \"{batchFileName}\"";

            try
            {
                // Start the process, allowing the command window to be visible
                ProcessStartInfo startInfo = new ProcessStartInfo(programToRun, arguments);
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;

                Process.Start(startInfo);

                MessageBox.Show("Controller 0 Delay script has been launched. Please check the command window for completion ", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // The batch file provides the final success message and pause, so we don't need a MessageBox here.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void keyboardZeroDelay_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "LunchboxTweaks\\keyboard_0_delay.bat";

            // 2. Define the process environment
            string programToRun = "cmd.exe";

            // Use /c (Execute and Close) so the CMD window closes after the 'pause' command is satisfied
            string arguments = $"/c \"{batchFileName}\"";

            try
            {
                // Start the process, allowing the command window to be visible
                ProcessStartInfo startInfo = new ProcessStartInfo(programToRun, arguments);
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;

                Process.Start(startInfo);

                MessageBox.Show("Keyboard 0 Delay script has been launched. Please check the command window for completion ", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // No MessageBox needed, as the batch file handles the final message and pause.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stutterandFPSsafe_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "LunchboxTweaks\\stutter_safe.bat";

            // 2. Define the process environment
            string programToRun = "cmd.exe";

            // Use /c (Execute and Close) so the CMD window closes after the 'pause' command is satisfied
            string arguments = $"/c \"{batchFileName}\"";

            try
            {
                // Start the process, allowing the command window to be visible
                ProcessStartInfo startInfo = new ProcessStartInfo(programToRun, arguments);
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;

                Process.Start(startInfo);

                MessageBox.Show("Stutter and FPS (SAFE) script has been launched. Please check the command window for completion ", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stutterandFPSaggressive_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "LunchboxTweaks\\stutter_aggressive.bat";

            // 2. Define the process environment
            string programToRun = "cmd.exe";

            // Use /c (Execute and Close) so the CMD window closes after the 'pause' command is satisfied
            string arguments = $"/c \"{batchFileName}\"";

            try
            {
                // Start the process, allowing the command window to be visible
                ProcessStartInfo startInfo = new ProcessStartInfo(programToRun, arguments);
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;

                Process.Start(startInfo);

                MessageBox.Show("Stutter and FPS (AGGRESSIVE) script has been launched. Please check the command window for completion ", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Resinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void networkTweaks_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action (the new chooser script)
            string batchFileName = "LunchboxTweaks\\network_chooser.bat";

            // 2. Define the process environment
            string programToRun = "cmd.exe";

            // Use /c (Execute and Close) so the CMD window closes after the script exits
            string arguments = $"/c \"{batchFileName}\"";

            try
            {
                // Start the process, allowing the command window to be visible for the menu
                ProcessStartInfo startInfo = new ProcessStartInfo(programToRun, arguments);
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;

                Process.Start(startInfo);

                MessageBox.Show("Network Tweaks script has been launched. Please check the command window for completion ", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void performanceModeAdvanced_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "LunchboxTweaks\\cleanup_advanced.bat";

            // 2. Define the process environment
            string programToRun = "cmd.exe";

            // Use /c (Execute and Close) so the CMD window closes after the 'pause' command is satisfied
            string arguments = $"/c \"{batchFileName}\"";

            try
            {
                // Start the process, allowing the command window to be visible
                ProcessStartInfo startInfo = new ProcessStartInfo(programToRun, arguments);
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;

                Process.Start(startInfo);

                MessageBox.Show("Cleanup / Performance Mode (Advanced) script has been launched. Please check the command window for completion ", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fortniteConfigTweaks_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "LunchboxTweaks\\fortnite_config.bat";

            // 2. Define the process environment
            string programToRun = "cmd.exe";

            // Use /c (Execute and Close) so the CMD window closes after the 'pause' command is satisfied
            string arguments = $"/c \"{batchFileName}\"";

            try
            {
                // Start the process, allowing the command window to be visible
                ProcessStartInfo startInfo = new ProcessStartInfo(programToRun, arguments);
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;

                Process.Start(startInfo);

                MessageBox.Show("Fortnite Config Tweaks script has been launched. Please check the command window for completion ", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void applyAllTweaks_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action (the new master script)
            string batchFileName = "LunchboxTweaks\\apply_all_tweaks.bat";

            // 2. Define the process environment
            string programToRun = "cmd.exe";

            // Use /c (Execute and Close) so the CMD window closes after the final 'pause' is satisfied
            string arguments = $"/c \"{batchFileName}\"";

            try
            {
                // Start the process, allowing the command window to be visible
                ProcessStartInfo startInfo = new ProcessStartInfo(programToRun, arguments);
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;

                Process.Start(startInfo);

                MessageBox.Show("Apply All Tweaks script has been launched. Please check the command window for completion ", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName}: {ex.Message} Try to Reinstall this Program.", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetAdvancedTweaks_Click(object sender, EventArgs e)
        {
            // --- STEP 1: Confirmation Prompt ---
            DialogResult result = MessageBox.Show(
                "WARNING: This will reset services and registry keys to the state recorded BEFORE the advanced tweaks were applied. Are you absolutely sure you want to proceed?",
                "Confirm Advanced Tweak Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2 // Default to 'No' for safety
            );

            // Only run the script if the user clicks YES
            if (result == DialogResult.Yes)
            {
                // --- STEP 2: Launch Script (Only if confirmed) ---
                string batchFileName = "LunchboxTweaks\\reset_advanced_tweaks.bat";
                string programToRun = "cmd.exe";
                string arguments = $"/c \"{batchFileName}\"";

                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(programToRun, arguments);
                    startInfo.CreateNoWindow = false;
                    startInfo.UseShellExecute = true;

                    Process.Start(startInfo);

                    MessageBox.Show("Reset Advanced Tweaks script has been launched. Please check the command window for completion ", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // User clicked No or closed the dialog
                MessageBox.Show("Advanced Tweak Reset cancelled by user.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void resetAllTweaks_Click(object sender, EventArgs e)
        {
            // --- STEP 1: Confirmation Prompt ---
            DialogResult result = MessageBox.Show(
                "WARNING: This will reset all applied tweaks (registry, network, services) to their recorded backup state or Windows defaults. Are you ABSOLUTELY sure you want to proceed?",
                "Confirm Master Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, // Use Error icon for a severe warning
                MessageBoxDefaultButton.Button2 // Default to 'No' for safety
            );

            // Only run the script if the user clicks YES
            if (result == DialogResult.Yes)
            {
                // --- STEP 2: Launch Script (Only if confirmed) ---
                string batchFileName = "LunchboxTweaks\\reset_all_tweaks.bat";
                string programToRun = "cmd.exe";
                string arguments = $"/c \"{batchFileName}\"";

                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(programToRun, arguments);
                    startInfo.CreateNoWindow = false;
                    startInfo.UseShellExecute = true;

                    Process.Start(startInfo);

                    MessageBox.Show("Master Reset script has been launched. Please check the command window for completion ", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error running {batchFileName} Try Reinstalling this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // User clicked No or closed the dialog
                MessageBox.Show("Master Reset cancelled by user.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void credits_Click(object sender, EventArgs e)
        {
            // Assemble the credits and information text
            string creditsText =
                "LUNCHBOX Fortnite Tweaks\n\n" +
                "Code created by: LUNCHBOX.\n" +
                "UI created by: AGENTINFINITY2.\n\n" +
                "You are using Version 0.0.8 of this software.\n\n" +
                "DISCLAIMER:\n" +
                "Use of this software is at your own risk. System changes (registry, services) are backed up by the Revert Advanced Tweaks button, but always create a system restore point before running any system tweaker.";

            // Show the information in a standard Windows message box
            MessageBox.Show(
                creditsText,
                "Application Credits & Disclaimer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information // Use the Information icon
            );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // --- STEP 1: Confirmation Prompt ---
            DialogResult result = MessageBox.Show(
                "WARNING: This will restart your PC!",
                "Are you sure you want to contiune?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, // Use Error icon for a severe warning
                MessageBoxDefaultButton.Button2 // Default to 'No' for safety
            );

            // Only run the script if the user clicks YES
            if (result == DialogResult.Yes)
            {
                // --- STEP 2: Launch Script (Only if confirmed) ---
                string batchFileName = "LunchboxTweaks\\restart_pc.bat";
                string programToRun = "cmd.exe";
                string arguments = $"/c \"{batchFileName}\"";

                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(programToRun, arguments);
                    startInfo.CreateNoWindow = false;
                    startInfo.UseShellExecute = true;

                    Process.Start(startInfo);

                    MessageBox.Show("Your PC will restart soon! ", "Script Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error running {batchFileName} Try Reinstalling this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // User clicked No or closed the dialog
                MessageBox.Show("PC failed to restart!", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void otherTweaks_Click(object sender, EventArgs e)
        {
            string setupFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OtherTweaks");
            string setupScriptPath = Path.Combine(setupFolderPath, "Setup.bat");

            // 1. Check if the file exists just in case (optional, but good practice)
            if (!File.Exists(setupScriptPath))
            {
                MessageBox.Show("Error: Setup.bat file not found in the 'OtherTweaks' folder.",
                                "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Execute the existing Setup.bat file and wait for it to finish.
            // The batch file's internal logic will handle checking if setup is already complete.
            try
            {
                // ExecuteBatchFile waits for the script to finish (or exit quickly)
                ExecuteBatchFile(setupScriptPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to run Setup.bat: {ex.Message}", "Setup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Open the Tweaks Form immediately after the script finishes.

            // Replace the following lines with your actual code to open the new form:
            // OtherTweaksForm tweaksForm = new OtherTweaksForm();
            // tweaksForm.Show();
            // this.Hide();
        }
    }
}


