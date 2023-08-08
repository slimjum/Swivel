using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelLIb
{
    public class SwapperConfig
    {
        public string PackName { get; set; } = string.Empty;

        public SwapType ActiveSwappers { get; set; } = SwapType.Video | SwapType.Music | SwapType.SoundEffect;

        public List<SwapperFile> swapperFiles { get; set; } = new List<SwapperFile>();

        public SwapperConfig(string _name)
        {
            PackName = _name;
        }

        public static SwapperConfig? ByName(string name)
        {
            if (Directory.GetDirectories(LibGlobal.Dir).Length == 0)
                return null;

            var path = $@"{LibGlobal.Dir}\{name}";
            if (!Directory.Exists(path))
                return null;

            path += @$"\{LibGlobal.SwapperConfigFileName}";
            if (!File.Exists(path))
                return null;

            return JsonConvert.DeserializeObject<SwapperConfig>(File.ReadAllText(path), LibGlobal.SerializerSettings);
        }

        public bool GetFile(string target, SwapType swapType, out string _Name, out string _RootDir)
        {
            _Name = string.Empty; _RootDir = string.Empty;

            if (!ActiveSwappers.HasFlag(swapType) || swapType == SwapType.NotSpecified)
                return false;

            if (!GetFiles(target, swapType, out var _Files, out var _RootDirs))
                return false;

            var index = new Random().Next(0, _Files.Length);
            _RootDir = _RootDirs[index]; _Name = _Files[index];
            return true;
        }

        public bool GetFiles(string target, SwapType swapType, out string[] _Files, out string[] _RootDirs)
        {
            var files = new List<string>();
            var _Names = new List<string>();
            var remove = new List<string>();
            var Temp_RootDirs = new List<string>();

            _Files = new string[0];
            _RootDirs = new string[0];

            if (!ActiveSwappers.HasFlag(swapType) || swapType == SwapType.NotSpecified)
                return false;

            foreach (var swapp in swapperFiles)
            {
                if (!File.Exists($@"{LibGlobal.Dir}\{PackName}\{swapp.path}"))
                {
                    remove.Add(swapp.path); continue;
                }
                if (!swapp.Enabled || swapp.SwapType != swapType)
                    continue;

                if (swapp.Triggers.Any(s => s.Target.ToLower() == target.ToLower()) || swapp.Triggers.Any(s => s.Target == "*") && swapp.SwapType == swapType)
                {
                    var triggers = swapp.Triggers.FindAll(t => t.Target.ToLower() == target.ToLower());
                    foreach (var trigger in triggers)
                    {
                        if (!trigger.Enabled)
                            continue;

                        if (trigger.chance == -1 || new Random().Next(0, 100) <= trigger.chance && !files.Contains(swapp.path))
                        {
                            files.Add(swapp.path);
                        }
                    }
                }
            }

            foreach (string path in remove)
            {
                swapperFiles.RemoveAll(s => s.path == path); files.Remove(path);
            }

            if (remove.Count > 0)
                Save();

            foreach (var item in files)
            {
                var File_path = $@"{LibGlobal.Dir}\{PackName}{item}";
                var Dir = File_path.Substring(0, File_path.LastIndexOf(@"\"));
                _Names.Add(item.Substring(item.LastIndexOf(@"\") + 1).Replace(".xnb", string.Empty));
                Temp_RootDirs.Add(Dir);
            }

            _RootDirs = Temp_RootDirs.ToArray(); _Files = _Names.ToArray();
            return _Files.Length != 0;
        }

        private SwapType FromPath(string path)
        {
            switch (path.Split(@"\").SkipLast(1).Reverse().ToArray().First())
            {
                case "Video": return SwapType.Video;
                case "Music": return SwapType.Music;
                case "Effects": return SwapType.SoundEffect;
                case "Textures": return SwapType.SoundEffect;
                default: return SwapType.NotSpecified;
                    //Todo: if swap \Effects fix Audio\Effects
            }
        }

        public void Update()
        {
            foreach (var item in Directory.GetFiles($@"{LibGlobal.Dir}\{PackName}", "*.xnb", SearchOption.AllDirectories))
            {
                var path = item.Replace(@$"{LibGlobal.Dir}\{PackName}", string.Empty);
                var swapType = FromPath(path);

                if (!swapperFiles.Any(s => s.path == path))
                {
                    swapperFiles.Add(new SwapperFile()
                    {
                        path = path,
                        Triggers = new List<Trigger>(),
                        SwapType = swapType,
                        Enabled = true,
                    });
                }

                var fix = swapperFiles.Find(s => s.path == path);
                if (fix.SwapType == SwapType.NotSpecified)
                    fix.SwapType = swapType;
            }

            var remove = new List<SwapperFile>();
            foreach (var swap in swapperFiles)
            {
                var path = @$"{LibGlobal.Dir}\{PackName}{swap.path}";

                if (File.Exists(path))
                    continue;

                remove.Add(swap);
            }
            remove.ForEach(swap => swapperFiles.Remove(swap));

            Save();
        }

        /// <summary>
        /// Behavior: Look For triggers that match Key.. Does not check with not path 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SwapperFile[]? this[string key]
        {
            //get => swapperFiles.Find(s => key.EndsWith(s.path));
            get => swapperFiles.FindAll(s => s.Triggers.Any(t => t.Target == key)).ToArray();
            set
            {
                //var index = Triggers.FindIndex(t => t.Target == key);
                //if (index == -1 || value == null)
                //    return;

                //Triggers[index] = value;
            }
        }

        public void Save() => File.WriteAllText(@$"{LibGlobal.Dir}\{PackName}\{LibGlobal.SwapperConfigFileName}", JsonConvert.SerializeObject(this, LibGlobal.SerializerSettings));
    }

    public class Trigger
    {
        public string Target { get; set; } = string.Empty;

        public sbyte chance { get; set; } = -1;

        public bool Enabled { get; set; } = true;

        public Trigger Clone()
        {
            return new Trigger()
            {
                chance = chance,
                Target = Target,
                Enabled = Enabled
            };
        }

        public override string ToString() => $"[{Enabled}]: {Path.GetFileNameWithoutExtension(Target)} - {chance}";
    }

    public class SwapperFile
    {
        public List<Trigger> Triggers { get; set; } = new List<Trigger>();

        public string path { get; set; } = string.Empty;

        public SwapType SwapType { get; set; } = SwapType.NotSpecified;

        public bool Enabled { get; set; } = true;

        public Trigger? this[string key]
        {
            get => Triggers.Find(t => key.EndsWith(t.Target));
            set
            {
                var index = Triggers.FindIndex(t => t.Target == key);
                if (index == -1 || value == null)
                    return;

                Triggers[index] = value;
            }
        }

        public SwapperFile Clone()
        {
            return new SwapperFile()
            {
                Enabled = Enabled,
                path = path,
                SwapType = SwapType,
                Triggers = Triggers.ToList(),
            };
        }

        public override string ToString() => $"{path} : {Triggers.Count}";
    }

    [Flags]
    public enum SwapType : byte
    {
        NotSpecified = 0,
        Video = 1,
        Music = 2,
        SoundEffect = 4,
    }
}
