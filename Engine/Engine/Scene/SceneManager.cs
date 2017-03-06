// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System.Collections.Generic;

using CoreEngine.Engine.Components;
using CoreEngine.Engine.Rendering;

namespace CoreEngine.Engine.Scene
{
    /// <summary>
    /// Scene Manager class
    /// </summary>
    public class SceneManager
    {
        #region Data
        
        public static SceneManager Instance = null;
        public static Scene CurrentScene = null;
        #endregion

        #region Public Static API
        /// <summary>
        /// Loads a scene
        /// </summary>
        /// <param name="name">Name of the scene</param>
        public static void LoadScene(string name)
        {
            Scene scene = new Scene();
            scene.Load(name);
        }
        #endregion

        #region Interal API
        /// <summary>
        /// Update the scene
        /// </summary>
        internal static void Update()
        {
            if (CurrentScene == null)
                return;

            foreach(GameObject go in CurrentScene.GameObjects)
            {
                if (go.Enabled == false)
                    continue;

                CurrentScene.CurrentObject = go;
                foreach (CoreComponent comp in go.Components)
                {
                    if (comp.Enabled == false)
                        continue;

                    comp.Update();
                }
            }
        }

        /// <summary>
        /// Fixed update the scene
        /// </summary>
        internal static void FixedUpdate()
        {
            if (CurrentScene == null)
                return;

            foreach (GameObject go in CurrentScene.GameObjects)
            {
                if (go.Enabled == false)
                    continue;

                CurrentScene.CurrentObject = go;
                foreach (CoreComponent comp in go.Components)
                {
                    if (comp.Enabled == false)
                        continue;

                    comp.FixedUpdate();
                }
            }
        }

        /// <summary>
        /// Render the scene
        /// </summary>
        internal static void Render()
        {
            if (CurrentScene == null)
                return;

            // grab all cameras
            List<Camera> _cameras = new List<Camera>();
            foreach (GameObject go in CurrentScene.GameObjects)
            {
                if (go.Enabled == false)
                    continue;

                foreach (CoreComponent comp in go.Components)
                {
                    if(comp is Camera && comp.Enabled == true)
                    {
                        _cameras.Add((Camera)comp);
                    }
                }
            }

            foreach(Camera cam in _cameras)
            {
                Camera.Current = cam;

                OnPreRender();
                OnRenderObject();
                OnPostRender();
            }
        }

        /// <summary>
        /// Pre render the scene
        /// </summary>
        internal static void OnPreRender()
        {
            Camera.Current.OnPreRender();

            foreach (GameObject go in CurrentScene.GameObjects)
            {
                if (go.Enabled == false)
                    continue;

                CurrentScene.CurrentObject = go;
                foreach (CoreComponent comp in go.Components)
                {
                    if (comp is Camera || comp.Enabled == false)
                        continue;

                    comp.OnPreRender();
                }
            }
        }

        /// <summary>
        /// Render the scene
        /// </summary>
        internal static void OnRenderObject()
        {
            Camera.Current.OnRenderObject();

            foreach (GameObject go in CurrentScene.GameObjects)
            {
                if (go.Enabled == false)
                    continue;

                CurrentScene.CurrentObject = go;
                foreach (CoreComponent comp in go.Components)
                {
                    if (comp is Camera || comp.Enabled == false)
                        continue;

                    comp.OnRenderObject();
                }
            }
        }

        /// <summary>
        /// Post render the scene
        /// </summary>
        internal static void OnPostRender()
        {
            Camera.Current.OnPostRender();

            foreach (GameObject go in CurrentScene.GameObjects)
            {
                if (go.Enabled == false)
                    continue;

                CurrentScene.CurrentObject = go;
                foreach (CoreComponent comp in go.Components)
                {
                    if (comp is Camera || comp.Enabled == false)
                        continue;

                    comp.OnPostRender();
                }
            }
        }
        #endregion
    }
}
