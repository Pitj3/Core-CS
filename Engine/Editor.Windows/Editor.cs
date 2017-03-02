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

namespace Editor.Windows
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            while(GLWidget.IsIdle)
            {
                OnUpdateFrame();
                OnRenderFrame();
            }
        }

        private void OnUpdateFrame()
        {
            
        }

        private void OnRenderFrame()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(54.0f / 255.0f, 57.0f / 255.0f, 62.0f / 255.0f, 1);

            GLWidget.SwapBuffers();
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
            GLWidget.MakeCurrent();

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GLWidget.SwapBuffers();
        }

        private void GLWidgetResize(object sender, EventArgs e)
        {
            if (GLWidget.ClientSize.Height == 0)
                GLWidget.ClientSize = new System.Drawing.Size(GLWidget.ClientSize.Width, 1);

            GL.Viewport(0, 0, GLWidget.ClientSize.Width, GLWidget.ClientSize.Height);
        }
    }
}
