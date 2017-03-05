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
        public VertexArray va;
        public IndexBuffer ib;

        public MeshVertex[] vertices;
        public ushort[] indices;

        public Material material;

        #endregion

        #region Constructors
        public Mesh(MeshVertex[] vertices, ushort[] indices)
        {
            this.vertices = vertices;
            this.indices = indices;

            va = new VertexArray();
            va.Bind();

            VertexBuffer vb = new VertexBuffer();
            vb.SetData((uint)(System.Runtime.InteropServices.Marshal.SizeOf(typeof(MeshVertex)) * vertices.Length), vertices);

            BufferLayout layout = new BufferLayout();

            // TODO: Make this the default mesh data
            layout.Push<Vector3>("POSITION");
            layout.Push<Vector2>("TEXCOORD");
            layout.Push<Vector4>("COLOR");

            vb.SetLayout(layout);

            va.PushBuffer(vb);

            ib = new IndexBuffer(indices, (uint)indices.Length);

            va.Unbind();
        }
        #endregion
    }
}
