// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System;

using OpenTK.Graphics.OpenGL;

namespace CoreEngine.Engine.Graphics
{
    #region Enums
    /// <summary>
    ///  Defines the usage of the Vertex Buffer
    /// </summary>
    public enum VertexBufferUsage
    {
        BUFFER_STATIC = BufferUsageHint.StaticDraw,
        BUFFER_DYNAMIC = BufferUsageHint.DynamicDraw
    };
    #endregion

    /// <summary>
    /// Vertex Buffer class
    /// </summary>
    public class VertexBuffer
    {
        #region Data
        private uint _id;
        private uint _size;
        private VertexBufferUsage _usage;
        private BufferLayout _layout;
        #endregion

        #region Constructors
        public VertexBuffer(VertexBufferUsage usage = VertexBufferUsage.BUFFER_STATIC)
        {
            this._usage = usage;
            _id = (uint)GL.GenBuffer();
        }
        #endregion

        #region Public API
        /// <summary>
        /// Resizes the vertex buffer
        /// </summary>
        /// <param name="size">New size of the vertex buffer</param>
        public void Resize(uint size)
        {
            this._size = size;

            GL.BindBuffer(BufferTarget.ArrayBuffer, _id);
            GL.BufferData(BufferTarget.ArrayBuffer, (int)size, new IntPtr(0), (BufferUsageHint)_usage);
        }

        /// <summary>
        /// Sets the data of the vertex buffer
        /// </summary>
        /// <param name="size">Size of the data</param>
        /// <param name="data">New data of the vertex buffer</param>
        public void SetData(uint size, object data)
        {
            this._size = size;
            GL.BindBuffer(BufferTarget.ArrayBuffer, _id);

            MeshVertex[] d = (MeshVertex[])data;

            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(size), d, (BufferUsageHint)_usage);
        }

        /// <summary>
        /// Sets the layout of the vertex buffer
        /// </summary>
        /// <param name="layout">New layout of the vertex buffer</param>
        public void SetLayout(BufferLayout layout)
        {
            this._layout = layout;

            for (int i = 0; i < layout.GetLayout().Count; i++)
            {
                BufferElement element = layout.GetLayout()[i];
                GL.EnableVertexAttribArray(i);
                GL.VertexAttribPointer(i, (int)element.Count, element.AttribType, element.Normalized, (int)layout.GetStride(), new IntPtr(element.Offset));
            }
        }

        /// <summary>
        /// Binds the vertex buffer
        /// </summary>
        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, _id);
            for (int i = 0; i < _layout.GetLayout().Count; i++)
            {
                GL.EnableVertexAttribArray(i);
            }
        }

        /// <summary>
        /// Unbinds the vertex buffer
        /// </summary>
        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            for (int i = 0; i < _layout.GetLayout().Count; i++)
            {
                GL.DisableVertexAttribArray(i);
            }
        }
        #endregion
    }
}
