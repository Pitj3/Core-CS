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
