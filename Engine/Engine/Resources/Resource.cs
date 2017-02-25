using CoreEngine.Engine.Core;

namespace CoreEngine.Engine.Resources
{
    /// <summary>
    /// Resource class
    /// </summary>
    public abstract class Resource : Object
    {
        #region Data
        private string _name;
        #endregion

        #region Constructors
        public Resource()
        {

        }

        #endregion

        #region Public API

        /// <summary>
        /// Abstract load function
        /// </summary>
        /// <param name="source">Source of the resource</param>
        public abstract bool Load(string source);
        #endregion
    }
}
