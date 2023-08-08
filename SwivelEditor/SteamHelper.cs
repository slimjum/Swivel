using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelEditor
{
    public static class SteamHelper
    {
        private static string SteamDir = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", string.Empty) as string;

        private static string Steamapps = @$"{SteamDir}\steamapps";

        private static string TargetFile = @$"{Steamapps}\libraryfolders.vdf";

        private static string[] LibraryFolders
        {
            get
            {
                var list = new List<string>();

                foreach (var item in File.ReadAllLines(TargetFile))
                {
                    if (!item.Contains(@$"{'"'}path{'"'}"))
                        continue;

                    list.Add(item.Replace("\t\t\"path\"\t\t", string.Empty).Replace("\"", string.Empty));
                }

                return list.ToArray();
            }
        }

        public static string FindGame(string game)
        {
            foreach (var item in LibraryFolders)
            {
                var path = @$"{item}\steamapps\common\{game}";
                if (Directory.Exists(path))
                    return path;
            }

            return string.Empty;
        }

    }
}
