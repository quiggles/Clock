using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Clock
{
    public partial class Clock24 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public Clock24()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            if (Properties.Settings.Default.rememberScreenPosition)
            {
                this.Location = Properties.Settings.Default.screenPosition;
            }
            else
            {
                //positionScreen();
                this.Location = new Point(0, 0);
            }
            Utilities.itsQuietTime = Utilities.isQuietTime(DateTime.Now);
            
        }

        void positionScreen()
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

        void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        void Form1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Form 1 click"); // should never see this!
            this.Close();
        }

        void pictureBox1_Paint(object sender, PaintEventArgs e) // draw the clock face
        {
            DateTime time = DateTime.Now;
            string theTime = time.ToLongTimeString();
            string hoursAndMins = theTime.Remove(5, 3);
            string seconds = theTime.Remove(0, 5);
            int i1 = hoursAndMins.Count(x => x == '1'); // count the number of times the character 1 shows up

            //Console.WriteLine($"{TextRenderer.MeasureText("11:11", new Font("Segoe UI Light", 75))}");
            //Console.WriteLine($"{TextRenderer.MeasureText("11:12", new Font("Segoe UI Light", 75))}");
            //Console.WriteLine($"{TextRenderer.MeasureText("11:22", new Font("Segoe UI Light", 75))}");
            //Console.WriteLine($"{TextRenderer.MeasureText("12:00", new Font("Segoe UI Light", 75))}");
            //Console.WriteLine($"{TextRenderer.MeasureText("23:00", new Font("Segoe UI Light", 75))}");
            //{ Width = 223, Height = 133}
            //{ Width = 239, Height = 133}
            //{ Width = 255, Height = 133}
            //{ Width = 271, Height = 133}
            //{ Width = 287, Height = 133}    16 difference

            TextRenderer.DrawText(e.Graphics,
                            hoursAndMins,
                            new Font("Segoe UI Light", 75),
                            new Point(30+(i1*16), -36),
                            Color.White,
                            Color.DimGray);

            TextRenderer.DrawText(e.Graphics,
                          seconds,
                          new Font("Segoe UI Light", 75),
                          new Point(260, -36),
                          Color.RoyalBlue,
                          Color.DimGray);
            if (Utilities.itsQuietTime)
            {
                TextRenderer.DrawText(e.Graphics,
                                "Quiet Time",
                                new Font("Segoe UI Light", 8),
                                new Point(50, 70),
                                Color.Red,
                                Color.DimGray);
            }

            if (time.Second == 0) 
            {
                if (Utilities.isQuietTime(time))  // only want to check the quiet time once a minute
                {
                    TextRenderer.DrawText(e.Graphics,
                                    "Quiet Time",
                                    new Font("Segoe UI Light", 8),
                                    new Point(50, 70),
                                    Color.Red,
                                    Color.DimGray);
                }
                else
                {
                    timeForSound(time);
                }
            }
        }

        void timeForSound(DateTime timeSound)
        {
            if ((timeSound.Minute == 0) && Properties.Settings.Default.beepOnHour)
            {
                Utilities.playSound(@Properties.Settings.Default.hourSound);
            }
            else if (timeSound.Minute % 5 == 0)
            {
                foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
                {
                    int intValue = timeSound.Minute;
                    string intName = "00";
                    string intFieldName = "";

                    intName = intValue.ToString(intName); // Display the numbers using the ToString method.
                    intFieldName = "int" + intName;

                    if (currentProperty.Name == intFieldName)
                    {
                        if ((bool)Properties.Settings.Default[currentProperty.Name]) Utilities.playSound(@Properties.Settings.Default.intervalSound);
                        break;  // break out of foreach
                    }
                }
            }
        }

        void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) // click and move the clock
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

        void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Stuff and that...", "Options");
            Options optionsForm = new Options();
            optionsForm.ShowDialog();
        }

        void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show(e.CloseReason.ToString());
            Properties.Settings.Default.screenPosition = this.Location;
            Properties.Settings.Default.Save(); // saved at C:\Users\USERNAME\AppData\Local\Clock
        }

    }
}
