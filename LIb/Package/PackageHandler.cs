using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SwivelLIb.Package
{
    public static class PackageHandler
    {
        public static Package Load(string folder)
        {
            var dir = new DirectoryInfo(folder);
            var r = new Package()
            {
                Path = folder,
                Name = Path.GetFileName(dir.Name),
                files = new List<string>(),
            };

            foreach (var file in dir.GetFiles("*.*", SearchOption.AllDirectories).Where(f => f.Attributes != FileAttributes.Directory))
            {
                r.files.Add(file.FullName.Replace(@$"{r.Path}\", string.Empty));
            }

            return r;
        }

        public static Package FromFile(string path)
        {
            var Reader = new BinaryReader(new FileStream(path, FileMode.Open));

            var r = new Package()
            {
                Name = Reader.ReadString(),
                Description = Reader.ReadString(),
                files = new List<string>(),
            };

            r.Path = @$"{LibGlobal.Dir}\{r.Name}";
            r.Path = r.Path.Replace(LibGlobal.Ext, string.Empty);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(r.Path);

            var length = Reader.ReadInt32();
            for (int i = 0; i < length; i++)
            {
                var namepath = Reader.ReadString();
                var size = Reader.ReadInt32();
                var relpath = @$"{r.Path}\{namepath}";

                if (size > 0)
                {
                    var context = string.Empty;
                    var dirs = new List<string>(namepath.Split(@"\").Where(s => s != namepath.Split(@"\").Last()));
                    context = r.Path;

                    for (int j = 0; j < dirs.Count; j++)
                    {
                        context += @$"\{dirs[j]}";

                        if (!Directory.Exists(context))
                            Directory.CreateDirectory(context);
                    }


                    File.WriteAllBytes(relpath, Reader.ReadBytes(size));
                }
            }

            Reader.Close();
            return r;
        }

        public static void WriteFile(Package package, string __name = null)
        {
            if (__name == null)
                __name = @$"{package.Path}{LibGlobal.Ext}";

            var Writer = new BinaryWriter(new FileStream(__name, FileMode.Create));

            Writer.Write(package.Name);
            Writer.Write(package.Description);
            Writer.Write(package.files.Count);
            foreach (var item in package.files)
            {
                Writer.Write(item);

                var info = new FileInfo(@$"{package.Path}\{item}");
                Writer.Write((int)info.Length);

                if (info.Length != 0)
                    Writer.Write(File.ReadAllBytes(info.FullName));
            }
            Writer.Flush();
            Writer.Close();
        }
    }
}
