namespace CoreLauncher
{
    partial class LauncherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            this.LauncherNavigator = new System.Windows.Forms.TabControl();
            this.NewProject = new System.Windows.Forms.TabPage();
            this.FullProjectPath = new System.Windows.Forms.Label();
            this.FullProjectPathLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.ProjectLocationBox = new System.Windows.Forms.TextBox();
            this.ProjectNameLabel = new System.Windows.Forms.Label();
            this.ProjectNameBox = new System.Windows.Forms.TextBox();
            this.LoadProject = new System.Windows.Forms.TabPage();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.CreateProjectButton = new System.Windows.Forms.Button();
            this.LauncherNavigator.SuspendLayout();
            this.NewProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // LauncherNavigator
            // 
            this.LauncherNavigator.Controls.Add(this.NewProject);
            this.LauncherNavigator.Controls.Add(this.LoadProject);
            this.LauncherNavigator.Location = new System.Drawing.Point(13, 13);
            this.LauncherNavigator.Name = "LauncherNavigator";
            this.LauncherNavigator.SelectedIndex = 0;
            this.LauncherNavigator.Size = new System.Drawing.Size(859, 486);
            this.LauncherNavigator.TabIndex = 0;
            // 
            // NewProject
            // 
            this.NewProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.NewProject.Controls.Add(this.CreateProjectButton);
            this.NewProject.Controls.Add(this.FullProjectPath);
            this.NewProject.Controls.Add(this.FullProjectPathLabel);
            this.NewProject.Controls.Add(this.LocationLabel);
            this.NewProject.Controls.Add(this.ProjectLocationBox);
            this.NewProject.Controls.Add(this.ProjectNameLabel);
            this.NewProject.Controls.Add(this.ProjectNameBox);
            this.NewProject.Location = new System.Drawing.Point(4, 22);
            this.NewProject.Name = "NewProject";
            this.NewProject.Padding = new System.Windows.Forms.Padding(3);
            this.NewProject.Size = new System.Drawing.Size(851, 460);
            this.NewProject.TabIndex = 0;
            this.NewProject.Text = "New Project";
            // 
            // FullProjectPath
            // 
            this.FullProjectPath.AutoSize = true;
            this.FullProjectPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullProjectPath.ForeColor = System.Drawing.Color.White;
            this.FullProjectPath.Location = new System.Drawing.Point(32, 222);
            this.FullProjectPath.Name = "FullProjectPath";
            this.FullProjectPath.Size = new System.Drawing.Size(0, 20);
            this.FullProjectPath.TabIndex = 5;
            // 
            // FullProjectPathLabel
            // 
            this.FullProjectPathLabel.AutoSize = true;
            this.FullProjectPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullProjectPathLabel.ForeColor = System.Drawing.Color.White;
            this.FullProjectPathLabel.Location = new System.Drawing.Point(32, 202);
            this.FullProjectPathLabel.Name = "FullProjectPathLabel";
            this.FullProjectPathLabel.Size = new System.Drawing.Size(128, 20);
            this.FullProjectPathLabel.TabIndex = 4;
            this.FullProjectPathLabel.Text = "Full Project Path:";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationLabel.ForeColor = System.Drawing.Color.White;
            this.LocationLabel.Location = new System.Drawing.Point(32, 118);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(70, 20);
            this.LocationLabel.TabIndex = 3;
            this.LocationLabel.Text = "Location";
            // 
            // ProjectLocationBox
            // 
            this.ProjectLocationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectLocationBox.Location = new System.Drawing.Point(36, 141);
            this.ProjectLocationBox.Name = "ProjectLocationBox";
            this.ProjectLocationBox.Size = new System.Drawing.Size(292, 29);
            this.ProjectLocationBox.TabIndex = 2;
            this.ProjectLocationBox.Click += new System.EventHandler(this.ProjectLocationBox_Click);
            this.ProjectLocationBox.TextChanged += new System.EventHandler(this.ProjectNameBox_TextChanged);
            // 
            // ProjectNameLabel
            // 
            this.ProjectNameLabel.AutoSize = true;
            this.ProjectNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectNameLabel.ForeColor = System.Drawing.Color.White;
            this.ProjectNameLabel.Location = new System.Drawing.Point(32, 37);
            this.ProjectNameLabel.Name = "ProjectNameLabel";
            this.ProjectNameLabel.Size = new System.Drawing.Size(104, 20);
            this.ProjectNameLabel.TabIndex = 1;
            this.ProjectNameLabel.Text = "Project Name";
            // 
            // ProjectNameBox
            // 
            this.ProjectNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectNameBox.Location = new System.Drawing.Point(36, 60);
            this.ProjectNameBox.Name = "ProjectNameBox";
            this.ProjectNameBox.Size = new System.Drawing.Size(292, 29);
            this.ProjectNameBox.TabIndex = 0;
            // 
            // LoadProject
            // 
            this.LoadProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.LoadProject.Location = new System.Drawing.Point(4, 22);
            this.LoadProject.Name = "LoadProject";
            this.LoadProject.Padding = new System.Windows.Forms.Padding(3);
            this.LoadProject.Size = new System.Drawing.Size(851, 460);
            this.LoadProject.TabIndex = 1;
            this.LoadProject.Text = "Load Project";
            // 
            // FolderBrowser
            // 
            this.FolderBrowser.HelpRequest += new System.EventHandler(this.FolderBrowser_HelpRequest);
            // 
            // CreateProjectButton
            // 
            this.CreateProjectButton.Location = new System.Drawing.Point(689, 416);
            this.CreateProjectButton.Name = "CreateProjectButton";
            this.CreateProjectButton.Size = new System.Drawing.Size(156, 41);
            this.CreateProjectButton.TabIndex = 6;
            this.CreateProjectButton.Text = "Create";
            this.CreateProjectButton.UseVisualStyleBackColor = true;
            this.CreateProjectButton.Click += new System.EventHandler(this.CreateProjectButton_Click);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.LauncherNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LauncherForm";
            this.Text = "Core Engine Launcher";
            this.LauncherNavigator.ResumeLayout(false);
            this.NewProject.ResumeLayout(false);
            this.NewProject.PerformLayout();
            this.ResumeLayout(false);

        }

        


        #endregion

        private System.Windows.Forms.TabControl LauncherNavigator;
        private System.Windows.Forms.TabPage NewProject;
        private System.Windows.Forms.TabPage LoadProject;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.TextBox ProjectLocationBox;
        private System.Windows.Forms.Label ProjectNameLabel;
        private System.Windows.Forms.TextBox ProjectNameBox;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.Label FullProjectPath;
        private System.Windows.Forms.Label FullProjectPathLabel;
        private System.Windows.Forms.Button CreateProjectButton;
    }
}

