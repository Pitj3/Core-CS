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
        public Game(uint width = 800, uint height = 600, string title = "Core Application", bool fullscreen = false, bool vsync = true) : base(width, height, title, fullscreen, vsync)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SceneManager.LoadScene("Content/Scenes/Game.txt");
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            SwapBuffers();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
    }
}
