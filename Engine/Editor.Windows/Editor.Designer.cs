using System;
using System.Windows.Forms;

using OpenTK;

namespace Editor.Windows
{
    partial class Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.GLView = new OpenTK.GLControl();
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.TopMenuFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuNewOption = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuLoadOption = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuSaveOption = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuSaveAllOption = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuExitOption = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuEditOption = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuCreateOption = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateMenuGameObjectOption = new System.Windows.Forms.ToolStripMenuItem();
            this.childToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuWindowsOption = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuAboutOption = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuAboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveSceneDialog = new System.Windows.Forms.SaveFileDialog();
            this.LoadSceneDialog = new System.Windows.Forms.OpenFileDialog();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.MainEditorPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.MainEditorToolbar = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.MainEditorCenterPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.MainEditorBottomPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.MainEditorRightPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.HierarchyPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.HierarchyHeader = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.HierarchyTree = new ComponentFactory.Krypton.Toolkit.KryptonTreeView();
            this.InspectorPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.InspectorHeader = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.TransformGrid = new System.Windows.Forms.PropertyGrid();
            this.InspectorComponentsPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.MainEditorLeftPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainEditorPanel)).BeginInit();
            this.MainEditorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainEditorToolbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainEditorCenterPanel)).BeginInit();
            this.MainEditorCenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainEditorBottomPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainEditorRightPanel)).BeginInit();
            this.MainEditorRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HierarchyPanel)).BeginInit();
            this.HierarchyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InspectorPanel)).BeginInit();
            this.InspectorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InspectorComponentsPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainEditorLeftPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // GLView
            // 
            this.GLView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.GLView.Location = new System.Drawing.Point(399, 51);
            this.GLView.Name = "GLView";
            this.GLView.Size = new System.Drawing.Size(1106, 761);
            this.GLView.TabIndex = 0;
            this.GLView.VSync = false;
            this.GLView.Load += new System.EventHandler(this.GLViewLoaded);
            this.GLView.Click += new System.EventHandler(this.GLViewClicked);
            this.GLView.Paint += new System.Windows.Forms.PaintEventHandler(this.GLViewPaint);
            this.GLView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GLViewKeyDown);
            this.GLView.Resize += new System.EventHandler(this.GLViewResize);
            // 
            // TopMenu
            // 
            this.TopMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TopMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.TopMenu.ForeColor = System.Drawing.Color.White;
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TopMenuFileOption,
            this.TopMenuEditOption,
            this.TopMenuCreateOption,
            this.TopMenuWindowsOption,
            this.TopMenuAboutOption});
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(1904, 24);
            this.TopMenu.TabIndex = 0;
            this.TopMenu.Text = "menuStrip1";
            // 
            // TopMenuFileOption
            // 
            this.TopMenuFileOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuNewOption,
            this.FileMenuLoadOption,
            this.FileMenuSaveOption,
            this.FileMenuSaveAllOption,
            this.FileMenuExitOption});
            this.TopMenuFileOption.ForeColor = System.Drawing.Color.White;
            this.TopMenuFileOption.Name = "TopMenuFileOption";
            this.TopMenuFileOption.Size = new System.Drawing.Size(37, 20);
            this.TopMenuFileOption.Text = "File";
            // 
            // FileMenuNewOption
            // 
            this.FileMenuNewOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FileMenuNewOption.Name = "FileMenuNewOption";
            this.FileMenuNewOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.FileMenuNewOption.Size = new System.Drawing.Size(187, 22);
            this.FileMenuNewOption.Text = "New";
            this.FileMenuNewOption.Click += new System.EventHandler(this.FileMenuNewOptionClicked);
            // 
            // FileMenuLoadOption
            // 
            this.FileMenuLoadOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FileMenuLoadOption.Name = "FileMenuLoadOption";
            this.FileMenuLoadOption.Size = new System.Drawing.Size(187, 22);
            this.FileMenuLoadOption.Text = "Load";
            this.FileMenuLoadOption.Click += new System.EventHandler(this.FileMenuLoadOptionClicked);
            // 
            // FileMenuSaveOption
            // 
            this.FileMenuSaveOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FileMenuSaveOption.Name = "FileMenuSaveOption";
            this.FileMenuSaveOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileMenuSaveOption.Size = new System.Drawing.Size(187, 22);
            this.FileMenuSaveOption.Text = "Save";
            this.FileMenuSaveOption.Click += new System.EventHandler(this.FileMenuSaveOptionClicked);
            // 
            // FileMenuSaveAllOption
            // 
            this.FileMenuSaveAllOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FileMenuSaveAllOption.Name = "FileMenuSaveAllOption";
            this.FileMenuSaveAllOption.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.FileMenuSaveAllOption.Size = new System.Drawing.Size(187, 22);
            this.FileMenuSaveAllOption.Text = "Save All";
            // 
            // FileMenuExitOption
            // 
            this.FileMenuExitOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FileMenuExitOption.Name = "FileMenuExitOption";
            this.FileMenuExitOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.FileMenuExitOption.Size = new System.Drawing.Size(187, 22);
            this.FileMenuExitOption.Text = "Exit";
            this.FileMenuExitOption.Click += new System.EventHandler(this.ExitEditorButton);
            // 
            // TopMenuEditOption
            // 
            this.TopMenuEditOption.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TopMenuEditOption.Name = "TopMenuEditOption";
            this.TopMenuEditOption.Size = new System.Drawing.Size(39, 20);
            this.TopMenuEditOption.Text = "Edit";
            // 
            // TopMenuCreateOption
            // 
            this.TopMenuCreateOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateMenuGameObjectOption,
            this.childToolStripMenuItem,
            this.dToolStripMenuItem,
            this.cameraToolStripMenuItem});
            this.TopMenuCreateOption.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TopMenuCreateOption.Name = "TopMenuCreateOption";
            this.TopMenuCreateOption.Size = new System.Drawing.Size(53, 20);
            this.TopMenuCreateOption.Text = "Create";
            // 
            // CreateMenuGameObjectOption
            // 
            this.CreateMenuGameObjectOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CreateMenuGameObjectOption.Name = "CreateMenuGameObjectOption";
            this.CreateMenuGameObjectOption.Size = new System.Drawing.Size(140, 22);
            this.CreateMenuGameObjectOption.Text = "GameObject";
            this.CreateMenuGameObjectOption.Click += new System.EventHandler(this.GameObjectCreateButton);
            // 
            // childToolStripMenuItem
            // 
            this.childToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.childToolStripMenuItem.Name = "childToolStripMenuItem";
            this.childToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.childToolStripMenuItem.Text = "Child";
            this.childToolStripMenuItem.Click += new System.EventHandler(this.CreateChildGameObject);
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cubeToolStripMenuItem});
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.dToolStripMenuItem.Text = "3D";
            // 
            // cubeToolStripMenuItem
            // 
            this.cubeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cubeToolStripMenuItem.Name = "cubeToolStripMenuItem";
            this.cubeToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cubeToolStripMenuItem.Text = "Cube";
            this.cubeToolStripMenuItem.Click += new System.EventHandler(this.CreateMenuCreate3DCubeButton);
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.cameraToolStripMenuItem.Text = "Camera";
            this.cameraToolStripMenuItem.Click += new System.EventHandler(this.CreateMenuCreateCamera);
            // 
            // TopMenuWindowsOption
            // 
            this.TopMenuWindowsOption.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TopMenuWindowsOption.Name = "TopMenuWindowsOption";
            this.TopMenuWindowsOption.Size = new System.Drawing.Size(68, 20);
            this.TopMenuWindowsOption.Text = "Windows";
            // 
            // TopMenuAboutOption
            // 
            this.TopMenuAboutOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuAboutItem});
            this.TopMenuAboutOption.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TopMenuAboutOption.Name = "TopMenuAboutOption";
            this.TopMenuAboutOption.Size = new System.Drawing.Size(52, 20);
            this.TopMenuAboutOption.Text = "About";
            // 
            // AboutMenuAboutItem
            // 
            this.AboutMenuAboutItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AboutMenuAboutItem.Name = "AboutMenuAboutItem";
            this.AboutMenuAboutItem.Size = new System.Drawing.Size(107, 22);
            this.AboutMenuAboutItem.Text = "About";
            this.AboutMenuAboutItem.Click += new System.EventHandler(this.AboutEditorButton);
            // 
            // SaveSceneDialog
            // 
            this.SaveSceneDialog.DefaultExt = "txt";
            this.SaveSceneDialog.FileName = "untitled";
            this.SaveSceneDialog.Filter = "Scene Files|*.txt";
            this.SaveSceneDialog.InitialDirectory = "Content/Scenes";
            this.SaveSceneDialog.Title = "Save Scene";
            this.SaveSceneDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveSceneDialog_FileOk);
            // 
            // LoadSceneDialog
            // 
            this.LoadSceneDialog.Filter = "Scene Files|*.txt";
            this.LoadSceneDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadSceneDialog_FileOk);
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kryptonPalette1.ToolMenuStatus.Button.ButtonSelectedHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemText = System.Drawing.Color.White;
            this.kryptonPalette1.ToolMenuStatus.MenuStrip.MenuStripText = System.Drawing.Color.White;
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripDropDownBackground = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPalette = this.kryptonPalette1;
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom;
            // 
            // MainEditorPanel
            // 
            this.MainEditorPanel.Controls.Add(this.MainEditorToolbar);
            this.MainEditorPanel.Controls.Add(this.MainEditorCenterPanel);
            this.MainEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainEditorPanel.Location = new System.Drawing.Point(0, 0);
            this.MainEditorPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainEditorPanel.Name = "MainEditorPanel";
            this.MainEditorPanel.Size = new System.Drawing.Size(1904, 961);
            this.MainEditorPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MainEditorPanel.StateCommon.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.MainEditorPanel.TabIndex = 0;
            // 
            // MainEditorToolbar
            // 
            this.MainEditorToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainEditorToolbar.Location = new System.Drawing.Point(0, 0);
            this.MainEditorToolbar.Margin = new System.Windows.Forms.Padding(0);
            this.MainEditorToolbar.Name = "MainEditorToolbar";
            this.MainEditorToolbar.Size = new System.Drawing.Size(1904, 50);
            this.MainEditorToolbar.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.MainEditorToolbar.StateCommon.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.MainEditorToolbar.TabIndex = 0;
            // 
            // MainEditorCenterPanel
            // 
            this.MainEditorCenterPanel.Controls.Add(this.MainEditorBottomPanel);
            this.MainEditorCenterPanel.Controls.Add(this.MainEditorRightPanel);
            this.MainEditorCenterPanel.Controls.Add(this.MainEditorLeftPanel);
            this.MainEditorCenterPanel.Location = new System.Drawing.Point(0, 50);
            this.MainEditorCenterPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainEditorCenterPanel.Name = "MainEditorCenterPanel";
            this.MainEditorCenterPanel.Size = new System.Drawing.Size(1904, 961);
            this.MainEditorCenterPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MainEditorCenterPanel.StateCommon.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.MainEditorCenterPanel.TabIndex = 0;
            // 
            // MainEditorBottomPanel
            // 
            this.MainEditorBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainEditorBottomPanel.Location = new System.Drawing.Point(400, 761);
            this.MainEditorBottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainEditorBottomPanel.Name = "MainEditorBottomPanel";
            this.MainEditorBottomPanel.Size = new System.Drawing.Size(1104, 200);
            this.MainEditorBottomPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.MainEditorBottomPanel.StateCommon.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.MainEditorBottomPanel.TabIndex = 0;
            // 
            // MainEditorRightPanel
            // 
            this.MainEditorRightPanel.Controls.Add(this.HierarchyPanel);
            this.MainEditorRightPanel.Controls.Add(this.InspectorPanel);
            this.MainEditorRightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.MainEditorRightPanel.Location = new System.Drawing.Point(1504, 0);
            this.MainEditorRightPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainEditorRightPanel.Name = "MainEditorRightPanel";
            this.MainEditorRightPanel.Size = new System.Drawing.Size(400, 961);
            this.MainEditorRightPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.MainEditorRightPanel.StateCommon.Color2 = System.Drawing.Color.Black;
            this.MainEditorRightPanel.StateCommon.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.MainEditorRightPanel.TabIndex = 0;
            // 
            // HierarchyPanel
            // 
            this.HierarchyPanel.Controls.Add(this.HierarchyHeader);
            this.HierarchyPanel.Controls.Add(this.HierarchyTree);
            this.HierarchyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HierarchyPanel.Location = new System.Drawing.Point(0, 0);
            this.HierarchyPanel.Name = "HierarchyPanel";
            this.HierarchyPanel.Size = new System.Drawing.Size(400, 400);
            this.HierarchyPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.HierarchyPanel.StateCommon.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.HierarchyPanel.TabIndex = 0;
            // 
            // HierarchyHeader
            // 
            this.HierarchyHeader.AccessibleDescription = "";
            this.HierarchyHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.HierarchyHeader.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.HierarchyHeader.Location = new System.Drawing.Point(0, 0);
            this.HierarchyHeader.Margin = new System.Windows.Forms.Padding(0);
            this.HierarchyHeader.Name = "HierarchyHeader";
            this.HierarchyHeader.Size = new System.Drawing.Size(400, 29);
            this.HierarchyHeader.TabIndex = 0;
            this.HierarchyHeader.Values.Description = "The current scene";
            this.HierarchyHeader.Values.Heading = "Hierarchy";
            this.HierarchyHeader.Values.Image = null;
            // 
            // HierarchyTree
            // 
            this.HierarchyTree.CheckBoxes = true;
            this.HierarchyTree.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HierarchyTree.Location = new System.Drawing.Point(0, 29);
            this.HierarchyTree.Margin = new System.Windows.Forms.Padding(0);
            this.HierarchyTree.Name = "HierarchyTree";
            this.HierarchyTree.Size = new System.Drawing.Size(400, 371);
            this.HierarchyTree.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.HierarchyTree.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.HierarchyTree.StateCommon.Node.Back.Color1 = System.Drawing.Color.White;
            this.HierarchyTree.StateCommon.Node.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.HierarchyTree.StateCommon.Node.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.HierarchyTree.StateCommon.Node.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.HierarchyTree.StateCommon.Node.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.HierarchyTree.TabIndex = 0;
            this.HierarchyTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.HierarchyTreeNodeMouseClick);
            // 
            // InspectorPanel
            // 
            this.InspectorPanel.Controls.Add(this.InspectorHeader);
            this.InspectorPanel.Controls.Add(this.TransformGrid);
            this.InspectorPanel.Controls.Add(this.InspectorComponentsPanel);
            this.InspectorPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InspectorPanel.Location = new System.Drawing.Point(0, 400);
            this.InspectorPanel.Name = "InspectorPanel";
            this.InspectorPanel.Size = new System.Drawing.Size(400, 561);
            this.InspectorPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.InspectorPanel.StateCommon.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.InspectorPanel.TabIndex = 1;
            // 
            // InspectorHeader
            // 
            this.InspectorHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.InspectorHeader.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.InspectorHeader.Location = new System.Drawing.Point(0, 0);
            this.InspectorHeader.Margin = new System.Windows.Forms.Padding(0);
            this.InspectorHeader.Name = "InspectorHeader";
            this.InspectorHeader.Size = new System.Drawing.Size(400, 29);
            this.InspectorHeader.TabIndex = 0;
            this.InspectorHeader.Values.Description = "The current object";
            this.InspectorHeader.Values.Heading = "Inspector";
            this.InspectorHeader.Values.Image = null;
            // 
            // TransformGrid
            // 
            this.TransformGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.TransformGrid.CanShowVisualStyleGlyphs = false;
            this.TransformGrid.CategoryForeColor = System.Drawing.Color.White;
            this.TransformGrid.CategorySplitterColor = System.Drawing.Color.White;
            this.TransformGrid.CommandsForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.TransformGrid.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TransformGrid.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.TransformGrid.HelpForeColor = System.Drawing.Color.White;
            this.TransformGrid.HelpVisible = false;
            this.TransformGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.TransformGrid.Location = new System.Drawing.Point(0, 29);
            this.TransformGrid.Margin = new System.Windows.Forms.Padding(0);
            this.TransformGrid.Name = "TransformGrid";
            this.TransformGrid.SelectedItemWithFocusBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.TransformGrid.SelectedItemWithFocusForeColor = System.Drawing.Color.White;
            this.TransformGrid.Size = new System.Drawing.Size(400, 120);
            this.TransformGrid.TabIndex = 5;
            this.TransformGrid.ToolbarVisible = false;
            this.TransformGrid.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.TransformGrid.ViewForeColor = System.Drawing.Color.White;
            this.TransformGrid.Visible = false;
            this.TransformGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.TransformGrid_PropertyValueChanged);
            // 
            // InspectorComponentsPanel
            // 
            this.InspectorComponentsPanel.AutoScroll = true;
            this.InspectorComponentsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InspectorComponentsPanel.Location = new System.Drawing.Point(0, 149);
            this.InspectorComponentsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.InspectorComponentsPanel.Name = "InspectorComponentsPanel";
            this.InspectorComponentsPanel.Size = new System.Drawing.Size(400, 412);
            this.InspectorComponentsPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.InspectorComponentsPanel.StateCommon.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.InspectorComponentsPanel.TabIndex = 0;
            // 
            // MainEditorLeftPanel
            // 
            this.MainEditorLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainEditorLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.MainEditorLeftPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainEditorLeftPanel.Name = "MainEditorLeftPanel";
            this.MainEditorLeftPanel.Size = new System.Drawing.Size(400, 961);
            this.MainEditorLeftPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.MainEditorLeftPanel.StateCommon.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.MainEditorLeftPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TOOLBAR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(35, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ASSETS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(600, 831);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "CONSOLE";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1904, 961);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GLView);
            this.Controls.Add(this.TopMenu);
            this.Controls.Add(this.MainEditorPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.TopMenu;
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoreEngine Editor - Windows";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Editor_Load);
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainEditorPanel)).EndInit();
            this.MainEditorPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainEditorToolbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainEditorCenterPanel)).EndInit();
            this.MainEditorCenterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainEditorBottomPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainEditorRightPanel)).EndInit();
            this.MainEditorRightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HierarchyPanel)).EndInit();
            this.HierarchyPanel.ResumeLayout(false);
            this.HierarchyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InspectorPanel)).EndInit();
            this.InspectorPanel.ResumeLayout(false);
            this.InspectorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InspectorComponentsPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainEditorLeftPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Top Menu

        #endregion
        private MenuStrip TopMenu;
        private ToolStripMenuItem TopMenuFileOption;
        private ToolStripMenuItem FileMenuNewOption;
        private ToolStripMenuItem FileMenuLoadOption;
        private ToolStripMenuItem FileMenuSaveOption;
        private ToolStripMenuItem FileMenuSaveAllOption;
        private ToolStripMenuItem FileMenuExitOption;
        private ToolStripMenuItem TopMenuEditOption;
        private ToolStripMenuItem TopMenuCreateOption;
        private ToolStripMenuItem TopMenuWindowsOption;
        private ToolStripMenuItem TopMenuAboutOption;
        private ToolStripMenuItem AboutMenuAboutItem;
        private ToolStripMenuItem CreateMenuGameObjectOption;
        private ToolStripMenuItem dToolStripMenuItem;
        private ToolStripMenuItem cubeToolStripMenuItem;
        private ToolStripMenuItem cameraToolStripMenuItem;
        public SaveFileDialog SaveSceneDialog;
        private OpenFileDialog LoadSceneDialog;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel MainEditorPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel MainEditorToolbar;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel MainEditorCenterPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel MainEditorRightPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel MainEditorBottomPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel MainEditorLeftPanel;

        private GLControl GLView;
        private Label label1;
        private Label label2;
        private Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel HierarchyPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader HierarchyHeader;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel InspectorPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader InspectorHeader;
        private ComponentFactory.Krypton.Toolkit.KryptonTreeView HierarchyTree;
        private ToolStripMenuItem childToolStripMenuItem;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel InspectorComponentsPanel;
        private PropertyGrid TransformGrid;
    }
}

