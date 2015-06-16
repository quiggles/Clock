using System;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        public Form1()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            if (Properties.Settings.Default.rememberScreenPosition != null)
            {
                if (Properties.Settings.Default.rememberScreenPosition)
                {
                    this.Location = Properties.Settings.Default.screenPosition;
                }
                else
                {
                    positionScreen();
                }

            }
            else
            {
                if (Properties.Settings.Default.screenPosition != null)
                {
                    this.Location = Properties.Settings.Default.screenPosition;
                }
                else
                {
                    positionScreen();
                }
            }


        }

        private void positionScreen()
        {
            //http://stackoverflow.com/questions/18840381/start-form-in-top-right
            this.StartPosition = FormStartPosition.Manual;
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(this.Location))
                {
                    this.Location = new Point(scrn.Bounds.Right - this.Width, scrn.Bounds.Top);
                    return;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Form 1 click");
            this.Close();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) // draw the clock face
        {
            DateTime time = DateTime.Now;

            if (((time.Minute ==0) && (time.Second == 0)) && Properties.Settings.Default.beepOnHour)
            {
                Utilities.playSound(@Properties.Settings.Default.hourSound);
            }

            string theTime = time.ToLongTimeString();
            string hoursAndMins = theTime.Remove(5, 3);
            string seconds = theTime.Remove(0, 5);
            TextRenderer.DrawText(e.Graphics,
                          hoursAndMins,
                          new Font("Segoe UI Light", 75),
                          new Point(30, 30),
                          Color.White,
                          Color.DimGray);
            TextRenderer.DrawText(e.Graphics,
                          seconds,
                          new Font("Segoe UI Light", 75),
                          new Point(260, 30),
                          Color.RoyalBlue,
                          Color.DimGray);
        }


        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) // click and move the clock
        {
            // http://stackoverflow.com/questions/9823883/adding-a-right-click-menu-to-an-item
            switch (e.Button)
            {
                case MouseButtons.Left:
                    // http://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                    break;
                case MouseButtons.Right:
                    rightClickMenuStrip.Show(this, new Point(e.X, e.Y));//places the menu at the pointer position
                    break;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stuff and that...", "About");
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Stuff and that...", "Options");
            Options optionsForm = new Options();
            optionsForm.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show(e.CloseReason.ToString());
            Properties.Settings.Default.screenPosition = this.Location;
            Properties.Settings.Default.Save(); // saved at C:\Users\USERNAME\AppData\Local\Clock
        }

    }
}
