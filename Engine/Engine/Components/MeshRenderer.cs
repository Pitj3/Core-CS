using CoreEngine.Engine.Graphics;
using CoreEngine.Engine.Resources;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using System.Collections.Generic;

namespace CoreEngine.Engine.Components
{
    public class MeshRenderer : CoreComponent
    {
        #region Data
        public StaticModel mesh;
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

            if (mesh == null)
                return;

            foreach (Mesh m in mesh.meshes)
            {
                m.material?.Bind();

                m.va.Bind();
                m.ib.Bind();

                GL.DrawElements(BeginMode.Triangles, (int)m.ib.GetCount(), DrawElementsType.UnsignedShort, 0);

                m.ib.Unbind();
                m.va.Unbind();

                m.material?.Unbind();
            }
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
