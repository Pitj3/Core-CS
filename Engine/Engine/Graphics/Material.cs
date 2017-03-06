// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs
using System.Drawing;
using System.Collections.Generic;

using CoreEngine.Engine.Rendering;
using CoreEngine.Engine.Rendering.Lighting;
using CoreEngine.Engine.Resources;
using CoreEngine.Engine.Scene;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace CoreEngine.Engine.Graphics
{
    #region Enums
    /// <summary>
    /// Defines the type of a material
    /// </summary>
    public enum MaterialType
    {
        OPAQUE = 0,
        TRANSPARENT
    };

    /// <summary>
    /// Defines the type of the material variable
    /// </summary>
    public enum MaterialVariableType
    {
        INT = 0,
        FLOAT,
        DOUBLE,
        VECTOR2,
        VECTOR3,
        VECTOR4,
        MATRIX4,
        TEXTURE2D
    };

    /// <summary>
    /// Defines the type of shader that the material variable is from
    /// </summary>
    public enum MaterialVariableShaderType
    {
        VERTEX_SHADER,
        FRAGMENT_SHADER
    };
    #endregion

    #region Structs
    /// <summary>
    /// Material Variable struct
    /// </summary>
    public struct MaterialVariable
    {
        public MaterialVariableType VarType;
        public MaterialVariableShaderType ShaderType;

        public object Value;

        public int Location;
    };
    #endregion

    /// <summary>
    /// Material class
    /// </summary>
    public class Material
    {
        #region Data
        public Shader ShaderProgram;

        public Color DiffuseColor;

        public Texture2D DiffuseTexture;
        public Texture2D NormalTexture;
        public Texture2D MetallicTexture;
        public Texture2D RoughnessTexture;
        public Texture2D HeightTexture;

        public List<MaterialVariable> ShaderMembers = new List<MaterialVariable>();
        #endregion

        #region Constructors
        public Material()
        {

        }

        public Material(Shader shader)
        {
            this.ShaderProgram = shader;

            LoadShaderMembers(shader);
        }
        #endregion

        #region Public API
        /// <summary>
        /// Bind the material
        /// </summary>
        public void Bind()
        {
            ShaderProgram.Bind();

            Matrix4 projection = Camera.Current.Projection;
            GL.UniformMatrix4(ShaderMembers[0].Location, false, ref projection);

            Matrix4 view = Camera.Current.View;
            GL.UniformMatrix4(ShaderMembers[1].Location, false, ref view);

            GameObject go = SceneManager.CurrentScene.CurrentObject;

            if (go != null)
            {
                Matrix4 model = Matrix4.Identity;

                Vector3 axis;
                float angle;

                go.LocalTransform.Rotation.ToAxisAngle(out axis, out angle);

                model *= Matrix4.CreateScale(go.LocalTransform.Scale);

                model *= Matrix4.CreateFromAxisAngle(axis, angle);

                model *= Matrix4.CreateTranslation(go.LocalTransform.Position);

                GL.UniformMatrix4(ShaderMembers[2].Location, false, ref model);
            }

            int locDiffuse = ShaderProgram.GetVariableLocation("diffuseMap");

            GL.Uniform1(locDiffuse, 0);
            DiffuseTexture?.Bind();

            GameObject[] lights = GameObject.FindWithComponent<Light>();

            if(lights.Length > 0)
            {
                int locNormal = ShaderProgram.GetVariableLocation("normalMap");

                GL.Uniform1(locNormal, 1);
                NormalTexture?.Bind();

                foreach (GameObject light in lights) // TODO: fix this in shader
                {
                    int lightPosition = ShaderProgram.GetVariableLocation("lightPos");
                    GL.Uniform3(lightPosition, light.LocalTransform.Position);
                }

                int camPosition = ShaderProgram.GetVariableLocation("viewPos");
                GL.Uniform3(camPosition, Camera.Current.Parent.LocalTransform.Position);

                int normalMappingTrueLoc = ShaderProgram.GetVariableLocation("normalMapping");
                GL.Uniform1(normalMappingTrueLoc, 1);
            } 
        }

        /// <summary>
        /// Unbind the material
        /// </summary>
        public void Unbind()
        {
            DiffuseTexture?.Unbind();
            NormalTexture?.Unbind();
            ShaderProgram.Unbind();
        }
        #endregion

        #region Private API
        private void LoadShaderMembers(Shader shader)
        {
            // load vertex variables
            string[] vsLines = shader.VSSource.Split("/n".ToCharArray());
            //Logging.Logger.Log(Logging.LogLevel.DEBUG, vsLines.Length.ToString());

            MaterialVariable projection = new MaterialVariable() { VarType = MaterialVariableType.MATRIX4, ShaderType = MaterialVariableShaderType.VERTEX_SHADER, Location = shader.GetVariableLocation("projection"), Value = null };
            ShaderMembers.Add(projection);

            MaterialVariable view = new MaterialVariable() { VarType = MaterialVariableType.MATRIX4, ShaderType = MaterialVariableShaderType.VERTEX_SHADER, Location = shader.GetVariableLocation("view"), Value = null };
            ShaderMembers.Add(view);

            MaterialVariable model = new MaterialVariable() { VarType = MaterialVariableType.MATRIX4, ShaderType = MaterialVariableShaderType.VERTEX_SHADER, Location = shader.GetVariableLocation("model"), Value = null };
            ShaderMembers.Add(model);
        }
        #endregion
    }
}
