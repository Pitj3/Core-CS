using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return _currentApplication;
            }

            set
            {
                if(value != null)
                    _currentApplication = value;
            }
        }

        /// <summary>
        /// Creates a CoreApplication with given values
        /// </summary>
        /// <param name="width">Width of the screen</param>
        /// <param name="height">Height of the screen</param>
        /// <param name="title">Title of the screen</param>
        /// <param name="fullscreen">Should the screen be fullscreen</param>
        /// <param name="vsync">Should vsync be used</param>
        /// <returns></returns>
        public static CoreApplication CreateCoreApplication(uint width = 800, uint height = 600, string title = "Core Application", bool fullscreen = false, bool vsync = true)
        {
            _currentApplication = new CoreApplication(width, height, title, fullscreen, vsync);

            return _currentApplication;
        }

        /// <summary>
        /// Creates a CoreApplication with the given params
        /// </summary>
        /// <param name="param">Params to be used for creation</param>
        /// <returns></returns>
        public static CoreApplication CreateCoreApplication(CoreApplicationCreationParams param)
        {
            _currentApplication = new CoreApplication(param);

            return _currentApplication;
        }
        #endregion
    }
}
