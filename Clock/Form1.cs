using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            this.Close();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DateTime time = DateTime.Now;
            string theTime = time.ToLongTimeString();
            string hoursAndMins = theTime.Remove(5, 3);
            string seconds = theTime.Remove(0, 5);
            TextRenderer.DrawText(e.Graphics,
                          hoursAndMins,
                          new Font("Segoe UI", 75),
                          new Point(30, 30),
                          Color.White,
                          Color.DimGray);
            TextRenderer.DrawText(e.Graphics,
                          seconds,
                          new Font("Segoe UI", 75),
                          new Point(265, 30),
                          Color.RoyalBlue,
                          Color.DimGray);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
