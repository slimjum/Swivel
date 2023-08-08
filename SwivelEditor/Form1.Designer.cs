namespace SwivelEditor;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        PackcontextMenuStrip = new ContextMenuStrip(components);
        newToolStripMenuItem = new ToolStripMenuItem();
        saveToolStripMenuItem = new ToolStripMenuItem();
        testToolStripMenuItem = new ToolStripMenuItem();
        deleteToolStripMenuItem = new ToolStripMenuItem();
        setAsMainToolStripMenuItem = new ToolStripMenuItem();
        exportToolStripMenuItem = new ToolStripMenuItem();
        importToolStripMenuItem = new ToolStripMenuItem();
        updateToolStripMenuItem = new ToolStripMenuItem();
        listBoxPackFiles = new ListBox();
        SwapTypeCFomBox = new ComboBox();
        panel1 = new Panel();
        label5 = new Label();
        SwapTypecomboBox = new ComboBox();
        ChanceNumpad = new NumericUpDown();
        label1 = new Label();
        TriggerBTN = new Button();
        TriggerComboBox = new ComboBox();
        listBoxTriggers = new ListBox();
        ActionTriggewrcheckBox = new CheckBox();
        ActionTriggercomboBox = new ComboBox();
        label2 = new Label();
        panel3 = new Panel();
        panel2 = new Panel();
        ActionSwapFilecheckBox = new CheckBox();
        ActionSwapFilecomboBox = new ComboBox();
        label3 = new Label();
        listBoxPacks = new ListBox();
        panel4 = new Panel();
        ActionPackcheckBox = new CheckBox();
        ActionPackcomboBox = new ComboBox();
        label4 = new Label();
        VideocheckBox = new CheckBox();
        MusiccheckBox = new CheckBox();
        SoundEffectcheckBox = new CheckBox();
        label6 = new Label();
        panel5 = new Panel();
        PackcontextMenuStrip.SuspendLayout();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)ChanceNumpad).BeginInit();
        panel3.SuspendLayout();
        panel2.SuspendLayout();
        panel4.SuspendLayout();
        panel5.SuspendLayout();
        SuspendLayout();
        // 
        // PackcontextMenuStrip
        // 
        PackcontextMenuStrip.BackColor = SystemColors.AppWorkspace;
        PackcontextMenuStrip.Items.AddRange(new ToolStripItem[] { newToolStripMenuItem, saveToolStripMenuItem, testToolStripMenuItem, deleteToolStripMenuItem, setAsMainToolStripMenuItem, exportToolStripMenuItem, importToolStripMenuItem, updateToolStripMenuItem });
        PackcontextMenuStrip.Name = "contextMenuStrip1";
        PackcontextMenuStrip.Size = new Size(137, 180);
        // 
        // newToolStripMenuItem
        // 
        newToolStripMenuItem.BackColor = SystemColors.AppWorkspace;
        newToolStripMenuItem.Name = "newToolStripMenuItem";
        newToolStripMenuItem.Size = new Size(136, 22);
        newToolStripMenuItem.Text = "New";
        newToolStripMenuItem.Click += newToolStripMenuItem_Click;
        // 
        // saveToolStripMenuItem
        // 
        saveToolStripMenuItem.BackColor = SystemColors.AppWorkspace;
        saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        saveToolStripMenuItem.Size = new Size(136, 22);
        saveToolStripMenuItem.Text = "Save";
        saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
        // 
        // testToolStripMenuItem
        // 
        testToolStripMenuItem.BackColor = SystemColors.AppWorkspace;
        testToolStripMenuItem.Name = "testToolStripMenuItem";
        testToolStripMenuItem.Size = new Size(136, 22);
        testToolStripMenuItem.Text = "Rename";
        testToolStripMenuItem.Click += RenameToolStripMenuItem_Click;
        // 
        // deleteToolStripMenuItem
        // 
        deleteToolStripMenuItem.BackColor = SystemColors.AppWorkspace;
        deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
        deleteToolStripMenuItem.Size = new Size(136, 22);
        deleteToolStripMenuItem.Text = "Delete";
        deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
        // 
        // setAsMainToolStripMenuItem
        // 
        setAsMainToolStripMenuItem.BackColor = SystemColors.AppWorkspace;
        setAsMainToolStripMenuItem.Name = "setAsMainToolStripMenuItem";
        setAsMainToolStripMenuItem.Size = new Size(136, 22);
        setAsMainToolStripMenuItem.Text = "Set As Main";
        setAsMainToolStripMenuItem.Click += setAsMainToolStripMenuItem_Click;
        // 
        // exportToolStripMenuItem
        // 
        exportToolStripMenuItem.BackColor = SystemColors.AppWorkspace;
        exportToolStripMenuItem.Name = "exportToolStripMenuItem";
        exportToolStripMenuItem.Size = new Size(136, 22);
        exportToolStripMenuItem.Text = "Export";
        exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
        // 
        // importToolStripMenuItem
        // 
        importToolStripMenuItem.BackColor = SystemColors.AppWorkspace;
        importToolStripMenuItem.Name = "importToolStripMenuItem";
        importToolStripMenuItem.Size = new Size(136, 22);
        importToolStripMenuItem.Text = "Import";
        importToolStripMenuItem.Click += importToolStripMenuItem_Click;
        // 
        // updateToolStripMenuItem
        // 
        updateToolStripMenuItem.BackColor = SystemColors.AppWorkspace;
        updateToolStripMenuItem.Name = "updateToolStripMenuItem";
        updateToolStripMenuItem.Size = new Size(136, 22);
        updateToolStripMenuItem.Text = "Update";
        updateToolStripMenuItem.Click += updateToolStripMenuItem_Click;
        // 
        // listBoxPackFiles
        // 
        listBoxPackFiles.BackColor = SystemColors.AppWorkspace;
        listBoxPackFiles.FormattingEnabled = true;
        listBoxPackFiles.ItemHeight = 15;
        listBoxPackFiles.Location = new Point(3, 49);
        listBoxPackFiles.Name = "listBoxPackFiles";
        listBoxPackFiles.Size = new Size(294, 364);
        listBoxPackFiles.TabIndex = 1;
        listBoxPackFiles.SelectedIndexChanged += listBoxPackFiles_SelectedIndexChanged;
        listBoxPackFiles.KeyDown += listBoxPackFiles_KeyDown;
        // 
        // SwapTypeCFomBox
        // 
        SwapTypeCFomBox.BackColor = SystemColors.AppWorkspace;
        SwapTypeCFomBox.DropDownStyle = ComboBoxStyle.DropDownList;
        SwapTypeCFomBox.FormattingEnabled = true;
        SwapTypeCFomBox.Items.AddRange(new object[] { "Textures", "Video", "Effects", "Music" });
        SwapTypeCFomBox.Location = new Point(3, 3);
        SwapTypeCFomBox.Name = "SwapTypeCFomBox";
        SwapTypeCFomBox.Size = new Size(81, 23);
        SwapTypeCFomBox.TabIndex = 12;
        SwapTypeCFomBox.SelectedIndexChanged += SwapTypeDropbox_SelectedIndexChanged;
        // 
        // panel1
        // 
        panel1.BackColor = SystemColors.AppWorkspace;
        panel1.BorderStyle = BorderStyle.FixedSingle;
        panel1.Controls.Add(label5);
        panel1.Controls.Add(SwapTypecomboBox);
        panel1.Controls.Add(ChanceNumpad);
        panel1.Controls.Add(label1);
        panel1.Controls.Add(TriggerBTN);
        panel1.Controls.Add(TriggerComboBox);
        panel1.Controls.Add(SwapTypeCFomBox);
        panel1.Location = new Point(546, 287);
        panel1.Name = "panel1";
        panel1.Size = new Size(245, 132);
        panel1.TabIndex = 11;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.BackColor = SystemColors.AppWorkspace;
        label5.Location = new Point(17, 65);
        label5.Name = "label5";
        label5.Size = new Size(62, 15);
        label5.TabIndex = 18;
        label5.Text = "SwapType:";
        // 
        // SwapTypecomboBox
        // 
        SwapTypecomboBox.BackColor = SystemColors.AppWorkspace;
        SwapTypecomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        SwapTypecomboBox.FormattingEnabled = true;
        SwapTypecomboBox.Location = new Point(84, 61);
        SwapTypecomboBox.Name = "SwapTypecomboBox";
        SwapTypecomboBox.Size = new Size(150, 23);
        SwapTypecomboBox.TabIndex = 17;
        SwapTypecomboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // ChanceNumpad
        // 
        ChanceNumpad.BackColor = SystemColors.AppWorkspace;
        ChanceNumpad.Location = new Point(72, 89);
        ChanceNumpad.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        ChanceNumpad.Name = "ChanceNumpad";
        ChanceNumpad.Size = new Size(120, 23);
        ChanceNumpad.TabIndex = 16;
        ChanceNumpad.ValueChanged += numericUpDown1_ValueChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.BackColor = SystemColors.AppWorkspace;
        label1.Location = new Point(13, 93);
        label1.Name = "label1";
        label1.Size = new Size(53, 15);
        label1.TabIndex = 15;
        label1.Text = "Chance: ";
        // 
        // TriggerBTN
        // 
        TriggerBTN.BackColor = SystemColors.AppWorkspace;
        TriggerBTN.Location = new Point(9, 32);
        TriggerBTN.Name = "TriggerBTN";
        TriggerBTN.Size = new Size(231, 23);
        TriggerBTN.TabIndex = 14;
        TriggerBTN.Text = "Not Set";
        TriggerBTN.UseVisualStyleBackColor = false;
        TriggerBTN.Click += TriggerBTN_Click;
        // 
        // TriggerComboBox
        // 
        TriggerComboBox.BackColor = SystemColors.AppWorkspace;
        TriggerComboBox.FormattingEnabled = true;
        TriggerComboBox.Location = new Point(90, 3);
        TriggerComboBox.Name = "TriggerComboBox";
        TriggerComboBox.Size = new Size(150, 23);
        TriggerComboBox.Sorted = true;
        TriggerComboBox.TabIndex = 13;
        TriggerComboBox.SelectedIndexChanged += TriggerComboBox_SelectedIndexChanged;
        TriggerComboBox.SelectedValueChanged += TriggerComboBox_SelectedIndexChanged;
        TriggerComboBox.TextChanged += TriggerComboBox_SelectedIndexChanged;
        // 
        // listBoxTriggers
        // 
        listBoxTriggers.BackColor = SystemColors.AppWorkspace;
        listBoxTriggers.FormattingEnabled = true;
        listBoxTriggers.ItemHeight = 15;
        listBoxTriggers.Location = new Point(4, 47);
        listBoxTriggers.Name = "listBoxTriggers";
        listBoxTriggers.Size = new Size(241, 229);
        listBoxTriggers.TabIndex = 12;
        listBoxTriggers.SelectedIndexChanged += listBoxTargetStrings_SelectedIndexChanged;
        listBoxTriggers.KeyDown += listBoxTriggers_KeyDown;
        // 
        // ActionTriggewrcheckBox
        // 
        ActionTriggewrcheckBox.AutoSize = true;
        ActionTriggewrcheckBox.BackColor = SystemColors.AppWorkspace;
        ActionTriggewrcheckBox.Location = new Point(203, 18);
        ActionTriggewrcheckBox.Name = "ActionTriggewrcheckBox";
        ActionTriggewrcheckBox.Size = new Size(41, 19);
        ActionTriggewrcheckBox.TabIndex = 2;
        ActionTriggewrcheckBox.Text = "Do";
        ActionTriggewrcheckBox.UseVisualStyleBackColor = false;
        ActionTriggewrcheckBox.CheckedChanged += ActioncheckBox_CheckedChanged;
        // 
        // ActionTriggercomboBox
        // 
        ActionTriggercomboBox.BackColor = SystemColors.AppWorkspace;
        ActionTriggercomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        ActionTriggercomboBox.FormattingEnabled = true;
        ActionTriggercomboBox.Location = new Point(12, 17);
        ActionTriggercomboBox.Name = "ActionTriggercomboBox";
        ActionTriggercomboBox.Size = new Size(182, 23);
        ActionTriggercomboBox.TabIndex = 1;
        ActionTriggercomboBox.SelectedIndexChanged += ActioncomboBox_SelectedIndexChanged;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.BackColor = SystemColors.AppWorkspace;
        label2.Location = new Point(95, 0);
        label2.Name = "label2";
        label2.Size = new Size(48, 15);
        label2.TabIndex = 14;
        label2.Text = "Triggers";
        // 
        // panel3
        // 
        panel3.BackColor = SystemColors.AppWorkspace;
        panel3.BorderStyle = BorderStyle.FixedSingle;
        panel3.Controls.Add(ActionTriggewrcheckBox);
        panel3.Controls.Add(listBoxTriggers);
        panel3.Controls.Add(ActionTriggercomboBox);
        panel3.Controls.Add(label2);
        panel3.Location = new Point(543, 0);
        panel3.Name = "panel3";
        panel3.Size = new Size(249, 281);
        panel3.TabIndex = 15;
        // 
        // panel2
        // 
        panel2.BackColor = SystemColors.AppWorkspace;
        panel2.BorderStyle = BorderStyle.FixedSingle;
        panel2.Controls.Add(ActionSwapFilecheckBox);
        panel2.Controls.Add(ActionSwapFilecomboBox);
        panel2.Controls.Add(label3);
        panel2.Controls.Add(listBoxPackFiles);
        panel2.Location = new Point(237, 1);
        panel2.Name = "panel2";
        panel2.Size = new Size(300, 418);
        panel2.TabIndex = 16;
        // 
        // ActionSwapFilecheckBox
        // 
        ActionSwapFilecheckBox.AutoSize = true;
        ActionSwapFilecheckBox.BackColor = SystemColors.AppWorkspace;
        ActionSwapFilecheckBox.Location = new Point(226, 21);
        ActionSwapFilecheckBox.Name = "ActionSwapFilecheckBox";
        ActionSwapFilecheckBox.Size = new Size(41, 19);
        ActionSwapFilecheckBox.TabIndex = 17;
        ActionSwapFilecheckBox.Text = "Do";
        ActionSwapFilecheckBox.UseVisualStyleBackColor = false;
        ActionSwapFilecheckBox.CheckedChanged += ActionSwapFilecheckBox_CheckedChanged;
        // 
        // ActionSwapFilecomboBox
        // 
        ActionSwapFilecomboBox.BackColor = SystemColors.AppWorkspace;
        ActionSwapFilecomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        ActionSwapFilecomboBox.FormattingEnabled = true;
        ActionSwapFilecomboBox.Location = new Point(35, 20);
        ActionSwapFilecomboBox.Name = "ActionSwapFilecomboBox";
        ActionSwapFilecomboBox.Size = new Size(182, 23);
        ActionSwapFilecomboBox.TabIndex = 16;
        ActionSwapFilecomboBox.SelectedIndexChanged += ActionSwapFilecomboBox_SelectedIndexChanged;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.BackColor = SystemColors.AppWorkspace;
        label3.Location = new Point(116, 0);
        label3.Name = "label3";
        label3.Size = new Size(61, 15);
        label3.TabIndex = 15;
        label3.Text = "Swap Files";
        // 
        // listBoxPacks
        // 
        listBoxPacks.BackColor = SystemColors.AppWorkspace;
        listBoxPacks.ContextMenuStrip = PackcontextMenuStrip;
        listBoxPacks.FormattingEnabled = true;
        listBoxPacks.ItemHeight = 15;
        listBoxPacks.Location = new Point(5, 48);
        listBoxPacks.Name = "listBoxPacks";
        listBoxPacks.Size = new Size(219, 364);
        listBoxPacks.TabIndex = 0;
        listBoxPacks.SelectedIndexChanged += listBoxPacks_SelectedIndexChanged;
        // 
        // panel4
        // 
        panel4.BackColor = SystemColors.AppWorkspace;
        panel4.BorderStyle = BorderStyle.FixedSingle;
        panel4.Controls.Add(ActionPackcheckBox);
        panel4.Controls.Add(ActionPackcomboBox);
        panel4.Controls.Add(label4);
        panel4.Controls.Add(listBoxPacks);
        panel4.Location = new Point(6, 2);
        panel4.Name = "panel4";
        panel4.Size = new Size(229, 417);
        panel4.TabIndex = 17;
        // 
        // ActionPackcheckBox
        // 
        ActionPackcheckBox.AutoSize = true;
        ActionPackcheckBox.BackColor = SystemColors.AppWorkspace;
        ActionPackcheckBox.Location = new Point(186, 19);
        ActionPackcheckBox.Name = "ActionPackcheckBox";
        ActionPackcheckBox.Size = new Size(41, 19);
        ActionPackcheckBox.TabIndex = 19;
        ActionPackcheckBox.Text = "Do";
        ActionPackcheckBox.UseVisualStyleBackColor = false;
        ActionPackcheckBox.CheckedChanged += ActionPackcheckBox_CheckedChanged;
        // 
        // ActionPackcomboBox
        // 
        ActionPackcomboBox.BackColor = SystemColors.AppWorkspace;
        ActionPackcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        ActionPackcomboBox.FormattingEnabled = true;
        ActionPackcomboBox.Location = new Point(5, 18);
        ActionPackcomboBox.Name = "ActionPackcomboBox";
        ActionPackcomboBox.Size = new Size(172, 23);
        ActionPackcomboBox.TabIndex = 18;
        ActionPackcomboBox.SelectedIndexChanged += ActionPackcomboBox_SelectedIndexChanged;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.BackColor = SystemColors.AppWorkspace;
        label4.Location = new Point(84, 0);
        label4.Name = "label4";
        label4.Size = new Size(37, 15);
        label4.TabIndex = 16;
        label4.Text = "Packs";
        // 
        // VideocheckBox
        // 
        VideocheckBox.AutoSize = true;
        VideocheckBox.BackColor = SystemColors.AppWorkspace;
        VideocheckBox.Location = new Point(108, 3);
        VideocheckBox.Name = "VideocheckBox";
        VideocheckBox.Size = new Size(56, 19);
        VideocheckBox.TabIndex = 18;
        VideocheckBox.Text = "Video";
        VideocheckBox.UseVisualStyleBackColor = false;
        VideocheckBox.CheckedChanged += VideocheckBox_CheckedChanged;
        // 
        // MusiccheckBox
        // 
        MusiccheckBox.AutoSize = true;
        MusiccheckBox.BackColor = SystemColors.AppWorkspace;
        MusiccheckBox.Location = new Point(164, 3);
        MusiccheckBox.Name = "MusiccheckBox";
        MusiccheckBox.Size = new Size(58, 19);
        MusiccheckBox.TabIndex = 19;
        MusiccheckBox.Text = "Music";
        MusiccheckBox.UseVisualStyleBackColor = false;
        MusiccheckBox.CheckedChanged += MusiccheckBox_CheckedChanged;
        // 
        // SoundEffectcheckBox
        // 
        SoundEffectcheckBox.AutoSize = true;
        SoundEffectcheckBox.BackColor = SystemColors.AppWorkspace;
        SoundEffectcheckBox.Location = new Point(225, 3);
        SoundEffectcheckBox.Name = "SoundEffectcheckBox";
        SoundEffectcheckBox.Size = new Size(90, 19);
        SoundEffectcheckBox.TabIndex = 20;
        SoundEffectcheckBox.Text = "SoundEffect";
        SoundEffectcheckBox.UseVisualStyleBackColor = false;
        SoundEffectcheckBox.CheckedChanged += SoundEffectcheckBox_CheckedChanged;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.BackColor = SystemColors.AppWorkspace;
        label6.Location = new Point(8, 4);
        label6.Name = "label6";
        label6.Size = new Size(96, 15);
        label6.TabIndex = 21;
        label6.Text = "Active Swappers:";
        // 
        // panel5
        // 
        panel5.BackColor = SystemColors.AppWorkspace;
        panel5.BorderStyle = BorderStyle.FixedSingle;
        panel5.Controls.Add(SoundEffectcheckBox);
        panel5.Controls.Add(label6);
        panel5.Controls.Add(VideocheckBox);
        panel5.Controls.Add(MusiccheckBox);
        panel5.Location = new Point(6, 421);
        panel5.Name = "panel5";
        panel5.Size = new Size(319, 22);
        panel5.TabIndex = 22;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.AppWorkspace;
        ClientSize = new Size(800, 450);
        Controls.Add(panel5);
        Controls.Add(panel4);
        Controls.Add(panel2);
        Controls.Add(panel3);
        Controls.Add(panel1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "Form1";
        Text = "Swahili Config Builder";
        FormClosing += Form1_FormClosing;
        Load += Form1_Load;
        PackcontextMenuStrip.ResumeLayout(false);
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)ChanceNumpad).EndInit();
        panel3.ResumeLayout(false);
        panel3.PerformLayout();
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        panel4.ResumeLayout(false);
        panel4.PerformLayout();
        panel5.ResumeLayout(false);
        panel5.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private ListBox listBoxPackFiles;
    private ComboBox SwapTypeCFomBox;
    private Panel panel1;
    private ListBox listBoxTriggers;
    private ComboBox TriggerComboBox;
    private Button TriggerBTN;
    private Label label1;
    private NumericUpDown ChanceNumpad;
    private Label label2;
    private Panel panel3;
    private CheckBox ActionTriggewrcheckBox;
    private ComboBox ActionTriggercomboBox;
    private Panel panel2;
    private CheckBox ActionSwapFilecheckBox;
    private ComboBox ActionSwapFilecomboBox;
    private Label label3;
    private ContextMenuStrip PackcontextMenuStrip;
    private ToolStripMenuItem testToolStripMenuItem;
    private ToolStripMenuItem deleteToolStripMenuItem;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem exportToolStripMenuItem;
    private ToolStripMenuItem importToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripMenuItem setAsMainToolStripMenuItem;
    private ListBox listBoxPacks;
    private Panel panel4;
    private Label label4;
    private CheckBox ActionPackcheckBox;
    private ComboBox ActionPackcomboBox;
    private ToolStripMenuItem newToolStripMenuItem;
    private ToolStripMenuItem updateToolStripMenuItem;
    private Label label5;
    private ComboBox SwapTypecomboBox;
    private CheckBox VideocheckBox;
    private CheckBox MusiccheckBox;
    private CheckBox SoundEffectcheckBox;
    private Label label6;
    private Panel panel5;
}
