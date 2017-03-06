using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using CoreEngine.Engine;
using CoreEngine.Engine.Application;
using CoreEngine.Engine.Graphics;
using CoreEngine.Engine.Resources;
using CoreEngine.Engine.Scene;
using CoreEngine.Engine.Components;

using CoreEngine.Engine.Rendering;
using CoreEngine.Engine.Rendering.Lighting;

using CoreEngine.Engine.Input;

/*
Material mat = new Material(new Shader("Content/Shaders/default"));
mat.diffuseTexture = new Texture2D("Content/Images/image.png");

GameObject camera = GameObject.Instantiate(null) as GameObject;
camera.Name = "Main Camera";

Camera camComponent = camera.AddComponent<Camera>();

GameObject quadObject = GameObject.Instantiate(null) as GameObject;
quadObject.Name = "Logo";

MeshRenderer renderer = quadObject.AddComponent<MeshRenderer>();
renderer.mesh = PrimitiveFactory.CreateQuad(100, 100, 1050, 490);
renderer.materials.Add(mat);
*/

namespace CoreEngine.Tests
{
    public class Game : CoreApplication
    {
        public GameObject quadObject;

        public Game(uint width = 800, uint height = 600, string title = "Core Application", bool fullscreen = false, bool vsync = true) : base(width, height, title, fullscreen, vsync)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.Disable(EnableCap.CullFace);

            SceneManager.LoadScene("Content/Scenes/Game.txt");

            return;

            SceneManager.CurrentScene = new Scene();
            SceneManager.CurrentScene.Name = "Game.txt";

            GameObject camera = GameObject.Instantiate(null) as GameObject;
            camera.Name = "Main Camera";
            camera.LocalTransform.Position = new Vector3(10, 15, 10);

            Camera camComponent = camera.AddComponent<Camera>();
            camComponent.orthographic = false;

            quadObject = GameObject.Instantiate(null, Vector3.Zero, Quaternion.Identity) as GameObject;
            quadObject.Name = "Muro";
            quadObject.LocalTransform.Scale = new Vector3(0.05f, 0.05f, 0.05f);

            MeshRenderer renderer = quadObject.AddComponent<MeshRenderer>();

            StaticModel model = new StaticModel("Content/Models/muro.fbx");
            renderer.StaticMesh = model;

            GameObject sun = GameObject.Instantiate(null, new Vector3(0, 5, 5), Quaternion.Identity) as GameObject;
            sun.Name = "Sun";
            sun.AddComponent<DirectionalLight>();
            MeshRenderer sunRenderer = sun.AddComponent<MeshRenderer>();

            StaticModel sunModel = PrimitiveFactory.CreateCube(1);
            sunRenderer.StaticMesh = sunModel;
            Material sunmat = new Material(new Shader("Content/Shaders/default"));
            sunmat.DiffuseTexture = new Texture2D("Content/Images/checker.png");
            sunModel.Meshes[0].MeshMaterial = sunmat;

            GameObject plane = GameObject.Instantiate(null, new Vector3(-10, 0, -10), Quaternion.Identity) as GameObject;
            plane.Name = "Plane";
            MeshRenderer planeRenderer = plane.AddComponent<MeshRenderer>();

            StaticModel planeModel = PrimitiveFactory.CreatePlane(20, 20);
            planeRenderer.StaticMesh = planeModel;
            Material mat = new Material(new Shader("Content/Shaders/default"));
            mat.DiffuseTexture = new Texture2D("Content/Images/checker.png");
            planeModel.Meshes[0].MeshMaterial = mat; 
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            quadObject = GameObject.Find("Muro");

            if(InputManager.IsKeyDown(Key.A))
            {
                quadObject.LocalTransform.EulerRotation += new Vector3(0, -0.015f, 0);
            }
            if (InputManager.IsKeyDown(Key.D))
            {
                quadObject.LocalTransform.EulerRotation += new Vector3(0, 0.015f, 0);
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            SwapBuffers();
        }

        protected override void OnClosed(EventArgs e)
        {
            SceneManager.CurrentScene.Save("Content/Scenes/");
            base.OnClosed(e);
        }
    }
}
