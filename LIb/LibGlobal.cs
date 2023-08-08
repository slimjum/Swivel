using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelLIb
{
    public static class LibGlobal
    {
        public static string? WorkingDir = null;

        public static string Dir
        {
            get
            {
                if (WorkingDir != null)
                    return WorkingDir;

                return @$"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\My Games\TotalMiner\Swivel";
            }
        }

        public static string Ext => ".Swivel";

        public static string ConfigPath => @$"{Dir}\{SwahiliConfigFileName}";

        public static string SwahiliConfigFileName => @"Swivel.json";

        public static string SwapperConfigFileName => @"SwapperConfig.json";

        public static string? CurrentPack
        {
            get
            {
                if (SwivelConfig == null)
                    return null;

                return SwivelConfig.CurrentPack;
            }
        }

        public static SwapperConfig? SwapperConfig
        {
            get
            {
                var path = @$"{LibGlobal.CurrentPackDir}\{LibGlobal.SwapperConfigFileName}";

                if (!File.Exists(path) || File.ReadAllText(LibGlobal.ConfigPath).Length == 0)
                    return null;

                return JsonConvert.DeserializeObject<SwapperConfig>(File.ReadAllText(path), LibGlobal.SerializerSettings);
            }
        }

        public static SwivelConfig? SwivelConfig
        {
            get
            {
                if (Directory.GetDirectories(LibGlobal.Dir).Length == 0)
                    return null;

                if (!File.Exists(LibGlobal.ConfigPath) || File.ReadAllText(LibGlobal.ConfigPath).Length == 0)
                    return null;

                var r = JsonConvert.DeserializeObject<SwivelConfig>(File.ReadAllText(LibGlobal.ConfigPath), LibGlobal.SerializerSettings);
                if (!Directory.Exists($@"{LibGlobal.Dir}\{r.CurrentPack}"))
                    return null;

                return r;
            }
        }

        public static string CurrentPackDir => @$"{Dir}\{CurrentPack}";

        public static JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            MissingMemberHandling = MissingMemberHandling.Ignore,
        };
    }
}
