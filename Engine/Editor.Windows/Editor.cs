using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using CoreEngine.Engine.Input;
using CoreEngine.Engine.Scene;

namespace Editor.Windows
{
    public partial class Editor : Form
    {
        #region Data
        private GameObject _currentObject;
        #endregion

        public Editor()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Redraw();

            this.AddComponentSelectionBox.Items.Add("Camera");
        }

        private void OnUpdateFrame()
        {
            
        }

        private void OnRenderFrame()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(54.0f / 255.0f, 57.0f / 255.0f, 62.0f / 255.0f, 1);

            GLView.SwapBuffers();
        }

        private void AboutEditorButton(object sender, EventArgs e)
        {
            MessageBox.Show("CoreEngine Editor - Version 0.1" + Environment.NewLine + "Created by Roderick Griffioen", "About CoreEngine Editor");
        }

        private void ExitEditorButton(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void GLWidgetPaint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(54.0f / 255.0f, 57.0f / 255.0f, 62.0f / 255.0f, 1);

            GLView.SwapBuffers();
        }

        private void GLWidgetResize(object sender, EventArgs e)
        {
            if (GLView.ClientSize.Height == 0)
                GLView.ClientSize = new System.Drawing.Size(GLView.ClientSize.Width, 1);

            GL.Viewport(0, 0, GLView.ClientSize.Width, GLView.ClientSize.Height);
        }

        private void GLWidgetKeyDown(object sender, KeyEventArgs e)
        {
            Redraw();
        }

        private void GLWidgetKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Redraw();
        }

        public void Redraw()
        {
            OnUpdateFrame();
            OnRenderFrame();
        }

        public void AddSceneItem()
        {
            GameObject go = new GameObject();
            go.Name = "GameObject" + ListHierachy.Items.Count;

            LogToConsolePanel("Created Object: " + go.Name);

            ListHierachy.BeginUpdate();

            ListHierachy.Items.Add(go);

            ListHierachy.EndUpdate();

            Redraw();
        }

        private void GameObjectCreateButton(object sender, EventArgs e)
        {
            AddSceneItem();
        }

        public void LogToConsolePanel(object text)
        {
            ConsoleWindow.Items.Add(text.ToString());
        }
    }
}
