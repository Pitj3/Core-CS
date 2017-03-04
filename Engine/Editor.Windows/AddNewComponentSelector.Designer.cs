namespace Editor.Windows
{
    partial class AddNewComponentSelector
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
            this.InspectorAddComponentSelector = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.InspectorAddComponentSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // InspectorAddComponentSelector
            // 
            this.InspectorAddComponentSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InspectorAddComponentSelector.DropDownWidth = 121;
            this.InspectorAddComponentSelector.Location = new System.Drawing.Point(0, 0);
            this.InspectorAddComponentSelector.Margin = new System.Windows.Forms.Padding(0);
            this.InspectorAddComponentSelector.Name = "InspectorAddComponentSelector";
            this.InspectorAddComponentSelector.Size = new System.Drawing.Size(400, 21);
            this.InspectorAddComponentSelector.StateActive.ComboBox.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.InspectorAddComponentSelector.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.InspectorAddComponentSelector.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.InspectorAddComponentSelector.StateActive.ComboBox.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.InspectorAddComponentSelector.StateActive.ComboBox.Content.Color1 = System.Drawing.Color.White;
            this.InspectorAddComponentSelector.TabIndex = 0;
            this.InspectorAddComponentSelector.Text = "Add a new Component";
            this.InspectorAddComponentSelector.SelectedValueChanged += new System.EventHandler(this.InspectorAddComponentSelector_SelectedIndexChanged);
            // 
            // AddNewComponentSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.InspectorAddComponentSelector);
            this.Name = "AddNewComponentSelector";
            this.Size = new System.Drawing.Size(400, 21);
            ((System.ComponentModel.ISupportInitialize)(this.InspectorAddComponentSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonComboBox InspectorAddComponentSelector;
    }
}
