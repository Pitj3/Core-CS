// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs
using System.Collections.Generic;
using System.IO;

using CoreEngine.Engine.Math;
using CoreEngine.Engine.Core;
using CoreEngine.Engine.Components;

using OpenTK;

namespace CoreEngine.Engine.Scene
{
    /// <summary>
    /// GameObject class
    /// </summary>
    public class GameObject : Object
    {
        #region Data
        private static int staticID = 0;

        public bool Static;
        public List<GameObject> Children = new List<GameObject>();
        public List<CoreComponent> Components = new List<CoreComponent>();
        public GameObject Parent;

        public Transform LocalTransform
        {
            get
            {
                return _transform;
            }
            set
            {
                _transform = value;
            }
        }

        private Transform _transform;
        #endregion

        #region Constructors
        public GameObject()
        {
            Name = "GameObject";

            _transform = new Math.Transform();

            _transform.Scale = Vector3.One;

            ID = staticID++;
        }
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

            comp.Parent = this;

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

            instance.Parent = this;

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

            instance.Parent = this;

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
        }

        /// <summary>
        /// Default implementation of the Instantiate function
        /// </summary>
        public override Object Instantiate()
        {
            base.Instantiate();

            this.LocalTransform = new Transform();

            LocalTransform.Position = Vector3.Zero;
            LocalTransform.Rotation = Quaternion.Identity;
            this.LocalTransform.Scale = Vector3.One;

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

            this.LocalTransform = new Transform();

            this.LocalTransform.Position = position;
            this.LocalTransform.Rotation = rotation;
            this.LocalTransform.Scale = Vector3.One;

            SceneManager.CurrentScene.GameObjects.Add(this);

            Name = "GameObject";

            return this;
        }

        /// <summary>
        /// Finds the gameobject in a scene by name
        /// </summary>
        /// <param name="name"></param>
        public static GameObject Find(string name)
        {
            foreach(GameObject go in SceneManager.CurrentScene.GameObjects)
            {
                if(go.Name == name)
                {
                    return go;
                }
            }

            return null;
        }

        /// <summary>
        /// Finds all gameobjects in the scene which contain the component given
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static GameObject[] FindWithComponent<T>() where T: class
        {
            List<GameObject> returnlist = new List<GameObject>();
            foreach (GameObject go in SceneManager.CurrentScene.GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    if(comp is T)
                    {
                        returnlist.Add(go);
                    }
                }
            }

            return returnlist.ToArray();
        }

        #endregion

        #region Internal API
        /// <summary>
        /// Loads the gameobject from a .casset file
        /// </summary>
        /// <param name="goid"></param>
        internal static GameObject Load(int goid)
        {
            GameObject savedObject = null;

            using (BinaryReader br = new BinaryReader(File.Open("Library/GO" + goid + ".casset", FileMode.Open)))
            {
                // header with id
                int id = br.ReadInt32();

                // name
                string name = br.ReadString();

                // enabled
                bool enabled = br.ReadBoolean();

                // transform
                string posString = br.ReadString();
                posString = posString.TrimStart('(');
                posString = posString.TrimEnd(')');
                string[] arr = posString.Split(',');
                Vector3 position = new Vector3(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2]));

                string scaleString = br.ReadString();
                scaleString = scaleString.TrimStart('(');
                scaleString = scaleString.TrimEnd(')');
                arr = scaleString.Split(',');
                Vector3 scale = new Vector3(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2]));

                string eulerString = br.ReadString();
                eulerString = eulerString.TrimStart('(');
                eulerString = eulerString.TrimEnd(')');
                arr = eulerString.Split(',');
                Vector3 euler = new Vector3(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2]));

                // parent id
                bool hasParent = br.ReadBoolean();
                int parentId = -1;
                if (hasParent)
                    parentId = br.ReadInt32();

                // children ids
                int childrenCount = br.ReadInt32();

                int[] childIds = new int[childrenCount];
                for (int i = 0; i < childrenCount; i++)
                {
                    childIds[i] = br.ReadInt32();
                }

                // is static
                bool isStatic = br.ReadBoolean();

                // component ids
                int componentCount = br.ReadInt32();

                int[] compIds = new int[componentCount];
                for (int i = 0; i < componentCount; i++)
                {
                    compIds[i] = br.ReadInt32();
                }

                savedObject = GameObject.Instantiate(null, position, Quaternion.FromEulerAngles(euler)) as GameObject;
                savedObject.LocalTransform.EulerRotation = euler;
                savedObject.LocalTransform.Scale = scale;

                savedObject.ID = id;
                savedObject.Name = name;

                if (parentId != -1)
                {
                    GameObject p = null;
                    foreach (GameObject go in SceneManager.CurrentScene.GameObjects)
                    {
                        if (go.ID == parentId)
                        {
                            p = go;
                            break;
                        }
                    }

                    if (p != null)
                    {
                        savedObject.Parent = p;
                    }
                    else
                    {
                        p = GameObject.Load(parentId);
                    }
                }

                savedObject.Static = isStatic;

                for (int i = 0; i < childrenCount; i++)
                {
                    GameObject c = null;
                    foreach (GameObject go in SceneManager.CurrentScene.GameObjects)
                    {
                        if (go.ID == childIds[i])
                        {
                            savedObject.Children.Add(go);
                            c = go;
                        }
                    }

                    if (c == null)
                    {
                        savedObject.Children.Add(GameObject.Load(childIds[i]));
                    }
                }

                for (int i = 0; i < componentCount; i++)
                {
                    savedObject.AddComponent(CoreComponent.Load(compIds[i]));
                }
            }

            return savedObject;
        }

        /// <summary>
        /// Saves the gameobject to a .casset file
        /// </summary>
        internal void Save()
        {
            if(!Directory.Exists("Library"))
            {
                Directory.CreateDirectory("Library");
            }

            File.WriteAllText("Library/GO" + ID + ".casset", "");
            using (BinaryWriter bw = new BinaryWriter(File.Open("Library/GO" + ID + ".casset", FileMode.Append)))
            {
                // header with id
                bw.Write(ID);

                // name
                bw.Write(Name);

                // enabled
                bw.Write(Enabled);

                // transform
                bw.Write(LocalTransform.Position.ToString());
                bw.Write(LocalTransform.Scale.ToString());
                bw.Write(LocalTransform.EulerRotation.ToString());

                // parent id
                bw.Write(Parent != null);
                if (Parent != null)
                    bw.Write(Parent.ID);

                // children ids
                bw.Write(Children.Count);
                foreach (GameObject child in Children)
                {
                    bw.Write(child.ID);
                }

                // is static
                bw.Write(Static);

                // component ids
                bw.Write(Components.Count);
                foreach (CoreComponent comp in Components)
                {
                    bw.Write(comp.ID);
                    comp.Save();
                }
            }
        }
        #endregion
    }
}
