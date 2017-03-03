namespace Editor.Windows
{
    partial class ComponentVariableView
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
            this.VariableName = new System.Windows.Forms.Label();
            this.VariableValueBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // VariableName
            // 
            this.VariableName.AutoSize = true;
            this.VariableName.Location = new System.Drawing.Point(3, 6);
            this.VariableName.Name = "VariableName";
            this.VariableName.Size = new System.Drawing.Size(35, 13);
            this.VariableName.TabIndex = 0;
            this.VariableName.Text = "label1";
            this.VariableName.Click += new System.EventHandler(this.VariableName_Click);
            // 
            // VariableValueBox
            // 
            this.VariableValueBox.Location = new System.Drawing.Point(44, 3);
            this.VariableValueBox.Name = "VariableValueBox";
            this.VariableValueBox.Size = new System.Drawing.Size(208, 20);
            this.VariableValueBox.TabIndex = 1;
            // 
            // ComponentVariableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VariableValueBox);
            this.Controls.Add(this.VariableName);
            this.Name = "ComponentVariableView";
            this.Size = new System.Drawing.Size(255, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VariableName;
        private System.Windows.Forms.TextBox VariableValueBox;
    }
}
