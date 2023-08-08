using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelLIb
{
    public class SwivelConfig
    {
        public string CurrentPack { get; set; } = string.Empty;

        public void Save() => File.WriteAllText(LibGlobal.ConfigPath, JsonConvert.SerializeObject(this, LibGlobal.SerializerSettings));
    }
}
