using System;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using IWshRuntimeLibrary;

namespace TextSpeech
{
    static class Program
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        public static TextSpeaker speaker;
        const int CSIDL_COMMON_STARTUP = 0x0018;
        const int CSIDL_STARTUP = 0x0018;

        [DllImport("shell32.dll")]
        static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [Out] StringBuilder lpszPath, int nFolder, bool fCreate);

        [STAThread]
        static void Main()
        {
            
            _hookID = SetHook(_proc);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            speaker = new TextSpeaker();
            //check to see if the app.exe exist in the startup folder
            CreateStartupShortcut();
            Application.Run(speaker);
            UnhookWindowsHookEx(_hookID);
            
          
        }
        
        public static string FindStartupFolder() 
        {
            String path;
            //SHGetSpecialFolderPath(IntPtr.Zero, path, CSIDL_COMMON_STARTUP, false);
            path = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            return path.ToString();
        }
        private static string getAppShortcutFileName() 
        {
            return Path.Combine(FindStartupFolder(), Application.ProductName) + ".lnk";
        }
        public static bool CheckStartupFileExist() 
        {
            return System.IO.File.Exists(getAppShortcutFileName());    
        }
        public static string Createlocalshortcut() 
        {
            //TODO: this method needs to be fixed
            string shortcutPath = Application.StartupPath;
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, @"textSpeech" + ".lnk");

            //Create all users desktop shortcut for application settings
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.IconLocation = @"icon1";
            shortcut.Description = "Description";
            shortcut.Save();

            return shortcutLocation;
            
        }
        public static bool CreateStartupShortcut() 
        {
            //Createlocalshortcut();
            bool retval = false;
            string shortcutName = Createlocalshortcut();
            FileInfo shortcutFile = new FileInfo(shortcutName);
            FileInfo destination = new FileInfo(getAppShortcutFileName());

            if (destination.Exists)
            {
                //run overwrite code
                retval = CopyShortcut(shortcutFile,destination);
            }
            else if (!shortcutFile.Exists)
            { 
                MessageBox.Show("Unable to RunOnStartup becasue the local shortcut cant be found.");
            }
            else
            {
                retval = CopyShortcut(shortcutFile,destination);
            }
                

            return retval; 
        }
        public static bool CopyShortcut(FileInfo src, FileInfo dest) 
        {
            bool retVal = false;
            try
            {
                //System.IO.File.Copy(src.FullName, dest.FullName, true); you need to run this to overwrite the file
                System.IO.File.Copy(src.FullName,dest.FullName);
                retVal = true;
            }
            catch (UnauthorizedAccessException authEX) 
            {
                MessageBox.Show(string.Format("UnauthorizedAccessException: {0}",authEX.Message), "Copy Shortcut", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Copy Shortcut", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return retVal;
        }
       /// <summary>
       /// This method sets up the windows hook for the keyboard proc
       /// </summary>
       /// <param name="proc"></param>
       /// <returns></returns>
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,GetModuleHandle(curModule.ModuleName), 0);
            }            
        }        
        private delegate IntPtr LowLevelKeyboardProc(int nCode,IntPtr wParam, IntPtr lParam);

        #region
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if ((Keys)vkCode == Program.speaker.Customkey)
                {
                    speaker.Saytext();                    
                }               
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,IntPtr wParam, IntPtr lParam);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);


    }
    #endregion

  
    
}
