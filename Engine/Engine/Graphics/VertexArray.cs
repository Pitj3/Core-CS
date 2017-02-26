// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System;
using System.Diagnostics;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace CoreEngine.Engine.Graphics
{
    /// <summary>
    /// Vertex Array Class
    /// </summary>
    public class VertexArray
    {
        #region Data
        private List<VertexBuffer> _buffers;
        private uint _id;
        #endregion

        #region Constructors
        public VertexArray()
        {
            _id = (uint)GL.GenVertexArray();

            _buffers = new List<VertexBuffer>();
        }
        #endregion

        #region Public API
        /// <summary>
        /// Returns the Vertex Buffer at the given index
        /// </summary>
        /// <param name="index">Index of the Vertex Buffer</param>
        public VertexBuffer GetBuffer(uint index = 0)
        {
            Debug.Assert(_buffers[(int)index] != null);

            return _buffers[(int)index];
        }

        /// <summary>
        /// Pushes a new Vertex Buffer into the Vertex Array
        /// </summary>
        /// <param name="buffer">Buffer to push</param>
        public void PushBuffer(VertexBuffer buffer)
        {
            Debug.Assert(!_buffers.Contains(buffer));

            _buffers.Add(buffer);
        }

        /// <summary>
        /// Binds the vertex array
        /// </summary>
        public void Bind()
        {
            GL.BindVertexArray((int)_id);
            foreach(VertexBuffer b in _buffers)
            {
                b.Bind();
            }
        }

        /// <summary>
        /// Unbinds the vertex array
        /// </summary>
        public void Unbind()
        {
            foreach (VertexBuffer b in _buffers)
            {
                b.Unbind();
            }
            GL.BindVertexArray(0);
        }
        #endregion
    }
}
