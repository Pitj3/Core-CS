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
            this.TopMenuWindowsOption = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuAboutOption = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuAboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GLWidget = new OpenTK.GLControl();
            this.TopMenu.SuspendLayout();
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
            this.TopMenu.Size = new System.Drawing.Size(1280, 24);
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
            this.TopMenuCreateOption.Name = "TopMenuCreateOption";
            this.TopMenuCreateOption.Size = new System.Drawing.Size(53, 20);
            this.TopMenuCreateOption.Text = "Create";
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
            this.AboutMenuAboutItem.Size = new System.Drawing.Size(152, 22);
            this.AboutMenuAboutItem.Text = "About";
            this.AboutMenuAboutItem.Click += new System.EventHandler(this.AboutEditorButton);
            // 
            // GLWidget
            // 
            this.GLWidget.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.GLWidget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GLWidget.Location = new System.Drawing.Point(0, 0);
            this.GLWidget.Name = "GLWidget";
            this.GLWidget.Size = new System.Drawing.Size(1280, 720);
            this.GLWidget.TabIndex = 0;
            this.GLWidget.VSync = false;
            this.GLWidget.Paint += new System.Windows.Forms.PaintEventHandler(this.GLWidgetPaint);
            this.GLWidget.Resize += new System.EventHandler(this.GLWidgetResize);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.TopMenu);
            this.Controls.Add(this.GLWidget);
            this.MainMenuStrip = this.TopMenu;
            this.Name = "Editor";
            this.Text = "CoreEngine Editor - Windows";
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip TopMenu;
        private System.Windows.Forms.ToolStripMenuItem TopMenuFileOption;
        private System.Windows.Forms.ToolStripMenuItem FileMenuNewOption;
        private System.Windows.Forms.ToolStripMenuItem FileMenuLoadOption;
        private System.Windows.Forms.ToolStripMenuItem FileMenuSaveOption;
        private System.Windows.Forms.ToolStripMenuItem FileMenuSaveAllOption;
        private System.Windows.Forms.ToolStripMenuItem FileMenuExitOption;
        private System.Windows.Forms.ToolStripMenuItem TopMenuEditOption;
        private System.Windows.Forms.ToolStripMenuItem TopMenuCreateOption;
        private System.Windows.Forms.ToolStripMenuItem TopMenuWindowsOption;
        private System.Windows.Forms.ToolStripMenuItem TopMenuAboutOption;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuAboutItem;
        private OpenTK.GLControl GLWidget;
    }
}

