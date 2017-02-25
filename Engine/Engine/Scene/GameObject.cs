using CoreEngine.Engine.Core;
using CoreEngine.Engine.Components;

using OpenTK;

using System.Collections.Generic;

namespace CoreEngine.Engine.Scene
{
    public class GameObject : Object
    {
        #region Data
        public bool Static;
        public List<GameObject> Children = new List<GameObject>();
        public List<CoreComponent> Components = new List<CoreComponent>();
        public GameObject Parent;

        // TODO: transform
        public Vector3 position;
        public Quaternion rotation;
        #endregion

        #region Public Component API
        /// <summary>
        /// Adds a component to the GameObject and returns the new component
        /// </summary>
        /// <typeparam name="T">Type of object to add</typeparam>
        public T AddComponent<T>() where T : CoreComponent, new()
        {
            T comp = new T();
            Components.Add(comp);

            return comp;
        }

        /// <summary>
        /// Returns the first component that matches the type given
        /// </summary>
        /// <typeparam name="T">Type of component to find</typeparam>
        public T GetComponent<T>() where T : CoreComponent
        {
            System.Type type = typeof(T);
            foreach(CoreComponent comp in Components)
            {
                if(comp.GetType() == type)
                {
                    return (T)comp;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns an array of components that match the type given
        /// </summary>
        /// <typeparam name="T">Type of components to find</typeparam>
        public T[] GetComponents<T>() where T : CoreComponent
        {
            List<T> compList = new List<T>();

            System.Type type = typeof(T);
            foreach (CoreComponent comp in Components)
            {
                if (comp.GetType() == type)
                {
                    compList.Add((T)comp);
                }
            }

            return compList.ToArray();
        }

        /// <summary>
        /// Returns the first component that matches the given type in the children
        /// </summary>
        /// <typeparam name="T">Type of component to find</typeparam>
        public T GetComponentInChildren<T>() where T : CoreComponent
        {
            System.Type type = typeof(T);
            foreach (GameObject child in Children)
            {
                foreach (CoreComponent comp in child.Components)
                {
                    if (comp.GetType() == type)
                    {
                        return (T)comp;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns an array of components that matches the given type in the children
        /// </summary>
        /// <typeparam name="T">Type of components to find</typeparam>
        public T[] GetComponentsInChildren<T>() where T : CoreComponent
        {
            List<T> compList = new List<T>();

            System.Type type = typeof(T);
            foreach (GameObject child in Children)
            {
                foreach (CoreComponent comp in child.Components)
                {
                    if (comp.GetType() == type)
                    {
                        compList.Add((T)comp);
                    }
                }
            }

            return compList.ToArray();
        }

        #endregion

        #region Public API
        /// <summary>
        /// Sets the parent of the GameObject
        /// </summary>
        /// <param name="obj">The new parent</param>
        public void SetParent(GameObject obj)
        {
            Parent = obj;
            if (obj != null)
            {
                obj.Children.Add(this);
            }
        }

        /// <summary>
        /// Gameobject implementation of Destroy function
        /// </summary>
        public sealed override void Destroy()
        {
            base.Destroy();
            foreach (GameObject t in Children)
            {
                t.Destroy();
            }

            foreach (CoreComponent comp in Components)
            {
                comp.Destroy();
            }

            Children.Clear();
            Components.Clear();
            Parent.Children.Remove(this);
            Parent = null;
        }

        public override Object Instantiate()
        {
            base.Instantiate();

            position = Vector3.Zero;
            rotation = Quaternion.Identity;

            SceneManager.Scene.GameObjects.Add(this);

            return this;
        }

        public override Object Instantiate(Vector3 position, Quaternion rotation)
        {
            base.Instantiate(position, rotation);

            this.position = position;
            this.rotation = rotation;

            SceneManager.Scene.GameObjects.Add(this);

            return this;
        }

        #endregion

        #region Private API

        #endregion

        #region Protected API

        #endregion
    }
}
