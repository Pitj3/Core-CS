using System.Collections.Generic;

using CoreEngine.Engine.Core;
using CoreEngine.Engine.Components;
using CoreEngine.Engine.Rendering;
using OpenTK;

namespace CoreEngine.Engine.Scene
{
    public class SceneManager
    {
        #region Data
        public List<GameObject> GameObjects = new List<GameObject>();
        public static SceneManager Scene = null;
        #endregion

        #region Constructors
        public SceneManager()
        {
            Scene = this;
        }
        #endregion

        #region Public API
        public void Update()
        {
            foreach(GameObject go in GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    comp.Update();
                }
            }
        }

        public void FixedUpdate()
        {
            foreach (GameObject go in GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    comp.FixedUpdate();
                }
            }
        }

        public void Render()
        {
            // grab all cameras
            List<Camera> _cameras = new List<Camera>();
            foreach (GameObject go in GameObjects)
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
        internal void OnPreRender()
        {
            Camera.Current.OnPreRender();

            foreach (GameObject go in GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    if (comp is Camera)
                        continue;

                    comp.OnPreRender();
                }
            }
        }

        internal void OnRenderObject()
        {
            Camera.Current.OnRenderObject();

            foreach (GameObject go in GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    if (comp is Camera)
                        continue;

                    comp.OnRenderObject();
                }
            }
        }

        internal void OnPostRender()
        {
            Camera.Current.OnPostRender();

            foreach (GameObject go in GameObjects)
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
