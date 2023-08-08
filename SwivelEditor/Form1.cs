using SwivelLIb;
using SwivelLIb.Package;
using System.Diagnostics;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SwivelEditor;

using CmdDef = Dictionary<string, Action>;

public partial class Form1 : Form
{
    public SwivelConfig? SwivelConfig;

    public SwapperConfig? SwapperConfig;

    public SwapperFile? SwapperFile;

    public Trigger? Trigger;

    public List<string> PackFiles = new List<string>();

    public CmdDef TriggerCmds = new CmdDef();

    public CmdDef SwapFileCmds = new CmdDef();

    public CmdDef PackCmds = new CmdDef();

    private bool ModLoad = false;

    public Action<SwapperConfig>? Update;

    public Form1() { InitializeComponent(); }

    public Form1(SwapperConfig config, Action<SwapperConfig> action)
    {
        if (config != null)
        {
            SwapperConfig = config;
            ModLoad = true;
            Update = action;
        }

        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        //debug.. for editing untit test config
        //LibGlobal.WorkingDir = new DirectoryInfo(@"..\..\..\..\SwahiliTest\Swahili").FullName;

        AddTriggerCmds();
        AddSwapFileCmds();
        AddPackCmds();
        PackCmds.ToList().ForEach(c => ActionPackcomboBox.Items.Add(c.Key));
        SwapFileCmds.ToList().ForEach(c => ActionSwapFilecomboBox.Items.Add(c.Key));
        TriggerCmds.ToList().ForEach(c => ActionTriggercomboBox.Items.Add(c.Key));
        Enum.GetNames<SwapType>().ToList().ForEach(x => SwapTypecomboBox.Items.Add(x));

        if (SwivelConfig == null)
            SwivelConfig = LibGlobal.SwivelConfig;

        if (!Directory.Exists(LibGlobal.Dir))
            Directory.CreateDirectory(LibGlobal.Dir);

        if (SwivelConfig != null && !string.IsNullOrEmpty(SwivelConfig.CurrentPack))
            SwapperConfig = SwapperConfig.ByName(SwivelConfig.CurrentPack);

        if (SwapTypeCFomBox.Items.Count > -1)
            SwapTypeCFomBox.SelectedIndex = 0;

        foreach (var d in Directory.GetDirectories(LibGlobal.Dir))
        {
            if (SwivelConfig != null && SwapperConfig != null && Path.GetFileName(d) == SwapperConfig.PackName)
            {
                listBoxPacks.Items.Add(Path.GetFileName(d));
                var index = listBoxPacks.Items.IndexOf(Path.GetFileName(d));
                Debug.WriteLine(index);
                listBoxPacks.SelectedIndex = index;
                continue;
            }

            listBoxPacks.Items.Add(Path.GetFileName(d));
        }

        if (listBoxPacks.SelectedIndex != -1)
            return;

        if (listBoxPacks.Items.Count > 0 && SwapperConfig == null)
            listBoxPacks.SelectedIndex = 0;
    }

    private void AddPackCmds()
    {
        PackCmds.Add("Random Chance", () =>
        {
            foreach (var swaps in SwapperConfig.swapperFiles)
            {
                foreach (var swap in swaps.Triggers)
                {
                    if (swap.chance == -1)
                        continue;

                    swap.chance = (sbyte)new Random().Next(0, 100);
                }
            }
        });
    }

