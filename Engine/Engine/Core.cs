using System;
using System.Diagnostics;

using CoreEngine.Engine.Application;

namespace CoreEngine.Engine
{
    public static class Core
    {
        #region Data
        private static CoreApplication _currentApplication;
        #endregion

        #region Public API
        /// <summary>
        /// Returns the current CoreApplication
        /// </summary>
        public static CoreApplication CurrentApplication
        {
            get
            {
                Debug.Assert(_currentApplication != null);
                return _currentApplication;
            }

            
            set
            {
                if(value != null)
                    _currentApplication = value;
            }
        }
        #endregion
    }
}
