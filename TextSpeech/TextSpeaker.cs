using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;

namespace TextSpeech
{  
    //TODO: research how to change the theme of a visual studio applacation.
    
    [ComVisible(true)]
    public class TextSpeaker : ApplicationContext
    {
        NotifyIcon notifyIcon;
        static SpeechSynthesizer synth;
        const int VOLUME = 5;
        const int RATE  = 5;
        Keys customkey;
        SettingsForm customizeForm;
        string clipBoard;
        List<String> voices;

        public int Volume {
            get { return synth.Volume / 10; }
            set { synth.Volume = value * 10; }  
        }
        public int Rate { get => synth.Rate; set => synth.Rate = value; }
        public static SpeechSynthesizer Synth { get => synth; set => synth = value; }
        public Keys Customkey { get => customkey; set => customkey = value; }
        public string Voice
        {
            get => synth.Voice.Name.ToString();
            set
            {
                synth.SelectVoice(value);
            }
        }
        public string ClipBoard { get => clipBoard; set => clipBoard = value; }
        public List<string> Voices { get => voices; set => voices = value; }
        
        public TextSpeaker()
        {
            
            this.customkey = Keys.F8;
               
            
            Init();
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));
            MenuItem openMenuItem = new MenuItem("Settings", new EventHandler(OpenSettings));

            notifyIcon = new NotifyIcon();
            notifyIcon.MouseDown += new MouseEventHandler(notifyIcon_MouseDown);
            notifyIcon.Icon = TextSpeech.Properties.Resources.icon1;
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { openMenuItem });
            notifyIcon.ContextMenu.MenuItems.Add(exitMenuItem);
            notifyIcon.Visible = true;
            notifyIcon.Text = "Press F8 for Speech";



        }

        private void OpenSettings(object sender, EventArgs e)
        {
            customizeForm = new SettingsForm();
            customizeForm.Visible = true;
        }

        private void notifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SayText();
            }
        }
        public void SayText()
        {
            clipBoard = "array";

            if (Clipboard.ContainsText())
            {
                clipBoard = Clipboard.GetText();
            }
            else
            {
                clipBoard = "Man what did you do you ain't got no text here.";
            }
            
            synth.SpeakAsyncCancelAll();
            synth.SpeakAsync(clipBoard);

        }

        internal void Saytext()
        {
            //TODO:Fix redundent Saytext Method
            clipBoard = "array";

            if (Clipboard.ContainsText())
            {
                clipBoard = Clipboard.GetText();
            }
            else
            {
                clipBoard = "Man what did you do you ain't got no text here.";
            }

            synth.SpeakAsyncCancelAll();
            synth.SpeakAsync(clipBoard);

        }

        private void Exit(object sender, EventArgs e)
        {

            //notifyIcon.Visible = false;

            Application.Exit();
        }
        private void Init() {
            //initialize the Synthesizer
            synth = new SpeechSynthesizer();
            this.Volume = VOLUME;
            this.Rate = RATE;
            voices = new List<string>();
            //For debugging
            foreach (InstalledVoice voice in synth.GetInstalledVoices())
            {
                voices.Add(voice.VoiceInfo.Name);
            }            
            synth.SelectVoice( voices.ElementAt(0));
            

        }
       
    }

}
