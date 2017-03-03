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
            this.ComponentNameLabel = new System.Windows.Forms.Label();
            this.ComponentEnabled = new System.Windows.Forms.CheckBox();
            this.VariableViewPanel = new System.Windows.Forms.Panel();
            this.ComponentVariableTable = new System.Windows.Forms.TableLayoutPanel();
            this.VariableViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComponentNameLabel
            // 
            this.ComponentNameLabel.AutoSize = true;
            this.ComponentNameLabel.Location = new System.Drawing.Point(4, 4);
            this.ComponentNameLabel.Name = "ComponentNameLabel";
            this.ComponentNameLabel.Size = new System.Drawing.Size(35, 13);
            this.ComponentNameLabel.TabIndex = 0;
            this.ComponentNameLabel.Text = "label1";
            // 
            // ComponentEnabled
            // 
            this.ComponentEnabled.AutoSize = true;
            this.ComponentEnabled.Location = new System.Drawing.Point(215, 3);
            this.ComponentEnabled.Name = "ComponentEnabled";
            this.ComponentEnabled.Size = new System.Drawing.Size(15, 14);
            this.ComponentEnabled.TabIndex = 1;
            this.ComponentEnabled.UseVisualStyleBackColor = true;
            // 
            // VariableViewPanel
            // 
            this.VariableViewPanel.AutoSize = true;
            this.VariableViewPanel.Controls.Add(this.ComponentVariableTable);
            this.VariableViewPanel.Location = new System.Drawing.Point(7, 20);
            this.VariableViewPanel.Name = "VariableViewPanel";
            this.VariableViewPanel.Size = new System.Drawing.Size(220, 114);
            this.VariableViewPanel.TabIndex = 2;
            // 
            // ComponentVariableTable
            // 
            this.ComponentVariableTable.AutoSize = true;
            this.ComponentVariableTable.ColumnCount = 1;
            this.ComponentVariableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ComponentVariableTable.Location = new System.Drawing.Point(3, 3);
            this.ComponentVariableTable.Name = "ComponentVariableTable";
            this.ComponentVariableTable.RowCount = 1;
            this.ComponentVariableTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ComponentVariableTable.Size = new System.Drawing.Size(214, 108);
            this.ComponentVariableTable.TabIndex = 0;
            // 
            // InspectorComponentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VariableViewPanel);
            this.Controls.Add(this.ComponentEnabled);
            this.Controls.Add(this.ComponentNameLabel);
            this.Name = "InspectorComponentView";
            this.Size = new System.Drawing.Size(233, 137);
            this.VariableViewPanel.ResumeLayout(false);
            this.VariableViewPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ComponentNameLabel;
        private System.Windows.Forms.CheckBox ComponentEnabled;
        private System.Windows.Forms.Panel VariableViewPanel;
        private System.Windows.Forms.TableLayoutPanel ComponentVariableTable;
    }
}
