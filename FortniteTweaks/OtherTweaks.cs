using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
