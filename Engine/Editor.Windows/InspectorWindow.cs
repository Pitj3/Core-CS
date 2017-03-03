using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using OpenTK;

using CoreEngine.Engine.Scene;
using CoreEngine.Engine.Components;

namespace Editor.Windows
{
    public partial class Editor // INSPECTOR
    {
        private void ListHierarchyObjectSelected(object sender, EventArgs e)
        {
            // update inspector
            _currentObject = (GameObject)ListHierachy.SelectedItem;

            if (_currentObject == null)
                return;

            InspectorComponentsBox.Items.Clear();

            // load gameobject data to inspector
            PositionX.Text = _currentObject.position.X.ToString();
            PositionY.Text = _currentObject.position.Y.ToString();
            PositionZ.Text = _currentObject.position.Z.ToString();

            RotationX.Text = _currentObject.rotationEuler.X.ToString();
            RotationY.Text = _currentObject.rotationEuler.Y.ToString();
            RotationZ.Text = _currentObject.rotationEuler.Z.ToString();

            foreach (CoreComponent comp in _currentObject.Components)
            {
                InspectorComponentsBox.Items.Add(comp.type);
            }

            InspectorPanel.Visible = true;
        }

        private void InspectorComponentsBoxComponentSelected(object sender, EventArgs e)
        {

        }

        private void GLWidgetMouseClick(object sender, MouseEventArgs e)
        {
            InspectorPanel.Visible = false;

            ListHierachy.SelectedItem = null;
        }

        private void AddComponentSelectionBoxSelectedComponent(object sender, EventArgs e)
        { 
            if (_currentObject == null)
                return;

            _currentObject.AddComponent(((CoreComponent)AddComponentSelectionBox.SelectedItem).systemType.ToString());

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
                Redraw();
            }
            else
            {
                if(PositionX.Text == "")
                {
                    _currentObject.position.X = 0;
                }
                PositionX.Text = _currentObject.position.X.ToString();
            }
        }

        private void PositionYBoxChanged(object sender, EventArgs e)
        {
            float r = 0.0f;
            if (float.TryParse(PositionY.Text, out r))
            {
                _currentObject.position.Y = r;
                Redraw();
            }
            else
            {
                if (PositionY.Text == "")
                {
                    _currentObject.position.Y = 0;
                }
                PositionY.Text = _currentObject.position.Y.ToString();
            }
        }

        private void PositionZBoxChanged(object sender, EventArgs e)
        {
            float r = 0.0f;
            if (float.TryParse(PositionZ.Text, out r))
            {
                _currentObject.position.Z = r;
                Redraw();
            }
            else
            {
                if (PositionZ.Text == "")
                {
                    _currentObject.position.Z = 0;
                }
                PositionZ.Text = _currentObject.position.Z.ToString();
            }
        }

        private void RotationXBoxChanged(object sender, EventArgs e)
        {
            float r = 0.0f;
            if (float.TryParse(RotationX.Text, out r))
            {
                _currentObject.rotationEuler.X = r;
                _currentObject.rotation = OpenTK.Quaternion.FromEulerAngles(MathHelper.DegreesToRadians(r), MathHelper.DegreesToRadians(_currentObject.rotationEuler.Y), MathHelper.DegreesToRadians(_currentObject.rotationEuler.Z));
                Redraw();
            }
            else
            {
                if (RotationX.Text == "")
                {
                    _currentObject.rotationEuler.X = 0;
                    _currentObject.rotation = OpenTK.Quaternion.FromEulerAngles(0, MathHelper.DegreesToRadians(_currentObject.rotationEuler.Y), MathHelper.DegreesToRadians(_currentObject.rotationEuler.Z));
                }

                RotationX.Text = _currentObject.rotationEuler.X.ToString();
            }
        }

        private void RotationYBoxChanged(object sender, EventArgs e)
        {
            float r = 0.0f;
            if (float.TryParse(RotationY.Text, out r))
            {
                _currentObject.rotation = OpenTK.Quaternion.FromEulerAngles(MathHelper.DegreesToRadians(_currentObject.rotationEuler.X), MathHelper.DegreesToRadians(r), MathHelper.DegreesToRadians(_currentObject.rotationEuler.Z));
                _currentObject.rotationEuler.Y = r;
                Redraw();
            }
            else
            {
                if (RotationY.Text == "")
                {
                    _currentObject.rotationEuler.Y = 0;
                    _currentObject.rotation = OpenTK.Quaternion.FromEulerAngles(MathHelper.DegreesToRadians(_currentObject.rotationEuler.X), 0, MathHelper.DegreesToRadians(_currentObject.rotationEuler.Z));
                }

                RotationY.Text = _currentObject.rotationEuler.Y.ToString();
            }
        }

        private void RotationZBoxChanged(object sender, EventArgs e)
        {
            float r = 0.0f;
            if (float.TryParse(RotationZ.Text, out r))
            {
                _currentObject.rotationEuler.Z = r;
                _currentObject.rotation = OpenTK.Quaternion.FromEulerAngles(MathHelper.DegreesToRadians(_currentObject.rotationEuler.X), MathHelper.DegreesToRadians(_currentObject.rotationEuler.Y), MathHelper.DegreesToRadians(r));
                Redraw();
            }
            else
            {
                if (RotationZ.Text == "")
                {
                    _currentObject.rotationEuler.Z = 0;
                    _currentObject.rotation = OpenTK.Quaternion.FromEulerAngles(MathHelper.DegreesToRadians(_currentObject.rotationEuler.X), MathHelper.DegreesToRadians(_currentObject.rotationEuler.Y), 0);
                }

                RotationZ.Text = _currentObject.rotationEuler.Z.ToString();
            }
        }
    }
}
