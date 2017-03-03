using System;
using System.Windows.Forms;

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
            this.TopMenuWindowsOption = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuAboutOption = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuAboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GLView = new OpenTK.GLControl();
            this.PanelHierarchy = new System.Windows.Forms.Panel();
            this.ListHierachy = new System.Windows.Forms.ListBox();
            this.ConsoleWindow = new System.Windows.Forms.ListBox();
            this.AssetsWindow = new System.Windows.Forms.ListView();
            this.RightSidePanel = new System.Windows.Forms.Panel();
            this.RightSideTab = new System.Windows.Forms.TabControl();
            this.Inspector = new System.Windows.Forms.TabPage();
            this.InspectorPanel = new System.Windows.Forms.Panel();
            this.ComponentSelectLabel = new System.Windows.Forms.Label();
            this.AddComponentSelectionBox = new System.Windows.Forms.ComboBox();
            this.InspectorComponentsBox = new System.Windows.Forms.CheckedListBox();
            this.RotationLabel = new System.Windows.Forms.Label();
            this.RotationZ = new System.Windows.Forms.TextBox();
            this.RotationY = new System.Windows.Forms.TextBox();
            this.RotationX = new System.Windows.Forms.TextBox();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.PositionZ = new System.Windows.Forms.TextBox();
            this.PositionY = new System.Windows.Forms.TextBox();
            this.PositionX = new System.Windows.Forms.TextBox();
            this.Physics = new System.Windows.Forms.TabPage();
            this.TopMenu.SuspendLayout();
            this.PanelHierarchy.SuspendLayout();
            this.RightSidePanel.SuspendLayout();
            this.RightSideTab.SuspendLayout();
            this.Inspector.SuspendLayout();
            this.InspectorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopMenu
            // 
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
            this.TopMenuFileOption.Name = "TopMenuFileOption";
            this.TopMenuFileOption.Size = new System.Drawing.Size(37, 20);
            this.TopMenuFileOption.Text = "File";
            // 
            // FileMenuNewOption
            // 
            this.FileMenuNewOption.Name = "FileMenuNewOption";
            this.FileMenuNewOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.FileMenuNewOption.Size = new System.Drawing.Size(187, 22);
            this.FileMenuNewOption.Text = "New";
            // 
            // FileMenuLoadOption
            // 
            this.FileMenuLoadOption.Name = "FileMenuLoadOption";
            this.FileMenuLoadOption.Size = new System.Drawing.Size(187, 22);
            this.FileMenuLoadOption.Text = "Load";
            // 
            // FileMenuSaveOption
            // 
            this.FileMenuSaveOption.Name = "FileMenuSaveOption";
            this.FileMenuSaveOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileMenuSaveOption.Size = new System.Drawing.Size(187, 22);
            this.FileMenuSaveOption.Text = "Save";
            // 
            // FileMenuSaveAllOption
            // 
            this.FileMenuSaveAllOption.Name = "FileMenuSaveAllOption";
            this.FileMenuSaveAllOption.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.FileMenuSaveAllOption.Size = new System.Drawing.Size(187, 22);
            this.FileMenuSaveAllOption.Text = "Save All";
            // 
            // FileMenuExitOption
            // 
            this.FileMenuExitOption.Name = "FileMenuExitOption";
            this.FileMenuExitOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.FileMenuExitOption.Size = new System.Drawing.Size(187, 22);
            this.FileMenuExitOption.Text = "Exit";
            this.FileMenuExitOption.Click += new System.EventHandler(this.ExitEditorButton);
            // 
            // TopMenuEditOption
            // 
            this.TopMenuEditOption.Name = "TopMenuEditOption";
            this.TopMenuEditOption.Size = new System.Drawing.Size(39, 20);
            this.TopMenuEditOption.Text = "Edit";
            // 
            // TopMenuCreateOption
            // 
            this.TopMenuCreateOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateMenuGameObjectOption});
            this.TopMenuCreateOption.Name = "TopMenuCreateOption";
            this.TopMenuCreateOption.Size = new System.Drawing.Size(53, 20);
            this.TopMenuCreateOption.Text = "Create";
            // 
            // CreateMenuGameObjectOption
            // 
            this.CreateMenuGameObjectOption.Name = "CreateMenuGameObjectOption";
            this.CreateMenuGameObjectOption.Size = new System.Drawing.Size(140, 22);
            this.CreateMenuGameObjectOption.Text = "GameObject";
            this.CreateMenuGameObjectOption.Click += new System.EventHandler(this.GameObjectCreateButton);
            // 
            // TopMenuWindowsOption
            // 
            this.TopMenuWindowsOption.Name = "TopMenuWindowsOption";
            this.TopMenuWindowsOption.Size = new System.Drawing.Size(68, 20);
            this.TopMenuWindowsOption.Text = "Windows";
            // 
            // TopMenuAboutOption
            // 
            this.TopMenuAboutOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuAboutItem});
            this.TopMenuAboutOption.Name = "TopMenuAboutOption";
            this.TopMenuAboutOption.Size = new System.Drawing.Size(52, 20);
            this.TopMenuAboutOption.Text = "About";
            // 
            // AboutMenuAboutItem
            // 
            this.AboutMenuAboutItem.Name = "AboutMenuAboutItem";
            this.AboutMenuAboutItem.Size = new System.Drawing.Size(107, 22);
            this.AboutMenuAboutItem.Text = "About";
            this.AboutMenuAboutItem.Click += new System.EventHandler(this.AboutEditorButton);
            // 
            // GLView
            // 
            this.GLView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.GLView.Location = new System.Drawing.Point(329, 33);
            this.GLView.Name = "GLView";
            this.GLView.Size = new System.Drawing.Size(1269, 771);
            this.GLView.TabIndex = 0;
            this.GLView.VSync = false;
            this.GLView.Paint += new System.Windows.Forms.PaintEventHandler(this.GLWidgetPaint);
            this.GLView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GLWidgetKeyDown);
            this.GLView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GLWidgetKeyPress);
            this.GLView.Resize += new System.EventHandler(this.GLWidgetResize);
            // 
            // PanelHierarchy
            // 
            this.PanelHierarchy.Controls.Add(this.ListHierachy);
            this.PanelHierarchy.Location = new System.Drawing.Point(12, 27);
            this.PanelHierarchy.Name = "PanelHierarchy";
            this.PanelHierarchy.Size = new System.Drawing.Size(323, 784);
            this.PanelHierarchy.TabIndex = 1;
            // 
            // ListHierachy
            // 
            this.ListHierachy.FormattingEnabled = true;
            this.ListHierachy.Location = new System.Drawing.Point(0, 6);
            this.ListHierachy.Name = "ListHierachy";
            this.ListHierachy.Size = new System.Drawing.Size(317, 771);
            this.ListHierachy.TabIndex = 0;
            this.ListHierachy.SelectedIndexChanged += new System.EventHandler(this.ListHierarchyObjectSelected);
            // 
            // ConsoleWindow
            // 
            this.ConsoleWindow.FormattingEnabled = true;
            this.ConsoleWindow.Location = new System.Drawing.Point(12, 817);
            this.ConsoleWindow.Name = "ConsoleWindow";
            this.ConsoleWindow.Size = new System.Drawing.Size(317, 134);
            this.ConsoleWindow.TabIndex = 2;
            // 
            // AssetsWindow
            // 
            this.AssetsWindow.Location = new System.Drawing.Point(335, 817);
            this.AssetsWindow.Name = "AssetsWindow";
            this.AssetsWindow.Size = new System.Drawing.Size(1263, 132);
            this.AssetsWindow.TabIndex = 3;
            this.AssetsWindow.UseCompatibleStateImageBehavior = false;
            // 
            // RightSidePanel
            // 
            this.RightSidePanel.Controls.Add(this.RightSideTab);
            this.RightSidePanel.Location = new System.Drawing.Point(1604, 33);
            this.RightSidePanel.Name = "RightSidePanel";
            this.RightSidePanel.Size = new System.Drawing.Size(300, 916);
            this.RightSidePanel.TabIndex = 4;
            // 
            // RightSideTab
            // 
            this.RightSideTab.Controls.Add(this.Inspector);
            this.RightSideTab.Controls.Add(this.Physics);
            this.RightSideTab.Location = new System.Drawing.Point(3, 3);
            this.RightSideTab.Name = "RightSideTab";
            this.RightSideTab.SelectedIndex = 0;
            this.RightSideTab.Size = new System.Drawing.Size(297, 915);
            this.RightSideTab.TabIndex = 0;
            // 
            // Inspector
            // 
            this.Inspector.Controls.Add(this.InspectorPanel);
            this.Inspector.Location = new System.Drawing.Point(4, 22);
            this.Inspector.Name = "Inspector";
            this.Inspector.Padding = new System.Windows.Forms.Padding(3);
            this.Inspector.Size = new System.Drawing.Size(289, 889);
            this.Inspector.TabIndex = 0;
            this.Inspector.Text = "Inspector";
            this.Inspector.UseVisualStyleBackColor = true;
            // 
            // InspectorPanel
            // 
            this.InspectorPanel.Controls.Add(this.ComponentSelectLabel);
            this.InspectorPanel.Controls.Add(this.AddComponentSelectionBox);
            this.InspectorPanel.Controls.Add(this.InspectorComponentsBox);
            this.InspectorPanel.Controls.Add(this.RotationLabel);
            this.InspectorPanel.Controls.Add(this.RotationZ);
            this.InspectorPanel.Controls.Add(this.RotationY);
            this.InspectorPanel.Controls.Add(this.RotationX);
            this.InspectorPanel.Controls.Add(this.PositionLabel);
            this.InspectorPanel.Controls.Add(this.PositionZ);
            this.InspectorPanel.Controls.Add(this.PositionY);
            this.InspectorPanel.Controls.Add(this.PositionX);
            this.InspectorPanel.Location = new System.Drawing.Point(0, 0);
            this.InspectorPanel.Name = "InspectorPanel";
            this.InspectorPanel.Size = new System.Drawing.Size(289, 889);
            this.InspectorPanel.TabIndex = 0;
            this.InspectorPanel.Visible = false;
            // 
            // ComponentSelectLabel
            // 
            this.ComponentSelectLabel.AutoSize = true;
            this.ComponentSelectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComponentSelectLabel.Location = new System.Drawing.Point(18, 793);
            this.ComponentSelectLabel.Name = "ComponentSelectLabel";
            this.ComponentSelectLabel.Size = new System.Drawing.Size(109, 17);
            this.ComponentSelectLabel.TabIndex = 10;
            this.ComponentSelectLabel.Text = "Add Component";
            // 
            // AddComponentSelectionBox
            // 
            this.AddComponentSelectionBox.FormattingEnabled = true;
            this.AddComponentSelectionBox.Location = new System.Drawing.Point(21, 813);
            this.AddComponentSelectionBox.Name = "AddComponentSelectionBox";
            this.AddComponentSelectionBox.Size = new System.Drawing.Size(245, 21);
            this.AddComponentSelectionBox.TabIndex = 9;
            this.AddComponentSelectionBox.SelectedIndexChanged += new System.EventHandler(this.AddComponentSelectionBoxSelectedComponent);
            // 
            // InspectorComponentsBox
            // 
            this.InspectorComponentsBox.FormattingEnabled = true;
            this.InspectorComponentsBox.Location = new System.Drawing.Point(21, 94);
            this.InspectorComponentsBox.Name = "InspectorComponentsBox";
            this.InspectorComponentsBox.Size = new System.Drawing.Size(245, 664);
            this.InspectorComponentsBox.TabIndex = 8;
            this.InspectorComponentsBox.SelectedIndexChanged += new System.EventHandler(this.InspectorComponentsBoxComponentSelected);
            // 
            // RotationLabel
            // 
            this.RotationLabel.AutoSize = true;
            this.RotationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotationLabel.Location = new System.Drawing.Point(18, 46);
            this.RotationLabel.Name = "RotationLabel";
            this.RotationLabel.Size = new System.Drawing.Size(65, 17);
            this.RotationLabel.TabIndex = 7;
            this.RotationLabel.Text = "Rotation:";
            // 
            // RotationZ
            // 
            this.RotationZ.Location = new System.Drawing.Point(211, 45);
            this.RotationZ.Name = "RotationZ";
            this.RotationZ.Size = new System.Drawing.Size(55, 20);
            this.RotationZ.TabIndex = 6;
            this.RotationZ.TextChanged += new System.EventHandler(this.RotationZBoxChanged);
            // 
            // RotationY
            // 
            this.RotationY.Location = new System.Drawing.Point(150, 45);
            this.RotationY.Name = "RotationY";
            this.RotationY.Size = new System.Drawing.Size(55, 20);
            this.RotationY.TabIndex = 5;
            this.RotationY.TextChanged += new System.EventHandler(this.RotationYBoxChanged);
            // 
            // RotationX
            // 
            this.RotationX.Location = new System.Drawing.Point(89, 45);
            this.RotationX.Name = "RotationX";
            this.RotationX.Size = new System.Drawing.Size(55, 20);
            this.RotationX.TabIndex = 4;
            this.RotationX.TextChanged += new System.EventHandler(this.RotationXBoxChanged);
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionLabel.Location = new System.Drawing.Point(18, 20);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(62, 17);
            this.PositionLabel.TabIndex = 3;
            this.PositionLabel.Text = "Position:";
            // 
            // PositionZ
            // 
            this.PositionZ.Location = new System.Drawing.Point(211, 19);
            this.PositionZ.Name = "PositionZ";
            this.PositionZ.Size = new System.Drawing.Size(55, 20);
            this.PositionZ.TabIndex = 2;
            this.PositionZ.TextChanged += new System.EventHandler(this.PositionZBoxChanged);
            // 
            // PositionY
            // 
            this.PositionY.Location = new System.Drawing.Point(150, 19);
            this.PositionY.Name = "PositionY";
            this.PositionY.Size = new System.Drawing.Size(55, 20);
            this.PositionY.TabIndex = 1;
            this.PositionY.TextChanged += new System.EventHandler(this.PositionYBoxChanged);
            // 
            // PositionX
            // 
            this.PositionX.Location = new System.Drawing.Point(89, 19);
            this.PositionX.Name = "PositionX";
            this.PositionX.Size = new System.Drawing.Size(55, 20);
            this.PositionX.TabIndex = 0;
            this.PositionX.TextChanged += new System.EventHandler(this.PositionXBoxChanged);
            // 
            // Physics
            // 
            this.Physics.Location = new System.Drawing.Point(4, 22);
            this.Physics.Name = "Physics";
            this.Physics.Padding = new System.Windows.Forms.Padding(3);
            this.Physics.Size = new System.Drawing.Size(289, 889);
            this.Physics.TabIndex = 1;
            this.Physics.Text = "Physics";
            this.Physics.UseVisualStyleBackColor = true;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1904, 961);
            this.Controls.Add(this.RightSidePanel);
            this.Controls.Add(this.ConsoleWindow);
            this.Controls.Add(this.AssetsWindow);
            this.Controls.Add(this.PanelHierarchy);
            this.Controls.Add(this.TopMenu);
            this.Controls.Add(this.GLView);
            this.MainMenuStrip = this.TopMenu;
            this.Name = "Editor";
            this.Text = "CoreEngine Editor - Windows";
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.PanelHierarchy.ResumeLayout(false);
            this.RightSidePanel.ResumeLayout(false);
            this.RightSideTab.ResumeLayout(false);
            this.Inspector.ResumeLayout(false);
            this.InspectorPanel.ResumeLayout(false);
            this.InspectorPanel.PerformLayout();
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
        private OpenTK.GLControl GLView;
        private Panel PanelHierarchy;
        private ListBox ListHierachy;
        private ToolStripMenuItem CreateMenuGameObjectOption;
        private ListBox ConsoleWindow;
        private ListView AssetsWindow;
        private Panel RightSidePanel;
        private TabControl RightSideTab;
        private TabPage Inspector;
        private TabPage Physics;
        private Panel InspectorPanel;
        private Label PositionLabel;
        private TextBox PositionZ;
        private TextBox PositionY;
        private TextBox PositionX;
        private Label RotationLabel;
        private TextBox RotationZ;
        private TextBox RotationY;
        private TextBox RotationX;
        private CheckedListBox InspectorComponentsBox;
        private Label ComponentSelectLabel;
        private ComboBox AddComponentSelectionBox;
    }
}

