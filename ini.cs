using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace UNOSInterface
{
    class ini
    {
        public static string Path;
        public static string EXE = "uapi_token";

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public static void IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }

        public static string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public static void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public static void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public static void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public static bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }
    }
}
/*
// Creates or loads an INI file in the same directory as your executable
// named EXE.ini (where EXE is the name of your executable)
var MyIni = new IniFile();

// Or specify a specific name in the current dir
var MyIni = new IniFile("Settings.ini");

// Or specify a specific name in a specific dir
var MyIni = new IniFile(@"C:\Settings.ini");

//Write to ini file like this:
MyIni.Write("DefaultVolume", "100");
MyIni.Write("HomePage", "http://www.google.com");

//To read the values out of the INI file:
var DefaultVolume = MyIni.Read("DefaultVolume");
var HomePage = MyIni.Read("HomePage");

//Optionally, you can set [Section]'s:
MyIni.Write("DefaultVolume", "100", "Audio");
MyIni.Write("HomePage", "http://www.google.com", "Web");

//You can also check for the existence of a key like so:
if(!MyIni.KeyExists("DefaultVolume", "Audio"))
{
    MyIni.Write("DefaultVolume", "100", "Audio");
}

//You can delete a key like so:
MyIni.DeleteKey("DefaultVolume", "Audio");

//You can also delete a whole section (including all keys) like so:
MyIni.DeleteSection("Web");

 */