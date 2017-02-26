using System.Collections.Generic;

using CoreEngine.Engine.Core;
using CoreEngine.Engine.Components;
using CoreEngine.Engine.Rendering;
using OpenTK;

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

        #region Constructors
        public SceneManager()
        {
            Instance = this;
        }
        #endregion

        #region Static API
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

        #region Public API
        /// <summary>
        /// Update the scene
        /// </summary>
        public void Update()
        {
            foreach(GameObject go in CurrentScene.GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    comp.Update();
                }
            }
        }

        /// <summary>
        /// Fixed update the scene
        /// </summary>
        public void FixedUpdate()
        {
            foreach (GameObject go in CurrentScene.GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    comp.FixedUpdate();
                }
            }
        }

        /// <summary>
        /// Render the scene
        /// </summary>
        public void Render()
        {
            // grab all cameras
            List<Camera> _cameras = new List<Camera>();
            foreach (GameObject go in CurrentScene.GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    if(comp is Camera)
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
        #endregion

        #region Interal API
        /// <summary>
        /// Pre render the scene
        /// </summary>
        internal void OnPreRender()
        {
            Camera.Current.OnPreRender();

            foreach (GameObject go in CurrentScene.GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    if (comp is Camera)
                        continue;

                    comp.OnPreRender();
                }
            }
        }

        /// <summary>
        /// Render the scene
        /// </summary>
        internal void OnRenderObject()
        {
            Camera.Current.OnRenderObject();

            foreach (GameObject go in CurrentScene.GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    if (comp is Camera)
                        continue;

                    comp.OnRenderObject();
                }
            }
        }

        /// <summary>
        /// Post render the scene
        /// </summary>
        internal void OnPostRender()
        {
            Camera.Current.OnPostRender();

            foreach (GameObject go in CurrentScene.GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    if (comp is Camera)
                        continue;

                    comp.OnPostRender();
                }
            }
        }
        #endregion
    }
}
