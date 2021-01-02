using System;

using System.Windows.Input;

namespace TextSpeech
{
    public class KeyPressedArgs:EventArgs
    {
        public Key KeyPressed { get; private set; }
        public KeyPressedArgs(Key key)
        {
            KeyPressed = key;
        }
    }
}
