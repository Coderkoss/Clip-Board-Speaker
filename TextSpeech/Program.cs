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
        public static TextSpeaker speaker;
        const int CSIDL_COMMON_STARTUP = 0x0018;
        const int CSIDL_STARTUP = 0x0018;

        [DllImport("shell32.dll")]
        static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [Out] StringBuilder lpszPath, int nFolder, bool fCreate);

        [STAThread]
        static void Main()
        {
            
            //_hookID = SetHook(_proc);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            speaker = new TextSpeaker();
            //check to see if the app.exe exist in the startup folder
            CreateStartupShortcut();
            Application.Run(speaker);
            //UnhookWindowsHookEx(_hookID);
            
          
        }
        #region sends app to startup folder
        public static string FindStartupFolder() 
        {
            String path;
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
            string shortcutPath = Application.StartupPath;
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, @"textSpeech" + ".lnk");

            //Create all users desktop shortcut for application settings
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.IconLocation = Application.StartupPath + @"\..\..\icon1.ico" ;
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
        #endregion
      
    }

  
    
}
