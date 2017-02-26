/*
Interface of the Core Engine

Copyright (C) 2017 Roderick Griffioen

This program is free software : you can redistribute it and / or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program. If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.Diagnostics;

using CoreEngine.Engine.Application;

namespace CoreEngine.Engine
{
    /// <summary>
    /// Base class of the engine
    /// </summary>
    public static class CoreEngine
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
