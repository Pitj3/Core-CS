// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs
using System.Diagnostics;
using System.IO;

using CoreEngine.Engine.Graphics;
using CoreEngine.Engine.Utils;

using Assimp;
using OpenTK;

namespace CoreEngine.Engine.Resources
{
    /// <summary>
    /// Static Model class
    /// </summary>
    public class StaticModel : Resource
    {
        #region Data
        private Assimp.Scene _scene;

        public Graphics.Mesh[] Meshes;
        private Graphics.Material[] _materials;
        #endregion

        #region Constructors
        public StaticModel()
        {

        }

        public StaticModel(string source)
        {
            Debug.Assert(Load(source));
        }
        #endregion

        #region Public API
        /// <summary>
        /// Loads the model from source
        /// </summary>
        /// <param name="source"></param>
        public override bool Load(string source)
        {
            if (source.Contains(".casset"))
            {
                return InternalLoad(source);
            }

            AssimpContext importer = new AssimpContext();

            _scene = importer.ImportFile(source, PostProcessSteps.GenerateNormals | PostProcessSteps.CalculateTangentSpace | PostProcessSteps.Triangulate);

            _materials = new Graphics.Material[_scene.Materials.Count];

            int materialIndex = 0;

            // load materials
            foreach (Assimp.Material mat in _scene.Materials)
            {
                if (materialIndex >= _materials.Length)
                    break;

                if (mat.HasTextureDiffuse)
                {
                    string path = DirectoryUtils.SearchDirectory("Content", mat.TextureDiffuse.FilePath);
                    if (path == "")
                    {
                        // Texture not found
                    }
                    else
                    {
                        if (_materials[materialIndex] == null)
                            _materials[materialIndex] = new Graphics.Material(new Shader("Content/Shaders/default"));

                        _materials[materialIndex].DiffuseTexture = new Texture2D(path);
                    }
                }
                if (mat.HasTextureNormal || mat.HasTextureHeight)
                {
                    string path = DirectoryUtils.SearchDirectory("Content", mat.TextureDiffuse.FilePath);
                    if (path == "")
                    {
                        // Texture not found
                        path = DirectoryUtils.SearchDirectory("Content", mat.TextureHeight.FilePath);
                    }

                    // else
                    {
                        if (_materials[materialIndex] == null)
                            _materials[materialIndex] = new Graphics.Material(new Shader("Content/Shaders/default"));

                        _materials[materialIndex].NormalTexture = new Texture2D(path);
                    }
                }
                materialIndex++;
            }


            int meshIndex = 0;

            Meshes = new Graphics.Mesh[_scene.Meshes.Count];

            foreach (Assimp.Mesh m in _scene.Meshes)
            {
                MeshVertex[] vertices = new MeshVertex[m.VertexCount];
                ushort[] indices = new ushort[m.GetIndices().Length];

                foreach (Face face in m.Faces)
                {
                    Debug.Assert(face.IndexCount == 3);

                    for (int i = 0; i < 3; i++)
                    {
                        int indice = face.Indices[i];

                        Vector3D pos = m.Vertices[indice];
                        vertices[indice].Position = new OpenTK.Vector3(pos.X, pos.Y, pos.Z);

                        if (m.HasTextureCoords(0))
                        {
                            Assimp.Vector3D uv = m.TextureCoordinateChannels[0][indice];
                            vertices[indice].UV = new OpenTK.Vector2(uv.X, uv.Y);
                        }

                        if (m.HasNormals)
                        {
                            Assimp.Vector3D normal = m.Normals[indice];
                            vertices[indice].Normal = new OpenTK.Vector3(normal.X, normal.Y, normal.Z);
                        }

                        if (m.BiTangents.Count > 0)
                        {
                            Assimp.Vector3D bitangent = m.BiTangents[indice];
                            vertices[indice].BiTangent = new OpenTK.Vector3(bitangent.X, bitangent.Y, bitangent.Z);
                        }

                        if (m.Tangents.Count > 0)
                        {
                            Assimp.Vector3D tangent = m.Tangents[indice];
                            vertices[indice].Tangent = new OpenTK.Vector3(tangent.X, tangent.Y, tangent.Z);
                        }

                        if (m.HasVertexColors(0))
                        {
                            Color4D col = m.VertexColorChannels[0][indice];
                            vertices[indice].Color = new OpenTK.Vector4(col.R, col.G, col.B, col.A);
                        }
                        else
                        {
                            vertices[indice].Color = new OpenTK.Vector4(1, 1, 1, 1);
                        }
                    }
                }

                int j = 0;
                foreach (int index in m.GetIndices())
                {
                    indices[j++] = (ushort)index;
                }

                Meshes[meshIndex] = new Graphics.Mesh(vertices, indices);

                if (m.MaterialIndex <= _materials.Length)
                {
                    Meshes[meshIndex].MeshMaterial = _materials[m.MaterialIndex];
                }

                meshIndex++;
            }

            return true;
        }

