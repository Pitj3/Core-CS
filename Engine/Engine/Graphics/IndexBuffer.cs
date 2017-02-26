// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace CoreEngine.Engine.Graphics
{
    /// <summary>
    /// Index Buffer class
    /// </summary>
    public class IndexBuffer
    {
        #region Data
        private uint _id;
        private uint _count;
        #endregion

        #region Constructors
        public IndexBuffer(ushort[] data, uint count)
        {
            this._count = count;
            _id = (uint)GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, (int)_id);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (int)(count * sizeof(ushort)), data, BufferUsageHint.StaticDraw);
        }
        #endregion

        #region Public API
        /// <summary>
        /// Binds the Index Buffer
        /// </summary>
        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, (int)_id);
        }

        /// <summary>
        /// Unbinds the Index Buffer
        /// </summary>
        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        /// <summary>
        /// Returns the count of the Index Buffer
        /// </summary>
        public uint GetCount()
        {
            return _count;
        }

        #endregion
    }
}
