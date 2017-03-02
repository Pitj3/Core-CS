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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Inspector = new System.Windows.Forms.TabPage();
            this.Physics = new System.Windows.Forms.TabPage();
            this.TopMenu.SuspendLayout();
            this.PanelHierarchy.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(1604, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 916);
            this.panel1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Inspector);
            this.tabControl1.Controls.Add(this.Physics);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(297, 915);
            this.tabControl1.TabIndex = 0;
            // 
            // Inspector
            // 
            this.Inspector.Location = new System.Drawing.Point(4, 22);
            this.Inspector.Name = "Inspector";
            this.Inspector.Padding = new System.Windows.Forms.Padding(3);
            this.Inspector.Size = new System.Drawing.Size(289, 889);
            this.Inspector.TabIndex = 0;
            this.Inspector.Text = "Inspector";
            this.Inspector.UseVisualStyleBackColor = true;
            // 
            // Physics
            // 
            this.Physics.Location = new System.Drawing.Point(4, 22);
            this.Physics.Name = "Physics";
            this.Physics.Padding = new System.Windows.Forms.Padding(3);
            this.Physics.Size = new System.Drawing.Size(289, 674);
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
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

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
        private Panel panel1;
        private TabControl tabControl1;
        private TabPage Inspector;
        private TabPage Physics;
    }
}

