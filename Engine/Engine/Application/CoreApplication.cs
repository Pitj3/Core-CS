// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

using CoreEngine.Engine.Input;
using CoreEngine.Engine.Time;
using CoreEngine.Engine.Logging;

using CoreEngine.Engine.Scene;

using CoreEngine.Engine.Interface;

using CoreEngine.Engine.Utils;

namespace CoreEngine.Engine.Application
{
    #region Structs
    /// <summary>
    /// Creation params for the CoreApplication
    /// </summary>
    public struct CoreApplicationCreationParams
    {
        public uint width;
        public uint height;
        public string title;
        public bool fullscreen;
        public bool vsync;
    };
    #endregion

    /// <summary>
    /// Main Application class
    /// </summary>
    public class CoreApplication : GameWindow
    {
        #region Data
        private CoreApplicationCreationParams _params;

        private uint _width, _height;
        private string _title;
        private bool _fullscreen, _vsync;
        private SceneManager _scene;
        #endregion

        #region Constructors
        /// <summary>
        /// CoreApplication constructor
        /// </summary>
        /// <param name="width">Width of the window</param>
        /// <param name="height">Height of the window</param>
        /// <param name="title">Title of the window</param>
        /// <param name="fullscreen">Should this window by fullscreen</param>
        /// <param name="vsync">Should this windows use vsync</param>
        public CoreApplication(uint width = 800, uint height = 600, string title = "Core Application", bool fullscreen = false, bool vsync = true) : base((int)width, (int)height, OpenTK.Graphics.GraphicsMode.Default, title, fullscreen?GameWindowFlags.Fullscreen:GameWindowFlags.Default)
        {
            this._width = width;
            this._height = height;
            this._title = title;
            this._fullscreen = fullscreen;
            this._vsync = vsync;

            _params = new CoreApplicationCreationParams()
            {
                width = width,
                height = height,
                title = title,
                fullscreen = fullscreen,
                vsync = vsync
            };

            CoreEngine.CurrentApplication = this;
        }

        /// <summary>
        /// CoreApplication constructor
        /// </summary>
        /// <param name="param">Params of the window, see CoreApplicationCreationParams for values</param>
        public CoreApplication(CoreApplicationCreationParams param) : this(param.width, param.height, param.title, param.fullscreen, param.vsync)
        {

        }
        #endregion

        #region Events
        /// <summary>
        /// Called when the Application is loaded
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ConverterLoader.Load();

            Logger.OnLoad(e);
            Logger.Log(LogLevel.DEBUG, "CoreApplication:OnLoad(e)");
            InputManager.OnLoad(e);

            _scene = new SceneManager();
        }

        /// <summary>
        /// Called when the Application is unloaded
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnUnload(EventArgs e)
        {
            Logger.Log(LogLevel.DEBUG, "CoreApplication:OnUnload(e)");
            base.OnUnload(e);

            InputManager.OnUnload(e);
        }

        /// <summary>
        /// Called on the update of every frame
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            CoreTime.deltaTime = e.Time;

            if (InputManager.IsKeyDown(Key.Escape))
                Close();

            _scene?.Update();
        }

        /// <summary>
        /// Called on the render of every frame
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(54.0f / 255.0f, 57.0f / 255.0f, 62.0f / 255.0f, 1);

            _scene?.Render();

            InputManager.OnRenderFrame(e);
        }

        /// <summary>
        /// Called when the Application window is resized
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnResize(EventArgs e)
        {
            Logger.Log(LogLevel.DEBUG, "CoreApplication:OnResize(e)");
            base.OnResize(e);
        }

        /// <summary>
        /// Called when the Application window is moved
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
        }

        /// <summary>
        /// Called when the Title of the Application is changed
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnTitleChanged(EventArgs e)
        {
            Logger.Log(LogLevel.DEBUG, "CoreApplication:OnTitleChanged(e)");
            base.OnTitleChanged(e);
        }

        /// <summary>
        /// Called when the Application is closed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            if(SceneManager.CurrentScene != null)
                SceneManager.CurrentScene.Save();

            Logger.Log(LogLevel.DEBUG, "CoreApplication:OnClosed(e)");
            base.OnClosed(e);
        }

        #endregion
    }
}
