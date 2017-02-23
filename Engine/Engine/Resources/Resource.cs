using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEngine.Engine.Resources
{
    /// <summary>
    /// Resource class
    /// </summary>
    public abstract class Resource
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
        /// Getter/Setter for the resource name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Abstract load function
        /// </summary>
        /// <param name="source">Source of the resource</param>
        public abstract bool Load(string source);
        #endregion
    }
}
