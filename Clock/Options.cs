using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            checkBoxRmbrScreenPos.Checked = Properties.Settings.Default.rememberScreenPosition;
            checkBoxSoundOnHour.Checked = Properties.Settings.Default.beepOnHour;
            textBoxHourSoundName.Text = Properties.Settings.Default.hourSound;            
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.rememberScreenPosition = checkBoxRmbrScreenPos.Checked;
            Properties.Settings.Default.beepOnHour = checkBoxSoundOnHour.Checked;
            Properties.Settings.Default.hourSound = textBoxHourSoundName.Text;
            Properties.Settings.Default.Save(); // saved at C:\Users\USERNAME\AppData\Local\Clock
        }

        private void buttonHourSoundName_Click(object sender, EventArgs e)
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
                if (string.Compare( textBoxHourSoundName.Text, Properties.Settings.Default.hourSound)!=0)
                {
                    buttonRevert.Visible = true;
                    buttonRevert.Enabled = true;
                }

                Utilities.playSound(dialog.FileName);

            }
        }

        private void buttonRevert_Click(object sender, EventArgs e)
        {
            textBoxHourSoundName.Text = Properties.Settings.Default.hourSound;
            buttonRevert.Visible = false;
            buttonRevert.Enabled = false;
        }
    }
}
