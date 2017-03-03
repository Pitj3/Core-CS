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
            MeshVertex[] data = new MeshVertex[4];

            data[0].position = new Vector3(x, y, 0);
	        data[0].uv = new Vector2(0, 0);
	        data[0].color = new Vector4(1, 0, 0, 1);

	        data[1].position = new Vector3(x + width, y, 0);
	        data[1].uv = new Vector2(1, 0);
	        data[1].color = new Vector4(1, 0, 0, 1);

	        data[2].position = new Vector3(x + width, y + height, 0);
	        data[2].uv = new Vector2(1, 1);
	        data[2].color = new Vector4(1, 0, 0, 1);

	        data[3].position = new Vector3(x, y + height, 0);
	        data[3].uv = new Vector2(0, 1);
	        data[3].color = new Vector4(1, 0, 0, 1);

            ushort[] indices = new ushort[6] { 0, 1, 2, 2, 3, 0 };
            
	        return new Mesh(data, indices);
        }

        public static Mesh CreateCube(float size)
        {
            MeshVertex[] data = new MeshVertex[8];

            data[0].position = new Vector3(-size / 2.0f, -size / 2.0f, size / 2.0f);
            data[0].uv = new Vector2(0, 0);
            data[0].color = new Vector4(1, 0, 0, 1);

            data[1].position = new Vector3(size / 2.0f, -size / 2.0f, size / 2.0f);
            data[1].uv = new Vector2(1, 0);
            data[1].color = new Vector4(1, 0, 0, 1);

            data[2].position = new Vector3(size / 2.0f, size / 2.0f, size / 2.0f);
            data[2].uv = new Vector2(1, 1);
            data[2].color = new Vector4(1, 0, 0, 1);

            data[3].position = new Vector3(-size / 2.0f, size / 2.0f, size / 2.0f);
            data[3].uv = new Vector2(0, 1);
            data[3].color = new Vector4(1, 0, 0, 1);

            data[4].position = new Vector3(-size / 2.0f, -size / 2.0f, -size / 2.0f);
            data[4].uv = new Vector2(0, 0);
            data[4].color = new Vector4(1, 0, 0, 1);

            data[5].position = new Vector3(size / 2.0f, -size / 2.0f, -size / 2.0f);
            data[5].uv = new Vector2(1, 0);
            data[5].color = new Vector4(1, 0, 0, 1);

            data[6].position = new Vector3(size / 2.0f, size / 2.0f, -size / 2.0f);
            data[6].uv = new Vector2(1, 1);
            data[6].color = new Vector4(1, 0, 0, 1);

            data[7].position = new Vector3(-size / 2.0f, size / 2.0f, -size / 2.0f);
            data[7].uv = new Vector2(0, 1);
            data[7].color = new Vector4(1, 0, 0, 1);

            ushort[] indices = new ushort[36] {
                        0, 1, 2, 2, 3, 0,
                        3, 2, 6, 6, 7, 3,
                        7, 6, 5, 5, 4, 7,
                        4, 0, 3, 3, 7, 4,
                        0, 1, 5, 5, 4, 0,
                        1, 5, 6, 6, 2, 1
            };

            return new Mesh(data, indices);
        }
        #endregion
    }
}
