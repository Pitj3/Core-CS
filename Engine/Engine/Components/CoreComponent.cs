// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System.IO;
using System.Reflection;

using CoreEngine.Engine.Core;
using CoreEngine.Engine.Scene;
using CoreEngine.Engine.Utils;
using CoreEngine.Engine.Resources;

namespace CoreEngine.Engine.Components
{
    #region Attributes
    [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Field, AllowMultiple = false)]
    public sealed class IgnoreInSaveAttribute : System.Attribute
    {
        public override string ToString()
        {
            return "Ignore in Inspector";
        }
    }
    #endregion

    /// <summary>
    /// Base CoreComponent class
    /// </summary>
    public class CoreComponent : Object
    {
        #region Data
        public string TypeString;
        public System.Type SystemType;

        public GameObject Parent;

        private static int StaticID = 0;
        #endregion

        #region Constructors
        public CoreComponent()
        {
            TypeString = this.GetType().ToString();
            SystemType = this.GetType();

            Name = TypeString;

            ID = StaticID++;
        }
        #endregion

        #region Events
        /// <summary>
        /// Called when the component is created
        /// </summary>
        public virtual void Awake() { }
        /// <summary>
        /// Called after awake, and all other component awakes
        /// </summary>
        public virtual void Start() { }
        /// <summary>
        /// Called on the update of the component
        /// </summary>
        public virtual void Update() { }
        /// <summary>
        /// Called on the fixed update of the component (depends on refresh rate)
        /// </summary>
        public virtual void FixedUpdate() { }

        /// <summary>
        /// Called when the components collider enters a collision
        /// </summary>
        public virtual void OnCollisionEnter() { }
        /// <summary>
        /// Called when the components collider exits a collision
        /// </summary>
        public virtual void OnCollisionExit() { }
        /// <summary>
        /// Called when the components collider is still having a collision
        /// </summary>
        public virtual void OnCollisionStay() { }

        /// <summary>
        /// Called when the component is destroyed
        /// </summary>
        public virtual void OnDestroy() { }

        /// <summary>
        /// Called before the render happens
        /// </summary>
        public virtual void OnPreRender() { }
        /// <summary>
        /// Called when the component is being rendered
        /// </summary>
        public virtual void OnRenderObject() { }
        /// <summary>
        /// Called after the component was rendered
        /// </summary>
        public virtual void OnPostRender() { }
        #endregion

        #region Public API
        /// <summary>
        /// Implementation of the Destroy function
        /// </summary>
        public sealed override void Destroy()
        {
            base.Destroy();

            OnDestroy();

            Parent.Components.Remove(this);
        }
        #endregion

        #region Internal API
        /// <summary>
        /// Loads the component .casset with the corresponding component id
        /// </summary>
        /// <param name="compid">Component id to load</param>
        internal static CoreComponent Load(int compid)
        {
            CoreComponent savedObject = null;

            using (BinaryReader br = new BinaryReader(File.Open("Library/COMP" + compid + ".casset", FileMode.Open)))
            {
                // header with id
                int id = br.ReadInt32();

                // type
                string type = br.ReadString();

                // systemType
                string systemType = br.ReadString();

                // name
                string name = br.ReadString();

                // enabled
                bool enabled = br.ReadBoolean();

                // parent
                int parentId = br.ReadInt32();

                // system type
                System.Type t = System.Type.GetType(systemType);
                savedObject = (CoreComponent)System.Activator.CreateInstance(t);

                // field count
                int fieldCount = br.ReadInt32();
                for (int i = 0; i < fieldCount; i++)
                {
                    string fieldName = br.ReadString();
                    FieldInfo field = t.GetField(fieldName);
                    if (field != null && field.FieldType.BaseType.Name.Contains("Resource"))
                    {
                        Resource r = (Resource)System.Activator.CreateInstance(field.FieldType);
                        r.ID = br.ReadInt32();
                        r.Load("Library/RES" + r.ID + ".casset");
                        field.SetValue(savedObject, r);
                    }
                }

                // prop count
                int propCount = br.ReadInt32();
                for (int i = 0; i < propCount; i++)
                {
                    string propName = br.ReadString();
                    FieldInfo prop = t.GetField(propName);
                    if (prop != null && prop.FieldType.BaseType.Name.Contains("Resource"))
                    {
                        Resource r = (Resource)System.Activator.CreateInstance(prop.FieldType);
                        r.ID = br.ReadInt32();
                        r.Load("Library/RES" + r.ID + ".casset");
                        prop.SetValue(savedObject, r);
                    }
                }
            }

            return savedObject;
        }

        /// <summary>
        /// Saves the component to a .casset
        /// </summary>
        internal void Save()
        {
            if (!Directory.Exists("Library"))
            {
                Directory.CreateDirectory("Library");
            }

            if (!File.Exists("Library/COMP" + ID + ".casset"))
            {
                // create it
                using (BinaryWriter bw = new BinaryWriter(File.Open("Library/COMP" + ID + ".casset", FileMode.Create)))
                {
                    // header with id
                    bw.Write(ID);

                    // type
                    bw.Write(TypeString);

                    // systemtype
                    bw.Write(SystemType.ToString());

                    // name
                    bw.Write(Name);

                    // enabled
                    bw.Write(Enabled);

                    // parent id
                    bw.Write(Parent.ID);

                    FieldInfo[] fields = ComponentUtils.GetFields(this);
                    PropertyInfo[] props = ComponentUtils.GetProperties(this);

                    // Fields
                    int fieldCount = 0;
                    foreach (FieldInfo field in fields)
                    {
                        if (ComponentUtils.GetValue(this, field) is Resource)
                            fieldCount++;
                    }

                    bw.Write(fieldCount);
                    if (fieldCount > 0)
                    {
                        foreach (FieldInfo field in fields)
                        {
                            // write value
                            if (ComponentUtils.GetValue(this, field) is Resource)
                            {
                                // write name
                                bw.Write(ComponentUtils.GetName(field));

                                Resource r = (Resource)ComponentUtils.GetValue(this, field);
                                bw.Write(r.ID);
                                r.Save();
                            }
                        }
                    }

                    // Props
                    int propCount = 0;
                    foreach (PropertyInfo prop in props)
                    {
                        if (ComponentUtils.GetValue(this, prop) is Resource)
                            propCount++;
                    }

                    bw.Write(propCount);
                    if (propCount > 0)
                    {
                        foreach (PropertyInfo prop in props)
                        {
                            // write value
                            if (ComponentUtils.GetValue(this, prop) is Resource)
                            {
                                // write name
                                bw.Write(ComponentUtils.GetName(prop));

                                Resource r = (Resource)ComponentUtils.GetValue(this, prop);
                                bw.Write(r.ID);
                                r.Save();
                            }
                        }
                    }
                }
            }
            else
            {
                // TODO: Update existing
            }
        }
        #endregion
    }
}
