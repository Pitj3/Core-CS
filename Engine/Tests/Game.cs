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

using CoreEngine.Engine.Rendering;

namespace CoreEngine.Tests
{
    public class Game : CoreApplication
    {
        #region Data
        private Mesh _mesh;
        private Shader _shader;
        private Texture2D _texture;

        private int _mvpLoc, _diffuseLoc;

        private GameObject cam;
        #endregion

        public Game(uint width = 800, uint height = 600, string title = "Core Application", bool fullscreen = false, bool vsync = true) : base(width, height, title, fullscreen, vsync)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _mesh = PrimitiveFactory.CreateQuad(100, 100, 1050, 490);

            _shader = new Shader("Content/Shaders/default");
            _mvpLoc = _shader.GetVariableLocation("mvp");
            _diffuseLoc = _shader.GetVariableLocation("diffuse");

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.Uniform1(_diffuseLoc, 0);

            GL.Disable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.Disable(EnableCap.CullFace);

            _texture = new Texture2D("Content/Images/image.png");

            cam = GameObject.Instantiate(null) as GameObject;
            Camera camComp = cam.AddComponent<Camera>();
            camComp.
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(54.0f / 255.0f, 57.0f / 255.0f, 62.0f / 255.0f, 1);

            _shader.Bind();

            Matrix4 mvp = Matrix4.CreateOrthographicOffCenter(0, 1280, 720, 0, -10, 10);
            GL.UniformMatrix4(_mvpLoc, false, ref mvp);

            GL.BindTexture(TextureTarget.Texture2D, _texture.ID);

            _mesh.Render();

            _shader.Unbind();

            SwapBuffers();

        }
    }
}
