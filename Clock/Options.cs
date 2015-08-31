using System;
using System.Windows.Forms;

namespace Clock
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        void Options_Load(object sender, EventArgs e)
        {
            checkBoxRmbrScreenPos.Checked = Properties.Settings.Default.rememberScreenPosition;
            checkBoxSoundOnHour.Checked = Properties.Settings.Default.beepOnHour;
            textBoxHourSoundName.Text = Properties.Settings.Default.hourSound;
            checkBoxInt05.Checked = Properties.Settings.Default.int05;
            checkBoxInt10.Checked = Properties.Settings.Default.int10;
            checkBoxInt15.Checked = Properties.Settings.Default.int15;
            checkBoxInt20.Checked = Properties.Settings.Default.int20;
            checkBoxInt25.Checked = Properties.Settings.Default.int25;
            checkBoxInt30.Checked = Properties.Settings.Default.int30;
            checkBoxInt35.Checked = Properties.Settings.Default.int35;
            checkBoxInt40.Checked = Properties.Settings.Default.int40;
            checkBoxInt45.Checked = Properties.Settings.Default.int45;
            checkBoxInt50.Checked = Properties.Settings.Default.int50;
            checkBoxInt55.Checked = Properties.Settings.Default.int55;
            textBoxIntervalSoundName.Text = Properties.Settings.Default.intervalSound;
            checkBoxQuietHours.Checked = Properties.Settings.Default.quietTime;
            timeStart.Value = Properties.Settings.Default.quietStart;
            timeEnd.Value = Properties.Settings.Default.quietEnd;
        }

        void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.rememberScreenPosition = checkBoxRmbrScreenPos.Checked;
            Properties.Settings.Default.beepOnHour = checkBoxSoundOnHour.Checked;
            Properties.Settings.Default.hourSound = textBoxHourSoundName.Text;
            Properties.Settings.Default.int05 = checkBoxInt05.Checked;
            Properties.Settings.Default.int10 = checkBoxInt10.Checked;
            Properties.Settings.Default.int15 = checkBoxInt15.Checked;
            Properties.Settings.Default.int20 = checkBoxInt20.Checked;
            Properties.Settings.Default.int25 = checkBoxInt25.Checked;
            Properties.Settings.Default.int30 = checkBoxInt30.Checked;
            Properties.Settings.Default.int35 = checkBoxInt35.Checked;
            Properties.Settings.Default.int40 = checkBoxInt40.Checked;
            Properties.Settings.Default.int45 = checkBoxInt45.Checked;
            Properties.Settings.Default.int50 = checkBoxInt50.Checked;
            Properties.Settings.Default.int55 = checkBoxInt55.Checked;
            Properties.Settings.Default.intervalSound=textBoxIntervalSoundName.Text;
            Properties.Settings.Default.quietTime = checkBoxQuietHours.Checked;
            Properties.Settings.Default.quietStart = timeStart.Value;
            Properties.Settings.Default.quietEnd = timeEnd.Value;
            Properties.Settings.Default.Save(); // saved at C:\Users\USERNAME\AppData\Local\Clock
            Utilities.itsQuietTime = Utilities.isQuietTime(DateTime.Now);
        }

        void buttonHourSoundName_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "WAV Files (*.wav)|*.wav|MP3 Files (*.mp3)|*.mp3|WMA Files (*.wma)|*.wma";
            dialog.Multiselect = false;
            string input = Properties.Settings.Default.hourSound;
            input = input.Substring(0, input.LastIndexOf(@"\") + 1);
            dialog.InitialDirectory = @input;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxHourSoundName.Text = dialog.FileName;
                if (string.Compare(textBoxHourSoundName.Text, Properties.Settings.Default.hourSound, StringComparison.Ordinal) != 0)
                {
                    buttonHourSoundRevert.Visible = true;
                    buttonHourSoundRevert.Enabled = true;
                }

                Utilities.playSound(dialog.FileName);

            }
        }

        void buttonHourSoundRevert_Click(object sender, EventArgs e)
        {
            textBoxHourSoundName.Text = Properties.Settings.Default.hourSound;
            buttonHourSoundRevert.Visible = false;
            buttonHourSoundRevert.Enabled = false;
        }

        void buttonIntervalSoundRevert_Click(object sender, EventArgs e)
        {
            textBoxIntervalSoundName.Text = Properties.Settings.Default.intervalSound;
            buttonIntervalSoundRevert.Visible = false;
            buttonIntervalSoundRevert.Enabled = false;
        }

        void buttonIntervalSoundName_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "WAV Files (*.wav)|*.wav|MP3 Files (*.mp3)|*.mp3|WMA Files (*.wma)|*.wma";
            dialog.Multiselect = false;
            string input = Properties.Settings.Default.intervalSound;
            input = input.Substring(0, input.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
            dialog.InitialDirectory = @input;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxIntervalSoundName.Text = dialog.FileName;
                if (string.Compare(textBoxIntervalSoundName.Text, Properties.Settings.Default.intervalSound, StringComparison.Ordinal) != 0)
                {
                    buttonIntervalSoundRevert.Visible = true;
                    buttonIntervalSoundRevert.Enabled = true;
                }
                Utilities.playSound(dialog.FileName);
            }
        }

        void checkBoxQuietHours_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQuietHours.Checked)
            {
                timeStart.Enabled = true;
                timeEnd.Enabled = true;
            }
            else
            {
                timeStart.Enabled = false;
                timeEnd.Enabled = false;
            }
        }
    }
}
