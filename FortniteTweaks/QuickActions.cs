using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FortniteTweaks
{
    public partial class QuickActions : Form
    {

        public QuickActions()
        {
            InitializeComponent();

            // Set the form to be borderless for the custom border to work
            this.FormBorderStyle = FormBorderStyle.None;
            // Set the background color (e.g., a dark theme)
            this.BackColor = Color.FromArgb(40, 40, 40);
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
        /// <summary>
        /// Creates a System Restore Point using WMI. Runs on a background thread.
        /// </summary>
        private async Task<bool> CreateRestorePointAsync(string description)
        {
            // The WMI class for System Restore
            // *** USE FQN HERE ***
            System.Management.ManagementScope scope = new System.Management.ManagementScope("\\\\.\\root\\default");
            System.Management.ManagementPath path = new System.Management.ManagementPath("SystemRestore");

            // The arguments for the CreateRestorePoint method
            object[] args = new object[] { description, 0x14, 0x64 };

            try
            {
                // 1. Get the WMI class definition
                // *** USE FQN HERE ***
                using (System.Management.ManagementClass sysRestore = new System.Management.ManagementClass(scope, path, null))
                {
                    // 2. Execute the CreateRestorePoint method
                    await Task.Run(() =>
                    {
                        sysRestore.InvokeMethod("CreateRestorePoint", args);
                    });

                    return true;
                }
            }
            catch (Exception ex)
            {
                // ... (rest of the catch block is unchanged)
                // ...
                return false;
            }
        }
        // ----------------------------------------------------------------------
        // 1. FIELDS AND CONSTANTS
        // ----------------------------------------------------------------------

        
        // --- Windows API Imports for Dragging the Borderless Form ---
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        // ----------------------------------------------------------------------
        // 2. CONSTRUCTOR AND INITIALIZATION
        // ----------------------------------------------------------------------
        

        // ----------------------------------------------------------------------
        // 4. BORDER DRAWING LOGIC
        // ----------------------------------------------------------------------
       
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
        private void KillFortniteProcess()
        {
            // The typical main process name for Fortnite (without the .exe extension)
            const string ProcessName = "FortniteClient-Win64-Shipping";

            try
            {
                // 1. Get all running processes with that name
                Process[] processes = Process.GetProcessesByName(ProcessName);

                if (processes.Length > 0)
                {
                    // 2. Iterate and kill each instance found
                    foreach (Process process in processes)
                    {
                        // Use Kill() for immediate termination
                        process.Kill();
                    }

                    // 3. Success message
                    MessageBox.Show(
                        "Fortnite process successfully closed!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    // Message if the game isn't running
                    MessageBox.Show(
                        "Fortnite is not currently running.",
                        "Process Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors (e.g., permission denied)
                MessageBox.Show(
                    $"Error closing Fortnite: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void hoverButton(object sender, EventArgs e)
        {
            PlaySound("Sounds\\hover.wav");
        }

        

        private void closeFortnite_Click(object sender, EventArgs e)
        {
            // STEP 1: Show the confirmation message box
            DialogResult result = MessageBox.Show(
                "Are you sure you want to close Fortnite?",
                "Confirm Closure",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // STEP 2: Check the result
            if (result == DialogResult.Yes)
            {
                // User clicked YES: Execute the kill function
                KillFortniteProcess();
            }
            else
            {
                // User clicked NO or closed the dialog
                MessageBox.Show(
                    "Fortnite closure aborted.",
                    "Aborted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void launchTweaks_Click(object sender, EventArgs e)
        {
            this.Hide();
            keyboardPack open = new keyboardPack();
            open.ShowDialog();
        }

        private void credits_Click(object sender, EventArgs e)
        {
            Info_Credits open = new Info_Credits();
            open.ShowDialog();
        }

        private async void btnCreateRestorePoint_Click(object sender, EventArgs e)
        {
            // Make sure you have controls named:
            // ProgressBar: progressBarRestore
            // Label: lblRestoreStatus

            // 1. Prepare the UI and lock the button
            btnCreateRestorePoint.Enabled = false;
            lblRestoreStatus.Visible = true;
            progressBarRestore.Style = ProgressBarStyle.Blocks; // Use Blocks for percentage
            progressBarRestore.Minimum = 0;
            progressBarRestore.Maximum = 100;
            progressBarRestore.Value = 0;
            progressBarRestore.Visible = true;
            lblRestoreStatus.Text = "Initiating System Restore Point (0% Completed)...";

            // The PowerShell command to create a restore point
            string psCommand = "Checkpoint-Computer -Description 'FortniteTweaks Backup' -RestorePointType 'MODIFY_SETTINGS'";

            // --- CRITICAL CHANGE: Use ProcessStartInfo for output redirection ---
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -NonInteractive -ExecutionPolicy Bypass -Command \"{psCommand}\"",

                // Settings required for reading the output stream:
                UseShellExecute = false,          // Must be false to redirect streams
                RedirectStandardOutput = true,    // Redirect the text output
                CreateNoWindow = true             // Hide the console window
            };

            try
            {
                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();

                    // 2. Start a background task to read the PowerShell output
                    await Task.Run(() =>
                    {
                        // This loop reads output line by line until the process closes
                        while (!process.StandardOutput.EndOfStream)
                        {
                            string line = process.StandardOutput.ReadLine();

                            if (!string.IsNullOrEmpty(line) && line.Contains("Completed"))
                            {
                                // 3. Parse the percentage from the line (e.g., "34% Completed")
                                int startIndex = line.IndexOf('(') + 1;
                                int endIndex = line.IndexOf('%');

                                if (endIndex > startIndex && startIndex > 0)
                                {
                                    string percentString = line.Substring(startIndex, endIndex - startIndex).Trim();
                                    if (int.TryParse(percentString, out int percentage))
                                    {
                                        // 4. Use Invoke to safely update the UI from the background thread
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            // Clamp the value to ensure it stays between 0 and 100
                                            progressBarRestore.Value = Math.Min(100, Math.Max(0, percentage));
                                            lblRestoreStatus.Text = $"Creating System Restore Point ({percentage}% Completed)...";
                                        });
                                    }
                                }
                            }
                        }
                    });

                    // Wait for the process to fully close after the output stream ends
                    process.WaitForExit();

                    // 5. Check the final exit code for success
                    if (process.ExitCode == 0)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            progressBarRestore.Value = 100;
                            lblRestoreStatus.Text = "Restore Point Created Successfully!";
                            MessageBox.Show("System Restore Point successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        });
                    }
                    else
                    {
                        // PowerShell exits with a non-zero code on failure
                        this.Invoke((MethodInvoker)delegate
                        {
                            lblRestoreStatus.Text = $"Restore Point Failed. (Exit Code: {process.ExitCode})";
                            MessageBox.Show($"Restore Point Failed. PowerShell exited with code {process.ExitCode}. Try turning System Protection on for your drive, or Restart your PC!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblRestoreStatus.Text = "CRITICAL FAILURE. See error details.";
                    MessageBox.Show($"Critical Error during PowerShell execution: {ex.Message}", "Restore Point Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
            finally
            {
                // 6. Cleanup the UI
                this.Invoke((MethodInvoker)delegate
                {
                    progressBarRestore.Visible = false;
                    progressBarRestore.Style = ProgressBarStyle.Blocks;
                    progressBarRestore.Value = 0;
                    btnCreateRestorePoint.Enabled = true;
                    lblRestoreStatus.Visible = false;
                });
            }
        }

        private void hoverDiscordButton(object sender, EventArgs e)
        {
            PlaySound("Sounds\\join-discord-server-hover.wav");
        }

        private void unhoverDiscordButton(object sender, EventArgs e)
        {
            PlaySound("Sounds\\join-discord-server-unhovered.wav");
        }

        private void joinDiscordServer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PlaySound("Sounds\\join-discord-server-hovered.wav");
        }

        private void apply(object sender, MouseEventArgs e)
        {
            PlaySound("Sounds\\apply.wav");
        }

        private void joinDiscord(object sender, EventArgs e)
        {
            const string DiscordInviteLink = "https://discord.gg/YourCustomInvite";

            // Open the link
            OpenWebLink(DiscordInviteLink);
        }
    }
}
