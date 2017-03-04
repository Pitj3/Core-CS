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
using ComponentFactory.Krypton.Toolkit;

namespace Editor.Windows
{
    public partial class Editor : Form
    {
        #region Data
        public EditorWindow editorWindow;
        #endregion

        public Editor()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            editorWindow = new EditorWindow();
            editorWindow.GLView = this.GLView;
            editorWindow.OnLoad(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            GLView.Dispose();
        }

        private void GLViewKeyDown(object sender, KeyEventArgs e)
        {
            editorWindow?.Redraw();
        }

        internal KryptonTreeView GetHierarchy()
        {
            return this.HierarchyTree;
        }

        internal KryptonPanel GetInspector()
        {
            return this.InspectorComponentsPanel;
        }

        internal PropertyGrid GetInspectorTransformGrid()
        {
            return this.TransformGrid;
        }

        private void GLViewPaint(object sender, PaintEventArgs e)
        {
            editorWindow?.Redraw();
        }

        private void GLViewResize(object sender, EventArgs e)
        {
            //resize
            editorWindow?.Redraw();
        }

        private void AboutEditorButton(object sender, EventArgs e)
        {
            MessageBox.Show("CoreEngine Editor - Version 0.1" + Environment.NewLine + "Created by Roderick Griffioen", "About CoreEngine Editor");
        }

        private void ExitEditorButton(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void GameObjectCreateButton(object sender, EventArgs e)
        {
            editorWindow.CreateEmptyGameObject();
        }

        private void CreateMenuCreate3DCubeButton(object sender, EventArgs e)
        {
            editorWindow.CreateCubeGameObject();
        }

        private void CreateMenuCreateCamera(object sender, EventArgs e)
        {
            editorWindow.CreateCameraGameObject();
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
            this.HierarchyTree.Nodes.Clear();

            SceneManager.LoadScene(LoadSceneDialog.FileName);

            foreach(GameObject go in SceneManager.CurrentScene.GameObjects)
            {
                editorWindow.AddObjectToHierarchy(go);
            }
        }

        private void FileMenuNewOptionClicked(object sender, EventArgs e)
        {
            Scene newScene = new Scene();
            SceneManager.CurrentScene = newScene;

            this.HierarchyTree.Nodes.Clear();

            editorWindow.CreateCameraGameObject();
        }

        private void Editor_Load(object sender, EventArgs e)
        {

        }

        private void HierarchyTreeNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            editorWindow.Redraw();

            editorWindow.ClickedHierarchyObject();
        }

        private void GLViewLoaded(object sender, EventArgs e)
        {

        }

        private void GLViewClicked(object sender, EventArgs e)
        {
            editorWindow.Clicked();
        }

        private void CreateChildGameObject(object sender, EventArgs e)
        {
            editorWindow.CreateChildGameObject();
        }

        private void TransformGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            editorWindow.Redraw();
        }
    }
}
