using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using CoreEngine.Engine.Scene;

namespace Editor.Windows
{
    public partial class Editor // INSPECTOR
    {
        private void ListHierarchyObjectSelected(object sender, EventArgs e)
        {
            // update inspector
            _currentObject = (GameObject)ListHierachy.SelectedItem;

            // load gameobject data to inspector
            PositionX.Text = _currentObject.position.X.ToString();
            PositionY.Text = _currentObject.position.Y.ToString();
            PositionZ.Text = _currentObject.position.Z.ToString();

            RotationX.Text = _currentObject.rotation.Xyz.X.ToString();
            RotationY.Text = _currentObject.rotation.Xyz.Y.ToString();
            RotationZ.Text = _currentObject.rotation.Xyz.Z.ToString();

            InspectorPanel.Visible = true;
        }

        private void InspectorComponentsBoxComponentSelected(object sender, EventArgs e)
        {

        }

        private void AddComponentSelectionBoxSelectedComponent(object sender, EventArgs e)
        {
            InspectorComponentsBox.Items.Add(AddComponentSelectionBox.SelectedItem.ToString());
            AddComponentSelectionBox.Text = "";
            AddComponentSelectionBox.SelectedText = "";
        }

        private void PositionXBoxChanged(object sender, EventArgs e)
        {
            float r = 0.0f;
            if (float.TryParse(PositionX.Text, out r))
            {
                _currentObject.position.X = r;
            }
            else
            {
                PositionX.Text = _currentObject.position.X.ToString();
            }
        }

        private void PositionYBoxChanged(object sender, EventArgs e)
        {
            float r = 0.0f;
            if (float.TryParse(PositionY.Text, out r))
            {
                _currentObject.position.Y = r;
            }
            else
            {
                PositionY.Text = _currentObject.position.Y.ToString();
            }
        }

        private void PositionZBoxChanged(object sender, EventArgs e)
        {
            float r = 0.0f;
            if (float.TryParse(PositionZ.Text, out r))
            {
                _currentObject.position.Z = r;
            }
            else
            {
                PositionZ.Text = _currentObject.position.Z.ToString();
            }
        }

        private void RotationYBoxChanged(object sender, EventArgs e)
        {
            float r = 0.0f;
            if (float.TryParse(RotationY.Text, out r))
            {
                _currentObject.rotation *= OpenTK.Quaternion.FromEulerAngles(0, r, 0);
            }
            else
            {
                RotationY.Text = _currentObject.rotation.Xyz.Z.ToString();
            }
        }

        private void RotationXBoxChanged(object sender, EventArgs e)
        {
            float r = 0.0f;
            if (float.TryParse(RotationX.Text, out r))
            {
                _currentObject.rotation *= OpenTK.Quaternion.FromEulerAngles(r, 0, 0);
            }
            else
            {
                RotationX.Text = _currentObject.rotation.Xyz.X.ToString();
            }
        }

        private void RotationZBoxChanged(object sender, EventArgs e)
        {
            float r = 0.0f;
            if (float.TryParse(RotationZ.Text, out r))
            {
                _currentObject.rotation *= OpenTK.Quaternion.FromEulerAngles(0, 0, r);
            }
            else
            {
                RotationZ.Text = _currentObject.rotation.Xyz.Z.ToString();
            }
        }
    }
}
