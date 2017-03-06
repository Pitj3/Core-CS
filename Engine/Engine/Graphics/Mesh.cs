// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs
using OpenTK;

namespace CoreEngine.Engine.Graphics
{
    #region Structs
    /// <summary>
    /// Defines a vertex for a mesh
    /// </summary>
    public struct MeshVertex
    {
        public Vector3 Position;
        public Vector2 UV;
        public Vector3 Normal;
        public Vector3 BiTangent;
        public Vector3 Tangent;
        public Vector4 Color;
    }
    #endregion

    /// <summary>
    /// Mesh class
    /// </summary>
    public class Mesh
    {
        #region Data
        public VertexArray VA;
        public IndexBuffer IB;

        public MeshVertex[] Vertices;
        public ushort[] Indices;

        public Material MeshMaterial;

        #endregion

        #region Constructors
        public Mesh(MeshVertex[] vertices, ushort[] indices)
        {
            this.Vertices = vertices;
            this.Indices = indices;

            VA = new VertexArray();
            VA.Bind();

            VertexBuffer vb = new VertexBuffer();
            vb.SetData((uint)(System.Runtime.InteropServices.Marshal.SizeOf(typeof(MeshVertex)) * vertices.Length), vertices);

            BufferLayout layout = new BufferLayout();

            layout.Push<Vector3>("POSITION");
            layout.Push<Vector2>("TEXCOORD");
            layout.Push<Vector3>("NORMAL");
            layout.Push<Vector3>("BITANGENT");
            layout.Push<Vector3>("TANGENT");
            layout.Push<Vector4>("COLOR");

            vb.SetLayout(layout);

            VA.PushBuffer(vb);

            IB = new IndexBuffer(indices, (uint)indices.Length);

            VA.Unbind();
        }
        #endregion
    }
}
