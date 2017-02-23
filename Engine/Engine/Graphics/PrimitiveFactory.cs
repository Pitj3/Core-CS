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
    /// Primitive Factory class
    /// </summary>
    public static class PrimitiveFactory
    {
        #region Public API
        /// <summary>
        /// Returns a mesh containing a Quad
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static Mesh CreateQuad(int x, int y, int width, int height)
        {
            VertexArray va = null;
            MeshVertex[] data = new MeshVertex[4];

            data[0].position = new Vector3(x, y, 0);
	        data[0].uv = new Vector2(0, 1);
	        data[0].color = new Vector4(1, 0, 0, 1);

	        data[1].position = new Vector3(x + width, y, 0);
	        data[1].uv = new Vector2(1, 1);
	        data[1].color = new Vector4(1, 0, 0, 1);

	        data[2].position = new Vector3(x + width, y + height, 0);
	        data[2].uv = new Vector2(1, 0);
	        data[2].color = new Vector4(1, 0, 0, 1);

	        data[3].position = new Vector3(x, y + height, 0);
	        data[3].uv = new Vector2(0, 0);
	        data[3].color = new Vector4(1, 0, 0, 1);

            va = new VertexArray();
		    va.Bind();

            VertexBuffer vb = new VertexBuffer();
            vb.SetData((uint)(System.Runtime.InteropServices.Marshal.SizeOf(typeof(MeshVertex)) * 4), data);

            BufferLayout layout = new BufferLayout();

            layout.Push<Vector3>("POSITION");
	        layout.Push<Vector2>("TEXCOORD");
	        layout.Push<Vector4>("COLOR");

	        vb.SetLayout(layout);

            va.PushBuffer(vb);

            ushort[] indices = new ushort[6] { 0, 1, 2, 2, 3, 0 };
            IndexBuffer ib = new IndexBuffer(indices, 6);

            va.Unbind();

	        return new Mesh(va, ib);
        }
        #endregion
    }
}
