using CoreEngine.Engine.Core;
using CoreEngine.Engine.Components;

using OpenTK;

using System.Collections.Generic;

namespace CoreEngine.Engine.Scene
{
    #region Save Data
    /// <summary>
    /// Save version of a GameObject
    /// </summary>
    public class SaveGameObject
    {
        public string Name;
        public bool Static;
        //public Prefab prefab;

        public Vector3 position;
        public Quaternion rotation;
        public List<CoreComponent> Components;
        public GameObject Parent;
        public List<SaveGameObject> Children;
    }
    #endregion

    /// <summary>
    /// GameObject class
    /// </summary>
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

            comp.Awake();
            comp.Start();

            return comp;
        }

        /// <summary>
        /// Add component by string
        /// </summary>
        /// <param name="classname">Component name</param>
        public object AddComponent(string classname)
        {
            System.Type type = System.Type.GetType(classname);
            CoreComponent instance = (CoreComponent)System.Activator.CreateInstance(type);

            Components.Add(instance);

            instance.Awake();
            instance.Start();

            return instance;
        }

        /// <summary>
        /// Add component that already exists
        /// </summary>
        /// <param name="component">Component to add</param>
        /// <returns></returns>
        internal object AddComponent(object component)
        {
            CoreComponent instance = (CoreComponent)component;

            Components.Add(instance);

            instance.Awake();
            instance.Start();

            return instance;
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

        /// <summary>
        /// Default implementation of the Instantiate function
        /// </summary>
        public override Object Instantiate()
        {
            base.Instantiate();

            position = Vector3.Zero;
            rotation = Quaternion.Identity;

            SceneManager.CurrentScene.GameObjects.Add(this);

            Name = "GameObject";

            return this;
        }

        /// <summary>
        /// Implementation of the Instantiate function
        /// </summary>
        /// <param name="position">Position of the GameObject</param>
        /// <param name="rotation">Rotation of the GameObject</param>
        /// <returns></returns>
        public override Object Instantiate(Vector3 position, Quaternion rotation)
        {
            base.Instantiate(position, rotation);

            this.position = position;
            this.rotation = rotation;

            SceneManager.CurrentScene.GameObjects.Add(this);

            Name = "GameObject";

            return this;
        }

        /// <summary>
        /// Serialize this GameObject to save data
        /// </summary>
        public SaveGameObject Serialize()
        {
            SaveGameObject sgo = new SaveGameObject();
            sgo.Name = Name;
            sgo.Parent = Parent;
            sgo.Static = Static;

            List<SaveGameObject> childs = new List<SaveGameObject>();
            foreach (GameObject child in Children)
            {
                childs.Add(child.Serialize());
            }
            sgo.Children = childs;

            sgo.Components = Components;

            sgo.position = position;
            sgo.rotation = rotation;

            return sgo;
        }
        #endregion
    }
}