    private void AddSwapFileCmds()
    {
        SwapFileCmds.Add("All Songs", () =>
        {
            SwapperFile.Triggers.Clear();
            foreach (var item in Directory.GetFiles(@$"{SteamHelper.FindGame("Total Miner")}\Content\\Audio\Music", "*.xnb"))
            {
                SwapperFile.Triggers.Add(new Trigger()
                {
                    Target = Path.GetFileNameWithoutExtension(item),
                    chance = -1,
                });
            }
        });

        SwapFileCmds.Add("Random Chance", () =>
        {
            foreach (var item in SwapperFile.Triggers)
            {
                if (item.chance == -1)
                    continue;

                item.chance = (sbyte)new Random().Next(0, 100);
            }
        });

        SwapFileCmds.Add("Random X", () =>
        {
            if (SwapTypeCFomBox.SelectedIndex == -1 || string.IsNullOrEmpty(SwapTypeCFomBox.Text))
                return;

            var list = GetNames(SwapTypeCFomBox.Text);
            if (list.Length == 0)
                return;

            var index = new Random().Next(0, list.Length);

            if (TriggerComboBox.Items.Count >= 0)
                TriggerComboBox.Text = Path.GetFileNameWithoutExtension(list[index]);

            if (SwapperFile.Triggers.Any(s => s.Target == list[index]))
                return;

            SwapperFile.Triggers.Add(new Trigger()
            {
                Target = list[index],
                chance = -1,
            });

            listBoxTriggers.Items.Add(list[index]);
        });

        SwapFileCmds.Add("Show Missing Swaps", () =>
        {
            throw new NotImplementedException();
        });

        SwapFileCmds.Add("Simulate", () =>
        {
            var str = string.Empty;
            foreach (var item in SwapperFile.Triggers)
            {
                Enum.TryParse(SwapTypecomboBox.Text, out SwapType result);
                str += $"==={Path.GetFileNameWithoutExtension(item.Target)}===========\n";
                if (!SwapperConfig.GetFiles(item.Target, result, out var _Files, out var _))
                    return;

                foreach (var item2 in _Files)
                {
                    str += $"{Path.GetFileNameWithoutExtension(item2)}\n";
                }
            }
            MessageBox.Show(str);
        });
    }

    private void AddTriggerCmds()
    {
        TriggerCmds.Add("All Songs", () =>
        {
            SwapperFile.Triggers.Clear();
            foreach (var item in Directory.GetFiles(@$"{SteamHelper.FindGame("Total Miner")}\Content\\Audio\Music", "*.xnb"))
            {
                SwapperFile.Triggers.Add(new Trigger()
                {
                    Target = Path.GetFileNameWithoutExtension(item),
                    chance = -1,
                });
            }
        });

        TriggerCmds.Add("Clear", () =>
        {
            SwapperFile.Triggers.Clear();
            listBoxTriggers.Items.Clear();
        });

        TriggerCmds.Add("Random X", () =>
        {
            if (SwapTypeCFomBox.SelectedIndex == -1 || string.IsNullOrEmpty(SwapTypeCFomBox.Text))
                return;

            var list = GetNames(SwapTypeCFomBox.Text);
            if (list.Length == 0)
                return;

            if (TriggerComboBox.Items.Count >= 0)
                TriggerComboBox.Text = Path.GetFileNameWithoutExtension(list[0]);

            var index = new Random().Next(0, list.Length);
            SwapperFile.Triggers.Add(new Trigger()
            {
                Target = list[index],
                chance = -1,
            });

            listBoxTriggers.Items.Add(list[index]);
        });

        TriggerCmds.Add("Random Chance", () =>
        {
            Trigger.chance = (sbyte)new Random().Next(0, 100);
        });

        TriggerCmds.Add("Show Missing Swaps", () =>
        {
            throw new NotImplementedException();
        });

        TriggerCmds.Add("Simulate", () =>
        {
            if (SwapperConfig == null)
                return;

            var str = string.Empty;
            Enum.TryParse(SwapTypecomboBox.Text, out SwapType result);
            if (!SwapperConfig.GetFiles(TriggerComboBox.Text, result, out var _Files, out var _))
                return;

            foreach (var item in _Files)
            {
                str += $"{Path.GetFileNameWithoutExtension(item)}\n";
            }
            MessageBox.Show(str);
        });
    }

