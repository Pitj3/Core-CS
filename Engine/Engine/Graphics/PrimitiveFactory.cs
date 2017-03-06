// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using OpenTK;

using CoreEngine.Engine.Resources;

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
        public static StaticModel CreateQuad(int x, int y, int width, int height)
        {
            MeshVertex[] data = new MeshVertex[4];

            data[0].Position = new Vector3(x, y, 0);
	        data[0].UV = new Vector2(0, 0);
	        data[0].Color = new Vector4(1, 0, 0, 1);

	        data[1].Position = new Vector3(x + width, y, 0);
	        data[1].UV = new Vector2(1, 0);
	        data[1].Color = new Vector4(1, 0, 0, 1);

	        data[2].Position = new Vector3(x + width, y + height, 0);
	        data[2].UV = new Vector2(1, 1);
	        data[2].Color = new Vector4(1, 0, 0, 1);

	        data[3].Position = new Vector3(x, y + height, 0);
	        data[3].UV = new Vector2(0, 1);
	        data[3].Color = new Vector4(1, 0, 0, 1);

            ushort[] indices = new ushort[6] { 0, 1, 2, 2, 3, 0 };
            
	        Mesh m = new Mesh(data, indices);

            StaticModel model = new StaticModel();
            model.Meshes = new Mesh[1];
            model.Meshes[0] = m;

            return model;
        }

        /// <summary>
        /// Creates a 3D plane
        /// </summary>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static StaticModel CreatePlane(int width, int length)
        {
            MeshVertex[] data = new MeshVertex[4];

            data[0].Position = new Vector3(0, 0, 0);
            data[0].Normal = Vector3.UnitY;
            data[0].UV = new Vector2(0, 0);
            data[0].Color = new Vector4(1, 0, 0, 1);

            data[1].Position = new Vector3(width, 0, 0);
            data[1].Normal = Vector3.UnitY;
            data[1].UV = new Vector2(1, 0);
            data[1].Color = new Vector4(1, 0, 0, 1);

            data[2].Position = new Vector3(width, 0, length);
            data[2].Normal = Vector3.UnitY;
            data[2].UV = new Vector2(1, 1);
            data[2].Color = new Vector4(1, 0, 0, 1);

            data[3].Position = new Vector3(0, 0, length);
            data[3].Normal = Vector3.UnitY;
            data[3].UV = new Vector2(0, 1);
            data[3].Color = new Vector4(1, 0, 0, 1);

            ushort[] indices = new ushort[6] { 0, 1, 2, 2, 3, 0 };

            Mesh m = new Mesh(data, indices);

            StaticModel model = new StaticModel();
            model.Meshes = new Mesh[1];
            model.Meshes[0] = m;

            return model;
        }

        /// <summary>
        /// Creates a 3D cube
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static StaticModel CreateCube(float size)
        {
            MeshVertex[] data = new MeshVertex[8];

            data[0].Position = new Vector3(-size / 2.0f, -size / 2.0f, size / 2.0f);
            data[0].UV = new Vector2(0, 0);
            data[0].Color = new Vector4(1, 0, 0, 1);

            data[1].Position = new Vector3(size / 2.0f, -size / 2.0f, size / 2.0f);
            data[1].UV = new Vector2(1, 0);
            data[1].Color = new Vector4(1, 0, 0, 1);

            data[2].Position = new Vector3(size / 2.0f, size / 2.0f, size / 2.0f);
            data[2].UV = new Vector2(1, 1);
            data[2].Color = new Vector4(1, 0, 0, 1);

            data[3].Position = new Vector3(-size / 2.0f, size / 2.0f, size / 2.0f);
            data[3].UV = new Vector2(0, 1);
            data[3].Color = new Vector4(1, 0, 0, 1);

            data[4].Position = new Vector3(-size / 2.0f, -size / 2.0f, -size / 2.0f);
            data[4].UV = new Vector2(0, 0);
            data[4].Color = new Vector4(1, 0, 0, 1);

            data[5].Position = new Vector3(size / 2.0f, -size / 2.0f, -size / 2.0f);
            data[5].UV = new Vector2(1, 0);
            data[5].Color = new Vector4(1, 0, 0, 1);

            data[6].Position = new Vector3(size / 2.0f, size / 2.0f, -size / 2.0f);
            data[6].UV = new Vector2(1, 1);
            data[6].Color = new Vector4(1, 0, 0, 1);

            data[7].Position = new Vector3(-size / 2.0f, size / 2.0f, -size / 2.0f);
            data[7].UV = new Vector2(0, 1);
            data[7].Color = new Vector4(1, 0, 0, 1);

            ushort[] indices = new ushort[36] {
                        0, 1, 2, 2, 3, 0,
                        3, 2, 6, 6, 7, 3,
                        7, 6, 5, 5, 4, 7,
                        4, 0, 3, 3, 7, 4,
                        0, 1, 5, 5, 4, 0,
                        1, 5, 6, 6, 2, 1
            };

            Mesh m = new Mesh(data, indices);

            StaticModel model = new StaticModel();
            model.Meshes = new Mesh[1];
            model.Meshes[0] = m;

            return model;
        }
        #endregion
    }
}
