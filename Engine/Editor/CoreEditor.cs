using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using CoreEngine.Engine.Scene;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Editor
{
    public partial class CoreEditor : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public CoreEditor()
        {
            Toolkit.Init();

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            glControl1_Resize(this, EventArgs.Empty);   // Ensure the Viewport is set up correctly
            GL.ClearColor(54.0f / 255.0f, 57.0f / 255.0f, 62.0f / 255.0f, 1);
        }

        private void CoreEditor_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            glControl1.MakeCurrent();

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(54.0f / 255.0f, 57.0f / 255.0f, 62.0f / 255.0f, 1);
            glControl1.SwapBuffers();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (glControl1.ClientSize.Height == 0)
                glControl1.ClientSize = new System.Drawing.Size(glControl1.ClientSize.Width, 1);

            GL.Viewport(0, 0, glControl1.ClientSize.Width, glControl1.ClientSize.Height);
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                this.Close();
                break;
            }
        }

        OpenFileDialog fileDialog = new OpenFileDialog();

        private void LoadScene(object sender, EventArgs e)
        {
            fileDialog.InitialDirectory = "c:\\";
            fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.FilterIndex = 2;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = File.OpenText(fileDialog.FileName))
                {
                    string data = sr.ReadToEnd();
                    SceneManager.LoadSceneByString(data, "Content/Scenes/" + fileDialog.SafeFileName.Remove(fileDialog.SafeFileName.Length - 4, 4));
                }
            }
            
        }
        
        private void OpenFile(object sender, CancelEventArgs e)
        {
            SceneManager.LoadScene(fileDialog.FileName);

            Console.WriteLine(fileDialog.FileName);
        }

        private void SaveScene(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
