// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using CoreEngine.Engine.Graphics;
using CoreEngine.Engine.Resources;
using CoreEngine.Engine.Rendering.Lighting;

using OpenTK.Graphics.OpenGL;

namespace CoreEngine.Engine.Components
{
    /// <summary>
    /// Mesh Renderer component
    /// </summary>
    public class MeshRenderer : CoreComponent
    {
        #region Data
        public StaticModel StaticMesh;
        #endregion

        #region Constructors
        public MeshRenderer()
        {

        }
        #endregion

        #region Events
        /// <summary>
        /// Called when the object is rendered
        /// </summary>
        public override void OnRenderObject()
        {
            base.OnRenderObject();

            if (StaticMesh == null)
                return;

            foreach (Mesh mesh in StaticMesh.Meshes)
            {
                mesh.MeshMaterial?.Bind();

                foreach (CoreComponent comp in Parent.Components)
                {
                    if(comp is Light)
                    {
                        GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                    }
                }

                mesh.VA.Bind();
                mesh.IB.Bind();

                GL.DrawElements(BeginMode.Triangles, (int)mesh.IB.GetCount(), DrawElementsType.UnsignedShort, 0);

                mesh.IB.Unbind();
                mesh.VA.Unbind();

                foreach (CoreComponent comp in Parent.Components)
                {
                    if (comp is Light)
                    {
                        GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                    }
                }

                mesh.MeshMaterial?.Unbind();
            }
        }
        #endregion
    }
}
