using CoreEngine.Engine.Graphics;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using System.Collections.Generic;

namespace CoreEngine.Engine.Components
{
    public class MeshRenderer : CoreComponent
    {
        #region Data
        public Mesh mesh;
        public List<Material> materials = new List<Material>();
        #endregion

        #region Constructors
        public MeshRenderer()
        {

        }
        #endregion

        #region Events
        public override void OnRenderObject()
        {
            base.OnRenderObject();

            materials[0].Bind();

            mesh.va.Bind();
            mesh.ib.Bind();

            GL.DrawElements(BeginMode.Triangles, (int)mesh.ib.GetCount(), DrawElementsType.UnsignedShort, 0);

            mesh.ib.Unbind();
            mesh.va.Unbind();

            materials[0].Unbind();
        }
        #endregion

        #region Public API
        public void AddMaterial(Material mat)
        {
            materials.Add(mat);
        }
        #endregion
    }
}
