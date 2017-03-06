// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using OpenTK;

namespace CoreEngine.Engine.Math
{
    /// <summary>
    /// Transform class
    /// </summary>
    public class Transform
    {
        #region Data
        public Vector3 Position { get; set; }
        public Vector3 Scale { get; set; }
        public Quaternion Rotation;
        public Vector3 EulerRotation
        {
            get
            {
                return _rotationEuler;
            }
            set
            {
                _rotationEuler = value;
                Rotation = Quaternion.FromEulerAngles(value);
            }
        }

        private Vector3 _rotationEuler;
        #endregion
    }
}
