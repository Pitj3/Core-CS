// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

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
        public string Source;

        public static int StaticID = 0;
        #endregion

        #region Constructors
        public Resource()
        {
            ID = StaticID++;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Abstract load function
        /// </summary>
        /// <param name="source">Source of the resource</param>
        public abstract bool Load(string source);

        /// <summary>
        /// Abstract save function
        /// </summary>
        public abstract void Save();
        #endregion
    }
}
