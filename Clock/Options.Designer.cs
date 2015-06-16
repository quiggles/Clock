namespace Clock
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxRmbrScreenPos = new System.Windows.Forms.CheckBox();
            this.labelRmbrScreenPos = new System.Windows.Forms.Label();
            this.labelSoundOnHour = new System.Windows.Forms.Label();
            this.checkBoxSoundOnHour = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelHourSoundName = new System.Windows.Forms.Label();
            this.textBoxHourSoundName = new System.Windows.Forms.TextBox();
            this.buttonHourSoundName = new System.Windows.Forms.Button();
            this.buttonRevert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxRmbrScreenPos
            // 
            this.checkBoxRmbrScreenPos.AutoSize = true;
            this.checkBoxRmbrScreenPos.Location = new System.Drawing.Point(140, 41);
            this.checkBoxRmbrScreenPos.Name = "checkBoxRmbrScreenPos";
            this.checkBoxRmbrScreenPos.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRmbrScreenPos.TabIndex = 0;
            this.checkBoxRmbrScreenPos.UseVisualStyleBackColor = true;
            // 
            // labelRmbrScreenPos
            // 
            this.labelRmbrScreenPos.AutoSize = true;
            this.labelRmbrScreenPos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRmbrScreenPos.Location = new System.Drawing.Point(6, 38);
            this.labelRmbrScreenPos.Name = "labelRmbrScreenPos";
            this.labelRmbrScreenPos.Size = new System.Drawing.Size(128, 17);
            this.labelRmbrScreenPos.TabIndex = 1;
            this.labelRmbrScreenPos.Text = "Remember Position?";
            // 
            // labelSoundOnHour
            // 
            this.labelSoundOnHour.AutoSize = true;
            this.labelSoundOnHour.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSoundOnHour.Location = new System.Drawing.Point(6, 64);
            this.labelSoundOnHour.Name = "labelSoundOnHour";
            this.labelSoundOnHour.Size = new System.Drawing.Size(101, 17);
            this.labelSoundOnHour.TabIndex = 3;
            this.labelSoundOnHour.Text = "Sound on hour?";
            // 
            // checkBoxSoundOnHour
            // 
            this.checkBoxSoundOnHour.AutoSize = true;
            this.checkBoxSoundOnHour.Location = new System.Drawing.Point(140, 67);
            this.checkBoxSoundOnHour.Name = "checkBoxSoundOnHour";
            this.checkBoxSoundOnHour.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSoundOnHour.TabIndex = 2;
            this.checkBoxSoundOnHour.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelHourSoundName
            // 
            this.labelHourSoundName.AutoSize = true;
            this.labelHourSoundName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHourSoundName.Location = new System.Drawing.Point(6, 92);
            this.labelHourSoundName.Name = "labelHourSoundName";
            this.labelHourSoundName.Size = new System.Drawing.Size(95, 17);
            this.labelHourSoundName.TabIndex = 4;
            this.labelHourSoundName.Text = "Sound to play?";
            // 
            // textBoxHourSoundName
            // 
            this.textBoxHourSoundName.Location = new System.Drawing.Point(140, 92);
            this.textBoxHourSoundName.Name = "textBoxHourSoundName";
            this.textBoxHourSoundName.Size = new System.Drawing.Size(223, 22);
            this.textBoxHourSoundName.TabIndex = 5;
            // 
            // buttonHourSoundName
            // 
            this.buttonHourSoundName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHourSoundName.Location = new System.Drawing.Point(369, 91);
            this.buttonHourSoundName.Name = "buttonHourSoundName";
            this.buttonHourSoundName.Size = new System.Drawing.Size(62, 23);
            this.buttonHourSoundName.TabIndex = 6;
            this.buttonHourSoundName.Text = "&Browse";
            this.buttonHourSoundName.UseVisualStyleBackColor = true;
            this.buttonHourSoundName.Click += new System.EventHandler(this.buttonHourSoundName_Click);
            // 
            // buttonRevert
            // 
            this.buttonRevert.Enabled = false;
            this.buttonRevert.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRevert.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonRevert.Location = new System.Drawing.Point(437, 92);
            this.buttonRevert.Name = "buttonRevert";
            this.buttonRevert.Size = new System.Drawing.Size(29, 23);
            this.buttonRevert.TabIndex = 7;
            this.buttonRevert.Text = "←";
            this.buttonRevert.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonRevert.UseVisualStyleBackColor = true;
            this.buttonRevert.Visible = false;
            this.buttonRevert.Click += new System.EventHandler(this.buttonRevert_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 261);
            this.Controls.Add(this.buttonRevert);
            this.Controls.Add(this.buttonHourSoundName);
            this.Controls.Add(this.textBoxHourSoundName);
            this.Controls.Add(this.labelHourSoundName);
            this.Controls.Add(this.labelSoundOnHour);
            this.Controls.Add(this.checkBoxSoundOnHour);
            this.Controls.Add(this.labelRmbrScreenPos);
            this.Controls.Add(this.checkBoxRmbrScreenPos);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxRmbrScreenPos;
        private System.Windows.Forms.Label labelRmbrScreenPos;
        private System.Windows.Forms.Label labelSoundOnHour;
        private System.Windows.Forms.CheckBox checkBoxSoundOnHour;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelHourSoundName;
        private System.Windows.Forms.TextBox textBoxHourSoundName;
        private System.Windows.Forms.Button buttonHourSoundName;
        private System.Windows.Forms.Button buttonRevert;
    }
}