        /// <summary>
        /// Saves the model to a .casset file
        /// </summary>
        public override void Save()
        {
            if (!Directory.Exists("Library"))
            {
                Directory.CreateDirectory("Library");
            }

            File.WriteAllText("Library/RES" + ID + ".casset", "");

            using (BinaryWriter bw = new BinaryWriter(File.Open("Library/RES" + ID + ".casset", FileMode.Append)))
            {
                // header with id
                bw.Write(ID);

                // mesh data
                bw.Write(Meshes.Length);
                foreach (Graphics.Mesh m in Meshes)
                {
                    bw.Write(m.Vertices.Length);
                    foreach (MeshVertex vert in m.Vertices)
                    {
                        bw.Write(vert.Position.ToString());
                        bw.Write(vert.UV.ToString());
                        bw.Write(vert.Normal.ToString());
                        bw.Write(vert.BiTangent.ToString());
                        bw.Write(vert.Tangent.ToString());
                        bw.Write(vert.Color.ToString());
                    }

                    bw.Write(m.Indices.Length);
                    foreach (ushort index in m.Indices)
                    {
                        bw.Write(index);
                    }

                    bw.Write(m.MeshMaterial != null);

                    if (m.MeshMaterial != null)
                    {
                        bw.Write(m.MeshMaterial.DiffuseTexture != null);

                        if (m.MeshMaterial.DiffuseTexture != null)
                        {
                            bw.Write(m.MeshMaterial.DiffuseTexture.ID);
                            m.MeshMaterial.DiffuseTexture.Save();
                        }

                        bw.Write(m.MeshMaterial.NormalTexture != null);

                        if (m.MeshMaterial.NormalTexture != null)
                        {
                            bw.Write(m.MeshMaterial.NormalTexture.ID);
                            m.MeshMaterial.NormalTexture.Save();
                        }

                        bw.Write(m.MeshMaterial.ShaderProgram.ID);
                        m.MeshMaterial.ShaderProgram.Save();
                    }
                }
            }
        }
        #endregion

        #region Internal API
        /// <summary>
        /// Loads the model from a .casset file
        /// </summary>
        /// <param name="source"></param>
        internal bool InternalLoad(string source)
        {
            using (BinaryReader br = new BinaryReader(File.Open(source, FileMode.Open)))
            {
                // header with id
                int id = br.ReadInt32();

                // mesh data
                int meshCount = br.ReadInt32();
                Meshes = new Graphics.Mesh[meshCount];
                for (int i = 0; i < meshCount; i++)
                {
                    int verticesCount = br.ReadInt32();
                    MeshVertex[] vertices = new MeshVertex[verticesCount];
                    for (int j = 0; j < verticesCount; j++)
                    {
                        string[] arr;

                        // position
                        string posString = br.ReadString();
                        posString = posString.TrimStart('(');
                        posString = posString.TrimEnd(')');
                        arr = posString.Split(',');
                        Vector3 position = new Vector3(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2]));

                        // uv
                        string uvString = br.ReadString();
                        uvString = uvString.TrimStart('(');
                        uvString = uvString.TrimEnd(')');
                        arr = uvString.Split(',');
                        Vector2 uv = new Vector2(float.Parse(arr[0]), float.Parse(arr[1]));

                        // normal
                        string normalString = br.ReadString();
                        normalString = normalString.TrimStart('(');
                        normalString = normalString.TrimEnd(')');
                        arr = normalString.Split(',');
                        Vector3 normal = new Vector3(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2]));

                        // bitangent
                        string bitangentString = br.ReadString();
                        bitangentString = bitangentString.TrimStart('(');
                        bitangentString = bitangentString.TrimEnd(')');
                        arr = bitangentString.Split(',');
                        Vector3 bitangent = new Vector3(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2]));

                        // tangent
                        string tangentString = br.ReadString();
                        tangentString = tangentString.TrimStart('(');
                        tangentString = tangentString.TrimEnd(')');
                        arr = tangentString.Split(',');
                        Vector3 tangent = new Vector3(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2]));

                        // color
                        string colorString = br.ReadString();
                        colorString = colorString.TrimStart('(');
                        colorString = colorString.TrimEnd(')');
                        arr = colorString.Split(',');
                        Vector4 color = new Vector4(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2]), float.Parse(arr[3]));

                        // TODO: Put em in the array

                        vertices[j].Position = position;
                        vertices[j].UV = uv;
                        vertices[j].Normal = normal;
                        vertices[j].BiTangent = bitangent;
                        vertices[j].Tangent = tangent;
                        vertices[j].Color = color;
                    }

                    int indexCount = br.ReadInt32();
                    ushort[] indices = new ushort[indexCount];
                    for (int j = 0; j < indexCount; j++)
                    {
                        ushort index = br.ReadUInt16();

                        // TODO put em in the array
                        indices[j] = index;
                    }

                    Graphics.Mesh mesh = new Graphics.Mesh(vertices, indices);

                    bool hasMaterial = br.ReadBoolean();
                    if (hasMaterial)
                    {
                        bool hasDiffuse = br.ReadBoolean();
                        Texture2D diffuseTex = null;
                        Texture2D normalTex = null;

                        if (hasDiffuse)
                        {
                            int diffuseID = br.ReadInt32();
                            diffuseTex = new Texture2D();
                            diffuseTex.Load("Library/RES" + diffuseID + ".casset");
                        }

                        bool hasNormal = br.ReadBoolean();

                        if (hasNormal)
                        {
                            int normalID = br.ReadInt32();
                            normalTex = new Texture2D();
                            normalTex.Load("Library/RES" + normalID + ".casset");
                        }

                        int shaderID = br.ReadInt32();
                        Shader shader = new Shader();
                        shader.Load("Library/RES" + shaderID + ".casset");

                        mesh.MeshMaterial = new Graphics.Material(shader);
                        mesh.MeshMaterial.DiffuseTexture = diffuseTex;
                        mesh.MeshMaterial.NormalTexture = normalTex;
                    }

                    Meshes[i] = mesh;
                }

                return true;
            }
        }
        #endregion
    }
}
