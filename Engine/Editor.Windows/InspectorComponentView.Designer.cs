namespace Editor.Windows
{
    partial class InspectorComponentView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.ComponentHeader = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.ComponentSeperator = new ComponentFactory.Krypton.Toolkit.KryptonBorderEdge();
            this.ComponentProperties = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ComponentHeader);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(400, 199);
            this.MainPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.MainPanel.TabIndex = 0;
            // 
            // ComponentHeader
            // 
            this.ComponentHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComponentHeader.Location = new System.Drawing.Point(0, 0);
            this.ComponentHeader.Margin = new System.Windows.Forms.Padding(0);
            this.ComponentHeader.Name = "ComponentHeader";
            this.ComponentHeader.Size = new System.Drawing.Size(400, 29);
            this.ComponentHeader.TabIndex = 0;
            this.ComponentHeader.Values.Description = "Component description";
            this.ComponentHeader.Values.Heading = "Component Name";
            this.ComponentHeader.Values.Image = null;
            // 
            // ComponentSeperator
            // 
            this.ComponentSeperator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ComponentSeperator.Location = new System.Drawing.Point(0, 199);
            this.ComponentSeperator.Name = "ComponentSeperator";
            this.ComponentSeperator.Size = new System.Drawing.Size(400, 1);
            this.ComponentSeperator.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            // 
            // ComponentProperties
            // 
            this.ComponentProperties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ComponentProperties.CanShowVisualStyleGlyphs = false;
            this.ComponentProperties.CategoryForeColor = System.Drawing.Color.White;
            this.ComponentProperties.CategorySplitterColor = System.Drawing.Color.White;
            this.ComponentProperties.CommandsForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ComponentProperties.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ComponentProperties.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ComponentProperties.HelpForeColor = System.Drawing.Color.White;
            this.ComponentProperties.HelpVisible = false;
            this.ComponentProperties.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ComponentProperties.Location = new System.Drawing.Point(0, 29);
            this.ComponentProperties.Name = "ComponentProperties";
            this.ComponentProperties.SelectedItemWithFocusBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ComponentProperties.SelectedItemWithFocusForeColor = System.Drawing.Color.White;
            this.ComponentProperties.Size = new System.Drawing.Size(400, 168);
            this.ComponentProperties.TabIndex = 2;
            this.ComponentProperties.ToolbarVisible = false;
            this.ComponentProperties.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ComponentProperties.ViewForeColor = System.Drawing.Color.White;
            this.ComponentProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(ComponentProperties_PropertyValueChanged);
            // 
            // InspectorComponentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ComponentProperties);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.ComponentSeperator);
            this.Name = "InspectorComponentView";
            this.Size = new System.Drawing.Size(400, 200);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonBorderEdge ComponentSeperator;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader ComponentHeader;
        private System.Windows.Forms.PropertyGrid ComponentProperties;
    }
}
