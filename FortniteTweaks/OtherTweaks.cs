using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FortniteTweaks
{
    public partial class OtherTweaks : Form
    {
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
    }
}
