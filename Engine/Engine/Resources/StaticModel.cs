using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using Assimp;
using Assimp.Configs;

using CoreEngine.Engine.Graphics;
using CoreEngine.Engine.Utils;

namespace CoreEngine.Engine.Resources
{
    public class StaticModel : Resource
    {
        private Assimp.Scene _scene;

        public Graphics.Mesh[] meshes;
        public Graphics.Material[] materials;

        public StaticModel()
        {

        }

        public StaticModel(string source)
        {
            Debug.Assert(Load(source));
        }

        public override bool Load(string source)
        {
            AssimpContext importer = new AssimpContext();
            importer.SetConfig(new NormalSmoothingAngleConfig(66.0f));

            _scene = importer.ImportFile(source, PostProcessPreset.TargetRealTimeMaximumQuality);

            materials = new Graphics.Material[_scene.Materials.Count];

            int materialIndex = 0;

            // load materials
            foreach (Assimp.Material mat in _scene.Materials)
            {
                if (mat.HasTextureDiffuse)
                {
                    string path = DirectoryUtils.SearchDirectory("Content", mat.TextureDiffuse.FilePath);
                    if(path == "")
                    {
                        // Texture not found
                    }
                    else
                    {
                        materials[materialIndex] = new Graphics.Material(new Shader("Content/Shaders/default"));
                        materials[materialIndex].diffuseTexture = new Texture2D(path);
                        materialIndex++;
                    }
                }
            }


            int meshIndex = 0;

            meshes = new Graphics.Mesh[_scene.Meshes.Count];

            foreach (Assimp.Mesh m in _scene.Meshes)
            {
                MeshVertex[] vertices = new MeshVertex[m.VertexCount];
                ushort[] indices = new ushort[m.GetIndices().Length];

                

                bool hasUV = m.HasTextureCoords(0);

                foreach (Face face in m.Faces)
                {
                    Debug.Assert(face.IndexCount == 3);

                    for (int i = 0; i < 3; i++)
                    {
                        int indice = face.Indices[i];
                        if (m.HasVertexColors(0))
                        {
                            Color4D col = m.VertexColorChannels[0][indice];
                            vertices[indice].color = new OpenTK.Vector4(col.R, col.G, col.B, col.A);
                        }
                        else
                            vertices[indice].color = new OpenTK.Vector4(1, 1, 1, 1);

                        if (hasUV)
                        {
                            Assimp.Vector3D uv = m.TextureCoordinateChannels[0][indice];
                            vertices[indice].uv = new OpenTK.Vector2(uv.X, uv.Y);
                        }

                        Vector3D pos = m.Vertices[indice];
                        vertices[indice].position = new OpenTK.Vector3(pos.X, pos.Y, pos.Z);
                    }
                }

                int j = 0;
                foreach (int index in m.GetIndices())
                {
                    indices[j++] = (ushort)index;
                }

                meshes[meshIndex] = new Graphics.Mesh(vertices, indices);

                if (m.MaterialIndex <= materials.Length)
                {
                    meshes[meshIndex].material = materials[m.MaterialIndex];
                }

                meshIndex++;
            }

            return true;
        }
    }
}
