// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System;

using CoreEngine.Engine.Input;
using CoreEngine.Engine.Time;
using CoreEngine.Engine.Logging;
using CoreEngine.Engine.Scene;
using CoreEngine.Engine.Utils;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace CoreEngine.Engine.Application
{
    #region Structs
    /// <summary>
    /// Creation params for the CoreApplication
    /// </summary>
    public struct CoreApplicationCreationParams
    {
        public uint Width;
        public uint Height;
        public string Title;
        public bool Fullscreen;
        public bool VSync;
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
                Width = width,
                Height = height,
                Title = title,
                Fullscreen = fullscreen,
                VSync = vsync
            };

            CoreEngine.CurrentApplication = this;
        }

        /// <summary>
        /// CoreApplication constructor
        /// </summary>
        /// <param name="param">Params of the window, see CoreApplicationCreationParams for values</param>
        public CoreApplication(CoreApplicationCreationParams param) : this(param.Width, param.Height, param.Title, param.Fullscreen, param.VSync)
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

            // We need this for the editor, TODO: Find a better way for this
            ConverterLoader.Load();

            Logger.OnLoad(e);
            Logger.Log(LogLevel.DEBUG, "CoreApplication:OnLoad(e)");

            InputManager.OnLoad(e);
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
            CoreTime.DeltaTime = e.Time;

            if (InputManager.IsKeyDown(Key.Escape)) // TODO: Shouldn't happen like this, user should specify this
                Close();

            SceneManager.Update();
        }

        /// <summary>
        /// Called on the render of every frame
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            SceneManager.Render();

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
            Logger.Log(LogLevel.DEBUG, "CoreApplication:OnClosed(e)");
            base.OnClosed(e);
        }

        #endregion
    }
}
