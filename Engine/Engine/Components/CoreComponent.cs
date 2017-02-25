using CoreEngine.Engine.Core;

namespace CoreEngine.Engine.Components
{
    public class CoreComponent : Object
    {
        #region Data

        #endregion

        #region Events

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }

        public virtual void OnCollisionEnter() { }
        public virtual void OnCollisionExit() { }
        public virtual void OnCollisionStay() { }

        public virtual void OnDestroy() { }

        public virtual void OnPreRender() { }
        public virtual void OnRenderObject() { }
        public virtual void OnPostRender() { }
        #endregion

        #region Public API
        public sealed override void Destroy()
        {
            base.Destroy();

            OnDestroy();
        }
        #endregion
    }
}
