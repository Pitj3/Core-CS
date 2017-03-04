using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor.Windows
{
    public partial class AddNewComponentSelector : UserControl
    {
        public List<ComponentSelectorObject> data = new List<ComponentSelectorObject>();

        public AddNewComponentSelector()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            foreach (ComponentSelectorObject obj in data)
            {
                this.InspectorAddComponentSelector.Items.Add(obj);
            }
        }

        private void InspectorAddComponentSelector_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string fullname = "";
            foreach (ComponentSelectorObject obj in data)
            {
                if(obj.name == this.InspectorAddComponentSelector.Text)
                {
                    fullname = obj.fullname;
                }
            }

            if (fullname == "")
                return;
            
            Program.editor.editorWindow.CurrentObject.AddComponent(fullname);
            this.InspectorAddComponentSelector.SelectedValue = "";
            this.InspectorAddComponentSelector.SelectedText = "";
            this.InspectorAddComponentSelector.Text = "Add a new Component";

            Program.editor.editorWindow.UpdateInspector(Program.editor.editorWindow.CurrentObject);
        }
    }
}
