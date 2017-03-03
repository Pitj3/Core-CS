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

using CoreEngine.Engine.Rendering;
using CoreEngine.Engine.Graphics;
using CoreEngine.Engine.Components;
using CoreEngine.Engine.Resources;

namespace Editor.Windows
{
    public partial class Editor : Form
    {
        #region Data
        private GameObject _currentObject;

        private Scene _currentScene;
        private SceneManager _sceneManager;
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

            this.AddComponentSelectionBox.Items.Add(new CoreEngine.Engine.Rendering.Camera());

            _sceneManager = new SceneManager();

            _currentScene = new Scene();
            SceneManager.CurrentScene = _currentScene;

            CreateMenuCreateCamera(null, null);

            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            GLView.Dispose();
        }

        private void OnUpdateFrame()
        {
            _sceneManager?.Update();
        }

        private void OnRenderFrame()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(54.0f / 255.0f, 57.0f / 255.0f, 62.0f / 255.0f, 1);

            // render editor

            if (Camera.Current == null)
                return;

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.LoadMatrix(ref Camera.Current.projection);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.LoadMatrix(ref Camera.Current.view);


            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.PushMatrix();
            GL.Translate(0, 0, 0);
            GL.Begin(PrimitiveType.Quads);
            for(int x = -10; x < 10; x++)
            {
                for(int z = -10; z < 10; z++)
                {
                    GL.Vertex3(x + 1, 0, z);
                    GL.Vertex3(x, 0, z);
                    GL.Vertex3(x, 0, z + 1);
                    GL.Vertex3(x + 1, 0, z + 1);
                }
            }
            GL.End();
            GL.PopMatrix();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            _sceneManager?.Render();

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
            OnUpdateFrame();
            OnRenderFrame();
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

        public void AddSceneItem(GameObject obj)
        {
            LogToConsolePanel("Created Object: " + obj.Name);

            ListHierachy.BeginUpdate();

            ListHierachy.Items.Add(obj);

            ListHierachy.EndUpdate();

            Redraw();
        }

        private void GameObjectCreateButton(object sender, EventArgs e)
        {
            GameObject obj = GameObject.Instantiate(null) as GameObject;
            obj.Name = "GameObject" + ListHierachy.Items.Count;

            AddSceneItem(obj);
        }

        public void LogToConsolePanel(object text)
        {
            ConsoleWindow.Items.Add(text.ToString());
        }

        private void CreateMenuCreate3DCubeButton(object sender, EventArgs e)
        {
            GameObject obj = GameObject.Instantiate(null) as GameObject;
            obj.Name = "Cube" + ListHierachy.Items.Count;

            Material mat = new Material(new Shader("Content/Shaders/default"));
            mat.diffuseTexture = new Texture2D("Content/Images/cube.png");

            MeshRenderer renderer = obj.AddComponent<MeshRenderer>();
            renderer.mesh = PrimitiveFactory.CreateCube(1);
            renderer.AddMaterial(mat);

            AddSceneItem(obj);
        }

        private void CreateMenuCreateCamera(object sender, EventArgs e)
        {
            GameObject obj = GameObject.Instantiate(null) as GameObject;
            obj.Name = "Camera" + ListHierachy.Items.Count;

            obj.position = new Vector3(10, 10, 10);

            Camera cam = obj.AddComponent<Camera>();
            cam.orthographic = false;

            Camera.Current = cam;

            AddSceneItem(obj);
        }

        private void FileMenuSaveOptionClicked(object sender, EventArgs e)
        {
            if(SceneManager.CurrentScene.Name == "unnamed")
            {
                // open file dialog
                SaveSceneDialog.ShowDialog();
                return;
            }

            SceneManager.CurrentScene.Save();
        }

        private void SaveSceneDialog_FileOk(object sender, CancelEventArgs e)
        {
            string[] arr = SaveSceneDialog.FileName.Split('\\');
            string scenename = arr[arr.Length - 1];

            SceneManager.CurrentScene.Name = scenename;

            SceneManager.CurrentScene.Save(SaveSceneDialog.FileName.TrimEnd(scenename.ToCharArray()));
        }

        private void FileMenuLoadOptionClicked(object sender, EventArgs e)
        {
            LoadSceneDialog.ShowDialog();
        }

        private void LoadSceneDialog_FileOk(object sender, CancelEventArgs e)
        {
            ListHierachy.Items.Clear();

            SceneManager.LoadScene(LoadSceneDialog.FileName);

            foreach(GameObject go in SceneManager.CurrentScene.GameObjects)
            {
                AddSceneItem(go);
            }
        }

        private void FileMenuNewOptionClicked(object sender, EventArgs e)
        {
            Scene newScene = new Scene();
            SceneManager.CurrentScene = newScene;

            ListHierachy.Items.Clear();

            CreateMenuCreateCamera(null, null);
        }
    }
}
