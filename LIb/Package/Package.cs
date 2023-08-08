using System.Collections.Generic;
using System.IO;

namespace SwivelLIb.Package
{
    public class Package
    {
        private static string Dir => LibGlobal.Dir;

        public string Path { get; set; }

        public string Name { get; set; } = "New_Package";

        public string Description { get; set; } = string.Empty;

        public List<string> files { get; set; } = new List<string>();

        public Package() { }

        public Package(string _name, string _path = null) : this(_name, _path, string.Empty) { }

        public Package(string _name, string _path, string _description)
        {
            if (_path == null)
                Path = @$"{Dir}\{_name}";

            Name = _name;
            Description = _description;

            foreach (var file in Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories))
            {
                files.Add(file.Replace(Path, string.Empty));
            }
        }


        public void Save(string name = null, string path = null)
        {
            PackageHandler.WriteFile(this, path);
        }
    }
}