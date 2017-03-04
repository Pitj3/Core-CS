using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CoreEngine.Engine.Components;
using CoreEngine.Engine.Utils;

using System.Reflection;

namespace Editor.Windows
{
    public struct data
    {
        public string name;

        public override string ToString()
        {
            return name;
        }

        public Type objectType;
        public object value;
    }

    public partial class InspectorComponentView : UserControl
    {
        public InspectorComponentView()
        {
            InitializeComponent();

            /*
            FieldInfo[] fields = ComponentUtils.GetFields(component);
            PropertyInfo[] props = ComponentUtils.GetProperties(component);

            foreach (FieldInfo field in fields)
            {
                string name = ComponentUtils.GetName(field);
                object value = ComponentUtils.GetValue(component, field);
            }

            foreach (PropertyInfo prop in props)
            {
                string name = ComponentUtils.GetName(prop);
                object value = ComponentUtils.GetValue(component, prop);
            }
            */
        }

        public void Initialize(CoreComponent comp)
        {
            string[] arr = comp.type.Split('.');
            string name = arr[arr.Length - 1];
            this.ComponentHeader.Text = name;

            this.ComponentProperties.SelectedObject = comp;
        }

        private void ComponentProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Program.editor.editorWindow.Redraw();
        }
    }
}
