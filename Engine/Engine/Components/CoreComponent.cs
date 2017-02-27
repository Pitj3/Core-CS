// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using CoreEngine.Engine.Core;

using Newtonsoft.Json.Linq;

namespace CoreEngine.Engine.Components
{ 
    /// <summary>
    /// Base CoreComponent class
    /// </summary>
    public class CoreComponent : Object
    {
        #region Data
        public string type;
        public System.Type systemType;
        #endregion

        #region Constructors
        public CoreComponent()
        {
            type = this.GetType().ToString();
            systemType = this.GetType();

            Name = type;
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
        }
        #endregion
    }
}
