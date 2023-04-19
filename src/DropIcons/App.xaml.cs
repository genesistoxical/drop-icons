using System;
using System.Windows;
using win_version_csharp;

namespace DropIcons
{
    /// <summary>
    /// Get info from Config.ini
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Config.CheckPath();
            Config.Language();

            if (WinVersion.GetVersion(out VersionInfo info))
            {
                Config.winvers = "Windows Version: " + info.Major;
                Console.WriteLine(Config.winvers);
            }

            InitializeComponent();
            Config.GetTheme();
        }
    }
}
