// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using OpenTK;

namespace CoreEngine.Engine.Utils
{
    /// <summary>
    /// Converters for the property grid
    /// </summary>
    public class ConverterLoader
    {
        #region Public API
        /// <summary>
        /// Loads the converters into the classes
        /// </summary>
        public static void Load()
        {
            System.ComponentModel.TypeDescriptor.AddAttributes(typeof(Vector2), new System.ComponentModel.TypeConverterAttribute(typeof(VectorConverter)));
            System.ComponentModel.TypeDescriptor.AddAttributes(typeof(Vector3), new System.ComponentModel.TypeConverterAttribute(typeof(VectorConverter)));
            System.ComponentModel.TypeDescriptor.AddAttributes(typeof(Vector4), new System.ComponentModel.TypeConverterAttribute(typeof(VectorConverter)));
        }
        #endregion
    }
}
