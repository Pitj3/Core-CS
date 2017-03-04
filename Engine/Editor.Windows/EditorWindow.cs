using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using CoreEngine.Engine.Input;
using CoreEngine.Engine.Scene;

using CoreEngine.Engine.Rendering;
using CoreEngine.Engine.Graphics;
using CoreEngine.Engine.Components;
using CoreEngine.Engine.Resources;
using System.Windows.Forms;

namespace Editor.Windows
{
    public class EditorWindow
    {
        #region Data
        public Editor editor;

        private GameObject currentObject;

        public Scene currentScene;
        public SceneManager sceneManager;

        public GLControl GLView;

        // References to controls
        private ComponentFactory.Krypton.Toolkit.KryptonTreeView _hierarchyTreeView;

        public GameObject CurrentObject
        {
            get
            {
                return currentObject;
            }

            set
            {
                currentObject = value;
                // update inspector
                UpdateInspector(currentObject);
            }
        }

        #endregion

        #region Constructors
        public EditorWindow()
        {
            this.editor = Program.editor;
        }
        #endregion

        #region Events
        internal void OnLoad(EventArgs e)
        {
            Redraw();

            //this.AddComponentSelectionBox.Items.Add(new CoreEngine.Engine.Rendering.Camera());

            _hierarchyTreeView = Program.editor.GetHierarchy();

            sceneManager = new SceneManager();

            currentScene = new Scene();
            SceneManager.CurrentScene = currentScene;

            CreateCameraGameObject();

            GL.Enable(EnableCap.DepthTest);
        }

        internal void OnUpdateFrame()
        {
            sceneManager?.Update();


            if(_hierarchyTreeView != null)
            foreach (System.Windows.Forms.TreeNode node in _hierarchyTreeView.Nodes)
            {
                ((GameObject)node.Tag).Enabled = node.Checked;
            }
        }

        internal void OnRenderFrame()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(54.0f / 255.0f, 57.0f / 255.0f, 62.0f / 255.0f, 1);

            // render editor

            if (Camera.Current == null || Camera.Current.Enabled == false)
            {
                GLView.SwapBuffers();
                return;
            }

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
            for (int x = -100; x < 100; x++)
            {
                for (int z = -100; z < 100; z++)
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

            sceneManager?.Render();

            GLView.SwapBuffers();
        }

        #endregion

        #region Public API
        internal void CreateEmptyGameObject()
        {
            GameObject obj = GameObject.Instantiate(null) as GameObject;
            obj.Name = "GameObject" + currentScene.GameObjects.Count;

            AddObjectToHierarchy(obj);
        }

        internal void CreateCubeGameObject()
        {
            GameObject obj = GameObject.Instantiate(null) as GameObject;
            obj.Name = "Cube" + currentScene.GameObjects.Count;

            Material mat = new Material(new Shader("Content/Shaders/default"));
            mat.diffuseTexture = new Texture2D("Content/Images/cube.png");

            MeshRenderer renderer = obj.AddComponent<MeshRenderer>();
            renderer.mesh = PrimitiveFactory.CreateCube(1);
            renderer.AddMaterial(mat);

            AddObjectToHierarchy(obj);
        }

        internal void CreateCameraGameObject()
        {
            GameObject obj = GameObject.Instantiate(null) as GameObject;
            obj.Name = "Camera" + currentScene.GameObjects.Count;

            obj.position = new Vector3(10, 10, 10);

            Camera cam = obj.AddComponent<Camera>();
            cam.orthographic = false;

            Camera.Current = cam;

            AddObjectToHierarchy(obj);
        }

        internal void Redraw()
        {
            OnUpdateFrame();
            OnRenderFrame();
        }

        internal void Clicked()
        {
            currentObject = null;
            // Set inspector to nothing

            // check if we clicked another object
        }

        internal void CreateChildGameObject()
        {
            if (currentObject == null)
                CreateEmptyGameObject();
            else
            {
                GameObject go = GameObject.Instantiate(null) as GameObject;
                go.Parent = currentObject;
                go.Name = "Child" + currentObject.Children.Count;

                UpdateHierarchy();
            }
        }

        internal void UpdateHierarchy()
        {
            if (_hierarchyTreeView != null)
            {
                _hierarchyTreeView.Nodes.Clear();

                foreach (GameObject go in currentScene.GameObjects)
                {
                    System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode();
                    node.Text = go.Name;
                    node.Tag = go;

                    if (go.Parent)
                    {
                        foreach (TreeNode n in _hierarchyTreeView.Nodes)
                        {
                            if (n.Tag == go.Parent)
                            {
                                n.Text = go.Parent.Name;
                                n.Nodes.Add(node);
                                break;
                            }
                        }
                    }
                    else
                    {
                        node.Text = go.Name;
                        _hierarchyTreeView.Nodes.Add(node);
                    }
                }
            }
        }

        private void LoadChildrenIntoHierarchy(GameObject go, ref TreeNode node)
        {
            foreach (GameObject child in go.Children)
            {
                System.Windows.Forms.TreeNode n = new System.Windows.Forms.TreeNode();
                n.Text = child.Name;
                n.Tag = child;

                LoadChildrenIntoHierarchy(child, ref n);

                node.Nodes.Add(n);  
            }
        }
        #endregion

        #region Private API
        private void UpdateInspector(GameObject obj)
        {
            if(obj)
            {
                // new data
                System.Reflection.FieldInfo[] fields = obj.GetType().GetFields();
                Type fieldType = fields[0].FieldType;
            }
            else
            { 
                // no update, clear inspector
            }
        }

        private void AddObjectToHierarchy(GameObject obj)
        {
            // add to list

            System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode(obj.Name);
            node.Checked = true;
            node.Tag = obj;
            _hierarchyTreeView.Nodes.Add(node);

            Redraw();
        }  
        #endregion
    }
}