    private void listBoxPacks_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SwapperConfig != null)
            SwapperConfig.Save();

        var list = listBoxPackFiles;
        PackFiles.Clear();
        list.Items.Clear();

        if (!ModLoad)
            SwapperConfig = SwapperConfig.ByName(listBoxPacks.Text);

        if (ModLoad)
            ModLoad = false;

        SwapperConfig.Update();

        if (Update != null)
            Update(SwapperConfig);

        if (SwapperConfig.swapperFiles.Count == -1)
            return;

        foreach (var item in SwapperConfig.swapperFiles)
        {
            PackFiles.Add(item.path);
            listBoxPackFiles.Items.Add($"{Path.GetFileName(item.path)} [{item.path.Split(@"\").SkipLast(1).Last()}]");
        }

        if (listBoxPackFiles.Items.Count >= 0)
            listBoxPackFiles.SelectedIndex = 0;

        MusiccheckBox.Checked = SwapperConfig.ActiveSwappers.HasFlag(SwapType.Music);
        VideocheckBox.Checked = SwapperConfig.ActiveSwappers.HasFlag(SwapType.Video);
        SoundEffectcheckBox.Checked = SwapperConfig.ActiveSwappers.HasFlag(SwapType.SoundEffect);
    }

    private void listBoxPackFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBoxPacks.SelectedIndex == -1)
            return;

        //Todo: fix trim str
        var swap = SwapperConfig.swapperFiles.Find(f => f.path == PackFiles[listBoxPackFiles.SelectedIndex]);

        if (swap == null)
            return;

        SwapperFile = swap;
        listBoxTriggers.Items.Clear();
        swap.Triggers.ForEach(t => listBoxTriggers.Items.Add(t.Target));

        if (swap.Triggers.Count() > 0)
            listBoxTriggers.SelectedIndex = 0;

        if (swap.Triggers.Count() == 0)
            TriggerBTN.Text = "Add";

        if (listBoxTriggers.Items.Count == -1)
            listBoxTriggers.SelectedIndex = 0;

        ActionSwapFilecheckBox_CheckedChanged(null, EventArgs.Empty);
    }

    private void listBoxTargetStrings_SelectedIndexChanged(object sender, EventArgs e)
    {
        Trigger = SwapperFile.Triggers.Find(t => t.Target == listBoxTriggers.Text);

        if (Trigger == null)
            return;

        TriggerComboBox.Text = listBoxTriggers.Text;
        TriggerBTN.Text = Trigger != null ? "Remove" : "Add";
        ChanceNumpad.Value = Trigger.chance;
        SwapTypecomboBox.Text = SwapperFile.SwapType.ToString();
        SwapTypeCFomBox.Text = SwapperFile.SwapType.ToString();

        ActioncheckBox_CheckedChanged(null, EventArgs.Empty);

        if (Update != null)
            Update(SwapperConfig);
    }

    public string[] GetNames(string type)
    {
        var root = @$"{SteamHelper.FindGame("Total Miner")}\Content";
        var path = string.Empty;

        switch (SwapTypeCFomBox.Text)
        {
            case "Effects": path = @$"{root}\Audio\Effects"; break;
            case "Video": path = @$"{root}\Video"; break;
            case "Textures": path = @$"{root}\Textures"; break;
            case "Music": path = @$"{root}\Audio\Music"; break;
        }

        var list = new List<string>();
        foreach (var item in Directory.GetFiles(path, "*.xnb"))
        {
            list.Add(Path.GetFileNameWithoutExtension(item));
        }

        return list.ToArray();
    }

    private void SwapTypeDropbox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SwapTypeCFomBox.SelectedIndex == -1 || string.IsNullOrEmpty(SwapTypeCFomBox.Text))
            return;

        TriggerComboBox.Items.Clear();
        var list = GetNames(SwapTypeCFomBox.Text);

        if (list.Length == 0)
            return;

        TriggerComboBox.Items.Add("*");
        TriggerComboBox.Items.AddRange(list);

        if (TriggerComboBox.Items.Count >= 0)
            TriggerComboBox.Text = list[0];
    }

    private void TriggerComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TriggerComboBox.SelectedIndex == -1 || string.IsNullOrEmpty(TriggerComboBox.Text))
            return;

        if (SwapperFile == null)
            return;

        if (Trigger == null)
        {
            TriggerBTN.Text = "Add";
            return;
        }

        TriggerBTN.Text = Trigger.Target == TriggerComboBox.Text ? "Remove" : "Add";
    }

    private void TriggerBTN_Click(object sender, EventArgs e)
    {
        if (TriggerBTN.Text == "Add")
        {
            SwapperFile.Triggers.Add(new Trigger()
            {
                Target = TriggerComboBox.Text,
                chance = -1,
            });
            listBoxTriggers.Items.Add(TriggerComboBox.Text);
            TriggerBTN.Text = "Remove";
        }
        else
        {
            listBoxTriggers.Items.Remove(TriggerComboBox.Text);
            SwapperFile.Triggers.RemoveAll(t => t.Target == TriggerComboBox.Text);
            TriggerBTN.Text = "Add";
        }

        if (Update != null)
            Update(SwapperConfig);
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        Trigger.chance = (sbyte)ChanceNumpad.Value;
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (SwapperConfig != null)
            SwapperConfig.Save();

        if (Update != null)
            Update(SwapperConfig);

        if (SwivelConfig != null)
            SwivelConfig.Save();
    }

    private void listBoxTriggers_KeyDown(object sender, KeyEventArgs e)
    {
        if (listBoxTriggers.SelectedIndex == -1)
            return;

        if (listBoxTriggers.Items.Count == 0)
            return;

        if (Trigger == null)
            return;

        if (e.KeyCode == Keys.T)
        {
            Trigger.Enabled = !Trigger.Enabled;
            Debug.WriteLine($"[{Trigger.Enabled}]: {Trigger.Target}");
        }

        if (e.KeyCode == Keys.Delete)
        {
            SwapperFile.Triggers.RemoveAll(t => t.Target == listBoxTriggers.Text);
            listBoxTriggers.Items.RemoveAt(listBoxTriggers.SelectedIndex);
        }
    }


    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SwapperFile == null)
            return;

        if (string.IsNullOrEmpty(SwapTypecomboBox.Text))
            return;

        if (Enum.TryParse(SwapTypecomboBox.Text, out SwapType result))
            SwapperFile.SwapType = result;

        if (Update != null)
            Update(SwapperConfig);
    }

    private void ActioncomboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ActionTriggewrcheckBox.Checked = false;
    }

    private void ActioncheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (!ActionTriggewrcheckBox.Checked || ActionTriggercomboBox.SelectedIndex == -1)
            return;

        if (!TriggerCmds.TryGetValue(ActionTriggercomboBox.Text, out Action action))
            return;

        action();
    }

    private void ActionSwapFilecheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (!ActionSwapFilecheckBox.Checked || listBoxPackFiles.SelectedIndex == -1)
            return;

        if (!SwapFileCmds.TryGetValue(ActionSwapFilecomboBox.Text, out Action action))
            return;

        action();
    }

    private void ActionSwapFilecomboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ActionSwapFilecheckBox.Checked = false;
    }

    private void exportToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listBoxPackFiles.SelectedIndex == -1)
            return;

        foreach (var d in Directory.GetDirectories(LibGlobal.Dir))
        {
            if (listBoxPacks.Text == Path.GetFileName(d))
            {
                using (SaveFileDialog saveFile = new SaveFileDialog())
                {
                    saveFile.InitialDirectory = LibGlobal.Dir;
                    saveFile.RestoreDirectory = true;
                    saveFile.Filter = $"Swahili Files |*{LibGlobal.Ext}";
                    saveFile.Title = LibGlobal.Ext.Replace('.', ' ');
                    saveFile.FileName = Path.GetFileName(d);

                    if (saveFile.ShowDialog() != DialogResult.OK)
                        return;

                    var pgk = PackageHandler.Load(d);
                    pgk.Save(saveFile.FileName);

                }
            }
        }
    }

    private void importToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog fileDialog = new OpenFileDialog())
        {
            fileDialog.InitialDirectory = LibGlobal.Dir;
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = $"Swahili Files |*{LibGlobal.Ext}";
            fileDialog.Title = LibGlobal.Ext.Replace('.', ' ');

            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            var r = PackageHandler.FromFile(fileDialog.FileName);
            listBoxPacks.Items.Add(r.Name);
        }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listBoxPacks.SelectedIndex == -1)
            return;

        //SwahiliConfig.Save();
        SwapperConfig.Save();

        if (Update != null)
            Update(SwapperConfig);
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listBoxPackFiles.SelectedIndex == -1)
            return;

        throw new NotImplementedException();
    }

    private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listBoxPackFiles.SelectedIndex == -1)
            return;

        throw new NotImplementedException();
    }

    private void setAsMainToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listBoxPacks.SelectedIndex == -1)
            return;

        var r = LibGlobal.SwivelConfig;
        r.CurrentPack = listBoxPacks.Text;
        r.Save();
    }

    private void ActionPackcheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (!ActionPackcheckBox.Checked || listBoxPackFiles.SelectedIndex == -1)
            return;

        if (!PackCmds.TryGetValue(ActionPackcomboBox.Text, out Action action))
            return;

        action();
    }

    private void ActionPackcomboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ActionPackcheckBox.Checked = false;
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void updateToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listBoxPackFiles.SelectedIndex == -1)
            return;

        if (SwapperConfig == null)
            return;

        SwapperConfig.Update();
    }

    private void VideocheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (SwapperConfig == null)
            return;

        if (VideocheckBox.Checked)
        {
            SwapperConfig.ActiveSwappers |= SwapType.Video;
        }
        else
        {
            SwapperConfig.ActiveSwappers ^= SwapType.Video;
        }

        SwapperConfig.Save();

        if (Update != null)
            Update(SwapperConfig);
    }

    private void MusiccheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (SwapperConfig == null)
            return;

        if (MusiccheckBox.Checked)
        {
            SwapperConfig.ActiveSwappers |= SwapType.Music;
        }
        else
        {
            SwapperConfig.ActiveSwappers ^= SwapType.Music;
        }

        SwapperConfig.Save();

        if (Update != null)
            Update(SwapperConfig);
    }

    private void SoundEffectcheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (SwapperConfig == null)
            return;

        if (SoundEffectcheckBox.Checked)
        {
            SwapperConfig.ActiveSwappers |= SwapType.SoundEffect;
        }
        else
        {
            SwapperConfig.ActiveSwappers ^= SwapType.SoundEffect;
        }

        SwapperConfig.Save();

        if (Update != null)
            Update(SwapperConfig);
    }

    private void listBoxPackFiles_KeyDown(object sender, KeyEventArgs e)
    {
        if (listBoxPackFiles.SelectedIndex == -1)
            return;

        if (listBoxPackFiles.Items.Count == 0)
            return;

        if (SwapperFile == null)
            return;

        if (e.KeyCode == Keys.T)
        {
            SwapperFile.Enabled = !SwapperFile.Enabled;
            Debug.WriteLine($"[{SwapperFile.Enabled}]: {Path.GetFileNameWithoutExtension(SwapperFile.path)}");
        }

        if (e.KeyCode == Keys.Delete)
        {
            SwapperConfig.swapperFiles.RemoveAll(s => s.path == SwapperFile.path);
            listBoxTriggers.Items.RemoveAt(listBoxPackFiles.SelectedIndex);
        }
    }
}
