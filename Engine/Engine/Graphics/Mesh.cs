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
    #region Structs
    /// <summary>
    /// Defines a vertex for a mesh
    /// </summary>
    public struct MeshVertex
    {
        public Vector3 position;
        public Vector2 uv;
        public Vector4 color;
    }
    #endregion

    /// <summary>
    /// Mesh class
    /// </summary>
    public class Mesh
    {
        #region Data
        private VertexArray _va;
        private IndexBuffer _ib;
        #endregion

        #region Constructors
        public Mesh(VertexArray va, IndexBuffer ib)
        {
            this._va = va;
            this._ib = ib;
        }
        #endregion

        #region Public API
        /// <summary>
        /// Renders this mesh
        /// </summary>
        public void Render()
        {
            _va.Bind();
            _ib.Bind();

            GL.DrawElements(BeginMode.Triangles, (int)_ib.GetCount(), DrawElementsType.UnsignedShort, 0);

            _ib.Unbind();
            _va.Unbind();
        }
        #endregion
    }
}
