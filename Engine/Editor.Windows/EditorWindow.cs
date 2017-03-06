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
using CoreEngine.Engine.Utils;

using System.Windows.Forms;

using System.Reflection;

namespace Editor.Windows
{
    public struct ComponentSelectorObject
    {
        public string name;
        public string fullname;

        public override string ToString()
        {
            return name;
        }
    }

    public class EditorWindow
    {
        #region Data
        public Editor editor;

        private GameObject currentObject;

        public Scene currentScene;
        public SceneManager sceneManager;

        public GLControl GLView;

        private List<ComponentSelectorObject> componentList = new List<ComponentSelectorObject>();

        // References to controls
        private ComponentFactory.Krypton.Toolkit.KryptonTreeView _hierarchyTreeView;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel _inspectorComponentPanel;
        private System.Windows.Forms.PropertyGrid _inspectorTransformGrid;

        public GameObject CurrentObject
        {
            get
            {
                return currentObject;
            }

            set
            {
                if (currentObject == value)
                    return;

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
            ConverterLoader.Load();

            Redraw();     

            AssemblyName[] names = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            foreach (AssemblyName assem in names)
            {
                Assembly a = Assembly.Load(assem);
                IEnumerable<Type> classes = from t in a.GetTypes() where t.IsClass select t;

                foreach (Type elem in classes)
                {
                    if (elem.BaseType != null && elem.BaseType.Name == "CoreComponent")
                    {
                        ComponentSelectorObject o = new ComponentSelectorObject();
                        o.name = elem.Name;
                        o.fullname = elem.FullName;
                        componentList.Add(o);
                        //this.AddComponentSelectionBox.Items.Add(new CoreEngine.Engine.Rendering.Camera());
                    }
                }
            }

            _hierarchyTreeView = Program.editor.GetHierarchy();
            _inspectorComponentPanel = Program.editor.GetInspector();
            _inspectorTransformGrid = Program.editor.GetInspectorTransformGrid();
            _inspectorTransformGrid.Visible = false;

            sceneManager = new SceneManager();

            currentScene = new Scene();
            SceneManager.CurrentScene = currentScene;

            CreateCameraGameObject();

            GL.Enable(EnableCap.DepthTest);
        }

        internal void OnUpdateFrame()
        {
            SceneManager.Update();


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
            GL.LoadMatrix(ref Camera.Current.Projection);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.LoadMatrix(ref Camera.Current.View);


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

            SceneManager.Render();

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
            mat.DiffuseTexture = new Texture2D("Content/Images/cube.png");

            MeshRenderer renderer = obj.AddComponent<MeshRenderer>();
            renderer.StaticMesh = PrimitiveFactory.CreateCube(1);

            renderer.StaticMesh.Meshes[0].MeshMaterial = mat;

            AddObjectToHierarchy(obj);
        }

        internal void ClickedHierarchyObject()
        {
            if (_hierarchyTreeView.SelectedNode != null)
                CurrentObject = _hierarchyTreeView.SelectedNode.Tag as GameObject;
        }

        internal void CreateCameraGameObject()
        {
            GameObject obj = GameObject.Instantiate(null) as GameObject;
            obj.Name = "Camera" + currentScene.GameObjects.Count;

            obj.LocalTransform.Position = new Vector3(10, 10, 10);

            Camera cam = obj.AddComponent<Camera>();
            cam.orthographic = false;

            Camera.Current = cam;

            AddObjectToHierarchy(obj);
        }

        internal void CreateChildGameObject()
        {
            if (currentObject == null)
            {
                CreateEmptyGameObject();
            }
            else
            {
                GameObject go = GameObject.Instantiate(null) as GameObject;
                go.Parent = currentObject;
                go.Name = "Child" + currentObject.Children.Count;

                AddObjectToHierarchy(go);
            }
        }

        internal void Redraw()
        {
            OnUpdateFrame();
            OnRenderFrame();
        }

        internal void Clicked()
        {
            currentObject = null;
            // TODO: Set inspector to nothing

            // TODO: Check if we clicked another object
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

        public void UpdateInspector(GameObject obj)
        {
            if (obj)
            {
                _inspectorTransformGrid.SelectedObject = null;
                _inspectorComponentPanel.Controls.Clear();

                _inspectorTransformGrid.Visible = true;
                _inspectorComponentPanel.Visible = true;

                _inspectorTransformGrid.SelectedObject = obj.LocalTransform;

                // new data
                foreach (CoreComponent comp in obj.Components)
                {
                    InspectorComponentView view = new InspectorComponentView();

                    foreach (PropertyInfo prop in comp.GetType().GetProperties())
                    {

                    }

                    view.Initialize(comp);
                    view.Dock = DockStyle.Top;
                    //view.Height = 200;
                    _inspectorComponentPanel.Controls.Add(view);
                }

                AddNewComponentSelector selector = new AddNewComponentSelector();
                selector.Dock = DockStyle.Top;

                selector.data = componentList;

                selector.Initialize();

                _inspectorComponentPanel.Controls.Add(selector);
            }
            else
            {
                _inspectorTransformGrid.Visible = false;
                _inspectorComponentPanel.Visible = false;

                _inspectorTransformGrid.SelectedObject = null;
                _inspectorComponentPanel.Controls.Clear();
                // no object, clear inspector
            }
        }

        public void AddObjectToHierarchy(GameObject obj)
        {
            System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode(obj.Name);
            node.Checked = true;
            node.Tag = obj;

            if (obj.Parent != null)
            {
                foreach (TreeNode n in _hierarchyTreeView.Nodes)
                {
                    if (n.Tag == obj.Parent)
                    {
                        n.Nodes.Add(node);
                        break;
                    }
                }

                Redraw();
                return;
            }

            _hierarchyTreeView.Nodes.Add(node);

            Redraw();
        }
        #endregion

        #region Private API

        #endregion
    }
}
