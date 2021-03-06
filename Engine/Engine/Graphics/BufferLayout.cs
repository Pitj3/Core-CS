﻿// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace CoreEngine.Engine.Graphics
{
    #region Enums
    /// <summary>
    /// Defines an elements in the BufferLayout
    /// </summary>
    public struct BufferElement
    {
        public string Name;
        public VertexAttribPointerType AttribType;
        public uint Size;
        public uint Count;
        public uint Offset;
        public bool Normalized;
    };
    #endregion

    /// <summary>
    /// Buffer Layout class
    /// </summary>
    public class BufferLayout
    {
        #region Data
        private uint _size;
        private List<BufferElement> _layout;
        #endregion

        #region Push API
        /// <summary>
        /// Public Push function for pushing variable types into the layout
        /// </summary>
        /// <typeparam name="T">Variable type</typeparam>
        /// <param name="name">Name of the element</param>
        /// <param name="count">Count of the element</param>
        /// <param name="normalized">Is the variable normalized</param>
        public void Push<T>(string name, uint count = 1, bool normalized = false)
        {
            Type t = typeof(T);
            if(typeof(uint) == t)
            {
                Push(name, VertexAttribPointerType.UnsignedInt, sizeof(uint), count, normalized);
            }
            if(typeof(float) == t)
            {
                Push(name, VertexAttribPointerType.Float, sizeof(float), count, normalized);
            }
            if(typeof(byte) == t)
            {
                Push(name, VertexAttribPointerType.UnsignedByte, sizeof(byte), count, normalized);
            }
            if (typeof(Vector2) == t)
            {
                Push(name, VertexAttribPointerType.Float, sizeof(float), 2, normalized);
            }
            if (typeof(Vector3) == t)
            {
                Push(name, VertexAttribPointerType.Float, sizeof(float), 3, normalized);
            }
            if (typeof(Vector4) == t)
            {
                Push(name, VertexAttribPointerType.Float, sizeof(float), 4, normalized);
            }
        }

        #endregion

        #region Public API
        /// <summary>
        /// Returns the current layout
        /// </summary>
        public List<BufferElement> GetLayout() { return _layout; }
        /// <summary>
        /// Returns the stride of the buffer
        /// </summary>
        public uint GetStride() { return _size; }
        #endregion

        #region Private API
        private void Push(string name, VertexAttribPointerType type, uint size, uint count, bool normalized)
        {
            if (_layout == null)
                _layout = new List<BufferElement>();

            _layout.Add(new BufferElement() { Name = name, AttribType = type, Size = size, Count = count, Offset = this._size, Normalized = normalized });
            this._size += size * count;
        }
        #endregion
    }
}