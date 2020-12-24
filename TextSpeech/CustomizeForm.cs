using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;

namespace TextSpeech
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void CustomizeForm_Load(object sender, EventArgs e)
        {
            CustomPlayTextbox.Text = Program.speaker.Customkey.ToString();
            volumeLabel.Text = "Volume:" + Program.speaker.Volume.ToString();
            speedRateLabel.Text = "Speed Rate:" + Program.speaker.Rate.ToString();
            volume_Trackbar.Value = Program.speaker.Volume;
            speed_Trackbar.Value = Program.speaker.Rate;

            foreach (String voice in Program.speaker.Voices)
            {
                synthVoices.Items.Add(voice);
            }
            synthVoices.Text = Program.speaker.Voice;
            
            
        }        
        private void volume_Trackbar_Scroll(object sender, EventArgs e)
        {
           Program.speaker.Volume = volume_Trackbar.Value;
           volumeLabel.Text = "Volume:" + Program.speaker.Volume.ToString();

        }
        private void speed_Trackbar_Scroll(object sender, EventArgs e)
        {
            Program.speaker.Rate = speed_Trackbar.Value;
            speedRateLabel.Text = "Speed Rate:" + Program.speaker.Rate.ToString();

        }        
        private void synthVoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.speaker.Voice = synthVoices.SelectedItem.ToString();
        } 
        private void CustomPlayTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CustomPlayTextbox.Text = "";
            Program.speaker.Customkey = (Keys)char.ToUpper(e.KeyChar);          

        }
       
    }
}
