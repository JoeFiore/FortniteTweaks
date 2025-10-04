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
using System.Media;
using System.Threading.Tasks;
using Siticone.UI.WinForms;
using System.Net;

namespace FortniteTweaks
{
    public partial class KeySystemUI : Form
    {
        // A list to hold all the possible websites (UPDATED with your new links)
        private List<string> websites = new List<string>
    {
        "https://link-center.net/1406111/VVEK4FqJrVMv"
        // Ensure all URLs start with http:// or https://
    };

        // A single Random object instance (kept from the previous step)
        private Random random = new Random();
        // Inside your Form class

        private void PlaySound(string soundFileName)
        {
            // 1. Launch a new Task to handle the playback.
            Task.Run(() =>
            {
                // The SoundPlayer instance is new and exists only within this Task,
                // preventing any interference from other calls.
                SoundPlayer player = new SoundPlayer();

                try
                {
                    // Set the sound location
                    player.SoundLocation = soundFileName;

                    // 2. Load the sound file completely in the background.
                    // This prevents any delay on the UI or in the *start* of the sound.
                    player.Load();

                    // 3. Play the sound asynchronously. This returns immediately,
                    // but since it's in a separate Task, it doesn't block *anything* // and plays independent of other sounds.
                    player.Play();

                    // NOTE: You cannot reliably wait for an asynchronous Play() in 
                    // a Task. If you need to dispose of the player after it's done,
                    // you'd typically track the Player object, but for simple hover 
                    // sounds, letting the garbage collector handle the short-lived 
                    // instance after the sound finishes is usually fine.

                }
                catch (Exception ex)
                {
                    // Log any errors if the file is not found
                    System.Diagnostics.Debug.WriteLine($"Error playing sound: {ex.Message}");
                }
            });
        }
        // These constants are the Windows messages we need to send
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        // This imports the necessary Windows function
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public KeySystemUI()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button was pressed
            if (e.Button == MouseButtons.Left)
            {
                // 1. Tell Windows to release any mouse capture (important for smooth dragging)
                ReleaseCapture();

                // 2. Send the message to the form (this.Handle) that a non-client area (HT_CAPTION) 
                //    was clicked with the left button (WM_NCLBUTTONDOWN).
                //    This tricks Windows into starting the drag operation.
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button was pressed
            if (e.Button == MouseButtons.Left)
            {
                // 1. Tell Windows to release any mouse capture (important for smooth dragging)
                ReleaseCapture();

                // 2. Send the message to the form (this.Handle) that a non-client area (HT_CAPTION) 
                //    was clicked with the left button (WM_NCLBUTTONDOWN).
                //    This tricks Windows into starting the drag operation.
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            PlaySound("join-discord-server-hovered.wav");
            // Define the URL you want to open
            string url = "https://discord.gg/CdR6KVSpYv"; // Example: Your Discord link

            // Optionally, you can add a try-catch block for robust error handling
            try
            {
                // Use Process.Start to launch the default browser with the specified URL
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

        private void siticoneButton1_MouseEnter(object sender, EventArgs e)
        {
            {
                // The sound file path/name
                PlaySound("join-discord-server-hover.wav");
            }
        }

        private void siticoneButton1_MouseLeave(object sender, EventArgs e)
        {
            {
                // The sound file path/name
                PlaySound("join-discord-server-unhovered.wav");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            PlaySound("apply.wav");
            this.Close();
        }

        private void closeButton_MouseHover(object sender, EventArgs e)
        {

        }

        private void minimizeButton_MouseEnter(object sender, EventArgs e)
        {
            // The sound file path/name
            PlaySound("hover.wav");
        }

        private void minimizeButton_MouseClick(object sender, MouseEventArgs e)
        {
            PlaySound("apply.wav");
        }

        private void minimizeButton_MouseClick1(object sender, MouseEventArgs e)
        {
            PlaySound("apply.wav");
            this.WindowState = FormWindowState.Minimized;
        }

        private void KeySystemUI_Load(object sender, EventArgs e)
        {

        }

        private void siticoneButton2_MouseEnter(object sender, EventArgs e)
        {
            PlaySound("hover.wav");
        }

        private void siticoneButton2_MouseClick(object sender, MouseEventArgs e)
        {
            PlaySound("apply.wav");
        }

        private void keyTextBox_TextChanged(object sender, EventArgs e)
        {
            PlaySound("keyboardclick.wav");
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            // 1. Determine the range for the random number (from 0 up to, but not including, the list count)
            int maxIndex = websites.Count;

            // 2. Generate a random index
            int randomIndex = random.Next(0, maxIndex);

            // 3. Get the randomly chosen URL
            string selectedUrl = websites[randomIndex];

            try
            {
                Process.Start(new ProcessStartInfo(selectedUrl) { UseShellExecute = true });
                string message =
            "The Key site is opening in your browser!\n\n" +
            "Follow the Linkvertise AND don't download anything!\n" +
            "The code should be given to you as text not as a file or anything like that.\n\n" +
            "After that come back and type that key into here!";

                string title = "Retrieve Key!";

                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Handle case where the browser can't be launched or the URL is malformed
                MessageBox.Show($"Could not open website!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            string gettext = keyTextBox.Text;
            int gettext_amount = gettext.Length;

            if (gettext_amount > 29)
            {
                WebClient wc = new WebClient();
                string ks = wc.DownloadString("https://raw.githubusercontent.com/JoeFiore/FortniteTweaks/refs/heads/master/Key%20System");

                if (ks.Contains(keyTextBox.Text))
                {
                    //true side
                    this.Hide();
                    keyboardPack mainPage = new keyboardPack();
                    mainPage.Show();
                }
                else
                {
                    //false side
                    MessageBox.Show("Invalid Key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (gettext_amount < 29)
                {
                    {
                        //false side
                        MessageBox.Show("Invalid Key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void keyTextBox_Click(object sender, EventArgs e)
        {

        }
    }
}
