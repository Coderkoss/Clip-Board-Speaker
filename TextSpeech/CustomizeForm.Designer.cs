namespace TextSpeech
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.volumeLabel = new System.Windows.Forms.Label();
            this.speedRateLabel = new System.Windows.Forms.Label();
            this.customKey = new System.Windows.Forms.Label();
            this.voiceSynth = new System.Windows.Forms.Label();
            this.CustomPlayTextbox = new System.Windows.Forms.TextBox();
            this.synthVoices = new System.Windows.Forms.ComboBox();
            this.volume_Trackbar = new System.Windows.Forms.TrackBar();
            this.speed_Trackbar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.volume_Trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_Trackbar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.BackColor = System.Drawing.Color.Transparent;
            this.volumeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.volumeLabel.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.volumeLabel.Location = new System.Drawing.Point(119, 189);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(75, 21);
            this.volumeLabel.TabIndex = 0;
            this.volumeLabel.Text = "Volume:";
            // 
            // speedRateLabel
            // 
            this.speedRateLabel.AutoSize = true;
            this.speedRateLabel.BackColor = System.Drawing.Color.Transparent;
            this.speedRateLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.speedRateLabel.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedRateLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.speedRateLabel.Location = new System.Drawing.Point(83, 130);
            this.speedRateLabel.Name = "speedRateLabel";
            this.speedRateLabel.Size = new System.Drawing.Size(102, 21);
            this.speedRateLabel.TabIndex = 0;
            this.speedRateLabel.Text = "Speed Rate:";
            // 
            // customKey
            // 
            this.customKey.AutoSize = true;
            this.customKey.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.customKey.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customKey.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.customKey.Location = new System.Drawing.Point(38, 22);
            this.customKey.Name = "customKey";
            this.customKey.Size = new System.Drawing.Size(145, 21);
            this.customKey.TabIndex = 0;
            this.customKey.Text = "Custom Play Key:";
            // 
            // voiceSynth
            // 
            this.voiceSynth.AutoSize = true;
            this.voiceSynth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.voiceSynth.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voiceSynth.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.voiceSynth.Location = new System.Drawing.Point(119, 60);
            this.voiceSynth.Name = "voiceSynth";
            this.voiceSynth.Size = new System.Drawing.Size(66, 21);
            this.voiceSynth.TabIndex = 0;
            this.voiceSynth.Text = "Voices:";
            // 
            // CustomPlayTextbox
            // 
            this.CustomPlayTextbox.BackColor = System.Drawing.Color.White;
            this.CustomPlayTextbox.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomPlayTextbox.Location = new System.Drawing.Point(8, 22);
            this.CustomPlayTextbox.Name = "CustomPlayTextbox";
            this.CustomPlayTextbox.Size = new System.Drawing.Size(100, 26);
            this.CustomPlayTextbox.TabIndex = 2;
            this.CustomPlayTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomPlayTextbox_KeyDown);
            this.CustomPlayTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomPlayTextbox_KeyPress);
            // 
            // synthVoices
            // 
            this.synthVoices.BackColor = System.Drawing.Color.White;
            this.synthVoices.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.synthVoices.FormattingEnabled = true;
            this.synthVoices.Location = new System.Drawing.Point(8, 59);
            this.synthVoices.Name = "synthVoices";
            this.synthVoices.Size = new System.Drawing.Size(206, 25);
            this.synthVoices.TabIndex = 4;
            this.synthVoices.Text = "Microsoft Zira Desktop ";
            this.synthVoices.SelectedIndexChanged += new System.EventHandler(this.synthVoices_SelectedIndexChanged);
            // 
            // volume_Trackbar
            // 
            this.volume_Trackbar.Location = new System.Drawing.Point(8, 176);
            this.volume_Trackbar.Name = "volume_Trackbar";
            this.volume_Trackbar.Size = new System.Drawing.Size(104, 45);
            this.volume_Trackbar.TabIndex = 5;
            this.volume_Trackbar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.volume_Trackbar.Scroll += new System.EventHandler(this.volume_Trackbar_Scroll);
            // 
            // speed_Trackbar
            // 
            this.speed_Trackbar.Location = new System.Drawing.Point(8, 118);
            this.speed_Trackbar.Name = "speed_Trackbar";
            this.speed_Trackbar.Size = new System.Drawing.Size(104, 45);
            this.speed_Trackbar.TabIndex = 5;
            this.speed_Trackbar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.speed_Trackbar.Scroll += new System.EventHandler(this.speed_Trackbar_Scroll);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.customKey);
            this.panel1.Controls.Add(this.voiceSynth);
            this.panel1.Controls.Add(this.volumeLabel);
            this.panel1.Controls.Add(this.speedRateLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 384);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.speed_Trackbar);
            this.panel2.Controls.Add(this.volume_Trackbar);
            this.panel2.Controls.Add(this.CustomPlayTextbox);
            this.panel2.Controls.Add(this.synthVoices);
            this.panel2.Location = new System.Drawing.Point(198, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 384);
            this.panel2.TabIndex = 7;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(595, 253);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.CustomizeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.volume_Trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_Trackbar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.Label speedRateLabel;
        private System.Windows.Forms.Label customKey;
        private System.Windows.Forms.Label voiceSynth;
        private System.Windows.Forms.TextBox CustomPlayTextbox;
        private System.Windows.Forms.ComboBox synthVoices;
        private System.Windows.Forms.TrackBar volume_Trackbar;
        private System.Windows.Forms.TrackBar speed_Trackbar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}