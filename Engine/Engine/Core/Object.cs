using OpenTK;

using CoreEngine.Engine.Scene;

namespace CoreEngine.Engine.Core
{
    /// <summary>
    /// Base Object class
    /// </summary>
    public class Object
    {
        #region Data
        public bool Enabled;
        public string Name;
        // TODO: GameObject
        // TODO: Transform
        #endregion

        #region Static API
        /// <summary>
        /// Static Destroy function
        /// </summary>
        /// <param name="obj">Object to destroy</param>
        public static void Destroy(Object obj)
        {
            obj.Destroy();
        }

        /// <summary>
        /// Flag an object to not destroy on load
        /// </summary>
        /// <param name="obj">Object to flag</param>
        public static void DontDestroyOnLoad(Object obj)
        {
            // TODO: Flag this object to not destroy on scene load
        }

        /// <summary>
        /// Default static instantiate function
        /// </summary>
        /// <param name="obj">Object to instantiate</param>
        public static Object Instantiate(Object obj)
        {
            GameObject go = new GameObject(); // TODO: Change to actual object
            go.Instantiate();

            return go;
        }

        /// <summary>
        /// Static instantiate function
        /// </summary>
        /// <param name="obj">Object to instantiate</param>
        /// <param name="position">Position of object</param>
        /// <param name="rotation">Rotation of object</param>
        public static Object Instantiate(Object obj, Vector3 position, Quaternion rotation)
        {
            GameObject go = new GameObject(); // TODO: Change to actual object
            go.Instantiate(position, rotation);

            return go;
        }

        #endregion

        #region Protected API
        /// <summary>
        /// Internal destroy function
        /// </summary>
        public virtual void Destroy()
        {

        }

        /// <summary>
        /// Internal to string function
        /// </summary>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Internal default instantiate function
        /// </summary>
        public virtual Object Instantiate()
        {
            return null;
        }

        /// <summary>
        /// Internal instantiate function
        /// </summary>
        /// <param name="obj">Object to instantiate</param>
        /// <param name="position">Position of object</param>
        /// <param name="rotation">Rotation of object</param>
        public virtual Object Instantiate(Vector3 position, Quaternion rotation)
        {
            return null;
        }
        #endregion

        /// <summary>
        /// Implicit bool operator
        /// </summary>
        public static implicit operator bool(Object obj)
        {
            return obj != null;
        }
    }
}
