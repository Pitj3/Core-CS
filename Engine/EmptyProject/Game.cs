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


namespace EmptyProject
{
    public class Game : CoreApplication
    {
        public Game(uint width = 800, uint height = 600, string title = "Core Application", bool fullscreen = false, bool vsync = true) : base(width, height, title, fullscreen, vsync)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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
