// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using CoreEngine.Engine.Resources;

using System.Drawing;
using System.Collections.Generic;
using System;

using CoreEngine.Engine.Rendering;
using CoreEngine.Engine.Components;

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
        public MaterialVariableType type;
        public MaterialVariableShaderType shaderType;

        public object value;

        public int location;
    };
    #endregion

    /// <summary>
    /// Material class
    /// </summary>
    public class Material
    {
        #region Data
        public Shader shader;

        public Color diffuseColor;
        public Texture2D diffuseTexture;

        public Texture2D normalTexture;
        public Texture2D metallicTexture;
        public Texture2D roughnessTexture;
        public Texture2D heightTexture;

        public List<MaterialVariable> shaderMembers = new List<MaterialVariable>();
        #endregion

        #region Constructors
        public Material()
        {

        }

        public Material(Shader shader)
        {
            this.shader = shader;

            LoadShaderMembers(shader);
        }
        #endregion

        #region Public API
        /// <summary>
        /// Bind the material
        /// </summary>
        public void Bind()
        {
            shader.Bind();

            Matrix4 projection = Camera.Current.projection;
            GL.UniformMatrix4(shaderMembers[0].location, false, ref projection);

            Matrix4 view = Camera.Current.view;
            GL.UniformMatrix4(shaderMembers[1].location, false, ref view);

            Scene.GameObject go = Scene.SceneManager.CurrentScene.CurrentObject;

            if (go != null)
            {
                Matrix4 model = Matrix4.Identity;

                Vector3 axis;
                float angle;

                go.transform.rotation.ToAxisAngle(out axis, out angle);

                model = Matrix4.CreateFromAxisAngle(axis, angle);

                model *= Matrix4.CreateTranslation(go.transform.position);

                model *= Matrix4.CreateScale(go.transform.scale);

                GL.UniformMatrix4(shaderMembers[2].location, false, ref model);
            }

            int loc = shader.GetVariableLocation("diffuse");

            GL.Uniform1(loc, 0);
            diffuseTexture?.Bind();
        }

        /// <summary>
        /// Unbind the material
        /// </summary>
        public void Unbind()
        {
            diffuseTexture?.Unbind();
            shader.Unbind();
        }
        #endregion

        #region Private API
        private void LoadShaderMembers(Shader shader)
        {
            // load vertex variables
            string[] vsLines = shader.vsSource.Split("/n".ToCharArray());
            //Logging.Logger.Log(Logging.LogLevel.DEBUG, vsLines.Length.ToString());

            MaterialVariable projection = new MaterialVariable() { type = MaterialVariableType.MATRIX4, shaderType = MaterialVariableShaderType.VERTEX_SHADER, location = shader.GetVariableLocation("projection"), value = null };
            shaderMembers.Add(projection);

            MaterialVariable view = new MaterialVariable() { type = MaterialVariableType.MATRIX4, shaderType = MaterialVariableShaderType.VERTEX_SHADER, location = shader.GetVariableLocation("view"), value = null };
            shaderMembers.Add(view);

            MaterialVariable model = new MaterialVariable() { type = MaterialVariableType.MATRIX4, shaderType = MaterialVariableShaderType.VERTEX_SHADER, location = shader.GetVariableLocation("model"), value = null };
            shaderMembers.Add(model);
        }
        #endregion
    }
}
