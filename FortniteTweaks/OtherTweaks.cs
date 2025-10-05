using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FortniteTweaks
{
    public partial class OtherTweaks : Form
    {
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
        // Imports for moving the window when the title bar is clicked
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Constants for the message flags
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public OtherTweaks()
        {
            InitializeComponent();
        }

        private void OtherTweaks_Load(object sender, EventArgs e)
        {

        }

        private void pnl1TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            // This code block allows the user to click and drag the window using the panel
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void win_telemetry_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "OtherTweaks\\win_telemetry.bat";

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
                MessageBox.Show($"Successfully ran {batchFileName}. Follow any on-screen instructions.", "Process Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void windowsIOTweaks_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "OtherTweaks\\win_io_tweaks.bat";

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
                MessageBox.Show($"Successfully ran {batchFileName}. Follow any on-screen instructions.", "Process Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void windowsPowerPlan_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "OtherTweaks\\win_power_plan.bat";

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
                MessageBox.Show($"Successfully ran {batchFileName}. Follow any on-screen instructions.", "Process Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void blockWindowsUpdates_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "OtherTweaks\\win_block_updates.bat";

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
                MessageBox.Show($"Successfully ran {batchFileName}. Follow any on-screen instructions.", "Process Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generalWindowsSettings_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "OtherTweaks\\win_general_settings.bat";

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
                MessageBox.Show($"Successfully ran {batchFileName}. Follow any on-screen instructions.", "Process Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void debloatWindows_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "OtherTweaks\\debloat_uninstall.bat";

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
                MessageBox.Show($"Successfully ran {batchFileName}. Follow any on-screen instructions.", "Process Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rebloatWindows_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "OtherTweaks\\debloat_reinstall.bat";

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
                MessageBox.Show($"Successfully ran {batchFileName}. Follow any on-screen instructions.", "Process Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void debloatStartup_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "OtherTweaks\\debloat_startup.bat";

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
                MessageBox.Show($"Successfully ran {batchFileName}. Follow any on-screen instructions.", "Process Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cpuTweaks_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "OtherTweaks\\cpu_tweaks.bat";

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
                MessageBox.Show($"Successfully ran {batchFileName}. Follow any on-screen instructions.", "Process Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cleanTempFiles_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "OtherTweaks\\clean_temp_files.bat";

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
                MessageBox.Show($"Successfully ran {batchFileName}. Follow any on-screen instructions.", "Process Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuKillTime_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "OtherTweaks\\misc_menukill.bat";

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
                MessageBox.Show($"Successfully ran {batchFileName}. Follow any on-screen instructions.", "Process Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void msiUtlity_Click(object sender, EventArgs e)
        {
            // 1. Define the specific batch file for this action
            string batchFileName = "OtherTweaks\\misc_msi_mode.bat";

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
                MessageBox.Show($"Successfully ran {batchFileName}. Follow any on-screen instructions.", "Process Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running {batchFileName} Try to Reinstall this Program.: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void i_Click(object sender, EventArgs e)
        {
            // List of applications that are uninstalled by the debloat script
            string debloatList =
                "--- Applications Uninstalled by Debloat Script ---\n\n" +
                "• 3D Builder\n" +
                "• Alarms and Clock\n" +
                "• Calendar and Mail\n" +
                "• Camera\n" +
                "• Groove Music\n" +
                "• Movies & TV\n" +
                "• OneNote\n" +
                "• People\n" +
                "• Photos\n" +
                "• Solitaire Collection\n" +
                "• Xbox app\n" +
                "• Xbox Game Bar\n" +
                "• Xbox Console Companion\n" +
                "• Paint 3D\n" +
                "• Your Phone\n" +
                "• Mixed Reality Portal";

            // Show the list in a message box
            MessageBox.Show(
                debloatList,
                "Debloating Target List",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void i2_Click(object sender, EventArgs e)
        {
            // List of applications that are uninstalled by the debloat script
            string debloatList =
                "--- Applications Reinstalled by Rebloat Script ---\n\n" +
                "• 3D Builder\n" +
                "• Alarms and Clock\n" +
                "• Calendar and Mail\n" +
                "• Camera\n" +
                "• Groove Music\n" +
                "• Movies & TV\n" +
                "• OneNote\n" +
                "• People\n" +
                "• Photos\n" +
                "• Solitaire Collection\n" +
                "• Xbox app\n" +
                "• Xbox Game Bar\n" +
                "• Xbox Console Companion\n" +
                "• Paint 3D\n" +
                "• Your Phone\n" +
                "• Mixed Reality Portal";

            // Show the list in a message box
            MessageBox.Show(
                debloatList,
                "Rebloating Target List",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void siticoneCloseButton1_Click(object sender, EventArgs e)
        {
            warrning.Visible = false;
            createRestorePoint.Visible = false;
        }

        private async void createRestorePoint_Click(object sender, EventArgs e)
        {
            // 1. Prepare UI and lock the button
            createRestorePoint.Enabled = false;
            progressBarRestore.Style = ProgressBarStyle.Blocks; // Use Blocks for percentage
            progressBarRestore.Minimum = 0;
            progressBarRestore.Maximum = 100;
            progressBarRestore.Value = 0;
            progressBarRestore.Visible = true;
            lblRestoreStatus.Visible = true;
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
                            MessageBox.Show($"Restore Point Failed. PowerShell exited with code {process.ExitCode}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    createRestorePoint.Enabled = true;
                    lblRestoreStatus.Visible = false;
                });
            }
        }

        private void hover(object sender, EventArgs e)
        {
            PlaySound("Sounds\\hover.wav");
        }

        private void apply(object sender, MouseEventArgs e)
        {
            PlaySound("Sounds\\apply.wav");
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            warrning.Visible = false;
            siticoneButton1.Visible = false;
            createRestorePoint.Visible = false;
            progressBarRestore.Visible = false;
            lblRestoreStatus.Visible = false;
        }
    }
}
